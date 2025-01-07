using Common.Sock;
using System.Net.Sockets;
using System.Xml.Linq;
using System;
using System.Collections;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace LumosityXMLInterface
{
    /// <summary>
    /// Lumosity의 통신 XML interface의 기능을 수행할 수 있는 Class
    /// </summary>
    public class XMLInterface
    {
        /// <summary>
        /// Frame의 측정 항목들의 Data를 표현하는 데이터 구조
        /// </summary>
        public struct EvaluationDataSet
        {
            public string val;
            public string unit;

            public EvaluationDataSet(string evalVal, string evalUnit)
            {
                val = evalVal;
                unit = evalUnit;
            }
        }

        /// <summary>
        /// Main control Mode 항목
        /// </summary>
        public enum GrabMode
        {
            /// <summary>
            /// 현재 Frame rate의 최대 성능으로 계속적으로 Capture
            /// </summary>
            Continuous,
            /// <summary>
            /// 하나의 Frame만 Capture
            /// </summary>
            SnapShot,
            /// <summary>
            /// 외부 Trigger를 이용한 Capture
            /// </summary>
            ExternalTriggered,
        }

        /// <summary>
        /// Viewer의 ROI Mode
        /// </summary>
        public enum FrameROIMode
        {
            /// <summary>
            /// 수동으로 Viewer에서 Size 및 위치 마우스로 조절
            /// </summary>
            MANUAL,
            /// <summary>
            /// 위치는 자동으로 이동, 수동으로 Size 조절
            /// </summary>
            CENTROID, 
            /// <summary>
            /// 자동으로 위치 및 Size 조절
            /// </summary>
            AUTORESIZE,
        }

        /// <summary>
        /// Viewer 의 ROI 모양
        /// </summary>
        public enum FrameROIShape
        {
            /// <summary>
            /// ROI 사각모양
            /// </summary>
            RECTANGLE, 
            /// <summary>
            /// ROI 원형모양
            /// </summary>
            CIRCLE,
        }

        /// <summary>
        /// Sections border Mode
        /// </summary>
        public enum FrameSectionBorderMode
        {
            /// <summary>
            /// Border를 마우스를 이용하여 수동으로 이동 가능
            /// </summary>
            MANUAL, 
            /// <summary>
            /// Border의 Percentage of reference 값을 기준으로 자동으로 Border 이동
            /// </summary>
            REFERENCE,
        }

        /// <summary>
        /// Camera의 자동조절 mode
        /// </summary>
        public enum ModeAutoControl
        {
            /// <summary>
            /// 모든 Camera property를 수동으로 조절
            /// </summary>
            AutoOff, 
            /// <summary>
            /// Camera의 Exposure time을 자동으로 조절
            /// </summary>
            AutoExposure,
        }

        /// <summary>
        /// Background correction mode
        /// </summary>
        public enum ModeBackgroundImageCorrection
        {
            /// <summary>
            /// Background image기반 노이즈 제거 모드
            /// </summary>
            IMAGE,
            /// <summary>
            /// Corner 4부분의 영역의 Intensity를 노이즈로 기준하여 노이즈 제거 모드
            /// </summary>
            CORNER, 
            /// <summary>
            /// 상수를 설정하여 노이즈를 상수 값만큼 제거하는 모드
            /// </summary>
            CONSTANT,
        }

        /// <summary>
        /// Frame image format
        /// </summary>
        public enum GetFrameFormat
        {
            BMP, JPG, PNG,
        }

        /// <summary>
        /// Image process blur 처리 Mode 항목
        /// </summary>
        public enum BlurMode
        {
            /// <summary>
            /// 정규화된 필터를 사용하여 이미지를 부드럽게 만듭니다.
            /// </summary>
            AVERAGE,
            /// <summary>
            /// 가우시안 필터를 사용하여 이미지를 흐리게 처리합니다.
            /// </summary>
            GAUSSIAN,
            /// <summary>
            /// 중앙값 필터를 사용하여 이미지를 부드럽게 만듭니다.
            /// </summary>
            MEDIAN
        }


        // socket
        private ClientSocket _mlxSock = new ClientSocket();
        private string _strIpAddr = "127.0.0.1";
        private int _nPort = 4096;
        private int _nTimeOut = 7000;

        // general info
        private string _strVersion = string.Empty;
        private string _strName = string.Empty;
        private GrabMode _nGrabMode = GrabMode.Continuous;
        private bool _bFloatingAvgEnable = false;
        private int _nFloatingAvgValue = 2;
        private int _nFloatingAvgValueMax = 40;
        private bool _bNumberRestrictionEnable = false;
        private int _nNumberRestrictionValue = 0;
        private int _nNumberRestrictionValueMax = 10000;
        private bool _bBlurEnable = false;
        private int _nBlurKervelValue = 3;
        private int _nBlurKervelValueMax = 99;
        private BlurMode _blurMode = BlurMode.AVERAGE;

        // camera info
        private string _strCamID = string.Empty;
        private int _nCamWidth = 0;
        private int _nCamHeight = 0;
        private int _nCamOffsetX = 0;
        private int _nCamOffsetY = 0;
        private int _nCamWidthMax = 0;
        private int _nCamHeightMax = 0;
        private int _nCamWidthStep = 1;
        private int _nCamHeightStep = 1;
        private bool _bCamAutoExposure = false;
        private int _nCamDepth = 8;
        private double _dCamPixelSizeWidth = 10.0;     // unit : um
        private double _dCamPixelSizeHeight = 10.0;    // unit : um
        private bool _bAvailableGain = false;
        private double _dCamGain = -1.0;
        private double _dCamGainMax = -1.0;
        private double _dCamGainMin = -1.0;
        private bool _bAvailableExposureTime = false;
        private double _dCamExposureTime = -1.0;
        private double _dCamExposureMin = -1.0;
        private double _dCamExporsureMax = -1.0;
        private bool _bAvailableTirggerDelay = false;
        private double _dCamTriggerDelay = -1.0;
        private double _dCamTriggerDelayMin = -1.0;
        private double _dCamTriggerDelayMax = -1.0;
        private double _dCamMagnification = -1.0;
        private ModeAutoControl _camModeAutoControl = ModeAutoControl.AutoOff;

        // Frame info
        private bool _bFrameROIActive = false;
        private FrameROIMode _frameROIMode = FrameROIMode.MANUAL;
        private FrameROIShape _frameROIShape = FrameROIShape.RECTANGLE;
        private int _nFrameROILeft = 0;
        private int _nFrameROITop = 0;
        private int _nFrameROIWidth = 0;
        private int _nFrameROIHeight = 0;
        private bool _bFrameCrossSection = false;
        private int _nFrameCrossSecRow = 0;
        private int _nFrameCrossSecCol = 0;
        private bool _bFrameCrossSecAuto = false;
        private bool _bFrameBeamSection = false;
        private int _nFrameBeamSecRow = 0;
        private int _nFrameBeamSecCol = 0;
        private double _dFrameBeamSecAngle = 0;
        private bool _bFrameBeamSecAuto = false;
        private FrameSectionBorderMode _frameCrossSecsHorBorderMode = FrameSectionBorderMode.MANUAL;
        private double _dFrameCrossSecsHorRefValue = 50.0;
        private int _nFrameCrossSecsHorOffsetValue = 0;
        private double _dFrameCrossSecsHorLeft = 0;
        private double _dFrameCrossSecsHorRight = 10;
        private FrameSectionBorderMode _frameCrossSecsVerBorderMode = FrameSectionBorderMode.MANUAL;
        private double _dFrameCrossSecsVerRefValue = 50.0;
        private int _nFrameCrossSecsVerOffsetValue = 0;
        private double _dFrameCrossSecsVerLeft = 0;
        private double _dFrameCrossSecsVerRight = 10;
        private FrameSectionBorderMode _frameBeamSecsLongBorderMode = FrameSectionBorderMode.MANUAL;
        private double _dFrameBeamSecsLongRefValue = 50.0;
        private int _nFrameBeamSecsLongOffsetValue = 0;
        private double _dFrameBeamSecsLongLeft = 0;
        private double _dFrameBeamSecsLongRight = 10;
        private FrameSectionBorderMode _frameBeamSecsShortBorderMode = FrameSectionBorderMode.MANUAL;
        private double _dFrameBeamSecsShortRefValue = 50.0;
        private int _nFrameBeamSecsShortOffsetValue = 0;
        private double _dFrameBeamSecsShortLeft = 0;
        private double _dFrameBeamSecsShortRight = 10;

        // background info
        private ModeBackgroundImageCorrection _backgroundMode = ModeBackgroundImageCorrection.IMAGE;
        private bool _bIsBackImageEnable = false;
        private int _nBackImageAcquireFrames = 16;
        private bool _bIsBackConerEnable = false;
        private int _nCornerOverlaySpan = 100;
        private bool _bIsOverlay = false;
        private bool _bIsBackConstantEnable = false;
        private double _dBackConstant = 1;

        // evaluation
        private Dictionary<string, string> _dicAvailableEval = new Dictionary<string, string>();
        private Dictionary<string, EvaluationDataSet> _dicUseEval = new Dictionary<string, EvaluationDataSet>();
        private bool _bGetFrameActive = false;
        private int _nGetGrameScale = 20;
        private GetFrameFormat _getFrameFormat = GetFrameFormat.BMP;

        // frame image
        private int _nFrameImgWidth = -1;
        private int _nFrameImgHeight = -1;
        private double _dFrameImgScale = 1.0;
        private bool _bIsFrameImgSucceeded = false;
        private Bitmap _bitmapFrameImg = null;

        // option
        private bool _bIsContinuous = false;
        private int _nInterval = 1;
        private bool _bIsReprocess = false;

        // current frame count
        private int _nFrameCount = 0;

        private string _strRemotePath = string.Empty;

        private static ManualResetEventSlim _receiveDone = new ManualResetEventSlim(false);
        private string _currCmd = string.Empty;
        private string _strError = string.Empty;

        /// <summary>
        /// Frame의 측정 항목의 결과에 대한 Event
        /// </summary>
        public event EventHandler FrameEvaluations;
        private void ReceivedItemsEvent()
        {
            if (FrameEvaluations != null)
            {
                FrameEvaluations(_dicUseEval, EventArgs.Empty);
            }
        }        

        /// <summary>
        /// Socket의 연결이 끊어짐에 대한 Event
        /// </summary>
        public event EventHandler Disconnected;
        private void SocketDisconnected()
        {
            if (Disconnected != null)
            {
                Disconnected(null, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Error 발생에 대한 Event
        /// </summary>
        public event EventHandler ErrorOccurred;
        private void ErrorOccurredEvent()
        {
            if (ErrorOccurred != null)
            {
                ErrorOccurred(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 사용 가능한 Evaluation 항목
        /// </summary>
        public string[] AvailableEvaluations
        {
            get { return _dicAvailableEval.Keys.ToArray(); }
        }

        /// <summary>
        /// 사용중인 Evaluation의 항목
        /// </summary>
        public string[] UseEvaluations
        {
            get { return _dicUseEval.Keys.ToArray(); }
        }

        /// <summary>
        /// Lumosity와 Socket연결/연결끊김 상태
        /// </summary>
        public bool IsConnected
        {
            get { return _mlxSock.IsConnected; }
        }

        /// <summary>
        /// Lumosity와 Socket연결 상세 상태
        /// </summary>
        public string ConnectionStatus
        {
            get
            {
                return _mlxSock.CommStatus.ToString();
            }
        }

        /// <summary>
        /// Lumosity 와 연결 중 Data 지연 Timeout 
        /// </summary>
        public int SocketTimeOut
        {
            get => _nTimeOut;
            set => _nTimeOut = value;
        }

        /// <summary>
        /// 연결된 Lumosity의 버전
        /// </summary>
        public string Version
        {
            get { return _strVersion; }
        }

        /// <summary>
        /// Main control의 Type mode
        /// </summary>
        public GrabMode GrabModeType
        {
            get => _nGrabMode;
            set
            {
                if (_mlxSock.IsConnected)
                {
                    XElement xSendRoot = new XElement("MLCommandSet");
                    XElement xSettings = new XElement("settings");
                    XElement xGeneral = new XElement("general");
                    XElement xGrabMode = new XElement("grabMode");
                    string mode = "grab";
                    switch (value)
                    {
                        case GrabMode.Continuous:
                            mode = "grab";
                            break;

                        case GrabMode.SnapShot:
                            mode = "snapshot";
                            break;

                        case GrabMode.ExternalTriggered:
                            mode = "externalGrab";
                            break;
                    }
                    XAttribute xMode = new XAttribute("mode", mode);
                    xGrabMode.Add(xMode);
                    xGeneral.Add(xGrabMode);
                    xSettings.Add(xGeneral);
                    xSendRoot.Add(xSettings);

                    SendData(null, xSendRoot.ToString(), "setting general grabmode");

                    if (CmdWait())
                    {
                        _nGrabMode = value;
                    }
                }
            }
        }

        /// <summary>
        /// Main control의 Image process에서 Float average 활성/비활성
        /// </summary>
        public bool FloatingAverageEnable
        {
            get => _bFloatingAvgEnable;
            set
            {
                SetSettingGeneralFloatingAverage(_nFloatingAvgValue, value);
            }
        }

        /// <summary>
        /// Main control의 Image process에서 Float average Frame 수 
        /// </summary>
        public int FloatingAverageValue
        {
            get => _nFloatingAvgValue;
            set
            {
                SetSettingGeneralFloatingAverage(value, _bFloatingAvgEnable);
            }
        }

        /// <summary>
        /// Main control의 Image process에서 Float average Frame 최대 설정가능 수
        /// </summary>
        public int FloatingAverageValueMax
        {
            get => _nFloatingAvgValueMax;
        }

        /// <summary>
        /// Main control의 Image process에서 Number restriction 활성/비활성
        /// </summary>
        public bool NumberRestrictionEnable
        {
            get => _bNumberRestrictionEnable;
            set
            {
                SetSettingGeneralNumber(_nNumberRestrictionValue, value);
            }
        }

        /// <summary>
        /// Main control의 Image process에서 Number restriction Frame 수 
        /// </summary>
        public int NumberRestrictionValue
        {
            get => _nNumberRestrictionValue;
            set
            {
                SetSettingGeneralNumber(value, _bNumberRestrictionEnable);
            }
        }

        /// <summary>
        /// Main control의 Image process에서 Number restriction 최대 설정가능 수 
        /// </summary>
        public int NumberRestrictionValueMax
        {
            get => _nNumberRestrictionValueMax;
        }

        /// <summary>
        /// Main control의 Image process에서 Blur 활성/비활성
        /// </summary>
        public bool BlurEnable
        {
            get => _bBlurEnable;
            set
            {
                SetSettingGeneralBlur(_blurMode, value);
            }
        }

        /// <summary>
        /// Main control의 Image process에서 Blur의 Kernel 수 
        /// </summary>
        public int BlurKernelValue
        {
            get => _nBlurKervelValue;
            set
            {
                SetSettingGeneralBlur(_blurMode, _bBlurEnable, value);
            }
        }

        /// <summary>
        /// Main control의 Image process에서 Blur의 Mode
        /// </summary>
        public BlurMode BlurModeType
        {
            get => _blurMode;
            set
            {
                SetSettingGeneralBlur(value, _bBlurEnable);
            }
        }

        /// <summary>
        /// Main control의 Image process에서 Blur의 Kernel 최대 설정가능 값
        /// </summary>
        public int BlurKernelValueMax
        {
            get => _nBlurKervelValueMax;
        }

        /// <summary>
        /// 연결된 Lumosity Beam profiler의 카메라 ID
        /// </summary>
        public string CamID
        {
            get => _strCamID;
        }

        /// <summary>
        /// Camera offset X
        /// </summary>
        public int CamOffsetX
        {
            get => _nCamOffsetX;
            set
            {
                SetSettingsCameraROI(value, _nCamOffsetY, _nCamWidth, _nCamHeight);
            }
        }

        /// <summary>
        /// Camera offset Y
        /// </summary>
        public int CamOffsetY
        {
            get => _nCamOffsetX;
            set
            {
                SetSettingsCameraROI(_nCamOffsetX, value, _nCamWidth, _nCamHeight);
            }
        }

        /// <summary>
        /// Camera Width
        /// </summary>
        public int CamWidth
        {
            get => _nCamWidth;
            set
            {
                SetSettingsCameraROI(_nCamOffsetX, _nCamOffsetY, value, _nCamHeight);
            }
        }

        /// <summary>
        /// Camera Height
        /// </summary>
        public int CamHeight
        {
            get => _nCamHeight;
            set
            {
                SetSettingsCameraROI(_nCamOffsetX, _nCamOffsetY, _nCamWidth, value);
            }
        }

        /// <summary>
        /// Camera Width 최대 설정가능 값
        /// </summary>
        public int CamWidthMax
        {
            get => _nCamWidthMax;
        }

        /// <summary>
        /// Camera Height 최대 설정가능 값
        /// </summary>
        public int CamHeightMax
        {
            get => _nCamHeightMax;
        }

        /// <summary>
        /// Camera Width step
        /// </summary>
        public int CamWidthStep
        {
            get => _nCamWidthStep;
        }

        /// <summary>
        /// Camera Height step
        /// </summary>
        public int CamHeightStep
        {
            get => _nCamHeightStep;
        }

        /// <summary>
        /// Camera intensity depth (camera bit수에 따른 밝기강도의 해상도 깊이)
        /// </summary>
        public int CamDepth
        {
            get => _nCamDepth;
        }

        /// <summary>
        /// Camera Width Pixel size
        /// </summary>
        public double CamPixelSizeWidth
        {
            get => _dCamPixelSizeWidth;
        }

        /// <summary>
        /// Camera Height Pixel size
        /// </summary>
        public double CamPixelSizeHeight
        {
            get => _dCamPixelSizeHeight;
        }

        /// <summary>
        /// Camera Gain 조절가능 여부
        /// </summary>
        public bool CamAvailableGain
        {
            get => _bAvailableGain;
        }

        /// <summary>
        /// Camera Gain 최대 설정가능 값
        /// </summary>
        public double CamGainMax
        {
            get => _dCamGainMax;
        }

        /// <summary>
        /// Camera Gain 최소 설정가능 값
        /// </summary>
        public double CamGainMin
        {
            get => _dCamGainMin;
        }

        /// <summary>
        /// Camera Gain
        /// </summary>
        public double CamGain
        {
            get => _dCamGain;
            set
            {
                if (IsConnected)
                {
                    XElement xSendRoot = new XElement("MLCommandSet");
                    XElement xSettings = new XElement("settings");
                    XElement xCam = new XElement("camera");
                    XAttribute xGain = new XAttribute("gain", value);
                    xCam.Add(xGain);
                    xSettings.Add(xCam);
                    xSendRoot.Add(xSettings);

                    SendData(null, xSendRoot.ToString(), "settings camera gain");

                    CmdWait();
                }
            }
        }

        /// <summary>
        /// Camera Exposure time 최대 설정가능 값
        /// </summary>
        public double CamExposureTimeMax
        {
            get => _dCamExporsureMax;
        }

        /// <summary>
        /// Camera Exposure time 최소 설정가능 값
        /// </summary>
        public double CamExposureTimeMin
        {
            get => _dCamExposureMin;
        }

        /// <summary>
        /// Camera Exposure time
        /// </summary>
        public double CamExposureTime
        {
            get => _dCamExposureTime;
            set
            {
                if (IsConnected)
                {
                    XElement xSendRoot = new XElement("MLCommandSet");
                    XElement xSettings = new XElement("settings");
                    XElement xCam = new XElement("camera");
                    XAttribute xExposure = new XAttribute("exposure", value);
                    xCam.Add(xExposure);
                    xSettings.Add(xCam);
                    xSendRoot.Add(xSettings);

                    SendData(null, xSendRoot.ToString(), "settings camera exposure");

                    CmdWait();
                }
            }
        }

        /// <summary>
        /// Camera Trigger delay 최대 설정가능 값
        /// </summary>
        public double CamTriggerDelayMax
        {
            get => _dCamTriggerDelayMax;
        }

        /// <summary>
        /// Camera Trigger delay 최소 설정가능 값
        /// </summary>
        public double CamTriggerDelayMin
        {
            get => _dCamTriggerDelayMin;
        }

        /// <summary>
        /// Camera Trigger delay
        /// </summary>
        public double CamTriggerDelay
        {
            get => _dCamTriggerDelay;
            set
            {
                if (IsConnected)
                {
                    XElement xSendRoot = new XElement("MLCommandSet");
                    XElement xSettings = new XElement("settings");
                    XElement xCam = new XElement("camera");
                    XAttribute xTriggerDelay = new XAttribute("triggerdelay", value);
                    xCam.Add(xTriggerDelay);
                    xSettings.Add(xCam);
                    xSendRoot.Add(xSettings);

                    SendData(null, xSendRoot.ToString(), "settings camera triggerdelay");

                    CmdWait();
                }
            }
        }

        /// <summary>
        /// Camera auto control mode
        /// </summary>
        public ModeAutoControl CamAutoControl
        {
            get => _camModeAutoControl;
            set
            {
                if (IsConnected)
                {
                    XElement xSendRoot = new XElement("MLCommandSet");
                    XElement xSettings = new XElement("settings");
                    XElement xCam = new XElement("camera");
                    XAttribute xAutoControl = null;
                    switch (value)
                    {
                        case ModeAutoControl.AutoOff:
                            xAutoControl = new XAttribute("autoControl", "auto-off");
                            break;

                        case ModeAutoControl.AutoExposure:
                            xAutoControl = new XAttribute("autoControl", "autoExp");
                            break;
                    }

                    if (xAutoControl != null)
                    {
                        xCam.Add(xAutoControl);
                        xSettings.Add(xCam);
                        xSendRoot.Add(xSettings);

                        SendData(null, xSendRoot.ToString(), "settings camera autocontrol");

                        CmdWait();
                    }
                }
            }
        }

        /// <summary>
        /// Evaluation Frame capture마다 값을 받아올지 여부
        /// </summary>
        public bool IsEvaluationContinuous
        {
            get { return _bIsContinuous; }
            set
            {
                _bIsContinuous = value;
                SendEvaluationItem();
            }
        }

        /// <summary>
        /// Evaluation interval 설정
        /// </summary>
        public int EvaluationInterval
        {
            get { return _nInterval; }
            set
            {
                _nInterval = value;
                SendEvaluationItem();
            }
        }

        /// <summary>
        /// Evaluation Frame Reprocess 할지 여부
        /// </summary>
        public bool IsReprocessFrame
        {
            get { return _bIsReprocess; }
            set
            {
                _bIsReprocess = value;
                SendEvaluationItem();
                _bIsReprocess = false;
            }
        }

        /// <summary>
        /// Frame ROI 기능 활성/비활성
        /// </summary>
        public bool FrameROIActive
        {
            get => _bFrameROIActive;
            set
            {
                SetFrameROI(value, _frameROIMode, _frameROIShape, _nFrameROILeft, _nFrameROITop, _nFrameROIWidth, _nFrameROIHeight);
            }
        }

        /// <summary>
        /// Viewer의 Frame ROI mode 설정
        /// </summary>
        public FrameROIMode FrameRoiMode
        {
            get => _frameROIMode;
            set
            {
                SetFrameROI(_bFrameROIActive, value, _frameROIShape, _nFrameROILeft, _nFrameROITop, _nFrameROIWidth, _nFrameROIHeight);
            }
        }

        /// <summary>
        /// Viewer의 Frame ROI shape
        /// </summary>
        public FrameROIShape FrameRoiShape
        {
            get => _frameROIShape;
            set
            {
                SetFrameROI(_bFrameROIActive, _frameROIMode, value, _nFrameROILeft, _nFrameROITop, _nFrameROIWidth, _nFrameROIHeight);
            }
        }

        /// <summary>
        /// Viewer의 Frame ROI 의 Left 위치 이동 (단위:Pixel)
        /// </summary>
        public int FrameROILeft
        {
            get => _nFrameROILeft;
            set
            {
                SetFrameROI(_bFrameROIActive, _frameROIMode, _frameROIShape, value, _nFrameROITop, _nFrameROIWidth, _nFrameROIHeight);
            }
        }

        /// <summary>
        /// Viewer의 Frame ROI 의 Top 위치 이동 (단위:Pixel)
        /// </summary>
        public int FrameROITop
        {
            get => _nFrameROITop;
            set
            {
                SetFrameROI(_bFrameROIActive, _frameROIMode, _frameROIShape, _nFrameROILeft, value, _nFrameROIWidth, _nFrameROIHeight);
            }
        }

        /// <summary>
        /// Viewer의 Frame ROI 의 넓이 (단위:Pixel)
        /// </summary>
        public int FrameROIWidth
        {
            get => _nFrameROIWidth;
            set
            {
                SetFrameROI(_bFrameROIActive, _frameROIMode, _frameROIShape, _nFrameROILeft, _nFrameROITop, value, _nFrameROIHeight);
            }
        }

        /// <summary>
        /// Viewer의 Frame ROI 의 높이 (단위:Pixel)
        /// </summary>
        public int FrameROIHeight
        {
            get => _nFrameROIHeight;
            set
            {
                SetFrameROI(_bFrameROIActive, _frameROIMode, _frameROIShape, _nFrameROILeft, _nFrameROITop, _nFrameROIWidth, value);
            }
        }

        /// <summary>
        /// Viewer의 Cross section 활성/비활성
        /// </summary>
        public bool FrameCrossSectionActive
        {
            get => _bFrameCrossSection;
            set
            {
                SetFrameCrossSection(value, _nFrameCrossSecRow, _nFrameCrossSecCol, _bFrameCrossSecAuto);
            }
        }

        /// <summary>
        /// Viewer의 Cross section의 수평(Horizontal) 이동
        /// </summary>
        public int FrameCrossSectionRow
        {
            get => _nFrameBeamSecRow;
            set
            {
                SetFrameCrossSection(_bFrameCrossSection, value, _nFrameCrossSecCol, _bFrameCrossSecAuto);
            }
        }

        /// <summary>
        /// Viewer의 Cross section의 수직(Vertical) 이동
        /// </summary>
        public int FrameCrossSectionCol
        {
            get => _nFrameBeamSecCol;
            set
            {
                SetFrameCrossSection(_bFrameCrossSection, _nFrameCrossSecRow, value, _bFrameCrossSecAuto);
            }
        }

        /// <summary>
        /// Viewer의 Cross section의 자동 추적 활성/비활성
        /// </summary>
        public bool FrameCrossSectionAuto
        {
            get => _bFrameCrossSecAuto;
            set
            {
                SetFrameCrossSection(_bFrameCrossSection, _nFrameCrossSecRow, _nFrameCrossSecCol, value);
            }
        }

        /// <summary>
        /// Viewer의 Beam section 활성/비활성
        /// </summary>
        public bool FrameBeamSectionActive
        {
            get => _bFrameBeamSection;
            set
            {
                SetFrameBeamSection(value, _nFrameBeamSecRow, _nFrameBeamSecCol, _bFrameBeamSecAuto, _dFrameBeamSecAngle);
            }
        }

        /// <summary>
        /// Viewer의 Beam section의 장축(Long axis) 이동
        /// </summary>
        public int FrameBeamSectionRow
        {
            get => _nFrameBeamSecRow;
            set
            {
                SetFrameBeamSection(_bFrameBeamSection, value, _nFrameBeamSecCol, _bFrameBeamSecAuto, _dFrameBeamSecAngle);
            }
        }

        /// <summary>
        /// Viewer의 Beam section의 단축(Short axis) 이동
        /// </summary>
        public int FrameBeamSectionCol
        {
            get => _nFrameBeamSecCol;
            set
            {
                SetFrameBeamSection(_bFrameBeamSection, _nFrameBeamSecRow, value, _bFrameBeamSecAuto, _dFrameBeamSecAngle);
            }
        }

        /// <summary>
        /// Viewer의 Beam section의 자동 추적 활성/비활성
        /// </summary>
        public bool FrameBeamSectionAuto
        {
            get => _bFrameBeamSecAuto;
            set
            {
                SetFrameBeamSection(_bFrameBeamSection, _nFrameBeamSecRow, _nFrameBeamSecCol, value, _dFrameBeamSecAngle);
            }
        }

        /// <summary>
        /// Viewer의 Beam section의 각도 조절
        /// </summary>
        public double FrameBeamSectionAngle
        {
            get => _dFrameBeamSecAngle;
            set
            {
                SetFrameBeamSection(_bFrameBeamSection, _nFrameBeamSecRow, _nFrameBeamSecCol, _bFrameBeamSecAuto, value);
            }
        }

        /// <summary>
        /// Cross section Horizontal Border mode
        /// </summary>
        public FrameSectionBorderMode FrameCrossSectionHorizontalBorderType
        {
            get => _frameCrossSecsHorBorderMode;
            set
            {
                SetFrameSecBorder("CrossSections",
                                        value,
                                        "horizontal",
                                        _dFrameCrossSecsHorRefValue,
                                        _nFrameCrossSecsHorOffsetValue,
                                        _dFrameCrossSecsHorLeft,
                                        _dFrameCrossSecsHorRight);
            }
        }

        /// <summary>
        /// Cross section Horizontal Border percentage of Ref.
        /// </summary>
        public double FrameCrossSectionHorizontalReference
        {
            get => _dFrameCrossSecsHorRefValue;
            set
            {
                SetFrameSecBorder("CrossSections",
                                        _frameCrossSecsHorBorderMode,
                                        "horizontal",
                                        value,
                                        _nFrameCrossSecsHorOffsetValue,
                                        _dFrameCrossSecsHorLeft,
                                        _dFrameCrossSecsHorRight);
            }
        }

        /// <summary>
        /// Cross section Horizontal Border Percentage offset
        /// </summary>
        public int FrameCrossSectionHorizontalOffset
        {
            get => _nFrameCrossSecsHorOffsetValue;
            set
            {
                SetFrameSecBorder("CrossSections",
                                        _frameCrossSecsHorBorderMode,
                                        "horizontal",
                                        _dFrameCrossSecsHorRefValue,
                                        value,
                                        _dFrameCrossSecsHorLeft,
                                        _dFrameCrossSecsHorRight);
            }
        }

        /// <summary>
        /// Cross section Horizontal Border Left
        /// </summary>
        public double FrameCrossSectionHorizontalLeft
        {
            get => _dFrameCrossSecsHorLeft;
            set
            {
                SetFrameSecBorder("CrossSections",
                                        _frameCrossSecsHorBorderMode,
                                        "horizontal",
                                        _dFrameCrossSecsHorRefValue,
                                        _nFrameCrossSecsHorOffsetValue,
                                        value,
                                        _dFrameCrossSecsHorRight);
            }
        }

        /// <summary>
        /// Cross section Horizontal Border Right
        /// </summary>
        public double FrameCrossSectionHorizontalRight
        {
            get => _dFrameCrossSecsHorRight;
            set
            {
                SetFrameSecBorder("CrossSections",
                                        _frameCrossSecsHorBorderMode,
                                        "horizontal",
                                        _dFrameCrossSecsHorRefValue,
                                        _nFrameCrossSecsHorOffsetValue,
                                        _dFrameCrossSecsHorLeft,
                                        value);
            }
        }

        /// <summary>
        /// Cross section Vertical Border mode
        /// </summary>
        public FrameSectionBorderMode FrameCrossSectionVerticalBorderType
        {
            get => _frameCrossSecsVerBorderMode;
            set
            {
                SetFrameSecBorder("CrossSections",
                                        value,
                                        "vertical",
                                        _dFrameCrossSecsVerRefValue,
                                        _nFrameCrossSecsVerOffsetValue,
                                        _dFrameCrossSecsVerLeft,
                                        _dFrameCrossSecsVerRight);
            }
        }

        /// <summary>
        /// Cross section Vertical Border percentage of Ref.
        /// </summary>
        public double FrameCrossSectionVerticalReference
        {
            get => _dFrameCrossSecsVerRefValue;
            set
            {
                SetFrameSecBorder("CrossSections",
                                        _frameCrossSecsVerBorderMode,
                                        "vertical",
                                        value,
                                        _nFrameCrossSecsVerOffsetValue,
                                        _dFrameCrossSecsVerLeft,
                                        _dFrameCrossSecsVerRight);
            }
        }

        /// <summary>
        /// Cross section Vertical Border Percentage offset
        /// </summary>
        public int FrameCrossSectionVerticalOffset
        {
            get => _nFrameCrossSecsVerOffsetValue;
            set
            {
                SetFrameSecBorder("CrossSections",
                                        _frameCrossSecsVerBorderMode,
                                        "vertical",
                                        _dFrameCrossSecsVerRefValue,
                                        value,
                                        _dFrameCrossSecsVerLeft,
                                        _dFrameCrossSecsVerRight);
            }
        }

        /// <summary>
        /// Cross section Vertical Border Left
        /// </summary>
        public double FrameCrossSectionVerticalLeft
        {
            get => _dFrameCrossSecsVerLeft;
            set
            {
                SetFrameSecBorder("CrossSections",
                                        _frameCrossSecsVerBorderMode,
                                        "vertical",
                                        _dFrameCrossSecsVerRefValue,
                                        _nFrameCrossSecsVerOffsetValue,
                                        value,
                                        _dFrameCrossSecsVerRight);
            }
        }

        /// <summary>
        /// Cross section Vertical Border Right
        /// </summary>
        public double FrameCrossSectionVerticalRight
        {
            get => _dFrameCrossSecsVerRight;
            set
            {
                SetFrameSecBorder("CrossSections",
                                        _frameCrossSecsVerBorderMode,
                                        "vertical",
                                        _dFrameCrossSecsVerRefValue,
                                        _nFrameCrossSecsVerOffsetValue,
                                        _dFrameCrossSecsVerLeft,
                                        value);
            }
        }

        /// <summary>
        /// Beam section Long axis Border mode
        /// </summary>
        public FrameSectionBorderMode FrameBeamSectionLongBorderType
        {
            get => _frameBeamSecsLongBorderMode;
            set
            {
                SetFrameSecBorder("BeamSections",
                                        value,
                                        "long",
                                        _dFrameBeamSecsLongRefValue,
                                        _nFrameBeamSecsLongOffsetValue,
                                        _dFrameBeamSecsLongLeft,
                                        _dFrameBeamSecsLongRight);
            }
        }

        /// <summary>
        /// Beam section Long axis Border percentage of Ref.
        /// </summary>
        public double FrameBeamSectionLongReference
        {
            get => _dFrameBeamSecsLongRefValue;
            set
            {
                SetFrameSecBorder("BeamSections",
                                        _frameBeamSecsLongBorderMode,
                                        "long",
                                        value,
                                        _nFrameBeamSecsLongOffsetValue,
                                        _dFrameBeamSecsLongLeft,
                                        _dFrameBeamSecsLongRight);
            }
        }

        /// <summary>
        /// Beam section Long axis Border Percentage offset
        /// </summary>
        public int FrameBeamSectionLongOffset
        {
            get => _nFrameBeamSecsLongOffsetValue;
            set
            {
                SetFrameSecBorder("BeamSections",
                                        _frameBeamSecsLongBorderMode,
                                        "long",
                                        _dFrameBeamSecsLongRefValue,
                                        value,
                                        _dFrameBeamSecsLongLeft,
                                        _dFrameBeamSecsLongRight);
            }
        }

        /// <summary>
        /// Beam section Long axis Border Left
        /// </summary>
        public double FrameBeamSectionLongLeft
        {
            get => _dFrameBeamSecsLongLeft;
            set
            {
                SetFrameSecBorder("BeamSections",
                                        _frameBeamSecsLongBorderMode,
                                        "long",
                                        _dFrameBeamSecsLongRefValue,
                                        _nFrameBeamSecsLongOffsetValue,
                                        value,
                                        _dFrameBeamSecsLongRight);
            }
        }

        /// <summary>
        /// Beam section Long axis Border Right
        /// </summary>
        public double FrameBeamSectionLongRight
        {
            get => _dFrameBeamSecsLongRight;
            set
            {
                SetFrameSecBorder("BeamSections",
                                        _frameBeamSecsLongBorderMode,
                                        "long",
                                        _dFrameBeamSecsLongRefValue,
                                        _nFrameBeamSecsLongOffsetValue,
                                        _dFrameBeamSecsLongLeft,
                                        value);
            }
        }

        /// <summary>
        /// Beam section Short axis Border mode
        /// </summary>
        public FrameSectionBorderMode FrameBeamSectionShortBorderType
        {
            get => _frameBeamSecsShortBorderMode;
            set
            {
                SetFrameSecBorder("BeamSections",
                                        value,
                                        "short",
                                        _dFrameBeamSecsShortRefValue,
                                        _nFrameBeamSecsShortOffsetValue,
                                        _dFrameBeamSecsShortLeft,
                                        _dFrameBeamSecsShortRight);
            }
        }

        /// <summary>
        /// Beam section Short axis Border percentage of Ref.
        /// </summary>
        public double FrameBeamSectionShortReference
        {
            get => _dFrameBeamSecsShortRefValue;
            set
            {
                SetFrameSecBorder("BeamSections",
                                        _frameBeamSecsShortBorderMode,
                                        "short",
                                        value,
                                        _nFrameBeamSecsShortOffsetValue,
                                        _dFrameBeamSecsShortLeft,
                                        _dFrameBeamSecsShortRight);
            }
        }

        /// <summary>
        /// Beam section Short axis Border percentage Offset.
        /// </summary>
        public int FrameBeamSectionShortOffset
        {
            get => _nFrameBeamSecsShortOffsetValue;
            set
            {
                SetFrameSecBorder("BeamSections",
                                        _frameBeamSecsShortBorderMode,
                                        "short",
                                        _dFrameBeamSecsShortRefValue,
                                        value,
                                        _dFrameBeamSecsShortLeft,
                                        _dFrameBeamSecsShortRight);
            }
        }

        /// <summary>
        /// Beam section Short axis Border left.
        /// </summary>
        public double FrameBeamSectionShortLeft
        {
            get => _dFrameBeamSecsShortLeft;
            set
            {
                SetFrameSecBorder("BeamSections",
                                        _frameBeamSecsShortBorderMode,
                                        "short",
                                        _dFrameBeamSecsShortRefValue,
                                        _nFrameBeamSecsShortOffsetValue,
                                        value,
                                        _dFrameBeamSecsShortRight);
            }
        }

        /// <summary>
        /// Beam section Short axis Border right.
        /// </summary>
        public double FrameBeamSectionShortRight
        {
            get => _dFrameBeamSecsShortRight;
            set
            {
                SetFrameSecBorder("BeamSections",
                                        _frameBeamSecsShortBorderMode,
                                        "short",
                                        _dFrameBeamSecsShortRefValue,
                                        _nFrameBeamSecsShortOffsetValue,
                                        _dFrameBeamSecsShortLeft,
                                        value);
            }
        }

        /// <summary>
        /// Image correction의 Mode
        /// </summary>
        public ModeBackgroundImageCorrection BackgourndMode
        {
            get => _backgroundMode;
            set
            {
                XElement xSendRoot = new XElement("MLCommandSet");
                XElement xSetting = new XElement("settings");
                XElement xCorrection = new XElement("correction");

                xCorrection.Add(new XAttribute("mode", value.ToString().ToLower()));
                switch (value)
                {
                    case ModeBackgroundImageCorrection.IMAGE:
                        xCorrection.Add(new XAttribute("value", _nBackImageAcquireFrames));
                        xCorrection.Add(new XAttribute("enable", _bIsBackImageEnable));
                        break;

                    case ModeBackgroundImageCorrection.CORNER:
                        xCorrection.Add(new XAttribute("value", _nCornerOverlaySpan));
                        xCorrection.Add(new XAttribute("enable", _bIsBackConerEnable));
                        xCorrection.Add(new XAttribute("overlay", _bIsOverlay));
                        break;

                    case ModeBackgroundImageCorrection.CONSTANT:
                        xCorrection.Add(new XAttribute("value", _dBackConstant));
                        xCorrection.Add(new XAttribute("enable", _bIsBackConstantEnable));
                        break;
                }

                xSetting.Add(xCorrection);
                xSendRoot.Add(xSetting);

                SendData(null, xSendRoot.ToString(), "settings correction");

                CmdWait();
            }
        }

        /// <summary>
        /// Image correction 활성/비활성화
        /// </summary>
        public bool BackgroundImageEnable
        {
            get => _bIsBackImageEnable;
            set
            {
                XElement xSendRoot = new XElement("MLCommandSet");
                XElement xSetting = new XElement("settings");
                XElement xCorrection = new XElement("correction");

                xCorrection.Add(new XAttribute("mode", _backgroundMode.ToString().ToLower()));
                switch (_backgroundMode)
                {
                    case ModeBackgroundImageCorrection.IMAGE:
                        xCorrection.Add(new XAttribute("value", _nBackImageAcquireFrames));
                        xCorrection.Add(new XAttribute("enable", value));
                        break;

                    case ModeBackgroundImageCorrection.CORNER:
                        xCorrection.Add(new XAttribute("value", _nCornerOverlaySpan));
                        xCorrection.Add(new XAttribute("enable", value));
                        xCorrection.Add(new XAttribute("overlay", _bIsOverlay));
                        break;

                    case ModeBackgroundImageCorrection.CONSTANT:
                        xCorrection.Add(new XAttribute("value", _dBackConstant));
                        xCorrection.Add(new XAttribute("enable", value));
                        break;
                }

                xSetting.Add(xCorrection);
                xSendRoot.Add(xSetting);

                SendData(null, xSendRoot.ToString(), "settings correction");

                CmdWait();
            }
        }

        /// <summary>
        /// Image correction의 Background mode의 Acquire할 이미지 Frame 수
        /// </summary>
        public int BackgroundAcquireFrames
        {
            get => _nBackImageAcquireFrames;
            set
            {
                XElement xSendRoot = new XElement("MLCommandSet");
                XElement xSetting = new XElement("settings");
                XElement xCorrection = new XElement("correction");

                xCorrection.Add(new XAttribute("mode", _backgroundMode.ToString().ToLower()));
                switch (_backgroundMode)
                {
                    case ModeBackgroundImageCorrection.IMAGE:
                        xCorrection.Add(new XAttribute("value", value));
                        xCorrection.Add(new XAttribute("enable", _bIsBackImageEnable));
                        break;

                    case ModeBackgroundImageCorrection.CORNER:
                        xCorrection.Add(new XAttribute("value", _nCornerOverlaySpan));
                        xCorrection.Add(new XAttribute("enable", _bIsBackConerEnable));
                        xCorrection.Add(new XAttribute("overlay", _bIsOverlay));
                        break;

                    case ModeBackgroundImageCorrection.CONSTANT:
                        xCorrection.Add(new XAttribute("value", _dBackConstant));
                        xCorrection.Add(new XAttribute("enable", _bIsBackConstantEnable));
                        break;
                }

                xSetting.Add(xCorrection);
                xSendRoot.Add(xSetting);

                SendData(null, xSendRoot.ToString(), "settings correction");

                CmdWait();
            }
        }

        /// <summary>
        /// Image correction의 Corner mode의 활성/비활성화
        /// </summary>
        public bool BackgroundCornerEnable
        {
            get => _bIsBackConerEnable;
            set
            {
                XElement xSendRoot = new XElement("MLCommandSet");
                XElement xSetting = new XElement("settings");
                XElement xCorrection = new XElement("correction");

                xCorrection.Add(new XAttribute("mode", _backgroundMode.ToString().ToLower()));
                switch (_backgroundMode)
                {
                    case ModeBackgroundImageCorrection.IMAGE:
                        xCorrection.Add(new XAttribute("value", _nBackImageAcquireFrames));
                        xCorrection.Add(new XAttribute("enable", value));
                        break;

                    case ModeBackgroundImageCorrection.CORNER:
                        xCorrection.Add(new XAttribute("value", _nCornerOverlaySpan));
                        xCorrection.Add(new XAttribute("enable", value));
                        xCorrection.Add(new XAttribute("overlay", _bIsOverlay));
                        break;

                    case ModeBackgroundImageCorrection.CONSTANT:
                        xCorrection.Add(new XAttribute("value", _dBackConstant));
                        xCorrection.Add(new XAttribute("enable", value));
                        break;
                }

                xSetting.Add(xCorrection);
                xSendRoot.Add(xSetting);

                SendData(null, xSendRoot.ToString(), "settings correction");

                CmdWait();
            }
        }

        /// <summary>
        /// Image correction의 Corner mode의 Span
        /// </summary>
        public int BackgroundCornerSpan
        {
            get => _nCornerOverlaySpan;
            set
            {
                XElement xSendRoot = new XElement("MLCommandSet");
                XElement xSetting = new XElement("settings");
                XElement xCorrection = new XElement("correction");

                xCorrection.Add(new XAttribute("mode", _backgroundMode.ToString().ToLower()));
                switch (_backgroundMode)
                {
                    case ModeBackgroundImageCorrection.IMAGE:
                        xCorrection.Add(new XAttribute("value", _nBackImageAcquireFrames));
                        xCorrection.Add(new XAttribute("enable", _bIsBackImageEnable));
                        break;

                    case ModeBackgroundImageCorrection.CORNER:
                        xCorrection.Add(new XAttribute("value", value));
                        xCorrection.Add(new XAttribute("enable", _bIsBackConerEnable));
                        xCorrection.Add(new XAttribute("overlay", _bIsOverlay));
                        break;

                    case ModeBackgroundImageCorrection.CONSTANT:
                        xCorrection.Add(new XAttribute("value", _dBackConstant));
                        xCorrection.Add(new XAttribute("enable", _bIsBackConstantEnable));
                        break;
                }

                xSetting.Add(xCorrection);
                xSendRoot.Add(xSetting);

                SendData(null, xSendRoot.ToString(), "settings correction");

                CmdWait();
            }
        }

        /// <summary>
        /// Image correction의 Corner mode에서 Viewer에 표시 여부
        /// </summary>
        public bool BackgroundCornerOverlay
        {
            get => _bIsOverlay;
            set
            {
                XElement xSendRoot = new XElement("MLCommandSet");
                XElement xSetting = new XElement("settings");
                XElement xCorrection = new XElement("correction");

                xCorrection.Add(new XAttribute("mode", _backgroundMode.ToString().ToLower()));
                switch (_backgroundMode)
                {
                    case ModeBackgroundImageCorrection.IMAGE:
                        xCorrection.Add(new XAttribute("value", _nBackImageAcquireFrames));
                        xCorrection.Add(new XAttribute("enable", _bIsBackImageEnable));
                        break;

                    case ModeBackgroundImageCorrection.CORNER:
                        xCorrection.Add(new XAttribute("value", value));
                        xCorrection.Add(new XAttribute("enable", _bIsBackConerEnable));
                        xCorrection.Add(new XAttribute("overlay", value));
                        break;

                    case ModeBackgroundImageCorrection.CONSTANT:
                        xCorrection.Add(new XAttribute("value", _dBackConstant));
                        xCorrection.Add(new XAttribute("enable", _bIsBackConstantEnable));
                        break;
                }

                xSetting.Add(xCorrection);
                xSendRoot.Add(xSetting);

                SendData(null, xSendRoot.ToString(), "settings correction");

                CmdWait();
            }
        }

        /// <summary>
        /// Image correction의 Constant 활성/비활성
        /// </summary>
        public bool BackgroundContantEnable
        {
            get => _bIsBackConstantEnable;
            set
            {
                XElement xSendRoot = new XElement("MLCommandSet");
                XElement xSetting = new XElement("settings");
                XElement xCorrection = new XElement("correction");

                xCorrection.Add(new XAttribute("mode", _backgroundMode.ToString().ToLower()));
                switch (_backgroundMode)
                {
                    case ModeBackgroundImageCorrection.IMAGE:
                        xCorrection.Add(new XAttribute("value", _nBackImageAcquireFrames));
                        xCorrection.Add(new XAttribute("enable", value));
                        break;

                    case ModeBackgroundImageCorrection.CORNER:
                        xCorrection.Add(new XAttribute("value", _nCornerOverlaySpan));
                        xCorrection.Add(new XAttribute("enable", value));
                        xCorrection.Add(new XAttribute("overlay", _bIsOverlay));
                        break;

                    case ModeBackgroundImageCorrection.CONSTANT:
                        xCorrection.Add(new XAttribute("value", _dBackConstant));
                        xCorrection.Add(new XAttribute("enable", value));
                        break;
                }

                xSetting.Add(xCorrection);
                xSendRoot.Add(xSetting);

                SendData(null, xSendRoot.ToString(), "settings correction");

                CmdWait();
            }
        }

        /// <summary>
        /// Image correction의 Constant 값 (Intensity)
        /// </summary>
        public double BackgroundConstantValue
        {
            get => _dBackConstant;
            set
            {
                XElement xSendRoot = new XElement("MLCommandSet");
                XElement xSetting = new XElement("settings");
                XElement xCorrection = new XElement("correction");

                xCorrection.Add(new XAttribute("mode", _backgroundMode.ToString().ToLower()));
                switch (_backgroundMode)
                {
                    case ModeBackgroundImageCorrection.IMAGE:
                        xCorrection.Add(new XAttribute("value", _nBackImageAcquireFrames));
                        xCorrection.Add(new XAttribute("enable", _bIsBackImageEnable));
                        break;

                    case ModeBackgroundImageCorrection.CORNER:
                        xCorrection.Add(new XAttribute("value", _nCornerOverlaySpan));
                        xCorrection.Add(new XAttribute("enable", _bIsBackConerEnable));
                        xCorrection.Add(new XAttribute("overlay", _bIsOverlay));
                        break;

                    case ModeBackgroundImageCorrection.CONSTANT:
                        xCorrection.Add(new XAttribute("value", value));
                        xCorrection.Add(new XAttribute("enable", _bIsBackConstantEnable));
                        break;
                }

                xSetting.Add(xCorrection);
                xSendRoot.Add(xSetting);

                SendData(null, xSendRoot.ToString(), "settings correction");

                CmdWait();
            }
        }

        /// <summary>
        /// Frame 취득 시 Viewer의 컬러 이미지 취득 활성/비활성
        /// </summary>
        public bool EvaluationGetFrameActive
        {
            get => _bGetFrameActive;
            set
            {
                SetEvaluationGetFrame(value, _nGetGrameScale, _getFrameFormat);
            }
        }

        /// <summary>
        /// Frame 취득시 가져올 컬러 이미지의 Scale 설정 (성능의 영향을 줄 수 있음)
        /// </summary>
        public int EvaluationGetFrameScale
        {
            get => _nGetGrameScale;
            set
            {
                SetEvaluationGetFrame(_bGetFrameActive, value, _getFrameFormat);
            }
        }

        /// <summary>
        /// Frame 취득시 가져올 컬러 이미지의 Format(BMP, JPG, PNG)  설정
        /// </summary>
        public GetFrameFormat EvaluationGetFrameFormat
        {
            get => _getFrameFormat;
            set
            {
                SetEvaluationGetFrame(_bGetFrameActive, _nGetGrameScale, value);
            }
        }

        /// <summary>
        /// 취득된 Frame 이미지의 성공 여부 확인
        /// </summary>
        public bool EvaluationGetFrameSucceeded
        {
            get => _bIsFrameImgSucceeded;
        }

        /// <summary>
        /// 취득된 Frame 이미지의 Width
        /// </summary>
        public int EvaluationGetFrameBitmapWidth
        {
            get => _nFrameImgWidth;
        }

        /// <summary>
        /// 취득된 Frame 이미지의 Height
        /// </summary>
        public int EvaluationGetFrameBitmapHeight
        {
            get => _nFrameImgHeight;
        }

        /// <summary>
        /// 취득된 Frame 이미지의 Bitmap data
        /// </summary>
        public Bitmap EvaluationGetFrameBitmap
        {
            get => _bitmapFrameImg;
        }

        /// <summary>
        /// 연결된 Lumosity Beam profiler interface Error 내용
        /// </summary>
        public string ErrorDetail
        {
            get => _strError;
        }

        /// <summary>
        /// XMLInterface 생성자
        /// </summary>
        public XMLInterface()
        {
            _mlxSock.disconnectedEvent += OnDisconnected;
        }

        /// <summary>
        /// 클라이언트 연결기능으로 Lumosity를 서버로 구동하여 연결한다.
        /// </summary>
        /// <param name="ip">Lumosity의 IP</param>
        /// <param name="port">Lumosity 서버 포트</param>
        /// <param name="timeout">연결 및 데이터 통신시 timeout 설정</param>
        /// <returns>연결 성공여부</returns>
        public bool Connect(string ip, int port, int timeout = 7000)
        {
            bool ret = false;

            _mlxSock.ParseContentStart = "<MLCommandSet>";
            _mlxSock.ParseContentEnd = "</MLCommandSet>";

            Stopwatch stopwatch = new Stopwatch();

            _strIpAddr = ip;
            _nPort = port;
            _nTimeOut = timeout;
            _mlxSock.StartConnect(_strIpAddr, _nPort, OnDataReceive, _nTimeOut);

            stopwatch.Start();
            while (stopwatch.ElapsedMilliseconds < timeout && !_mlxSock.IsConnected)
            {
                Thread.Sleep(10);
            }

            ret = _mlxSock.IsConnected;

            return ret;
        }

        /// <summary>
        /// Lumosity와의 연결을 끊는다.
        /// </summary>
        public void Disconnect()
        {
            _mlxSock.dataReceiveEvent -= OnDataReceive;
            _mlxSock.Disconnect();
            SocketDisconnected();
        }

        /// <summary>
        /// 연결된 Lumosity의 전체 정보(info tag)를 가져온다.
        /// </summary>
        /// <returns>Command info의 정상적인 Data send/recieve 성공여부</returns>
        public bool CmdGetInfomation()
        {
            if (_mlxSock.IsConnected)
            {
                XElement xSendRoot = new XElement("MLCommandSet");
                xSendRoot.Add(new XElement("info"));

                SendData(null, xSendRoot.ToString(), "info");

                return CmdWait();
            }

            return false;
        }

        /// <summary>
        /// 카메라 Capture(Grab) 하여 Beam profiler의 측정 구동을 시작
        /// </summary>
        /// <returns>Start 명령의 정상 동작 여부</returns>
        public bool Start()
        {
            if (IsConnected)
            {
                _nFrameCount = 0;

                XElement xSendRoot = new XElement("MLCommandSet");
                XElement xAcq = new XElement("acquisition");
                XAttribute xAcqMode = new XAttribute("mode", "start");
                xAcq.Add(xAcqMode);
                xSendRoot.Add(xAcq);

                SendData(null, xSendRoot.ToString(), "acquisition start");

                return CmdWait(700);
            }

            return false;
        }

        /// <summary>
        /// 카메라 Capture(Grab) 중지 하여 Beam profiler의 측정 구동을 멈춤
        /// </summary>
        /// <returns>Stop 명령의 정상 동작 여부</returns>
        public bool Stop()
        {
            if (IsConnected)
            {
                _nFrameCount = 0;

                XElement xSendRoot = new XElement("MLCommandSet");
                XElement xAcq = new XElement("acquisition");
                XAttribute xAcqMode = new XAttribute("mode", "stop");
                xAcq.Add(xAcqMode);
                xSendRoot.Add(xAcq);

                SendData(null, xSendRoot.ToString(), "acquisition stop");

                return CmdWait(700);
            }

            return false;
        }

        /// <summary>
        /// Image correction의 background mode에 필요한 Image acquire
        /// </summary>
        /// <returns>StartBackground 명령의 정상 동작 여부</returns>
        public bool StartBackground()
        {
            if (IsConnected)
            {
                _nFrameCount = 0;

                XElement xSendRoot = new XElement("MLCommandSet");
                XElement xAcq = new XElement("acquisition");
                XAttribute xAcqMode = new XAttribute("mode", "background");
                xAcq.Add(xAcqMode);
                xSendRoot.Add(xAcq);

                SendData(null, xSendRoot.ToString(), "acquisition background");

                return CmdWait(700);
            }

            return false;
        }

        /// <summary>
        /// AvailableEvaluations(사용가능 Eavaluation) 항목에서 필요한 항목을 사용항목으로 추가
        /// </summary>
        /// <param name="evaluationName">사용 가능 Evaluation 항목 이름</param>
        public void AddUseEvaluation(string evaluationName)
        {
            if (_mlxSock != null && _mlxSock.IsConnected)
            {
                if (!_dicUseEval.ContainsKey(evaluationName))
                {
                    _dicUseEval.Add(evaluationName, new EvaluationDataSet(string.Empty, string.Empty));
                    SendEvaluationItem();
                }
            }
        }

        /// <summary>
        /// UseEvaluations(사용중인 Evaluation) 항목에서 제거할 항목 지정하여 사용항목에서 제거
        /// </summary>
        /// <param name="evaluationName">사용중인 Evaluation에서 제거할 항목 이름</param>
        public void RemoveUseEvaluation(string evaluationName)
        {
            if (_mlxSock != null && _mlxSock.IsConnected)
            {
                if (_dicUseEval.ContainsKey(evaluationName))
                {
                    _dicUseEval.Remove(evaluationName);
                    SendEvaluationItem();
                }
            }
        }

        /// <summary>
        /// 사용중인 Evaluation 모두 제거
        /// </summary>
        public void ClearUseEvaluations()
        {
            if (_mlxSock != null && _mlxSock.IsConnected)
            {
                _dicUseEval.Clear();
                SendEvaluationItem();
            }
        }

        /// <summary>
        /// AvailableEvaluations(사용가능 Eavaluation)의 설명을 가져옴
        /// </summary>
        /// <param name="evaluationName">사용 가능 Evaluation 항목 이름</param>
        /// <returns>해당 Evaluation의 설명</returns>
        public string GetEvaluationDescription(string evaluationName)
        {
            return _dicAvailableEval[evaluationName];
        }

        /// <summary>
        /// UseEvaluations(사용중인 Evaluation) 사용되고 있는 Evaluation중 EvaluationDataSet구조의 결과값을 가져옴
        /// </summary>
        /// <param name="evaluationName">사용중인 Evaluation의 이름중에서 항목이름</param>
        /// <returns>evaluationName 에 대한 EvaluationDataSet 결과</returns>
        public EvaluationDataSet GetEvaluationResult(string evaluationName)
        {
            if (_dicUseEval.ContainsKey(evaluationName))
            {
                return _dicUseEval[evaluationName];
            }
            else
            {
                return new EvaluationDataSet(string.Empty, string.Empty);
            }
        }

        private bool SetSettingGeneralFloatingAverage(int averageValue, bool enable)
        {
            XElement xSendRoot = new XElement("MLCommandSet");
            XElement xSettings = new XElement("settings");
            XElement xGeneral = new XElement("general");
            XElement xFloatingAvg = new XElement("floatingAverage");

            xFloatingAvg.Add(new XAttribute("value", averageValue));
            xFloatingAvg.Add(new XAttribute("enable", enable));
            xGeneral.Add(xFloatingAvg);
            xSettings.Add(xGeneral);
            xSendRoot.Add(xSettings);

            SendData(null, xSendRoot.ToString(), "setting general floatingaverage");

            return CmdWait();
        }

        private bool SetSettingGeneralNumber(int numberRestric, bool enable)
        {
            XElement xSendRoot = new XElement("MLCommandSet");
            XElement xSettings = new XElement("settings");
            XElement xGeneral = new XElement("general");
            XElement xNumberRestriction = new XElement("numberRestriction");

            xNumberRestriction.Add(new XAttribute("value", numberRestric));
            xNumberRestriction.Add(new XAttribute("enable", enable));
            xGeneral.Add(xNumberRestriction);
            xSettings.Add(xGeneral);
            xSendRoot.Add(xSettings);

            SendData(null, xSendRoot.ToString(), "setting general numberrestriction");

            return CmdWait();
        }

        private bool SetSettingGeneralBlur(BlurMode blurMode, bool enable, int kernel = -1)
        {
            XElement xSendRoot = new XElement("MLCommandSet");
            XElement xSettings = new XElement("settings");
            XElement xGeneral = new XElement("general");
            XElement xBlur = new XElement("blur");

            if (kernel != -1)
            {
                xBlur.Add(new XAttribute("value", kernel));
            }            
            xBlur.Add(new XAttribute("enable", enable));
            switch (blurMode)
            {
                case BlurMode.AVERAGE:
                    xBlur.Add(new XAttribute("mode", "average"));
                    break;

                case BlurMode.GAUSSIAN:
                    xBlur.Add(new XAttribute("mode", "gaussian"));
                    break;

                case BlurMode.MEDIAN:
                    xBlur.Add(new XAttribute("mode", "median"));
                    break;
            }

            xGeneral.Add(xBlur);
            xSettings.Add(xGeneral);
            xSendRoot.Add(xSettings);

            SendData(null, xSendRoot.ToString(), "setting general blur");

            return CmdWait();
        }

        private bool SetSettingsCameraROI(int offsetX, int offsetY, int width, int height)
        {
            XElement xSendRoot = new XElement("MLCommandSet");
            XElement xSettings = new XElement("settings");
            XElement xCamera = new XElement("camera");
            xCamera.Add(new XAttribute("ROI", true));
            XElement xRoi = new XElement("roi");
            xRoi.Add(new XAttribute("left", offsetX));
            xRoi.Add(new XAttribute("top", offsetY));
            xRoi.Add(new XAttribute("width", width));
            xRoi.Add(new XAttribute("height", height));
            xCamera.Add(xRoi);
            xSettings.Add(xCamera);
            xSendRoot.Add(xSettings);

            SendData(null, xSendRoot.ToString(), "settings camera ROI");

            return CmdWait();
        }

        private bool SetFrameROI(bool active, FrameROIMode mode, FrameROIShape shape, int left, int top, int width, int height)
        {
            XElement xSendRoot = new XElement("MLCommandSet");
            XElement xFrame = new XElement("frame");
            XElement xROI = new XElement("ROI");
            xROI.Add(new XAttribute("active", active));
            xROI.Add(new XAttribute("mode", mode.ToString().ToLower()));
            xROI.Add(new XAttribute("shape", shape.ToString().ToLower()));
            xROI.Add(new XAttribute("left", left));
            xROI.Add(new XAttribute("top", top));
            xROI.Add(new XAttribute("width", width));
            xROI.Add(new XAttribute("height", height));
            xFrame.Add(xROI);
            xSendRoot.Add(xFrame);

            SendData(null, xSendRoot.ToString(), "frame ROI");

            return CmdWait();
        }

        private bool SetFrameCrossSection(bool active, int row, int col, bool autoCenter)
        {
            XElement xSendRoot = new XElement("MLCommandSet");
            XElement xFrame = new XElement("frame");
            XElement xCrossSec = new XElement("CrossSections");
            xCrossSec.Add(new XAttribute("active", active));
            xCrossSec.Add(new XAttribute("row", row));
            xCrossSec.Add(new XAttribute("column", col));
            if (autoCenter)
            {
                xCrossSec.Add(new XAttribute("mode", "centroid"));
            }
            else
            {
                xCrossSec.Add(new XAttribute("mode", "manual"));
            }

            xFrame.Add(xCrossSec);
            xSendRoot.Add(xFrame);

            SendData(null, xSendRoot.ToString(), "frame CrossSections");

            return CmdWait();
        }

        private bool SetFrameBeamSection(bool active, int row, int col, bool autoCenter, double angle)
        {
            XElement xSendRoot = new XElement("MLCommandSet");
            XElement xFrame = new XElement("frame");
            XElement xBeamSec = new XElement("BeamSections");
            xBeamSec.Add(new XAttribute("active", active));
            xBeamSec.Add(new XAttribute("row", row));
            xBeamSec.Add(new XAttribute("column", col));
            xBeamSec.Add(new XAttribute("angle", angle));
            if (autoCenter)
            {
                xBeamSec.Add(new XAttribute("mode", "followBeam"));
            }
            else
            {
                xBeamSec.Add(new XAttribute("mode", "manual"));
            }

            xFrame.Add(xBeamSec);
            xSendRoot.Add(xFrame);

            SendData(null, xSendRoot.ToString(), "frame BeamSections");

            return CmdWait();
        }

        private bool SetFrameSecBorder(string kindOfSection, FrameSectionBorderMode mode, string type, double refVal, int refOffset, double left, double right)
        {
            XElement xSendRoot = new XElement("MLCommandSet");
            XElement xFrame = new XElement("frame");
            XElement xCrossSec = new XElement(kindOfSection);
            XElement xBorders = new XElement("borders");
            xBorders.Add(new XAttribute("type", type));
            xBorders.Add(new XAttribute("mode", mode.ToString().ToLower()));
            switch (mode)
            {
                case FrameSectionBorderMode.MANUAL:
                    xBorders.Add(new XAttribute("left", left));
                    xBorders.Add(new XAttribute("right", right));
                    break;

                case FrameSectionBorderMode.REFERENCE:
                    xBorders.Add(new XAttribute("percentage", refVal));
                    xBorders.Add(new XAttribute("offset", refOffset));
                    break;
            }


            xCrossSec.Add(xBorders);
            xFrame.Add(xCrossSec);
            xSendRoot.Add(xFrame);

            SendData(null, xSendRoot.ToString(), "frame Sections Border");

            return CmdWait();
        }

        private bool SetEvaluationGetFrame(bool active, int scale, GetFrameFormat format)
        {
            XElement xSendRoot = new XElement("MLCommandSet");
            XElement xEvaluation = new XElement("evaluation");

            xEvaluation.Add(new XAttribute("continuous", _bIsContinuous));
            if (_nInterval > 1)
            {
                xEvaluation.Add(new XAttribute("interval", _nInterval));
            }

            XElement xGetFrame = new XElement("getFrame");
            xGetFrame.Add(new XAttribute("active", active));
            xGetFrame.Add(new XAttribute("scale", scale));
            xGetFrame.Add(new XAttribute("format", format.ToString()));

            xEvaluation.Add(xGetFrame);
            xSendRoot.Add(xEvaluation);

            SendData(null, xSendRoot.ToString(), "evaluation getFrame");

            return CmdWait();
        }

        private void SendEvaluationItem()
        {
            if (IsConnected)
            {
                XElement xSendRoot = new XElement("MLCommandSet");
                XElement xEvaluation = new XElement("evaluation");

                int evalCount = _dicUseEval.Count;
                if (evalCount > 0)
                {
                    xEvaluation.Add(new XAttribute("continuous", _bIsContinuous));
                    xEvaluation.Add(new XAttribute("reprocess", _bIsReprocess));
                    if (_nInterval > 1)
                    {
                        xEvaluation.Add(new XAttribute("interval", _nInterval));
                    }

                    XElement xResults = new XElement("results");

                    IDictionaryEnumerator enEvals = _dicUseEval.GetEnumerator();
                    while (enEvals.MoveNext())
                    {
                        string evalName = enEvals.Key.ToString();
                        XElement xItem = new XElement("item");
                        xItem.Add(new XAttribute("name", evalName));
                        xResults.Add(xItem);
                    }

                    xEvaluation.Add(xResults);
                }
                else
                {
                    xEvaluation.Add(new XAttribute("continuous", false));
                }

                xSendRoot.Add(xEvaluation);

                SendData(null, xSendRoot.ToString(), "evaluation");

                CmdWait();
            }
        }


        private void SendData(object sender, string xmlData, string cmd = "")
        {
            if (IsConnected)
            {
                _strError = string.Empty;

                if (cmd != "")
                {
                    _receiveDone.Reset();
                }
                _currCmd = cmd;

                string dat = string.Format("{0}\r\n{1}\r\n", "<?xml version='1.0' encoding='ISO-8859-1'?>", xmlData);

                _mlxSock.Send(null, dat);
            }
        }

        private bool CmdWait(int timeout = -9999)
        {
            if (timeout == -9999)
            {
                timeout = _nTimeOut;
            }

            bool ret = false;
            if (_currCmd != "")
            {
                ret = _receiveDone.Wait(timeout);
                if (!ret)
                {
                    if (string.IsNullOrEmpty(_strError))
                    {
                        _strError = "TimeOut response.";
                    }
                    ErrorOccurredEvent();
                }
            }
            else
            {
                ret = true;
                _strError = string.Empty;
            }

            _currCmd = string.Empty;
            return ret;
        }

        private void CmdCheckSet(string cmd)
        {
            if (_currCmd == cmd)
            {
                _currCmd = string.Empty;
                _receiveDone.Set();
            }
        }

        private void OnDataReceive(Socket handler, string data)
        {
            if (!_mlxSock.IsConnected)
            {
                _mlxSock.dataReceiveEvent -= OnDataReceive;

                SocketDisconnected();
                return;
            }
            else
            {
                if (data.Length > 0)
                {
                    //Console.WriteLine(data);
                    XDocument xDoc = null;
                    try
                    {
                        xDoc = XDocument.Parse(data);
                        if (xDoc != null)
                        {
                            XElement xRoot = xDoc.Root;
                            XElement xTmp = null;

                            #region Info
                            xTmp = xRoot.Element("info");
                            if (xTmp != null && !xTmp.IsEmpty)
                            {
                                if (xTmp.HasAttributes)
                                {
                                    XAttribute xAttTmp = xTmp.Attribute("version");
                                    if (xAttTmp != null)
                                    {
                                        _strVersion = xAttTmp.Value;
                                    }

                                    xAttTmp = xTmp.Attribute("name");
                                    if (xAttTmp != null)
                                    {
                                        _strName = xAttTmp.Value;
                                    }
                                }

                                XElement xResultInfo = xTmp.Element("result_info");
                                if (xResultInfo != null && !xResultInfo.IsEmpty)
                                {
                                    _dicAvailableEval.Clear();

                                    IEnumerator enXEl = xResultInfo.Elements().GetEnumerator();
                                    while (enXEl.MoveNext())
                                    {
                                        XElement xItem = (XElement)enXEl.Current;
                                        if (xItem != null)
                                        {
                                            XAttribute xAttrName = xItem.Attribute("name");
                                            XAttribute xAttrDesc = xItem.Attribute("description");
                                            if (xAttrName != null && xAttrDesc != null)
                                            {
                                                string strName = xAttrName.Value;
                                                string strDesc = xAttrDesc.Value;
                                                _dicAvailableEval.Add(strName, strDesc);
                                            }
                                        }
                                    }
                                }

                                XElement xCameraInfo = xTmp.Element("camera_info");
                                if (xCameraInfo != null && !xCameraInfo.IsEmpty)
                                {
                                    XAttribute xAttrActiveID = xCameraInfo.Attribute("active_ID");
                                    if (xAttrActiveID != null)
                                    {
                                        string activeID = xAttrActiveID.Value;
                                    }

                                    XElement xCameraItem = xCameraInfo.Element("camera_item");
                                    if (xCameraItem != null)
                                    {
                                        if (xCameraItem.HasAttributes)
                                        {
                                            XAttribute xCameraItemAttTmp = xCameraItem.Attribute("name");
                                            if (xCameraItemAttTmp != null)
                                            {
                                                _strCamID = xCameraItemAttTmp.Value;
                                            }

                                            xCameraItemAttTmp = xCameraItem.Attribute("max_height");
                                            if (xCameraItemAttTmp != null)
                                            {
                                                _nCamHeightMax = Convert.ToInt32(xCameraItemAttTmp.Value);
                                            }

                                            xCameraItemAttTmp = xCameraItem.Attribute("max_width");
                                            if (xCameraItemAttTmp != null)
                                            {
                                                _nCamWidthMax = Convert.ToInt32(xCameraItemAttTmp.Value);
                                            }

                                            xCameraItemAttTmp = xCameraItem.Attribute("pixel_height");
                                            if (xCameraItemAttTmp != null)
                                            {
                                                _dCamPixelSizeHeight = Convert.ToDouble(xCameraItemAttTmp.Value);
                                            }

                                            xCameraItemAttTmp = xCameraItem.Attribute("pixel_width");
                                            if (xCameraItemAttTmp != null)
                                            {
                                                _dCamPixelSizeWidth = Convert.ToDouble(xCameraItemAttTmp.Value);
                                            }

                                            xCameraItemAttTmp = xCameraItem.Attribute("depth");
                                            if (xCameraItemAttTmp != null)
                                            {
                                                _nCamDepth = Convert.ToInt32(xCameraItemAttTmp.Value);
                                            }

                                            xCameraItemAttTmp = xCameraItem.Attribute("magnification");
                                            if (xCameraItemAttTmp != null)
                                            {
                                                _dCamMagnification = Convert.ToDouble(xCameraItemAttTmp.Value);
                                            }

                                            xCameraItemAttTmp = xCameraItem.Attribute("autoControl");
                                            if (xCameraItemAttTmp != null)
                                            {
                                                string autoControl = xCameraItemAttTmp.Value;
                                                switch (autoControl)
                                                {
                                                    case "auto-off":
                                                        _camModeAutoControl = ModeAutoControl.AutoOff;
                                                        break;

                                                    case "autoExp":
                                                        _camModeAutoControl = ModeAutoControl.AutoExposure;
                                                        break;
                                                }
                                            }
                                        }

                                        if (!xCameraItem.IsEmpty)
                                        {
                                            XElement xCameraRoi = xCameraItem.Element("roi");
                                            if (xCameraRoi != null)
                                            {
                                                if (xCameraRoi.HasAttributes)
                                                {
                                                    XAttribute xCameraRoiAttTmp = xCameraRoi.Attribute("width");
                                                    if (xCameraRoiAttTmp != null)
                                                    {
                                                        _nCamWidth = Convert.ToInt32(xCameraRoiAttTmp.Value);
                                                    }

                                                    xCameraRoiAttTmp = xCameraRoi.Attribute("height");
                                                    if (xCameraRoiAttTmp != null)
                                                    {
                                                        _nCamHeight = Convert.ToInt32(xCameraRoiAttTmp.Value);
                                                    }

                                                    xCameraRoiAttTmp = xCameraRoi.Attribute("left");
                                                    if (xCameraRoiAttTmp != null)
                                                    {
                                                        _nCamOffsetX = Convert.ToInt32(xCameraRoiAttTmp.Value);
                                                    }

                                                    xCameraRoiAttTmp = xCameraRoi.Attribute("top");
                                                    if (xCameraRoiAttTmp != null)
                                                    {
                                                        _nCamOffsetY = Convert.ToInt32(xCameraRoiAttTmp.Value);
                                                    }

                                                    xCameraRoiAttTmp = xCameraRoi.Attribute("widthstep");
                                                    if (xCameraRoiAttTmp != null)
                                                    {
                                                        _nCamWidthStep = Convert.ToInt32(xCameraRoiAttTmp.Value);
                                                    }

                                                    xCameraRoiAttTmp = xCameraRoi.Attribute("heightstep");
                                                    if (xCameraRoiAttTmp != null)
                                                    {
                                                        _nCamHeightStep = Convert.ToInt32(xCameraRoiAttTmp.Value);
                                                    }
                                                }
                                            }

                                            XElement xCameraGain = xCameraItem.Element("gain");
                                            if (xCameraGain != null)
                                            {
                                                if (xCameraGain.HasAttributes)
                                                {
                                                    XAttribute xCameraGainAttTmp = xCameraGain.Attribute("available");
                                                    if (xCameraGainAttTmp != null)
                                                    {
                                                        _bAvailableGain = Convert.ToBoolean(xCameraGainAttTmp.Value);
                                                    }

                                                    xCameraGainAttTmp = xCameraGain.Attribute("min");
                                                    if (xCameraGainAttTmp != null)
                                                    {
                                                        _dCamGainMin = Convert.ToDouble(xCameraGainAttTmp.Value);
                                                    }

                                                    xCameraGainAttTmp = xCameraGain.Attribute("max");
                                                    if (xCameraGainAttTmp != null)
                                                    {
                                                        _dCamGainMax = Math.Truncate(Convert.ToDouble(xCameraGainAttTmp.Value) * 10) / 10;
                                                    }

                                                    xCameraGainAttTmp = xCameraGain.Attribute("value");
                                                    if (xCameraGainAttTmp != null)
                                                    {
                                                        _dCamGain = Convert.ToDouble(xCameraGainAttTmp.Value);
                                                    }
                                                }
                                            }

                                            XElement xCameraExposure = xCameraItem.Element("exposure");
                                            if (xCameraExposure != null)
                                            {
                                                if (xCameraExposure.HasAttributes)
                                                {
                                                    XAttribute xCameraExposureAttTmp = xCameraExposure.Attribute("available");
                                                    if (xCameraExposureAttTmp != null)
                                                    {
                                                        _bAvailableExposureTime = Convert.ToBoolean(xCameraExposureAttTmp.Value);
                                                    }

                                                    xCameraExposureAttTmp = xCameraExposure.Attribute("min");
                                                    if (xCameraExposureAttTmp != null)
                                                    {
                                                        _dCamExposureMin = Convert.ToDouble(xCameraExposureAttTmp.Value);
                                                    }

                                                    xCameraExposureAttTmp = xCameraExposure.Attribute("max");
                                                    if (xCameraExposureAttTmp != null)
                                                    {
                                                        _dCamExporsureMax = Convert.ToDouble(xCameraExposureAttTmp.Value);
                                                    }

                                                    xCameraExposureAttTmp = xCameraExposure.Attribute("value");
                                                    if (xCameraExposureAttTmp != null)
                                                    {
                                                        _dCamExposureTime = Convert.ToDouble(xCameraExposureAttTmp.Value);
                                                    }
                                                }
                                            }

                                            XElement xCameraTriggerDelay = xCameraItem.Element("triggerdelay");
                                            if (xCameraTriggerDelay != null)
                                            {
                                                if (xCameraTriggerDelay.HasAttributes)
                                                {
                                                    XAttribute xCameraTriggerDelayAttTmp = xCameraTriggerDelay.Attribute("available");
                                                    if (xCameraTriggerDelayAttTmp != null)
                                                    {
                                                        _bAvailableTirggerDelay = Convert.ToBoolean(xCameraTriggerDelayAttTmp.Value);
                                                    }

                                                    xCameraTriggerDelayAttTmp = xCameraTriggerDelay.Attribute("min");
                                                    if (xCameraTriggerDelayAttTmp != null)
                                                    {
                                                        _dCamTriggerDelayMin = Convert.ToDouble(xCameraTriggerDelayAttTmp.Value);
                                                    }

                                                    xCameraTriggerDelayAttTmp = xCameraTriggerDelay.Attribute("max");
                                                    if (xCameraTriggerDelayAttTmp != null)
                                                    {
                                                        _dCamTriggerDelayMax = Convert.ToDouble(xCameraTriggerDelayAttTmp.Value);
                                                    }

                                                    xCameraTriggerDelayAttTmp = xCameraTriggerDelay.Attribute("value");
                                                    if (xCameraTriggerDelayAttTmp != null)
                                                    {
                                                        _dCamTriggerDelay = Convert.ToDouble(xCameraTriggerDelayAttTmp.Value);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }

                                XElement xGeneralInfo = xTmp.Element("general_info");
                                if (xGeneralInfo != null && !xGeneralInfo.IsEmpty)
                                {
                                    XElement xGrabModeInfo = xGeneralInfo.Element("grabMode_info");
                                    if (xGrabModeInfo != null && !xGrabModeInfo.IsEmpty)
                                    {
                                        if (xGrabModeInfo.HasAttributes)
                                        {
                                            XAttribute xGrabModeInfoAttTmp = xGrabModeInfo.Attribute("available");

                                            string grabMode = xGrabModeInfoAttTmp.Value;
                                            switch (grabMode)
                                            {
                                                case "grab":
                                                    _nGrabMode = GrabMode.Continuous;
                                                    break;

                                                case "snapShot":
                                                    _nGrabMode = GrabMode.SnapShot;
                                                    break;

                                                case "externalGrab":
                                                    _nGrabMode = GrabMode.ExternalTriggered;
                                                    break;
                                            }
                                        }
                                    }

                                    XElement xFloatingAvgInfo = xGeneralInfo.Element("floatingAverage_info");
                                    if (xFloatingAvgInfo != null && xFloatingAvgInfo.HasAttributes)
                                    {
                                        XAttribute xFloatingAvgInfoAttTmp = xFloatingAvgInfo.Attribute("enabled");
                                        if (xFloatingAvgInfoAttTmp != null)
                                        {
                                            try
                                            {
                                                _bFloatingAvgEnable = Convert.ToBoolean(xFloatingAvgInfoAttTmp.Value);
                                            }
                                            catch (Exception)
                                            {
                                                _bFloatingAvgEnable = false;
                                            }
                                        }

                                        xFloatingAvgInfoAttTmp = xFloatingAvgInfo.Attribute("value");
                                        if (xFloatingAvgInfoAttTmp != null)
                                        {
                                            try
                                            {
                                                _nFloatingAvgValue = Convert.ToInt32(xFloatingAvgInfoAttTmp.Value);
                                            }
                                            catch (Exception)
                                            {
                                                _nFloatingAvgValue = 2;
                                            }
                                        }

                                        xFloatingAvgInfoAttTmp = xFloatingAvgInfo.Attribute("max");
                                        if (xFloatingAvgInfoAttTmp != null)
                                        {
                                            try
                                            {
                                                _nFloatingAvgValueMax = Convert.ToInt32(xFloatingAvgInfoAttTmp.Value);
                                            }
                                            catch (Exception)
                                            {
                                                _nFloatingAvgValueMax = 40;
                                            }
                                        }
                                    }

                                    XElement xNumberRestrictionInfo = xGeneralInfo.Element("numberRestriction_info");
                                    if (xNumberRestrictionInfo != null && xNumberRestrictionInfo.HasAttributes)
                                    {
                                        XAttribute xNumberRestrictionInfoAttTmp = xNumberRestrictionInfo.Attribute("enabled");
                                        if (xNumberRestrictionInfoAttTmp != null)
                                        {
                                            try
                                            {
                                                _bNumberRestrictionEnable = Convert.ToBoolean(xNumberRestrictionInfoAttTmp.Value);
                                            }
                                            catch (Exception)
                                            {
                                                _bNumberRestrictionEnable = false;
                                            }
                                        }

                                        xNumberRestrictionInfoAttTmp = xNumberRestrictionInfo.Attribute("value");
                                        if (xNumberRestrictionInfoAttTmp != null)
                                        {
                                            try
                                            {
                                                _nNumberRestrictionValue = Convert.ToInt32(xNumberRestrictionInfoAttTmp.Value);
                                            }
                                            catch (Exception)
                                            {
                                                _nNumberRestrictionValue = 2;
                                            }
                                        }

                                        xNumberRestrictionInfoAttTmp = xNumberRestrictionInfo.Attribute("max");
                                        if (xNumberRestrictionInfoAttTmp != null)
                                        {
                                            try
                                            {
                                                _nNumberRestrictionValueMax = Convert.ToInt32(xNumberRestrictionInfoAttTmp.Value);
                                            }
                                            catch (Exception)
                                            {
                                                _nNumberRestrictionValueMax = 10000;
                                            }
                                        }
                                    }

                                    XElement xBlurInfo = xGeneralInfo.Element("blur_info");
                                    if (xBlurInfo != null && xBlurInfo.HasAttributes)
                                    {
                                        XAttribute xBlurInfoAttTmp = xBlurInfo.Attribute("enabled");
                                        if (xBlurInfoAttTmp != null)
                                        {
                                            try
                                            {
                                                _bBlurEnable = Convert.ToBoolean(xBlurInfoAttTmp.Value);
                                            }
                                            catch (Exception)
                                            {
                                                _bBlurEnable = false;
                                            }
                                        }

                                        xBlurInfoAttTmp = xBlurInfo.Attribute("mode");
                                        if (xBlurInfoAttTmp != null)
                                        {
                                            string blurMode = xBlurInfoAttTmp.Value;
                                            switch (blurMode)
                                            {
                                                case "average":
                                                    _blurMode = BlurMode.AVERAGE;
                                                    break;

                                                case "gaussian":
                                                    _blurMode = BlurMode.GAUSSIAN;
                                                    break;

                                                case "median":
                                                    _blurMode = BlurMode.MEDIAN;
                                                    break;
                                            }
                                        }

                                        xBlurInfoAttTmp = xBlurInfo.Attribute("value");
                                        if (xBlurInfoAttTmp != null)
                                        {
                                            try
                                            {
                                                _nBlurKervelValue = Convert.ToInt32(xBlurInfoAttTmp.Value);
                                            }
                                            catch (Exception)
                                            {
                                                _nBlurKervelValue = 3;
                                            }
                                        }                                        

                                        xBlurInfoAttTmp = xBlurInfo.Attribute("max");
                                        if (xBlurInfoAttTmp != null)
                                        {
                                            try
                                            {
                                                _nBlurKervelValueMax = Convert.ToInt32(xBlurInfoAttTmp.Value);
                                            }
                                            catch (Exception)
                                            {
                                                _nBlurKervelValueMax = 99;
                                            }
                                        }
                                    }

                                    XElement xBackgroundInfo = xGeneralInfo.Element("background_info");
                                    if (xBackgroundInfo != null)
                                    {
                                        if (xBackgroundInfo.HasAttributes)
                                        {
                                            XAttribute xBackgroundInfoAttTmp = xBackgroundInfo.Attribute("mode");
                                            if (xBackgroundInfoAttTmp != null)
                                            {
                                                string mode = xBackgroundInfoAttTmp.Value;
                                                switch (mode)
                                                {
                                                    case "image":
                                                        _backgroundMode = ModeBackgroundImageCorrection.IMAGE;
                                                        break;

                                                    case "corner":
                                                        _backgroundMode = ModeBackgroundImageCorrection.CORNER;
                                                        break;

                                                    case "constant":
                                                        _backgroundMode = ModeBackgroundImageCorrection.CONSTANT;
                                                        break;
                                                }
                                            }

                                            xBackgroundInfoAttTmp = xBackgroundInfo.Attribute("enabled");
                                            if (xBackgroundInfoAttTmp != null)
                                            {
                                                bool enable = false;
                                                if (bool.TryParse(xBackgroundInfoAttTmp.Value, out enable))
                                                {
                                                    switch (_backgroundMode)
                                                    {
                                                        case ModeBackgroundImageCorrection.IMAGE:
                                                            _bIsBackImageEnable = enable;
                                                            break;

                                                        case ModeBackgroundImageCorrection.CORNER:
                                                            _bIsBackConerEnable = enable;
                                                            break;

                                                        case ModeBackgroundImageCorrection.CONSTANT:
                                                            _bIsBackConstantEnable = enable;
                                                            break;
                                                    }
                                                }
                                            }

                                            xBackgroundInfoAttTmp = xBackgroundInfo.Attribute("value");
                                            if (xBackgroundInfoAttTmp != null)
                                            {
                                                switch (_backgroundMode)
                                                {
                                                    case ModeBackgroundImageCorrection.IMAGE:
                                                        {
                                                            int value = -1;
                                                            if (int.TryParse(xBackgroundInfoAttTmp.Value, out value))
                                                            {
                                                                _nBackImageAcquireFrames = value;
                                                            }
                                                        }
                                                        break;

                                                    case ModeBackgroundImageCorrection.CORNER:
                                                        {
                                                            int value = -1;
                                                            if (int.TryParse(xBackgroundInfoAttTmp.Value, out value))
                                                            {
                                                                _nCornerOverlaySpan = value;
                                                            }
                                                        }
                                                        break;

                                                    case ModeBackgroundImageCorrection.CONSTANT:
                                                        {
                                                            double value = double.NaN;
                                                            if (double.TryParse(xBackgroundInfoAttTmp.Value, out value))
                                                            {
                                                                _dBackConstant = value;
                                                            }
                                                        }
                                                        break;
                                                }
                                            }
                                        }

                                        if (xBackgroundInfo.HasElements)
                                        {
                                            XElement xBackground_image = xBackgroundInfo.Element("background_image");
                                            if (xBackground_image != null && xBackground_image.HasAttributes)
                                            {
                                                XAttribute xImage = xBackground_image.Attribute("enable");
                                                if (xImage != null)
                                                {
                                                    bool enable = false;
                                                    if (bool.TryParse(xImage.Value, out enable))
                                                    {
                                                        _bIsBackImageEnable = enable;
                                                    }
                                                }

                                                xImage = xBackground_image.Attribute("value");
                                                if (xImage != null)
                                                {
                                                    int value = -1;
                                                    if (int.TryParse(xImage.Value, out value))
                                                    {
                                                        _nBackImageAcquireFrames = value;
                                                    }
                                                }
                                            }

                                            XElement xBackground_corner = xBackgroundInfo.Element("background_corner");
                                            if (xBackground_corner != null && xBackground_corner.HasAttributes)
                                            {
                                                XAttribute xCorner = xBackground_corner.Attribute("enable");
                                                if (xCorner != null)
                                                {
                                                    bool enable = false;
                                                    if (bool.TryParse(xCorner.Value, out enable))
                                                    {
                                                        _bIsBackConerEnable = enable;
                                                    }
                                                }

                                                xCorner = xBackground_corner.Attribute("value");
                                                if (xCorner != null)
                                                {
                                                    int value = -1;
                                                    if (int.TryParse(xCorner.Value, out value))
                                                    {
                                                        _nCornerOverlaySpan = value;
                                                    }
                                                }

                                                xCorner = xBackground_corner.Attribute("overlay");
                                                if (xCorner != null)
                                                {
                                                    bool overlay = false;
                                                    if (bool.TryParse(xCorner.Value, out overlay))
                                                    {
                                                        _bIsOverlay = overlay;
                                                    }
                                                }
                                            }

                                            XElement xBackground_constant = xBackgroundInfo.Element("background_constant");
                                            if (xBackground_constant != null && xBackground_constant.HasAttributes)
                                            {
                                                XAttribute xConstant = xBackground_constant.Attribute("enable");
                                                if (xConstant != null)
                                                {
                                                    bool enable = false;
                                                    if (bool.TryParse(xConstant.Value, out enable))
                                                    {
                                                        _bIsBackConstantEnable = enable;
                                                    }
                                                }

                                                xConstant = xBackground_constant.Attribute("value");
                                                if (xConstant != null)
                                                {
                                                    double value = double.NaN;
                                                    if (double.TryParse(xConstant.Value, out value))
                                                    {
                                                        _dBackConstant = value;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }

                                XElement xFrameInfo = xTmp.Element("frame_info");
                                if (xFrameInfo != null && !xFrameInfo.IsEmpty)
                                {
                                    XElement xROIInfo = xFrameInfo.Element("ROI_info");
                                    if (xROIInfo != null)
                                    {
                                        if (xROIInfo.HasAttributes)
                                        {
                                            XAttribute xROIInfoAtTmp = xROIInfo.Attribute("active");
                                            if (xROIInfoAtTmp != null)
                                            {
                                                _bFrameROIActive = Convert.ToBoolean(xROIInfoAtTmp.Value);
                                            }

                                            xROIInfoAtTmp = xROIInfo.Attribute("mode");
                                            if (xROIInfoAtTmp != null)
                                            {
                                                string mode = xROIInfoAtTmp.Value;
                                                switch (mode)
                                                {
                                                    case "manual":
                                                        _frameROIMode = FrameROIMode.MANUAL;
                                                        break;

                                                    case "centroid":
                                                        _frameROIMode = FrameROIMode.CENTROID;
                                                        break;

                                                    case "autoresize":
                                                        _frameROIMode = FrameROIMode.AUTORESIZE;
                                                        break;
                                                }
                                            }

                                            xROIInfoAtTmp = xROIInfo.Attribute("mode");
                                            if (xROIInfoAtTmp != null)
                                            {
                                                string shape = xROIInfoAtTmp.Value;
                                                switch (shape)
                                                {
                                                    case "rectangle":
                                                        _frameROIShape = FrameROIShape.RECTANGLE;
                                                        break;

                                                    case "circle":
                                                        _frameROIShape = FrameROIShape.CIRCLE;
                                                        break;
                                                }
                                            }

                                            xROIInfoAtTmp = xROIInfo.Attribute("left");
                                            if (xROIInfoAtTmp != null)
                                            {
                                                try
                                                {
                                                    _nFrameROILeft = Convert.ToInt32(xROIInfoAtTmp.Value);
                                                }
                                                catch (Exception) { _nFrameROILeft = -1; }
                                            }

                                            xROIInfoAtTmp = xROIInfo.Attribute("top");
                                            if (xROIInfoAtTmp != null)
                                            {
                                                try
                                                {
                                                    _nFrameROITop = Convert.ToInt32(xROIInfoAtTmp.Value);
                                                }
                                                catch (Exception) { _nFrameROITop = -1; }
                                            }

                                            xROIInfoAtTmp = xROIInfo.Attribute("width");
                                            if (xROIInfoAtTmp != null)
                                            {
                                                try
                                                {
                                                    _nFrameROIWidth = Convert.ToInt32(xROIInfoAtTmp.Value);
                                                }
                                                catch (Exception) { _nFrameROIWidth = -1; }
                                            }

                                            xROIInfoAtTmp = xROIInfo.Attribute("height");
                                            if (xROIInfoAtTmp != null)
                                            {
                                                try
                                                {
                                                    _nFrameROIHeight = Convert.ToInt32(xROIInfoAtTmp.Value);
                                                }
                                                catch (Exception) { _nFrameROIHeight = -1; }
                                            }
                                        }
                                    }

                                    XElement xCrossSecInfo = xFrameInfo.Element("CrossSections_info");
                                    if (xCrossSecInfo != null)
                                    {
                                        if (xCrossSecInfo.HasElements)
                                        {
                                            XAttribute xCrossSecInfoAtTmp = xCrossSecInfo.Attribute("active");
                                            if (xCrossSecInfoAtTmp != null)
                                            {
                                                _bFrameCrossSection = Convert.ToBoolean(xCrossSecInfoAtTmp.Value);
                                            }

                                            xCrossSecInfoAtTmp = xCrossSecInfo.Attribute("row");
                                            if (xCrossSecInfoAtTmp != null)
                                            {
                                                _nFrameCrossSecRow = Convert.ToInt32(xCrossSecInfoAtTmp.Value);
                                            }

                                            xCrossSecInfoAtTmp = xCrossSecInfo.Attribute("column");
                                            if (xCrossSecInfoAtTmp != null)
                                            {
                                                _nFrameCrossSecCol = Convert.ToInt32(xCrossSecInfoAtTmp.Value);
                                            }

                                            xCrossSecInfoAtTmp = xCrossSecInfo.Attribute("mode");
                                            if (xCrossSecInfoAtTmp != null)
                                            {
                                                string val = xCrossSecInfoAtTmp.Value;
                                                if (val == "manual")
                                                {
                                                    _bFrameCrossSecAuto = false;
                                                }
                                                else if (val == "centroid")
                                                {
                                                    _bFrameCrossSecAuto = true;
                                                }
                                            }
                                        }
                                    }

                                    XElement xBeamSecInfo = xFrameInfo.Element("BeamSections_info");
                                    if (xBeamSecInfo != null)
                                    {
                                        if (xBeamSecInfo.HasElements)
                                        {
                                            XAttribute xBeamSecInfoAtTmp = xBeamSecInfo.Attribute("active");
                                            if (xBeamSecInfoAtTmp != null)
                                            {
                                                _bFrameBeamSection = Convert.ToBoolean(xBeamSecInfoAtTmp.Value);
                                            }

                                            xBeamSecInfoAtTmp = xBeamSecInfo.Attribute("row");
                                            if (xBeamSecInfoAtTmp != null)
                                            {
                                                _nFrameBeamSecRow = Convert.ToInt32(xBeamSecInfoAtTmp.Value);
                                            }

                                            xBeamSecInfoAtTmp = xBeamSecInfo.Attribute("column");
                                            if (xBeamSecInfoAtTmp != null)
                                            {
                                                _nFrameBeamSecCol = Convert.ToInt32(xBeamSecInfoAtTmp.Value);
                                            }

                                            xBeamSecInfoAtTmp = xBeamSecInfo.Attribute("mode");
                                            if (xBeamSecInfoAtTmp != null)
                                            {
                                                string val = xBeamSecInfoAtTmp.Value;
                                                if (val == "manual")
                                                {
                                                    _bFrameBeamSecAuto = false;
                                                }
                                                else if (val == "followBeam")
                                                {
                                                    _bFrameBeamSecAuto = true;
                                                }
                                            }
                                        }
                                    }
                                }

                                CmdCheckSet("info");
                            }
                            #endregion

                            #region evaluation
                            xTmp = xRoot.Element("evaluation");
                            if (xTmp != null && !xTmp.IsEmpty)
                            {
                                XElement xResult = xTmp.Element("results");
                                if (xResult != null && !xResult.IsEmpty)
                                {
                                    IEnumerator enXResult = xResult.Elements().GetEnumerator();
                                    while (enXResult.MoveNext())
                                    {
                                        XElement xItem = enXResult.Current as XElement;
                                        if (xItem != null && xItem.HasAttributes)
                                        {
                                            bool isValid = false;
                                            XAttribute xAttr = xItem.Attribute("valid");
                                            if (xAttr != null)
                                            {
                                                isValid = Convert.ToBoolean(xAttr.Value);
                                            }

                                            if (isValid)
                                            {
                                                string name = string.Empty;
                                                xAttr = xItem.Attribute("name");
                                                if (xAttr != null)
                                                {
                                                    name = xAttr.Value.ToString();
                                                }

                                                string unit = string.Empty;
                                                xAttr = xItem.Attribute("unit");
                                                if (xAttr != null)
                                                {
                                                    unit = xAttr.Value.ToString();
                                                }

                                                string value = string.Empty;
                                                xAttr = xItem.Attribute("value");
                                                if (xAttr != null)
                                                {
                                                    value = xAttr.Value.ToString();
                                                }

                                                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(value))
                                                {
                                                    if (_dicUseEval.ContainsKey(name))
                                                    {
                                                        EvaluationDataSet dataSet = _dicUseEval[name];
                                                        dataSet.val = value;
                                                        dataSet.unit = unit;
                                                        _dicUseEval[name] = dataSet;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }

                                XElement xGetFrame = xTmp.Element("getFrame");
                                if (xGetFrame != null)
                                {
                                    bool bIsSucceeded = false;

                                    if (xGetFrame.HasAttributes)
                                    {
                                        XAttribute xAttrFrameTmp = xGetFrame.Attribute("succeeded");
                                        if (xAttrFrameTmp != null)
                                        {
                                            _bIsFrameImgSucceeded = false;
                                            bool.TryParse(xAttrFrameTmp.Value, out bIsSucceeded);                                            
                                        }

                                        if (bIsSucceeded)
                                        {
                                            xAttrFrameTmp = xGetFrame.Attribute("width");
                                            if (xAttrFrameTmp != null)
                                            {
                                                int width = -1;
                                                if (int.TryParse(xAttrFrameTmp.Value, out width))
                                                {
                                                    _nFrameImgWidth = width;
                                                }
                                            }

                                            xAttrFrameTmp = xGetFrame.Attribute("height");
                                            if (xAttrFrameTmp != null)
                                            {
                                                int height = -1;
                                                if (int.TryParse(xAttrFrameTmp.Value, out height))
                                                {
                                                    _nFrameImgHeight = height;
                                                }
                                            }
                                        }

                                        xAttrFrameTmp = xGetFrame.Attribute("active");
                                        if (xAttrFrameTmp != null)
                                        {
                                            bool active = false;
                                            if (bool.TryParse(xAttrFrameTmp.Value, out active))
                                            {
                                                _bGetFrameActive = active;
                                            }
                                        }

                                        xAttrFrameTmp = xGetFrame.Attribute("scale");
                                        if (xAttrFrameTmp != null)
                                        {
                                            int scale = 20;
                                            if (int.TryParse(xAttrFrameTmp.Value, out scale))
                                            {
                                                _nGetGrameScale = scale;
                                            }
                                        }

                                        xAttrFrameTmp = xGetFrame.Attribute("format");
                                        if (xAttrFrameTmp != null)
                                        {
                                            string strFrameImgFormat = xAttrFrameTmp.Value;
                                            switch (strFrameImgFormat)
                                            {
                                                case "BMP":
                                                    _getFrameFormat = GetFrameFormat.BMP; break;

                                                case "JPG":
                                                    _getFrameFormat = GetFrameFormat.JPG; break;

                                                case "PNG":
                                                    _getFrameFormat = GetFrameFormat.PNG; break;
                                            }
                                        }
                                    }

                                    if (bIsSucceeded)
                                    {
                                        string cdataVal = xGetFrame.Value;
                                        byte[] byteBuffer = Convert.FromBase64String(cdataVal);

                                        if (_bitmapFrameImg != null)
                                        {
                                            _bitmapFrameImg.Dispose();
                                            _bitmapFrameImg = null;
                                        }

                                        ImageConverter ic = new ImageConverter();
                                        Image img = ic.ConvertFrom(byteBuffer) as Image;
                                        if (img != null)
                                        {
                                            _bitmapFrameImg = new Bitmap(img);
                                        }
                                    }

                                    CmdCheckSet("evaluation getFrame");

                                    _bIsFrameImgSucceeded = bIsSucceeded;
                                }

                                ReceivedItemsEvent();
                            }

                            CmdCheckSet("evaluation");

                            #endregion

                            #region application
                            xTmp = xRoot.Element("application");
                            if (xTmp != null && !xTmp.IsEmpty)
                            {
                                XElement xSaveScr = xTmp.Element("saveScreen");
                                if (xSaveScr != null && xSaveScr.HasAttributes)
                                {
                                    XAttribute xAttrPath = xSaveScr.Attribute("path");
                                    _strRemotePath = xAttrPath.Value;
                                }
                            }
                            #endregion

                            #region acquisition
                            xTmp = xRoot.Element("acquisition");
                            if (xTmp != null && xTmp.HasAttributes)
                            {
                                XAttribute xAttrMode = xTmp.Attribute("mode");
                                if (xAttrMode != null)
                                {
                                    string modeVal = xAttrMode.Value;
                                    if (!string.IsNullOrEmpty(modeVal))
                                    {
                                        switch (modeVal)
                                        {
                                            case "start":
                                                CmdCheckSet("acquisition start");
                                                break;

                                            case "stop":
                                                CmdCheckSet("acquisition stop");
                                                break;

                                            case "background":
                                                CmdCheckSet("acquisition background");
                                                break;
                                        }
                                    }
                                }

                                xAttrMode = xTmp.Attribute("error");
                                if (xAttrMode != null)
                                {
                                    _strError = xAttrMode.Value;
                                }
                            }

                            #endregion

                            #region settings
                            xTmp = xRoot.Element("settings");
                            if (xTmp != null && !xTmp.IsEmpty)
                            {
                                #region settings general
                                XElement xGeneral = xTmp.Element("general");
                                if (xGeneral != null && !xGeneral.IsEmpty)
                                {
                                    #region settings general grabMode
                                    XElement xGrabMode = xGeneral.Element("grabMode");
                                    if (xGrabMode != null && xGrabMode.HasAttributes)
                                    {
                                        XAttribute xAttrMode = xGrabMode.Attribute("mode");
                                        if (xAttrMode != null)
                                        {
                                            string modeVal = xAttrMode.Value;
                                            if (!string.IsNullOrEmpty(modeVal))
                                            {
                                                switch (modeVal)
                                                {
                                                    case "grab":
                                                        _nGrabMode = GrabMode.Continuous;
                                                        break;

                                                    case "snapshot":
                                                        _nGrabMode = GrabMode.SnapShot;
                                                        break;

                                                    case "externalGrab":
                                                        _nGrabMode = GrabMode.ExternalTriggered;
                                                        break;
                                                }

                                                CmdCheckSet("setting general grabmode");
                                            }
                                        }

                                        XElement xGeneralErr = xGeneral.Element("error");
                                        if (xGeneralErr != null && !xGeneralErr.IsEmpty)
                                        {
                                            _strError = xGeneralErr.Value;
                                        }
                                    }
                                    #endregion

                                    #region settings general floatingAverage
                                    XElement xFloatingAverage = xGeneral.Element("floatingAverage");
                                    if (xFloatingAverage != null && xFloatingAverage.HasAttributes)
                                    {
                                        XAttribute xAttrValue = xFloatingAverage.Attribute("value");
                                        if (xAttrValue != null)
                                        {
                                            int floatingAvgValue = -1;
                                            if (int.TryParse(xAttrValue.Value, out floatingAvgValue))
                                            {
                                                _nFloatingAvgValue = floatingAvgValue;
                                            }
                                        }

                                        XAttribute xAttrEnable = xFloatingAverage.Attribute("enable");
                                        if (xAttrEnable != null)
                                        {
                                            bool floatingAvgEnable = false;
                                            if (bool.TryParse(xAttrEnable.Value, out floatingAvgEnable))
                                            {
                                                _bFloatingAvgEnable = floatingAvgEnable;
                                            }
                                        }

                                        CmdCheckSet("setting general floatingaverage");
                                    }
                                    #endregion

                                    #region settings general numberRestriction
                                    XElement xNumberRestriction = xGeneral.Element("numberRestriction");
                                    if (xNumberRestriction != null && xNumberRestriction.HasAttributes)
                                    {
                                        XAttribute xAttrValue = xNumberRestriction.Attribute("value");
                                        if (xAttrValue != null)
                                        {
                                            int numberRestrictionValue = -1;
                                            if (int.TryParse(xAttrValue.Value, out numberRestrictionValue))
                                            {
                                                _nNumberRestrictionValue = numberRestrictionValue;
                                            }
                                        }

                                        XAttribute xAttrEnable = xNumberRestriction.Attribute("enable");
                                        if (xAttrEnable != null)
                                        {
                                            bool numberRestrictionEnable = false;
                                            if (bool.TryParse(xAttrValue.Value, out numberRestrictionEnable))
                                            {
                                                _bNumberRestrictionEnable = numberRestrictionEnable;
                                            }
                                        }

                                        CmdCheckSet("setting general numberrestriction");
                                    }
                                    #endregion

                                    #region settings general blur
                                    XElement xBlur = xGeneral.Element("blur");
                                    if (xBlur != null && xBlur.HasAttributes)
                                    {
                                        XAttribute xAttrValue = xBlur.Attribute("value");
                                        if (xAttrValue != null)
                                        {
                                            int blureKenelValue = -1;
                                            if (int.TryParse(xAttrValue.Value, out blureKenelValue))
                                            {
                                                 _nBlurKervelValue = blureKenelValue;
                                            }
                                        }

                                        XAttribute xAttrMode = xBlur.Attribute("mode");
                                        if (xAttrMode != null)
                                        {
                                            string blurMode = xAttrMode.Value;
                                            switch (blurMode)
                                            {
                                                case "average":
                                                    _blurMode = BlurMode.AVERAGE;
                                                    break;

                                                case "gaussian":
                                                    _blurMode = BlurMode.GAUSSIAN;
                                                    break;

                                                case "median":
                                                    _blurMode = BlurMode.MEDIAN;
                                                    break;
                                            }
                                        }

                                        XAttribute xAttrEnable = xBlur.Attribute("enable");
                                        if (xAttrEnable != null)
                                        {
                                            bool blurEnable = false;
                                            if (bool.TryParse(xAttrEnable.Value, out blurEnable))
                                            {
                                                _bBlurEnable = blurEnable;
                                            }
                                        }

                                        CmdCheckSet("setting general blur");
                                    }
                                    #endregion
                                }
                                #endregion

                                #region settings camera
                                XElement xCamera = xTmp.Element("camera");
                                if (xCamera != null)
                                {
                                    if (xCamera.HasElements)
                                    {
                                        #region settings camera ROI
                                        XElement xROI = xCamera.Element("roi");
                                        if (xROI != null && xROI.HasAttributes)
                                        {
                                            bool isRoiErr = false;
                                            XAttribute xTmpROI = xROI.Attribute("width");
                                            if (xTmpROI != null)
                                            {
                                                try
                                                {
                                                    _nCamWidth = Convert.ToInt32(xTmpROI.Value);
                                                }
                                                catch (Exception)
                                                {
                                                    isRoiErr = true;
                                                }
                                            }

                                            xTmpROI = xROI.Attribute("height");
                                            if (xTmpROI != null)
                                            {
                                                try
                                                {
                                                    _nCamHeight = Convert.ToInt32(xTmpROI.Value);
                                                }
                                                catch (Exception)
                                                {
                                                    isRoiErr = true;
                                                }
                                            }

                                            xTmpROI = xROI.Attribute("left");
                                            if (xTmpROI != null)
                                            {
                                                try
                                                {
                                                    _nCamOffsetX = Convert.ToInt32(xTmpROI.Value);
                                                }
                                                catch (Exception)
                                                {
                                                    isRoiErr = true;
                                                }
                                            }

                                            xTmpROI = xROI.Attribute("top");
                                            if (xTmpROI != null)
                                            {
                                                try
                                                {
                                                    _nCamOffsetY = Convert.ToInt32(xTmpROI.Value);
                                                }
                                                catch (Exception)
                                                {
                                                    isRoiErr = true;
                                                }
                                            }

                                            if (!isRoiErr)
                                            {
                                                CmdCheckSet("settings camera ROI");
                                            }
                                        }
                                        #endregion
                                    }


                                    if (xCamera.HasAttributes)
                                    {
                                        #region settings camera gain
                                        XAttribute xAttrGain = xCamera.Attribute("gain");
                                        if (xAttrGain != null)
                                        {
                                            try
                                            {
                                                _dCamGain = Convert.ToDouble(xAttrGain.Value);
                                                CmdCheckSet("settings camera gain");
                                            }
                                            catch (Exception)
                                            {

                                            }
                                        }
                                        #endregion

                                        #region settings camera exposure
                                        XAttribute xAttrExpo = xCamera.Attribute("exposure");
                                        if (xAttrExpo != null)
                                        {
                                            try
                                            {
                                                _dCamExposureTime = Convert.ToDouble(xAttrExpo.Value);
                                                CmdCheckSet("settings camera exposure");
                                            }
                                            catch (Exception)
                                            {

                                            }
                                        }
                                        #endregion

                                        #region settings camera triggerdelay
                                        XAttribute xAttrTrigg = xCamera.Attribute("triggerdelay");
                                        if (xAttrTrigg != null)
                                        {
                                            try
                                            {
                                                _dCamTriggerDelay = Convert.ToDouble(xAttrTrigg.Value);
                                                CmdCheckSet("settings camera triggerdelay");
                                            }
                                            catch (Exception)
                                            {

                                            }
                                        }
                                        #endregion

                                        #region settings camera autocontrol
                                        XAttribute xAttrAutoControl = xCamera.Attribute("autoControl");
                                        if (xAttrAutoControl != null)
                                        {
                                            try
                                            {
                                                bool validValue = false;
                                                string autoControl = xAttrAutoControl.Value;

                                                switch (autoControl)
                                                {
                                                    case "auto-off":
                                                        _camModeAutoControl = ModeAutoControl.AutoOff;
                                                        validValue = true;
                                                        break;

                                                    case "autoExp":
                                                        _camModeAutoControl = ModeAutoControl.AutoExposure;
                                                        validValue = true;
                                                        break;
                                                }

                                                if (validValue)
                                                {
                                                    CmdCheckSet("settings camera autocontrol");
                                                }
                                            }
                                            catch (Exception)
                                            {

                                            }
                                        }
                                        #endregion
                                    }
                                }
                                #endregion

                                #region settings correction
                                XElement xCorrection = xTmp.Element("correction");
                                if (xCorrection != null && xCorrection.HasAttributes)
                                {
                                    XAttribute xAttrMode = xCorrection.Attribute("mode");
                                    if (xAttrMode != null)
                                    {
                                        string modeValue = xAttrMode.Value;
                                        switch (modeValue)
                                        {
                                            case "image":
                                                _backgroundMode = ModeBackgroundImageCorrection.IMAGE;
                                                break;

                                            case "corner":
                                                _backgroundMode = ModeBackgroundImageCorrection.CORNER;
                                                break;

                                            case "constant":
                                                _backgroundMode = ModeBackgroundImageCorrection.CONSTANT;
                                                break;
                                        }
                                    }

                                    XAttribute xAttrEnable = xCorrection.Attribute("enable");
                                    if (xAttrEnable != null)
                                    {
                                        bool corrEnable = false;
                                        if (bool.TryParse(xAttrEnable.Value, out corrEnable))
                                        {
                                            switch (_backgroundMode)
                                            {
                                                case ModeBackgroundImageCorrection.IMAGE:
                                                    _bIsBackImageEnable = corrEnable;
                                                    break;

                                                case ModeBackgroundImageCorrection.CORNER:
                                                    _bIsBackConerEnable = corrEnable;
                                                    break;

                                                case ModeBackgroundImageCorrection.CONSTANT:
                                                    _bIsBackConstantEnable = corrEnable;
                                                    break;
                                            }
                                        }
                                    }

                                    XAttribute xAttrValue = xCorrection.Attribute("value");
                                    if (xAttrValue != null)
                                    {
                                        switch (_backgroundMode)
                                        {
                                            case ModeBackgroundImageCorrection.IMAGE:
                                                {
                                                    int frames = -1;
                                                    if (int.TryParse(xAttrValue.Value, out frames))
                                                    {
                                                        _nBackImageAcquireFrames = frames;
                                                    }
                                                }
                                                break;

                                            case ModeBackgroundImageCorrection.CORNER:
                                                {
                                                    int span = -1;
                                                    if (int.TryParse(xAttrValue.Value, out span))
                                                    {
                                                        _nCornerOverlaySpan = span;
                                                    }
                                                }
                                                break;

                                            case ModeBackgroundImageCorrection.CONSTANT:
                                                {
                                                    double constant = double.NaN;
                                                    if (double.TryParse(xAttrValue.Value, out constant))
                                                    {
                                                        _dBackConstant = constant;
                                                    }
                                                }
                                                break;
                                        }
                                    }

                                    XAttribute xAttrOverlay = xCorrection.Attribute("overlay");
                                    if (xAttrOverlay != null)
                                    {
                                        bool overlay = false;
                                        if (bool.TryParse(xAttrOverlay.Value, out overlay))
                                        {
                                            _bIsOverlay = overlay;
                                        }
                                    }

                                    CmdCheckSet("settings correction");
                                }
                                #endregion
                            }
                            #endregion

                            #region frame
                            xTmp = xRoot.Element("frame");
                            if (xTmp != null && !xTmp.IsEmpty)
                            {
                                #region ROI
                                XElement xROI = xTmp.Element("ROI");
                                if (xROI != null && xROI.HasAttributes)
                                {
                                    bool isRoiErr = false;
                                    XAttribute xTmpROI = xROI.Attribute("active");
                                    if (xTmpROI != null)
                                    {
                                        try
                                        {
                                            _bFrameROIActive = Convert.ToBoolean(xTmpROI.Value);
                                        }
                                        catch (Exception)
                                        {
                                            isRoiErr = true;
                                        }
                                    }

                                    xTmpROI = xROI.Attribute("mode");
                                    if (xTmpROI != null)
                                    {
                                        try
                                        {
                                            string mode = xTmpROI.Value;
                                            switch (mode)
                                            {
                                                case "manual":
                                                    _frameROIMode = FrameROIMode.MANUAL;
                                                    break;

                                                case "centroid":
                                                    _frameROIMode = FrameROIMode.CENTROID;
                                                    break;

                                                case "autoresize":
                                                    _frameROIMode = FrameROIMode.AUTORESIZE;
                                                    break;
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            isRoiErr = true;
                                        }
                                    }

                                    xTmpROI = xROI.Attribute("shape");
                                    if (xTmpROI != null)
                                    {
                                        try
                                        {
                                            string shape = xTmpROI.Value;
                                            switch (shape)
                                            {
                                                case "rectangle":
                                                    _frameROIShape = FrameROIShape.RECTANGLE;
                                                    break;

                                                case "circle":
                                                    _frameROIShape = FrameROIShape.CIRCLE;
                                                    break;
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            isRoiErr = true;
                                        }
                                    }

                                    xTmpROI = xROI.Attribute("left");
                                    if (xTmpROI != null)
                                    {
                                        try
                                        {
                                            _nFrameROILeft = Convert.ToInt32(xTmpROI.Value);
                                        }
                                        catch (Exception)
                                        {
                                            isRoiErr = true;
                                        }
                                    }

                                    xTmpROI = xROI.Attribute("top");
                                    if (xTmpROI != null)
                                    {
                                        try
                                        {
                                            _nFrameROITop = Convert.ToInt32(xTmpROI.Value);
                                        }
                                        catch (Exception)
                                        {
                                            isRoiErr = true;
                                        }
                                    }

                                    xTmpROI = xROI.Attribute("width");
                                    if (xTmpROI != null)
                                    {
                                        try
                                        {
                                            _nFrameROIWidth = Convert.ToInt32(xTmpROI.Value);
                                        }
                                        catch (Exception)
                                        {
                                            isRoiErr = true;
                                        }
                                    }

                                    xTmpROI = xROI.Attribute("height");
                                    if (xTmpROI != null)
                                    {
                                        try
                                        {
                                            _nFrameROIHeight = Convert.ToInt32(xTmpROI.Value);
                                        }
                                        catch (Exception)
                                        {
                                            isRoiErr = true;
                                        }
                                    }

                                    if (!isRoiErr)
                                    {
                                        CmdCheckSet("frame ROI");
                                    }
                                }

                                //XElement xROI = xTmp.Element("ROI");
                                //if (xROI != null && xROI.HasAttributes)

                                #endregion

                                #region CrossSections
                                XElement xCrossSection = xTmp.Element("CrossSections");
                                if (xCrossSection != null)
                                {
                                    bool isCrossSectionErr = false;
                                    XAttribute xTmpCrossSection = xCrossSection.Attribute("active");
                                    if (xTmpCrossSection != null)
                                    {
                                        try
                                        {
                                            _bFrameCrossSection = Convert.ToBoolean(xTmpCrossSection.Value);
                                        }
                                        catch (Exception)
                                        {
                                            isCrossSectionErr = true;
                                        }
                                    }

                                    xTmpCrossSection = xCrossSection.Attribute("row");
                                    if (xTmpCrossSection != null)
                                    {
                                        try
                                        {
                                            _nFrameCrossSecRow = Convert.ToInt32(xTmpCrossSection.Value);
                                        }
                                        catch (Exception)
                                        {
                                            isCrossSectionErr = true;
                                        }
                                    }

                                    xTmpCrossSection = xCrossSection.Attribute("column");
                                    if (xTmpCrossSection != null)
                                    {
                                        try
                                        {
                                            _nFrameCrossSecCol = Convert.ToInt32(xTmpCrossSection.Value);
                                        }
                                        catch (Exception)
                                        {
                                            isCrossSectionErr = true;
                                        }
                                    }

                                    xTmpCrossSection = xCrossSection.Attribute("mode");
                                    if (xTmpCrossSection != null)
                                    {
                                        try
                                        {
                                            string mode = xTmpCrossSection.Value;
                                            if (mode != null)
                                            {
                                                if (mode == "manual")
                                                {
                                                    _bFrameCrossSecAuto = false;
                                                }
                                                else if (mode == "centroid")
                                                {
                                                    _bFrameCrossSecAuto = true;
                                                }
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            isCrossSectionErr = true;
                                        }
                                    }

                                    XElement xBorder = xCrossSection.Element("borders");
                                    if (xBorder != null && xBorder.HasAttributes)
                                    {
                                        string borderType = string.Empty;

                                        XAttribute xTmpBorder = xBorder.Attribute("type");
                                        if (xTmpBorder != null)
                                        {
                                            try
                                            {
                                                borderType = xTmpBorder.Value;
                                            }
                                            catch (Exception)
                                            {
                                                isCrossSectionErr = true;
                                                throw;
                                            }
                                        }

                                        switch (borderType)
                                        {
                                            case "horizontal":
                                                {
                                                    xTmpBorder = xBorder.Attribute("mode");
                                                    if (xTmpBorder != null)
                                                    {
                                                        string bordermode = xTmpBorder.Value;
                                                        if (bordermode.Equals("manual"))
                                                        {
                                                            _frameCrossSecsHorBorderMode = FrameSectionBorderMode.MANUAL;
                                                        }
                                                        else if (bordermode.Equals("reference"))
                                                        {
                                                            _frameCrossSecsHorBorderMode = FrameSectionBorderMode.REFERENCE;
                                                        }
                                                        else
                                                        {
                                                            isCrossSectionErr = true;
                                                        }
                                                    }

                                                    xTmpBorder = xBorder.Attribute("percentage");
                                                    if (xTmpBorder != null)
                                                    {
                                                        try
                                                        {
                                                            _dFrameCrossSecsHorRefValue = Convert.ToDouble(xTmpBorder.Value);
                                                        }
                                                        catch (Exception)
                                                        {
                                                            isCrossSectionErr = true;
                                                        }
                                                    }

                                                    xTmpBorder = xBorder.Attribute("offset");
                                                    if (xTmpBorder != null)
                                                    {
                                                        try
                                                        {
                                                            _nFrameCrossSecsHorOffsetValue = Convert.ToInt32(xTmpBorder.Value);
                                                        }
                                                        catch (Exception)
                                                        {
                                                            isCrossSectionErr = true;
                                                        }
                                                    }

                                                    xTmpBorder = xBorder.Attribute("left");
                                                    if (xTmpBorder != null)
                                                    {
                                                        try
                                                        {
                                                            _dFrameCrossSecsHorLeft = Convert.ToDouble(xTmpBorder.Value);
                                                        }
                                                        catch (Exception)
                                                        {
                                                            isCrossSectionErr = true;
                                                        }
                                                    }

                                                    xTmpBorder = xBorder.Attribute("right");
                                                    if (xTmpBorder != null)
                                                    {
                                                        try
                                                        {
                                                            _dFrameCrossSecsHorRight = Convert.ToDouble(xTmpBorder.Value);
                                                        }
                                                        catch (Exception)
                                                        {
                                                            isCrossSectionErr = true;
                                                        }
                                                    }
                                                }
                                                break;

                                            case "vertical":
                                                {
                                                    xTmpBorder = xBorder.Attribute("mode");
                                                    if (xTmpBorder != null)
                                                    {
                                                        string bordermode = xTmpBorder.Value;
                                                        if (bordermode.Equals("manual"))
                                                        {
                                                            _frameCrossSecsVerBorderMode = FrameSectionBorderMode.MANUAL;
                                                        }
                                                        else if (bordermode.Equals("reference"))
                                                        {
                                                            _frameCrossSecsVerBorderMode = FrameSectionBorderMode.REFERENCE;
                                                        }
                                                        else
                                                        {
                                                            isCrossSectionErr = true;
                                                        }
                                                    }

                                                    xTmpBorder = xBorder.Attribute("percentage");
                                                    if (xTmpBorder != null)
                                                    {
                                                        try
                                                        {
                                                            _dFrameCrossSecsVerRefValue = Convert.ToDouble(xTmpBorder.Value);
                                                        }
                                                        catch (Exception)
                                                        {
                                                            isCrossSectionErr = true;
                                                        }
                                                    }

                                                    xTmpBorder = xBorder.Attribute("offset");
                                                    if (xTmpBorder != null)
                                                    {
                                                        try
                                                        {
                                                            _nFrameCrossSecsVerOffsetValue = Convert.ToInt32(xTmpBorder.Value);
                                                        }
                                                        catch (Exception)
                                                        {
                                                            isCrossSectionErr = true;
                                                        }
                                                    }

                                                    xTmpBorder = xBorder.Attribute("left");
                                                    if (xTmpBorder != null)
                                                    {
                                                        try
                                                        {
                                                            _dFrameCrossSecsVerLeft = Convert.ToDouble(xTmpBorder.Value);
                                                        }
                                                        catch (Exception)
                                                        {
                                                            isCrossSectionErr = true;
                                                        }
                                                    }

                                                    xTmpBorder = xBorder.Attribute("right");
                                                    if (xTmpBorder != null)
                                                    {
                                                        try
                                                        {
                                                            _dFrameCrossSecsVerRight = Convert.ToDouble(xTmpBorder.Value);
                                                        }
                                                        catch (Exception)
                                                        {
                                                            isCrossSectionErr = true;
                                                        }
                                                    }
                                                }
                                                break;
                                        }

                                        if (!isCrossSectionErr)
                                        {
                                            CmdCheckSet("frame Sections Border");
                                        }
                                    }

                                    if (!isCrossSectionErr)
                                    {
                                        CmdCheckSet("frame CrossSections");
                                    }
                                }
                                #endregion

                                #region BeamSection
                                XElement xBeamSection = xTmp.Element("BeamSections");
                                if (xBeamSection != null)
                                {
                                    bool isBeamSectionErr = false;
                                    XAttribute xTmpBeamSection = xBeamSection.Attribute("active");
                                    if (xTmpBeamSection != null)
                                    {
                                        try
                                        {
                                            _bFrameBeamSection = Convert.ToBoolean(xTmpBeamSection.Value);
                                        }
                                        catch (Exception)
                                        {
                                            isBeamSectionErr = true;
                                        }
                                    }

                                    xTmpBeamSection = xBeamSection.Attribute("row");
                                    if (xTmpBeamSection != null)
                                    {
                                        try
                                        {
                                            _nFrameBeamSecRow = Convert.ToInt32(xTmpBeamSection.Value);
                                        }
                                        catch (Exception)
                                        {
                                            isBeamSectionErr = true;
                                        }
                                    }

                                    xTmpBeamSection = xBeamSection.Attribute("column");
                                    if (xTmpBeamSection != null)
                                    {
                                        try
                                        {
                                            _nFrameBeamSecCol = Convert.ToInt32(xTmpBeamSection.Value);
                                        }
                                        catch (Exception)
                                        {
                                            isBeamSectionErr = true;
                                        }
                                    }

                                    xTmpBeamSection = xBeamSection.Attribute("mode");
                                    if (xTmpBeamSection != null)
                                    {
                                        try
                                        {
                                            string mode = xTmpBeamSection.Value;
                                            if (mode != null)
                                            {
                                                if (mode == "manual")
                                                {
                                                    _bFrameBeamSecAuto = false;
                                                }
                                                else if (mode == "followBeam")
                                                {
                                                    _bFrameBeamSecAuto = true;
                                                }
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            isBeamSectionErr = true;
                                        }
                                    }

                                    xTmpBeamSection = xBeamSection.Attribute("angle");
                                    if (xTmpBeamSection != null)
                                    {
                                        try
                                        {
                                            _dFrameBeamSecAngle = Convert.ToDouble(xTmpBeamSection.Value);
                                        }
                                        catch (Exception)
                                        {
                                            isBeamSectionErr = true;
                                        }
                                    }

                                    XElement xBorder = xBeamSection.Element("borders");
                                    if (xBorder != null && xBorder.HasAttributes)
                                    {
                                        string borderType = string.Empty;

                                        XAttribute xTmpBorder = xBorder.Attribute("type");
                                        if (xTmpBorder != null)
                                        {
                                            try
                                            {
                                                borderType = xTmpBorder.Value;
                                            }
                                            catch (Exception)
                                            {
                                                isBeamSectionErr = true;
                                                throw;
                                            }
                                        }

                                        switch (borderType)
                                        {
                                            case "long":
                                                {
                                                    xTmpBorder = xBorder.Attribute("mode");
                                                    if (xTmpBorder != null)
                                                    {
                                                        string bordermode = xTmpBorder.Value;
                                                        if (bordermode.Equals("manual"))
                                                        {
                                                            _frameBeamSecsLongBorderMode = FrameSectionBorderMode.MANUAL;
                                                        }
                                                        else if (bordermode.Equals("reference"))
                                                        {
                                                            _frameBeamSecsLongBorderMode = FrameSectionBorderMode.REFERENCE;
                                                        }
                                                        else
                                                        {
                                                            isBeamSectionErr = true;
                                                        }
                                                    }

                                                    xTmpBorder = xBorder.Attribute("percentage");
                                                    if (xTmpBorder != null)
                                                    {
                                                        try
                                                        {
                                                            _dFrameBeamSecsLongRefValue = Convert.ToDouble(xTmpBorder.Value);
                                                        }
                                                        catch (Exception)
                                                        {
                                                            isBeamSectionErr = true;
                                                        }
                                                    }

                                                    xTmpBorder = xBorder.Attribute("offset");
                                                    if (xTmpBorder != null)
                                                    {
                                                        try
                                                        {
                                                            _nFrameBeamSecsLongOffsetValue = Convert.ToInt32(xTmpBorder.Value);
                                                        }
                                                        catch (Exception)
                                                        {
                                                            isBeamSectionErr = true;
                                                        }
                                                    }

                                                    xTmpBorder = xBorder.Attribute("left");
                                                    if (xTmpBorder != null)
                                                    {
                                                        try
                                                        {
                                                            _dFrameBeamSecsLongLeft = Convert.ToDouble(xTmpBorder.Value);
                                                        }
                                                        catch (Exception)
                                                        {
                                                            isBeamSectionErr = true;
                                                        }
                                                    }

                                                    xTmpBorder = xBorder.Attribute("right");
                                                    if (xTmpBorder != null)
                                                    {
                                                        try
                                                        {
                                                            _dFrameBeamSecsLongRight = Convert.ToDouble(xTmpBorder.Value);
                                                        }
                                                        catch (Exception)
                                                        {
                                                            isBeamSectionErr = true;
                                                        }
                                                    }
                                                }
                                                break;

                                            case "short":
                                                {
                                                    xTmpBorder = xBorder.Attribute("mode");
                                                    if (xTmpBorder != null)
                                                    {
                                                        string bordermode = xTmpBorder.Value;
                                                        if (bordermode.Equals("manual"))
                                                        {
                                                            _frameBeamSecsShortBorderMode = FrameSectionBorderMode.MANUAL;
                                                        }
                                                        else if (bordermode.Equals("reference"))
                                                        {
                                                            _frameBeamSecsShortBorderMode = FrameSectionBorderMode.REFERENCE;
                                                        }
                                                        else
                                                        {
                                                            isBeamSectionErr = true;
                                                        }
                                                    }

                                                    xTmpBorder = xBorder.Attribute("percentage");
                                                    if (xTmpBorder != null)
                                                    {
                                                        try
                                                        {
                                                            _dFrameBeamSecsShortRefValue = Convert.ToDouble(xTmpBorder.Value);
                                                        }
                                                        catch (Exception)
                                                        {
                                                            isBeamSectionErr = true;
                                                        }
                                                    }

                                                    xTmpBorder = xBorder.Attribute("offset");
                                                    if (xTmpBorder != null)
                                                    {
                                                        try
                                                        {
                                                            _nFrameBeamSecsShortOffsetValue = Convert.ToInt32(xTmpBorder.Value);
                                                        }
                                                        catch (Exception)
                                                        {
                                                            isBeamSectionErr = true;
                                                        }
                                                    }

                                                    xTmpBorder = xBorder.Attribute("left");
                                                    if (xTmpBorder != null)
                                                    {
                                                        try
                                                        {
                                                            _dFrameBeamSecsShortLeft = Convert.ToDouble(xTmpBorder.Value);
                                                        }
                                                        catch (Exception)
                                                        {
                                                            isBeamSectionErr = true;
                                                        }
                                                    }

                                                    xTmpBorder = xBorder.Attribute("right");
                                                    if (xTmpBorder != null)
                                                    {
                                                        try
                                                        {
                                                            _dFrameBeamSecsShortRight = Convert.ToDouble(xTmpBorder.Value);
                                                        }
                                                        catch (Exception)
                                                        {
                                                            isBeamSectionErr = true;
                                                        }
                                                    }
                                                }
                                                break;
                                        }

                                        if (!isBeamSectionErr)
                                        {
                                            CmdCheckSet("frame Sections Border");
                                        }
                                    }

                                    if (!isBeamSectionErr)
                                    {
                                        CmdCheckSet("frame BeamSections");
                                    }
                                }
                            }
                            #endregion
                        }
                        #endregion
                    }
                    catch (Exception E)
                    {
                        //LogFile.LogExceptionErr(E.ToString());
                        Console.WriteLine(E.ToString());
                    }
                }
            }
        }

        private void OnDisconnected(Socket handler)
        {
            SocketDisconnected();
        }
    }
}
