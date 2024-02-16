using LumosityXMLInterface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using static LumosityXMLInterface.XMLInterface;

namespace ExampleXMLInterface
{
    public partial class Form1 : Form
    {
        XMLInterface _xmlInterface = new XMLInterface();

        FramePreview _preview = null;
        public Form1()
        {
            InitializeComponent();
        }

        #region Frame 취득 후 Evaluation 결과 값 이벤트
        void OnFrameEvaluations(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new EventHandler(OnFrameEvaluations), new object[] { sender, e });
                return;
            }

            Dictionary<string, EvaluationDataSet> dicEvals = sender as Dictionary<string, EvaluationDataSet>;
            if (dicEvals != null)
            {
                if (!_bIsCheckAvailableItem)
                {
                    listView_use_items.BeginUpdate();

                    IEnumerator enumerator = listView_use_items.Items.GetEnumerator();
                    while (enumerator.MoveNext())
                    {

                        #region Evaluation item data 취득                        
                        ListViewItem item = enumerator.Current as ListViewItem;
                        if (item != null)
                        {
                            // -------------------- Evaluation 항목 별 data 취득 --------------------
                            EvaluationDataSet evds = dicEvals[item.Text];
                            string disp = evds.val + " " + evds.unit;
                            item.SubItems[1].Text = disp;
                            // ----------------------------------------------------------------------
                        }

                        #endregion

                    }

                    listView_use_items.EndUpdate();
                }
            }

            if (_preview != null)
            {
                _preview.SetBitmap(_xmlInterface.EvaluationGetFrameBitmap);
            }
        }
        #endregion

        void OnDisconnected(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler(OnDisconnected), new object[] { sender, e });
                return;
            }

            listView_available_items.Items.Clear();
            textBox_version.Text = "";
        }

        void OnErrorOccurred(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler(OnErrorOccurred), new object[] { sender, e });
            }

            MessageBox.Show(_xmlInterface.ErrorDetail);
        }

        private void button_connect_Click(object sender, EventArgs e)
        {
            textBox_conn_status.Text = "Connecting";

            if (!backgroundWorker_connect.IsBusy)
            {
                backgroundWorker_connect.RunWorkerAsync();
            }
        }

        private void button_disconnect_Click(object sender, EventArgs e)
        {
            _xmlInterface.Disconnect();
            listView_available_items.Items.Clear();
            listView_use_items.Items.Clear();
        }

        bool _isGetInfo = false;
        private void button_get_info_Click(object sender, EventArgs e)
        {
            _isGetInfo = true;
            
            // -------------------- Infomation --------------------
            if (_xmlInterface.CmdGetInfomation())
            // ----------------------------------------------------
            {
                textBox_version.Text = _xmlInterface.Version;

                string[] evaluations = _xmlInterface.AvailableEvaluations;

                if (evaluations != null && evaluations.Length > 0)
                {
                    listView_available_items.Items.Clear();

                    listView_available_items.BeginUpdate();
                    for (int i = 0; i < evaluations.Length; i++)
                    {
                        ListViewItem item = new ListViewItem(evaluations[i]);
                        item.SubItems.Add(_xmlInterface.GetEvaluationDescription(evaluations[i]));

                        listView_available_items.Items.Add(item);
                    }
                    listView_available_items.EndUpdate();
                }

                switch (_xmlInterface.GrabModeType)
                {
                    case GrabMode.Continuous:
                        radioButton_continuous.Checked = true;
                        radioButton_ext_trigger.Checked = radioButton_oneshot.Checked = false;
                        break;

                    case GrabMode.SnapShot:
                        radioButton_oneshot.Checked = true;
                        radioButton_continuous.Checked = radioButton_ext_trigger.Checked = false;
                        break;

                    case GrabMode.ExternalTriggered:
                        radioButton_ext_trigger.Checked = true;
                        radioButton_continuous.Checked = radioButton_oneshot.Checked = false;
                        break;
                }

                checkBox_avg_float.Checked = _xmlInterface.FloatingAverageEnable;
                numericUpDown_avg_float.Maximum = _xmlInterface.FloatingAverageValueMax;
                numericUpDown_avg_float.Value = _xmlInterface.FloatingAverageValue;

                checkBox_num_restriction.Checked = _xmlInterface.NumberRestrictionEnable;
                numericUpDown_num_restriction.Maximum = _xmlInterface.NumberRestrictionValueMax;
                numericUpDown_num_restriction.Value = _xmlInterface.NumberRestrictionValue;

                textBox_cam_id.Text = _xmlInterface.CamID;
                textBox_cam_pix_x.Text = _xmlInterface.CamPixelSizeWidth.ToString();
                textBox_cam_pix_y.Text = _xmlInterface.CamPixelSizeHeight.ToString();

                if (_xmlInterface.CamID != "None")
                {
                    numericUpDown_cam_roi_x.Maximum = _xmlInterface.CamWidthMax;
                    numericUpDown_cam_roi_y.Maximum = _xmlInterface.CamHeightMax;
                    numericUpDown_cam_roi_w.Maximum = _xmlInterface.CamWidthMax;                    
                    numericUpDown_cam_roi_h.Maximum = _xmlInterface.CamHeightMax;
                }                

                try
                {
                    numericUpDown_cam_roi_x.Value = _xmlInterface.CamOffsetX;
                    numericUpDown_cam_roi_y.Value = _xmlInterface.CamOffsetY;
                    numericUpDown_cam_roi_w.Value = _xmlInterface.CamWidth;
                    numericUpDown_cam_roi_h.Value = _xmlInterface.CamHeight;
                    numericUpDown_cam_roi_w.Increment = _xmlInterface.CamWidthStep;
                    numericUpDown_cam_roi_h.Increment = _xmlInterface.CamHeightStep;
                }
                catch (Exception E)
                {
                    MessageBox.Show(E.ToString());
                }

                numericUpDown_gain.Maximum = Convert.ToDecimal(_xmlInterface.CamGainMax);
                numericUpDown_gain.Minimum = Convert.ToDecimal(_xmlInterface.CamGainMin);
                numericUpDown_gain.Value = Convert.ToDecimal(_xmlInterface.CamGain);

                numericUpDown_exposure_time.Maximum = Convert.ToDecimal(_xmlInterface.CamExposureTimeMax);
                numericUpDown_exposure_time.Minimum = Convert.ToDecimal(_xmlInterface.CamExposureTimeMin);
                numericUpDown_exposure_time.Value = Convert.ToDecimal(_xmlInterface.CamExposureTime);

                numericUpDown_trigger_delay.Maximum = Convert.ToDecimal(_xmlInterface.CamTriggerDelayMax);
                numericUpDown_trigger_delay.Minimum = Convert.ToDecimal(_xmlInterface.CamTriggerDelayMin);
                numericUpDown_trigger_delay.Value = Convert.ToDecimal(_xmlInterface.CamTriggerDelay);

                switch (_xmlInterface.CamAutoControl)
                {
                    case ModeAutoControl.AutoOff:
                        comboBox_auto_control.SelectedIndex = 0;
                        break;

                    case ModeAutoControl.AutoExposure:
                        comboBox_auto_control.SelectedIndex= 1;
                        break;
                }

                checkBox_active_roi.Checked = _xmlInterface.FrameROIActive;
                numericUpDown_roi_left.Value = _xmlInterface.FrameROILeft;
                numericUpDown_roi_top.Value = _xmlInterface.FrameROITop;
                numericUpDown_roi_width.Value = _xmlInterface.FrameROIWidth;
                numericUpDown_roi_height.Value = _xmlInterface.FrameROIHeight;

                switch (_xmlInterface.FrameRoiMode)
                {
                    case FrameROIMode.MANUAL:
                        radioButton_roi_mod_manual.Checked = true;
                        radioButton_roi_mod_centroid.Checked = radioButton_roi_mod_autoresize.Checked = false;
                        break;

                    case FrameROIMode.CENTROID:
                        radioButton_roi_mod_centroid.Checked = true;
                        radioButton_roi_mod_manual.Checked = radioButton_roi_mod_autoresize.Checked = false;
                        break;

                    case FrameROIMode.AUTORESIZE:
                        radioButton_roi_mod_autoresize.Checked = true;
                        radioButton_roi_mod_manual.Checked = radioButton_roi_mod_centroid.Checked = false;
                        break;
                }

                switch (_xmlInterface.FrameRoiShape)
                {
                    case FrameROIShape.RECTANGLE:
                        radioButton_roi_shp_rectangle.Checked = true;
                        radioButton_roi_shp_circle.Checked = false;
                        break;

                    case FrameROIShape.CIRCLE:
                        radioButton_roi_shp_rectangle.Checked = false;
                        radioButton_roi_shp_circle.Checked = true;
                        break;
                }

                checkBox_secs_cross.Checked = _xmlInterface.FrameCrossSectionActive;
                numericUpDown_sect_cross_row.Value = _xmlInterface.FrameCrossSectionRow;
                numericUpDown_sect_cross_col.Value = _xmlInterface.FrameCrossSectionCol;
                radioButton_sect_cross_manual.Checked = !_xmlInterface.FrameCrossSectionAuto;
                radioButton_sect_cross_centroid.Checked = _xmlInterface.FrameCrossSectionAuto;                

                checkBox_secs_beam.Checked = _xmlInterface.FrameBeamSectionActive;
                numericUpDown_secs_beam_row.Value = _xmlInterface.FrameBeamSectionRow;
                numericUpDown_secs_beam_col.Value = _xmlInterface.FrameBeamSectionCol;
                numericUpDown_secs_beam_angle.Value = Convert.ToDecimal(_xmlInterface.FrameBeamSectionAngle);
                radioButton_secs_beam_manual.Checked = !_xmlInterface.FrameBeamSectionAuto;
                radioButton_secs_beam_centroid.Checked = _xmlInterface.FrameBeamSectionAuto;

                comboBox_background.SelectedIndex = Convert.ToInt32(_xmlInterface.BackgourndMode);
                checkBox_back_image.Checked = _xmlInterface.BackgroundImageEnable;
                numericUpDown_back_image_frames.Value = _xmlInterface.BackgroundAcquireFrames;

                checkBox_back_corner.Checked = _xmlInterface.BackgroundCornerEnable;
                numericUpDown_back_corner_span.Value = _xmlInterface.BackgroundCornerSpan;
                checkBox_back_corner_overlay.Checked = _xmlInterface.BackgroundCornerOverlay;

                checkBox_back_constant.Checked = _xmlInterface.BackgroundContantEnable;
                numericUpDown_back_constant_val.Value = Convert.ToDecimal(_xmlInterface.BackgroundConstantValue);
            }

            _isGetInfo = false;
        }

        private void timer_connect_status_Tick(object sender, EventArgs e)
        {
            if (_xmlInterface.IsConnected)
            {
                textBox_conn_status.Text = _xmlInterface.ConnectionStatus;
            }
            else
            {
                textBox_conn_status.Text = "Disconnected";
                timer_connect_status.Stop();
            }
        }

        bool _bIsCheckAvailableItem = false;
        private void listView_available_items_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            _bIsCheckAvailableItem = true;

            if (!_isGetInfo)
            {                
                if (e.Item.Checked)
                {
                    _xmlInterface.AddUseEvaluation(e.Item.Text);
                }
                else
                {
                    _xmlInterface.RemoveUseEvaluation(e.Item.Text);
                }

                listView_use_items.BeginUpdate();
                listView_use_items.Items.Clear();

                #region 사용할 Evaluation array
                // -------------------- 사용할 Evaluation array --------------------
                string[] evaluations = _xmlInterface.UseEvaluations;
                // -----------------------------------------------------------------
                #endregion

                for (int i = 0; i < evaluations.Length; i++)
                {
                    ListViewItem item = new ListViewItem(evaluations[i]);
                    item.SubItems.Add(" - ");
                    listView_use_items.Items.Add(item);
                }
                listView_use_items.EndUpdate();
            }

            _bIsCheckAvailableItem = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _xmlInterface.FrameEvaluations += OnFrameEvaluations;
            _xmlInterface.Disconnected += OnDisconnected;
            _xmlInterface.ErrorOccurred += OnErrorOccurred;

            comboBox_secs_border_mode.SelectedIndex = 0;

            tabControl_background.ItemSize = new System.Drawing.Size(0, 1);            
        }

        private void backgroundWorker_connect_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!_xmlInterface.IsConnected)
            {
                _xmlInterface.Connect("127.0.0.1", 4096);
                //_xmlInterface.Connect("192.168.0.141", 4096);
            }
        }

        private void backgroundWorker_connect_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            timer_connect_status.Enabled = _xmlInterface.IsConnected;
            if (!_xmlInterface.IsConnected)
            {
                textBox_conn_status.Text = "Disconnected";
            }            
        }

        private void checkBox_continuous_CheckedChanged(object sender, EventArgs e)
        {
            _xmlInterface.IsEvaluationContinuous = checkBox_continuous.Checked;
        }

        private void numericUpDown_interval_ValueChanged(object sender, EventArgs e)
        {
            _xmlInterface.EvaluationInterval = Convert.ToInt32(numericUpDown_interval.Value);
        }

        private void button_get_Click(object sender, EventArgs e)
        {
            // -------------------- 사용할 Evaluation Data 취득 --------------------
            EvaluationDataSet evds = _xmlInterface.GetEvaluationResult(textBox_key.Text);
            // --------------------------------------------------------------------

            if (!string.IsNullOrEmpty(evds.val))
            {
                textBox_value_unit.Text = evds.val;
                if (!string.IsNullOrEmpty(evds.unit))
                {
                    textBox_value_unit.Text += "(" + evds.unit + ")";
                }
            }
            else
            {
                textBox_value_unit.Text = "empty";
                MessageBox.Show("먼저 사용할 Evaluation을 추가 하십시오.");
            }
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            _xmlInterface.Start();
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            _xmlInterface.Stop();
        }

        private void button_background_Click(object sender, EventArgs e)
        {
            _xmlInterface.StartBackground();
        }

        private void radioButton_type_control_MouseCaptureChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null)
            {
                int tag = Convert.ToInt32(rb.Tag);
                _xmlInterface.GrabModeType = (GrabMode)tag;
            }
        }

        private void numericUpDown_cam_roi_x_ValueChanged(object sender, EventArgs e)
        {
            if (_isGetInfo) return;

            _xmlInterface.CamOffsetX = Convert.ToInt32(numericUpDown_cam_roi_x.Value);
            numericUpDown_cam_roi_x.Value = _xmlInterface.CamOffsetX;
        }

        private void numericUpDown_cam_roi_y_ValueChanged(object sender, EventArgs e)
        {
            if (_isGetInfo) return;

            _xmlInterface.CamOffsetY = Convert.ToInt32(numericUpDown_cam_roi_y.Value);
            numericUpDown_cam_roi_y.Value = _xmlInterface.CamOffsetY;
        }

        private void numericUpDown_cam_roi_w_ValueChanged(object sender, EventArgs e)
        {
            if (_isGetInfo) return;

            _xmlInterface.CamWidth = Convert.ToInt32(numericUpDown_cam_roi_w.Value);
            numericUpDown_cam_roi_w.Value = _xmlInterface.CamWidth;
        }

        private void numericUpDown_cam_roi_h_ValueChanged(object sender, EventArgs e)
        {
            if (_isGetInfo) return;

            _xmlInterface.CamHeight = Convert.ToInt32(numericUpDown_cam_roi_h.Value);
            numericUpDown_cam_roi_h.Value = _xmlInterface.CamHeight;
        }

        private void numericUpDown_gain_ValueChanged(object sender, EventArgs e)
        {
            if (_isGetInfo) return;

            _xmlInterface.CamGain = Convert.ToDouble(numericUpDown_gain.Value);
            numericUpDown_gain.Value = Convert.ToDecimal(_xmlInterface.CamGain);
        }

        private void numericUpDown_exposure_time_ValueChanged(object sender, EventArgs e)
        {
            if (_isGetInfo) return;

            _xmlInterface.CamExposureTime = Convert.ToDouble(numericUpDown_exposure_time.Value);
            numericUpDown_exposure_time.Value = Convert.ToDecimal(_xmlInterface.CamExposureTime);
        }

        private void numericUpDown_trigger_delay_ValueChanged(object sender, EventArgs e)
        {
            if (_isGetInfo) return;

            _xmlInterface.CamTriggerDelay = Convert.ToDouble(numericUpDown_trigger_delay.Value);
            numericUpDown_exposure_time.Value = Convert.ToDecimal(_xmlInterface.CamTriggerDelay);
        }

        private void numericUpDown_roi_left_ValueChanged(object sender, EventArgs e)
        {
            if (_isGetInfo) return;
            _xmlInterface.FrameROILeft = Convert.ToInt32(numericUpDown_roi_left.Value);
        }

        private void numericUpDown_roi_top_ValueChanged(object sender, EventArgs e)
        {
            if (_isGetInfo) return;
            _xmlInterface.FrameROITop = Convert.ToInt32(numericUpDown_roi_top.Value);
        }

        private void numericUpDown_roi_width_ValueChanged(object sender, EventArgs e)
        {
            if (_isGetInfo) return;
            _xmlInterface.FrameROIWidth = Convert.ToInt32(numericUpDown_roi_width.Value);
        }

        private void numericUpDown_roi_height_ValueChanged(object sender, EventArgs e)
        {
            if (_isGetInfo) return;
            _xmlInterface.FrameROIHeight = Convert.ToInt32(numericUpDown_roi_height.Value);
        }

        private void checkBox_active_roi_CheckedChanged(object sender, EventArgs e)
        {
            if (_isGetInfo) return;
            _xmlInterface.FrameROIActive = checkBox_active_roi.Checked;
        }

        private void radioButton_roi_mod_manual_MouseCaptureChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null)
            {
                int tag = Convert.ToInt32(rb.Tag);
                _xmlInterface.FrameRoiMode = (FrameROIMode)tag;
            }
        }

        private void radioButton_roi_shp_rectangle_MouseCaptureChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null)
            {
                int tag = Convert.ToInt32(rb.Tag);
                _xmlInterface.FrameRoiShape = (FrameROIShape)tag;
            }
        }

        private void checkBox_secs_cross_CheckedChanged(object sender, EventArgs e)
        {
            if (_isGetInfo) return;
            _xmlInterface.FrameCrossSectionActive = checkBox_secs_cross.Checked;
        }

        private void numericUpDown_sect_cross_row_ValueChanged(object sender, EventArgs e)
        {
            if (_isGetInfo) return;
            _xmlInterface.FrameCrossSectionRow = Convert.ToInt32(numericUpDown_sect_cross_row.Value);
        }

        private void numericUpDown_sect_cross_col_ValueChanged(object sender, EventArgs e)
        {
            if (_isGetInfo) return;
            _xmlInterface.FrameCrossSectionCol = Convert.ToInt32(numericUpDown_sect_cross_col.Value);
        }

        private void radioButton_sect_cross_manual_MouseCaptureChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null)
            {
                int tag = Convert.ToInt32(rb.Tag);
                _xmlInterface.FrameCrossSectionAuto = Convert.ToBoolean(tag);
            }
        }

        private void checkBox_secs_beam_CheckedChanged(object sender, EventArgs e)
        {
            if (_isGetInfo) return;
            _xmlInterface.FrameBeamSectionActive = checkBox_secs_beam.Checked;
        }

        private void numericUpDown_secs_beam_row_ValueChanged(object sender, EventArgs e)
        {
            if (_isGetInfo) return;
            _xmlInterface.FrameBeamSectionRow = Convert.ToInt32(numericUpDown_secs_beam_row.Value);
        }

        private void numericUpDown_secs_beam_col_ValueChanged(object sender, EventArgs e)
        {
            if (_isGetInfo) return;
            _xmlInterface.FrameBeamSectionCol = Convert.ToInt32(numericUpDown_secs_beam_col.Value);
        }

        private void numericUpDown_secs_beam_angle_ValueChanged(object sender, EventArgs e)
        {
            if (_isGetInfo) return;
            _xmlInterface.FrameBeamSectionAngle = Convert.ToDouble(numericUpDown_secs_beam_angle.Value);
        }

        private void radioButton_secs_beam_manual_MouseCaptureChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null)
            {
                int tag = Convert.ToInt32(rb.Tag);
                _xmlInterface.FrameBeamSectionAuto = Convert.ToBoolean(tag);
            }
        }

        private void button_secs_hor_attr_apply_Click(object sender, EventArgs e)
        {
            if (comboBox_secs_border_mode.SelectedIndex != -1)
            {
                if (comboBox_secs_border_mode.SelectedIndex == 0)
                {
                    _xmlInterface.FrameCrossSectionHorizontalBorderType = FrameSectionBorderMode.MANUAL;

                    _xmlInterface.FrameCrossSectionHorizontalLeft = Convert.ToDouble(numericUpDown_secs_border_left.Value);
                    numericUpDown_secs_border_left.Value = Convert.ToDecimal(_xmlInterface.FrameCrossSectionHorizontalLeft);

                    _xmlInterface.FrameCrossSectionHorizontalRight = Convert.ToDouble(numericUpDown_secs_border_right.Value);
                    numericUpDown_secs_border_right.Value = Convert.ToDecimal(_xmlInterface.FrameCrossSectionHorizontalRight);
                }
                else
                {
                    _xmlInterface.FrameCrossSectionHorizontalBorderType = FrameSectionBorderMode.REFERENCE;

                    _xmlInterface.FrameCrossSectionHorizontalReference = Convert.ToDouble(numericUpDown_secs_border_ref.Value);
                    numericUpDown_secs_border_ref.Value = Convert.ToDecimal(_xmlInterface.FrameCrossSectionHorizontalReference);

                    _xmlInterface.FrameCrossSectionHorizontalOffset = Convert.ToInt32(numericUpDown_secs_border_offset.Value);                    
                    numericUpDown_secs_border_offset.Value = Convert.ToDecimal(_xmlInterface.FrameCrossSectionHorizontalOffset);
                }
            }
        }

        private void button_secs_ver_attr_apply_Click(object sender, EventArgs e)
        {
            if (comboBox_secs_border_mode.SelectedIndex != -1)
            {
                if (comboBox_secs_border_mode.SelectedIndex == 0)
                {
                    _xmlInterface.FrameCrossSectionVerticalBorderType = FrameSectionBorderMode.MANUAL;

                    _xmlInterface.FrameCrossSectionVerticalLeft = Convert.ToDouble(numericUpDown_secs_border_left.Value);
                    numericUpDown_secs_border_left.Value = Convert.ToDecimal(_xmlInterface.FrameCrossSectionVerticalLeft);

                    _xmlInterface.FrameCrossSectionVerticalRight = Convert.ToDouble(numericUpDown_secs_border_right.Value);
                    numericUpDown_secs_border_right.Value = Convert.ToDecimal(_xmlInterface.FrameCrossSectionVerticalRight);
                }
                else
                {
                    _xmlInterface.FrameCrossSectionVerticalBorderType = FrameSectionBorderMode.REFERENCE;

                    _xmlInterface.FrameCrossSectionVerticalReference = Convert.ToDouble(numericUpDown_secs_border_ref.Value);
                    numericUpDown_secs_border_ref.Value = Convert.ToDecimal(_xmlInterface.FrameCrossSectionVerticalReference);

                    _xmlInterface.FrameCrossSectionVerticalOffset = Convert.ToInt32(numericUpDown_secs_border_offset.Value);
                    numericUpDown_secs_border_offset.Value = Convert.ToDecimal(_xmlInterface.FrameCrossSectionVerticalOffset);
                }
            }
        }

        private void button_secs_long_attr_apply_Click(object sender, EventArgs e)
        {
            if (comboBox_secs_border_mode.SelectedIndex != -1)
            {
                if (comboBox_secs_border_mode.SelectedIndex == 0)
                {
                    _xmlInterface.FrameBeamSectionLongBorderType = FrameSectionBorderMode.MANUAL;

                    _xmlInterface.FrameBeamSectionLongLeft = Convert.ToDouble(numericUpDown_secs_border_left.Value);
                    numericUpDown_secs_border_left.Value = Convert.ToDecimal(_xmlInterface.FrameBeamSectionLongLeft);

                    _xmlInterface.FrameBeamSectionLongRight = Convert.ToDouble(numericUpDown_secs_border_right.Value);
                    numericUpDown_secs_border_right.Value = Convert.ToDecimal(_xmlInterface.FrameBeamSectionLongRight);
                }
                else
                {
                    _xmlInterface.FrameBeamSectionLongBorderType = FrameSectionBorderMode.REFERENCE;

                    _xmlInterface.FrameBeamSectionLongReference = Convert.ToDouble(numericUpDown_secs_border_ref.Value);
                    numericUpDown_secs_border_ref.Value = Convert.ToDecimal(_xmlInterface.FrameBeamSectionLongReference);

                    _xmlInterface.FrameBeamSectionLongOffset = Convert.ToInt32(numericUpDown_secs_border_offset.Value);
                    numericUpDown_secs_border_offset.Value = Convert.ToDecimal(_xmlInterface.FrameBeamSectionLongOffset);
                }
            }
        }

        private void button_secs_short_attr_apply_Click(object sender, EventArgs e)
        {
            if (comboBox_secs_border_mode.SelectedIndex != -1)
            {
                if (comboBox_secs_border_mode.SelectedIndex == 0)
                {
                    _xmlInterface.FrameBeamSectionShortBorderType = FrameSectionBorderMode.MANUAL;

                    _xmlInterface.FrameBeamSectionShortLeft = Convert.ToDouble(numericUpDown_secs_border_left.Value);
                    numericUpDown_secs_border_left.Value = Convert.ToDecimal(_xmlInterface.FrameBeamSectionShortLeft);

                    _xmlInterface.FrameBeamSectionShortRight = Convert.ToDouble(numericUpDown_secs_border_right.Value);
                    numericUpDown_secs_border_right.Value = Convert.ToDecimal(_xmlInterface.FrameBeamSectionShortRight);
                }
                else
                {
                    _xmlInterface.FrameBeamSectionShortBorderType = FrameSectionBorderMode.REFERENCE;

                    _xmlInterface.FrameBeamSectionShortReference = Convert.ToDouble(numericUpDown_secs_border_ref.Value);
                    numericUpDown_secs_border_ref.Value = Convert.ToDecimal(_xmlInterface.FrameBeamSectionShortReference);

                    _xmlInterface.FrameBeamSectionShortOffset = Convert.ToInt32(numericUpDown_secs_border_offset.Value);
                    numericUpDown_secs_border_offset.Value = Convert.ToDecimal(_xmlInterface.FrameBeamSectionShortOffset);
                }
            }
        }

        private void comboBox_secs_border_mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selIndex = comboBox_secs_border_mode.SelectedIndex;
            if (selIndex != -1)
            {
                if (selIndex == 0)
                {
                    numericUpDown_secs_border_ref.Enabled = false;
                    numericUpDown_secs_border_offset.Enabled = false;
                    numericUpDown_secs_border_left.Enabled = true;
                    numericUpDown_secs_border_right.Enabled = true;                    
                }
                else if (selIndex == 1)
                {
                    numericUpDown_secs_border_ref.Enabled = true;
                    numericUpDown_secs_border_offset.Enabled = true;
                    numericUpDown_secs_border_left.Enabled = false;
                    numericUpDown_secs_border_right.Enabled = false;
                }
            }
        }

        private void comboBox_auto_control_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selIndex = comboBox_auto_control.SelectedIndex;
            if (selIndex != -1)
            {
                if (selIndex == 0)
                {
                    _xmlInterface.CamAutoControl = ModeAutoControl.AutoOff;
                }
                else if (selIndex == 1)
                {
                    _xmlInterface.CamAutoControl = ModeAutoControl.AutoExposure;
                }
            }
        }

        private void checkBox_avg_float_CheckedChanged(object sender, EventArgs e)
        {
            _xmlInterface.FloatingAverageEnable = checkBox_avg_float.Checked;
        }

        private void numericUpDown_avg_float_ValueChanged(object sender, EventArgs e)
        {
            _xmlInterface.FloatingAverageValue = Convert.ToInt32(numericUpDown_avg_float.Value);
        }

        private void checkBox_num_restriction_CheckedChanged(object sender, EventArgs e)
        {
            _xmlInterface.NumberRestrictionEnable = checkBox_num_restriction.Checked;
        }

        private void numericUpDown_num_restriction_ValueChanged(object sender, EventArgs e)
        {
            _xmlInterface.NumberRestrictionValue = Convert.ToInt32(numericUpDown_num_restriction.Value);
        }

        private void comboBox_background_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_background.SelectedIndex != -1)
            {
                tabControl_background.SelectedIndex = comboBox_background.SelectedIndex;
                _xmlInterface.BackgourndMode = (ModeBackgroundImageCorrection)comboBox_background.SelectedIndex;
            }
        }

        private void checkBox_back_image_CheckedChanged(object sender, EventArgs e)
        {
            _xmlInterface.BackgroundImageEnable = checkBox_back_image.Checked;
        }

        private void numericUpDown_back_image_frames_ValueChanged(object sender, EventArgs e)
        {
            _xmlInterface.BackgroundAcquireFrames = Convert.ToInt32(numericUpDown_back_image_frames.Value);
        }

        private void checkBox_back_corner_CheckedChanged(object sender, EventArgs e)
        {
            _xmlInterface.BackgroundCornerEnable = checkBox_back_corner.Checked;
        }

        private void numericUpDown_back_corner_span_ValueChanged(object sender, EventArgs e)
        {
            _xmlInterface.BackgroundCornerSpan = Convert.ToInt32(numericUpDown_back_corner_span.Value);
        }

        private void checkBox_back_corner_overlay_CheckedChanged(object sender, EventArgs e)
        {
            _xmlInterface.BackgroundCornerOverlay = checkBox_back_corner_overlay.Checked;
        }

        private void checkBox_back_constant_CheckedChanged(object sender, EventArgs e)
        {
            _xmlInterface.BackgroundContantEnable = checkBox_back_constant.Checked;
        }

        private void numericUpDown_back_constant_val_ValueChanged(object sender, EventArgs e)
        {
            _xmlInterface.BackgroundConstantValue = Convert.ToDouble(numericUpDown_back_constant_val.Value);
        }

        private void button_show_preview_Click(object sender, EventArgs e)
        {
            if (_preview == null)
            {
                _preview = new FramePreview(_xmlInterface);
            }

            _preview.Show();
            _preview.Focus();
        }

        private void listView_use_items_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip_listview_click_menu.Show(listView_use_items, e.Location);
            }
        }

        private void contextMenuStrip_listview_click_menu_Opening(object sender, CancelEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in listView_use_items.SelectedItems)
            {
                ListViewItem l = item as ListViewItem;
                if (l != null)
                {
                    bool isFirst = true;
                    foreach (ListViewItem.ListViewSubItem sub in l.SubItems)
                    {
                        if (!isFirst)
                        {
                            sb.Append(":");
                        }
                        sb.Append(sub.Text);

                        isFirst = false;
                    }
                }
                sb.AppendLine();
            }
            Clipboard.SetDataObject(sb.ToString().Trim());
        }
    }
}
