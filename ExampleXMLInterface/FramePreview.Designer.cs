﻿namespace ExampleXMLInterface
{
    partial class FramePreview
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBox_frame_act = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown_frame_scale = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_img_format = new System.Windows.Forms.ComboBox();
            this.pictureBox_frame_view = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_frame_scale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_frame_view)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.31579F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.89474F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.63158F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.84211F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.18421F));
            this.tableLayoutPanel1.Controls.Add(this.checkBox_frame_act, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown_frame_scale, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_img_format, 4, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(760, 29);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // checkBox_frame_act
            // 
            this.checkBox_frame_act.AutoSize = true;
            this.checkBox_frame_act.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox_frame_act.Location = new System.Drawing.Point(4, 3);
            this.checkBox_frame_act.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBox_frame_act.Name = "checkBox_frame_act";
            this.checkBox_frame_act.Size = new System.Drawing.Size(116, 23);
            this.checkBox_frame_act.TabIndex = 0;
            this.checkBox_frame_act.Text = "Activate preview";
            this.checkBox_frame_act.UseVisualStyleBackColor = true;
            this.checkBox_frame_act.CheckedChanged += new System.EventHandler(this.checkBox_frame_act_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(128, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Scale (%) : ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDown_frame_scale
            // 
            this.numericUpDown_frame_scale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown_frame_scale.Location = new System.Drawing.Point(340, 3);
            this.numericUpDown_frame_scale.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.numericUpDown_frame_scale.Name = "numericUpDown_frame_scale";
            this.numericUpDown_frame_scale.Size = new System.Drawing.Size(126, 21);
            this.numericUpDown_frame_scale.TabIndex = 2;
            this.numericUpDown_frame_scale.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDown_frame_scale.ValueChanged += new System.EventHandler(this.numericUpDown_frame_scale_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(474, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Image format : ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBox_img_format
            // 
            this.comboBox_img_format.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_img_format.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_img_format.FormattingEnabled = true;
            this.comboBox_img_format.Items.AddRange(new object[] {
            "BMP",
            "JPG",
            "PNG",
            "TIF"});
            this.comboBox_img_format.Location = new System.Drawing.Point(640, 3);
            this.comboBox_img_format.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBox_img_format.Name = "comboBox_img_format";
            this.comboBox_img_format.Size = new System.Drawing.Size(116, 20);
            this.comboBox_img_format.TabIndex = 4;
            this.comboBox_img_format.SelectedIndexChanged += new System.EventHandler(this.comboBox_img_format_SelectedIndexChanged);
            // 
            // pictureBox_frame_view
            // 
            this.pictureBox_frame_view.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_frame_view.Location = new System.Drawing.Point(12, 47);
            this.pictureBox_frame_view.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox_frame_view.Name = "pictureBox_frame_view";
            this.pictureBox_frame_view.Size = new System.Drawing.Size(760, 502);
            this.pictureBox_frame_view.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_frame_view.TabIndex = 1;
            this.pictureBox_frame_view.TabStop = false;
            // 
            // FramePreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.pictureBox_frame_view);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FramePreview";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FramePreview";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FramePreview_FormClosing);
            this.Load += new System.EventHandler(this.FramePreview_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_frame_scale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_frame_view)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox checkBox_frame_act;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown_frame_scale;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_img_format;
        private System.Windows.Forms.PictureBox pictureBox_frame_view;
    }
}