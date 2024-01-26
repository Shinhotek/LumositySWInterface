using LumosityXMLInterface;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ExampleXMLInterface
{
    public partial class FramePreview : Form
    {
        XMLInterface _xmlInterface;

        public FramePreview(XMLInterface xmlinterface)
        {
            _xmlInterface = xmlinterface;

            InitializeComponent();
        }

        public void SetBitmap(Bitmap bitmap)
        {
            if (bitmap != null)
            {
                pictureBox_frame_view.Image = bitmap;
            }
        }

        private void FramePreview_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void FramePreview_Load(object sender, EventArgs e)
        {
            comboBox_img_format.SelectedIndex = 0;

            pictureBox_frame_view.CancelAsync();
        }

        private void checkBox_frame_act_CheckedChanged(object sender, EventArgs e)
        {
            _xmlInterface.EvaluationGetFrameActive = checkBox_frame_act.Checked;
        }

        private void numericUpDown_frame_scale_ValueChanged(object sender, EventArgs e)
        {
            _xmlInterface.EvaluationGetFrameScale = Convert.ToInt32(numericUpDown_frame_scale.Value);
        }

        private void comboBox_img_format_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox_img_format.SelectedIndex)
            {
                case 0:
                    _xmlInterface.EvaluationGetFrameFormat = XMLInterface.GetFrameFormat.BMP;
                    break;

                case 1:
                    _xmlInterface.EvaluationGetFrameFormat = XMLInterface.GetFrameFormat.JPG;
                    break;

                case 2:
                    _xmlInterface.EvaluationGetFrameFormat = XMLInterface.GetFrameFormat.PNG;
                    break;
            }
        }
    }
}
