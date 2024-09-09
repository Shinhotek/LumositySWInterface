namespace ExampleXMLInterface
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button_connect = new System.Windows.Forms.Button();
            this.button_disconnect = new System.Windows.Forms.Button();
            this.button_get_info = new System.Windows.Forms.Button();
            this.listView_available_items = new System.Windows.Forms.ListView();
            this.columnHeader_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.timer_connect_status = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_conn_status = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_get = new System.Windows.Forms.Button();
            this.textBox_value_unit = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_key = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listView_use_items = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.backgroundWorker_connect = new System.ComponentModel.BackgroundWorker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_show_preview = new System.Windows.Forms.Button();
            this.numericUpDown_interval = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox_continuous = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button_stop = new System.Windows.Forms.Button();
            this.button_start = new System.Windows.Forms.Button();
            this.button_background = new System.Windows.Forms.Button();
            this.textBox_version = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_main = new System.Windows.Forms.TabPage();
            this.groupBox_img_process = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.label28 = new System.Windows.Forms.Label();
            this.checkBox_avg_float = new System.Windows.Forms.CheckBox();
            this.checkBox_num_restriction = new System.Windows.Forms.CheckBox();
            this.label_avg_float = new System.Windows.Forms.Label();
            this.numericUpDown_avg_float = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_num_restriction = new System.Windows.Forms.NumericUpDown();
            this.label30 = new System.Windows.Forms.Label();
            this.groupBox_main_ctrl = new System.Windows.Forms.GroupBox();
            this.button_test = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.radioButton_ext_trigger = new System.Windows.Forms.RadioButton();
            this.radioButton_oneshot = new System.Windows.Forms.RadioButton();
            this.radioButton_continuous = new System.Windows.Forms.RadioButton();
            this.tabPage_image_correction = new System.Windows.Forms.TabPage();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.comboBox_background = new System.Windows.Forms.ComboBox();
            this.tabControl_background = new System.Windows.Forms.TabControl();
            this.tabPage_back_image = new System.Windows.Forms.TabPage();
            this.checkBox_back_image = new System.Windows.Forms.CheckBox();
            this.label27 = new System.Windows.Forms.Label();
            this.numericUpDown_back_image_frames = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage_back_corner = new System.Windows.Forms.TabPage();
            this.checkBox_back_corner = new System.Windows.Forms.CheckBox();
            this.checkBox_back_corner_overlay = new System.Windows.Forms.CheckBox();
            this.numericUpDown_back_corner_span = new System.Windows.Forms.NumericUpDown();
            this.label29 = new System.Windows.Forms.Label();
            this.tabPage_back_constant = new System.Windows.Forms.TabPage();
            this.numericUpDown_back_constant_val = new System.Windows.Forms.NumericUpDown();
            this.label31 = new System.Windows.Forms.Label();
            this.checkBox_back_constant = new System.Windows.Forms.CheckBox();
            this.tabPage_cam = new System.Windows.Forms.TabPage();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.textBox_cam_pix_y = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.textBox_cam_pix_x = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.textBox_cam_id = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox_property = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label26 = new System.Windows.Forms.Label();
            this.numericUpDown_exposure_time = new System.Windows.Forms.NumericUpDown();
            this.label_exporsure_time = new System.Windows.Forms.Label();
            this.label_gain = new System.Windows.Forms.Label();
            this.numericUpDown_gain = new System.Windows.Forms.NumericUpDown();
            this.label_trigger_delay = new System.Windows.Forms.Label();
            this.numericUpDown_trigger_delay = new System.Windows.Forms.NumericUpDown();
            this.comboBox_auto_control = new System.Windows.Forms.ComboBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDown_cam_roi_h = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDown_cam_roi_w = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDown_cam_roi_y = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.numericUpDown_cam_roi_x = new System.Windows.Forms.NumericUpDown();
            this.tabPage_sections = new System.Windows.Forms.TabPage();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.numericUpDown_secs_border_right = new System.Windows.Forms.NumericUpDown();
            this.label25 = new System.Windows.Forms.Label();
            this.numericUpDown_secs_border_left = new System.Windows.Forms.NumericUpDown();
            this.label24 = new System.Windows.Forms.Label();
            this.button_secs_short_attr_apply = new System.Windows.Forms.Button();
            this.button_secs_long_attr_apply = new System.Windows.Forms.Button();
            this.numericUpDown_secs_border_offset = new System.Windows.Forms.NumericUpDown();
            this.label23 = new System.Windows.Forms.Label();
            this.numericUpDown_secs_border_ref = new System.Windows.Forms.NumericUpDown();
            this.label22 = new System.Windows.Forms.Label();
            this.button_secs_ver_attr_apply = new System.Windows.Forms.Button();
            this.button_secs_hor_attr_apply = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.comboBox_secs_border_mode = new System.Windows.Forms.ComboBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.radioButton_secs_beam_manual = new System.Windows.Forms.RadioButton();
            this.radioButton_secs_beam_centroid = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.label18 = new System.Windows.Forms.Label();
            this.numericUpDown_secs_beam_row = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.numericUpDown_secs_beam_col = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.numericUpDown_secs_beam_angle = new System.Windows.Forms.NumericUpDown();
            this.checkBox_secs_beam = new System.Windows.Forms.CheckBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.radioButton_sect_cross_manual = new System.Windows.Forms.RadioButton();
            this.radioButton_sect_cross_centroid = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.label16 = new System.Windows.Forms.Label();
            this.numericUpDown_sect_cross_row = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.numericUpDown_sect_cross_col = new System.Windows.Forms.NumericUpDown();
            this.checkBox_secs_cross = new System.Windows.Forms.CheckBox();
            this.tabPage_roi = new System.Windows.Forms.TabPage();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.radioButton_roi_shp_rectangle = new System.Windows.Forms.RadioButton();
            this.radioButton_roi_shp_circle = new System.Windows.Forms.RadioButton();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.radioButton_roi_mod_manual = new System.Windows.Forms.RadioButton();
            this.radioButton_roi_mod_centroid = new System.Windows.Forms.RadioButton();
            this.radioButton_roi_mod_autoresize = new System.Windows.Forms.RadioButton();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDown_roi_height = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.numericUpDown_roi_width = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.numericUpDown_roi_top = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.numericUpDown_roi_left = new System.Windows.Forms.NumericUpDown();
            this.checkBox_active_roi = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip_listview_click_menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox_ip_addr = new System.Windows.Forms.TextBox();
            this.numericUpDown_port = new System.Windows.Forms.NumericUpDown();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_interval)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage_main.SuspendLayout();
            this.groupBox_img_process.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_avg_float)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_num_restriction)).BeginInit();
            this.groupBox_main_ctrl.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabPage_image_correction.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.tabControl_background.SuspendLayout();
            this.tabPage_back_image.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_back_image_frames)).BeginInit();
            this.tabPage_back_corner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_back_corner_span)).BeginInit();
            this.tabPage_back_constant.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_back_constant_val)).BeginInit();
            this.tabPage_cam.SuspendLayout();
            this.groupBox_property.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_exposure_time)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_gain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_trigger_delay)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_cam_roi_h)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_cam_roi_w)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_cam_roi_y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_cam_roi_x)).BeginInit();
            this.tabPage_sections.SuspendLayout();
            this.groupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_secs_border_right)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_secs_border_left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_secs_border_offset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_secs_border_ref)).BeginInit();
            this.groupBox11.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_secs_beam_row)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_secs_beam_col)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_secs_beam_angle)).BeginInit();
            this.groupBox10.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_sect_cross_row)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_sect_cross_col)).BeginInit();
            this.tabPage_roi.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_roi_height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_roi_width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_roi_top)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_roi_left)).BeginInit();
            this.contextMenuStrip_listview_click_menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_port)).BeginInit();
            this.SuspendLayout();
            // 
            // button_connect
            // 
            this.button_connect.Location = new System.Drawing.Point(241, 12);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(75, 23);
            this.button_connect.TabIndex = 0;
            this.button_connect.Text = "Connect";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // button_disconnect
            // 
            this.button_disconnect.Location = new System.Drawing.Point(322, 12);
            this.button_disconnect.Name = "button_disconnect";
            this.button_disconnect.Size = new System.Drawing.Size(83, 23);
            this.button_disconnect.TabIndex = 1;
            this.button_disconnect.Text = "Disconnect";
            this.button_disconnect.UseVisualStyleBackColor = true;
            this.button_disconnect.Click += new System.EventHandler(this.button_disconnect_Click);
            // 
            // button_get_info
            // 
            this.button_get_info.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_get_info.Location = new System.Drawing.Point(587, 12);
            this.button_get_info.Name = "button_get_info";
            this.button_get_info.Size = new System.Drawing.Size(131, 23);
            this.button_get_info.TabIndex = 2;
            this.button_get_info.Text = "Get info (Refesh)";
            this.button_get_info.UseVisualStyleBackColor = true;
            this.button_get_info.Click += new System.EventHandler(this.button_get_info_Click);
            // 
            // listView_available_items
            // 
            this.listView_available_items.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView_available_items.CheckBoxes = true;
            this.listView_available_items.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_name,
            this.columnHeader_description});
            this.listView_available_items.FullRowSelect = true;
            this.listView_available_items.HideSelection = false;
            this.listView_available_items.Location = new System.Drawing.Point(6, 20);
            this.listView_available_items.Name = "listView_available_items";
            this.listView_available_items.Size = new System.Drawing.Size(520, 162);
            this.listView_available_items.TabIndex = 0;
            this.listView_available_items.UseCompatibleStateImageBehavior = false;
            this.listView_available_items.View = System.Windows.Forms.View.Details;
            this.listView_available_items.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listView_available_items_ItemChecked);
            // 
            // columnHeader_name
            // 
            this.columnHeader_name.Text = "Name";
            this.columnHeader_name.Width = 147;
            // 
            // columnHeader_description
            // 
            this.columnHeader_description.Text = "Description";
            this.columnHeader_description.Width = 350;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.listView_available_items);
            this.groupBox3.Location = new System.Drawing.Point(12, 131);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(532, 188);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Evaluation Available items";
            // 
            // timer_connect_status
            // 
            this.timer_connect_status.Tick += new System.EventHandler(this.timer_connect_status_Tick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(760, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "Status : ";
            // 
            // textBox_conn_status
            // 
            this.textBox_conn_status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_conn_status.Location = new System.Drawing.Point(819, 12);
            this.textBox_conn_status.Name = "textBox_conn_status";
            this.textBox_conn_status.ReadOnly = true;
            this.textBox_conn_status.Size = new System.Drawing.Size(177, 21);
            this.textBox_conn_status.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.button_get);
            this.groupBox1.Controls.Add(this.textBox_value_unit);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox_key);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.listView_use_items);
            this.groupBox1.Location = new System.Drawing.Point(12, 325);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(532, 274);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Evaluation Use items";
            // 
            // button_get
            // 
            this.button_get.Location = new System.Drawing.Point(487, 245);
            this.button_get.Name = "button_get";
            this.button_get.Size = new System.Drawing.Size(39, 23);
            this.button_get.TabIndex = 5;
            this.button_get.Text = "Get";
            this.button_get.UseVisualStyleBackColor = true;
            this.button_get.Click += new System.EventHandler(this.button_get_Click);
            // 
            // textBox_value_unit
            // 
            this.textBox_value_unit.Location = new System.Drawing.Point(310, 247);
            this.textBox_value_unit.Name = "textBox_value_unit";
            this.textBox_value_unit.ReadOnly = true;
            this.textBox_value_unit.Size = new System.Drawing.Size(171, 21);
            this.textBox_value_unit.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(225, 250);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "Value(unit) : ";
            // 
            // textBox_key
            // 
            this.textBox_key.Location = new System.Drawing.Point(100, 247);
            this.textBox_key.Name = "textBox_key";
            this.textBox_key.Size = new System.Drawing.Size(119, 21);
            this.textBox_key.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 250);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "Key Name : ";
            // 
            // listView_use_items
            // 
            this.listView_use_items.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView_use_items.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView_use_items.FullRowSelect = true;
            this.listView_use_items.HideSelection = false;
            this.listView_use_items.Location = new System.Drawing.Point(6, 20);
            this.listView_use_items.Name = "listView_use_items";
            this.listView_use_items.Size = new System.Drawing.Size(520, 219);
            this.listView_use_items.TabIndex = 0;
            this.listView_use_items.UseCompatibleStateImageBehavior = false;
            this.listView_use_items.View = System.Windows.Forms.View.Details;
            this.listView_use_items.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_use_items_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 147;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            this.columnHeader2.Width = 351;
            // 
            // backgroundWorker_connect
            // 
            this.backgroundWorker_connect.WorkerSupportsCancellation = true;
            this.backgroundWorker_connect.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_connect_DoWork);
            this.backgroundWorker_connect.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_connect_RunWorkerCompleted);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.button_show_preview);
            this.groupBox2.Controls.Add(this.numericUpDown_interval);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.checkBox_continuous);
            this.groupBox2.Location = new System.Drawing.Point(12, 72);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(532, 53);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Evaluation Option";
            // 
            // button_show_preview
            // 
            this.button_show_preview.Location = new System.Drawing.Point(398, 20);
            this.button_show_preview.Name = "button_show_preview";
            this.button_show_preview.Size = new System.Drawing.Size(128, 23);
            this.button_show_preview.TabIndex = 3;
            this.button_show_preview.Text = "Show preview";
            this.button_show_preview.UseVisualStyleBackColor = true;
            this.button_show_preview.Click += new System.EventHandler(this.button_show_preview_Click);
            // 
            // numericUpDown_interval
            // 
            this.numericUpDown_interval.Location = new System.Drawing.Point(185, 22);
            this.numericUpDown_interval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_interval.Name = "numericUpDown_interval";
            this.numericUpDown_interval.Size = new System.Drawing.Size(68, 21);
            this.numericUpDown_interval.TabIndex = 2;
            this.numericUpDown_interval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_interval.ValueChanged += new System.EventHandler(this.numericUpDown_interval_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(122, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Interval : ";
            // 
            // checkBox_continuous
            // 
            this.checkBox_continuous.AutoSize = true;
            this.checkBox_continuous.Location = new System.Drawing.Point(6, 20);
            this.checkBox_continuous.Name = "checkBox_continuous";
            this.checkBox_continuous.Size = new System.Drawing.Size(88, 16);
            this.checkBox_continuous.TabIndex = 0;
            this.checkBox_continuous.Text = "Continuous";
            this.checkBox_continuous.UseVisualStyleBackColor = true;
            this.checkBox_continuous.CheckedChanged += new System.EventHandler(this.checkBox_continuous_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.button_stop);
            this.groupBox4.Controls.Add(this.button_start);
            this.groupBox4.Location = new System.Drawing.Point(550, 72);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(446, 53);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Start / Stop";
            // 
            // button_stop
            // 
            this.button_stop.Location = new System.Drawing.Point(93, 20);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(75, 23);
            this.button_stop.TabIndex = 1;
            this.button_stop.Text = "Stop";
            this.button_stop.UseVisualStyleBackColor = true;
            this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(12, 20);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(75, 23);
            this.button_start.TabIndex = 0;
            this.button_start.Text = "Start";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // button_background
            // 
            this.button_background.Location = new System.Drawing.Point(295, 25);
            this.button_background.Name = "button_background";
            this.button_background.Size = new System.Drawing.Size(83, 23);
            this.button_background.TabIndex = 2;
            this.button_background.Text = "Acquire";
            this.button_background.UseVisualStyleBackColor = true;
            this.button_background.Click += new System.EventHandler(this.button_background_Click);
            // 
            // textBox_version
            // 
            this.textBox_version.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_version.Location = new System.Drawing.Point(819, 39);
            this.textBox_version.Name = "textBox_version";
            this.textBox_version.ReadOnly = true;
            this.textBox_version.Size = new System.Drawing.Size(177, 21);
            this.textBox_version.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(753, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "Version : ";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.tabControl1);
            this.groupBox5.Location = new System.Drawing.Point(550, 131);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(446, 468);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Remote System";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_main);
            this.tabControl1.Controls.Add(this.tabPage_image_correction);
            this.tabControl1.Controls.Add(this.tabPage_cam);
            this.tabControl1.Controls.Add(this.tabPage_sections);
            this.tabControl1.Controls.Add(this.tabPage_roi);
            this.tabControl1.Location = new System.Drawing.Point(6, 20);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(434, 442);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage_main
            // 
            this.tabPage_main.Controls.Add(this.groupBox_img_process);
            this.tabPage_main.Controls.Add(this.groupBox_main_ctrl);
            this.tabPage_main.Location = new System.Drawing.Point(4, 22);
            this.tabPage_main.Name = "tabPage_main";
            this.tabPage_main.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_main.Size = new System.Drawing.Size(426, 416);
            this.tabPage_main.TabIndex = 0;
            this.tabPage_main.Text = "Main";
            this.tabPage_main.UseVisualStyleBackColor = true;
            // 
            // groupBox_img_process
            // 
            this.groupBox_img_process.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_img_process.Controls.Add(this.tableLayoutPanel11);
            this.groupBox_img_process.Location = new System.Drawing.Point(7, 106);
            this.groupBox_img_process.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_img_process.Name = "groupBox_img_process";
            this.groupBox_img_process.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_img_process.Size = new System.Drawing.Size(412, 91);
            this.groupBox_img_process.TabIndex = 5;
            this.groupBox_img_process.TabStop = false;
            this.groupBox_img_process.Text = "Image process";
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel11.ColumnCount = 4;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.25397F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.80159F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.55159F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.39285F));
            this.tableLayoutPanel11.Controls.Add(this.label28, 3, 0);
            this.tableLayoutPanel11.Controls.Add(this.checkBox_avg_float, 0, 0);
            this.tableLayoutPanel11.Controls.Add(this.checkBox_num_restriction, 0, 1);
            this.tableLayoutPanel11.Controls.Add(this.label_avg_float, 1, 0);
            this.tableLayoutPanel11.Controls.Add(this.numericUpDown_avg_float, 2, 0);
            this.tableLayoutPanel11.Controls.Add(this.numericUpDown_num_restriction, 2, 1);
            this.tableLayoutPanel11.Controls.Add(this.label30, 3, 1);
            this.tableLayoutPanel11.Location = new System.Drawing.Point(9, 26);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 2;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(395, 58);
            this.tableLayoutPanel11.TabIndex = 0;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(343, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(48, 12);
            this.label28.TabIndex = 12;
            this.label28.Text = "Frames";
            // 
            // checkBox_avg_float
            // 
            this.checkBox_avg_float.AutoSize = true;
            this.checkBox_avg_float.Location = new System.Drawing.Point(3, 3);
            this.checkBox_avg_float.Name = "checkBox_avg_float";
            this.checkBox_avg_float.Size = new System.Drawing.Size(117, 16);
            this.checkBox_avg_float.TabIndex = 1;
            this.checkBox_avg_float.Text = "Floating average";
            this.checkBox_avg_float.UseVisualStyleBackColor = true;
            this.checkBox_avg_float.CheckedChanged += new System.EventHandler(this.checkBox_avg_float_CheckedChanged);
            // 
            // checkBox_num_restriction
            // 
            this.checkBox_num_restriction.AutoSize = true;
            this.checkBox_num_restriction.Location = new System.Drawing.Point(3, 32);
            this.checkBox_num_restriction.Name = "checkBox_num_restriction";
            this.checkBox_num_restriction.Size = new System.Drawing.Size(128, 16);
            this.checkBox_num_restriction.TabIndex = 3;
            this.checkBox_num_restriction.Text = "Number restriction";
            this.checkBox_num_restriction.UseVisualStyleBackColor = true;
            this.checkBox_num_restriction.CheckedChanged += new System.EventHandler(this.checkBox_num_restriction_CheckedChanged);
            // 
            // label_avg_float
            // 
            this.label_avg_float.AutoSize = true;
            this.label_avg_float.Location = new System.Drawing.Point(173, 0);
            this.label_avg_float.Name = "label_avg_float";
            this.label_avg_float.Size = new System.Drawing.Size(78, 12);
            this.label_avg_float.TabIndex = 5;
            this.label_avg_float.Text = "average over";
            // 
            // numericUpDown_avg_float
            // 
            this.numericUpDown_avg_float.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown_avg_float.Location = new System.Drawing.Point(270, 3);
            this.numericUpDown_avg_float.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDown_avg_float.Name = "numericUpDown_avg_float";
            this.numericUpDown_avg_float.Size = new System.Drawing.Size(67, 21);
            this.numericUpDown_avg_float.TabIndex = 8;
            this.numericUpDown_avg_float.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown_avg_float.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown_avg_float.ValueChanged += new System.EventHandler(this.numericUpDown_avg_float_ValueChanged);
            // 
            // numericUpDown_num_restriction
            // 
            this.numericUpDown_num_restriction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown_num_restriction.Location = new System.Drawing.Point(270, 32);
            this.numericUpDown_num_restriction.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDown_num_restriction.Name = "numericUpDown_num_restriction";
            this.numericUpDown_num_restriction.Size = new System.Drawing.Size(67, 21);
            this.numericUpDown_num_restriction.TabIndex = 10;
            this.numericUpDown_num_restriction.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown_num_restriction.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown_num_restriction.ValueChanged += new System.EventHandler(this.numericUpDown_num_restriction_ValueChanged);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(343, 29);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(48, 12);
            this.label30.TabIndex = 14;
            this.label30.Text = "Frames";
            // 
            // groupBox_main_ctrl
            // 
            this.groupBox_main_ctrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_main_ctrl.Controls.Add(this.button_test);
            this.groupBox_main_ctrl.Controls.Add(this.tableLayoutPanel2);
            this.groupBox_main_ctrl.Location = new System.Drawing.Point(7, 7);
            this.groupBox_main_ctrl.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_main_ctrl.Name = "groupBox_main_ctrl";
            this.groupBox_main_ctrl.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_main_ctrl.Size = new System.Drawing.Size(412, 90);
            this.groupBox_main_ctrl.TabIndex = 4;
            this.groupBox_main_ctrl.TabStop = false;
            this.groupBox_main_ctrl.Text = "Main control";
            // 
            // button_test
            // 
            this.button_test.Location = new System.Drawing.Point(496, -1);
            this.button_test.Name = "button_test";
            this.button_test.Size = new System.Drawing.Size(75, 23);
            this.button_test.TabIndex = 5;
            this.button_test.Text = "Test";
            this.button_test.UseVisualStyleBackColor = true;
            this.button_test.Visible = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.radioButton_ext_trigger, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.radioButton_oneshot, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.radioButton_continuous, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(9, 27);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(395, 55);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // radioButton_ext_trigger
            // 
            this.radioButton_ext_trigger.AutoSize = true;
            this.radioButton_ext_trigger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton_ext_trigger.Location = new System.Drawing.Point(4, 31);
            this.radioButton_ext_trigger.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton_ext_trigger.Name = "radioButton_ext_trigger";
            this.radioButton_ext_trigger.Size = new System.Drawing.Size(189, 20);
            this.radioButton_ext_trigger.TabIndex = 2;
            this.radioButton_ext_trigger.TabStop = true;
            this.radioButton_ext_trigger.Tag = "2";
            this.radioButton_ext_trigger.Text = "External triggered";
            this.radioButton_ext_trigger.UseVisualStyleBackColor = true;
            this.radioButton_ext_trigger.MouseCaptureChanged += new System.EventHandler(this.radioButton_type_control_MouseCaptureChanged);
            // 
            // radioButton_oneshot
            // 
            this.radioButton_oneshot.AutoSize = true;
            this.radioButton_oneshot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton_oneshot.Location = new System.Drawing.Point(201, 4);
            this.radioButton_oneshot.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton_oneshot.Name = "radioButton_oneshot";
            this.radioButton_oneshot.Size = new System.Drawing.Size(190, 19);
            this.radioButton_oneshot.TabIndex = 1;
            this.radioButton_oneshot.TabStop = true;
            this.radioButton_oneshot.Tag = "1";
            this.radioButton_oneshot.Text = "Snap shot";
            this.radioButton_oneshot.UseVisualStyleBackColor = true;
            this.radioButton_oneshot.MouseCaptureChanged += new System.EventHandler(this.radioButton_type_control_MouseCaptureChanged);
            // 
            // radioButton_continuous
            // 
            this.radioButton_continuous.AutoSize = true;
            this.radioButton_continuous.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton_continuous.Location = new System.Drawing.Point(4, 4);
            this.radioButton_continuous.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton_continuous.Name = "radioButton_continuous";
            this.radioButton_continuous.Size = new System.Drawing.Size(189, 19);
            this.radioButton_continuous.TabIndex = 0;
            this.radioButton_continuous.TabStop = true;
            this.radioButton_continuous.Tag = "0";
            this.radioButton_continuous.Text = "Continuous";
            this.radioButton_continuous.UseVisualStyleBackColor = true;
            this.radioButton_continuous.MouseCaptureChanged += new System.EventHandler(this.radioButton_type_control_MouseCaptureChanged);
            // 
            // tabPage_image_correction
            // 
            this.tabPage_image_correction.Controls.Add(this.groupBox13);
            this.tabPage_image_correction.Location = new System.Drawing.Point(4, 22);
            this.tabPage_image_correction.Name = "tabPage_image_correction";
            this.tabPage_image_correction.Size = new System.Drawing.Size(426, 416);
            this.tabPage_image_correction.TabIndex = 4;
            this.tabPage_image_correction.Text = "Image correction";
            this.tabPage_image_correction.UseVisualStyleBackColor = true;
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.comboBox_background);
            this.groupBox13.Controls.Add(this.tabControl_background);
            this.groupBox13.Location = new System.Drawing.Point(3, 3);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(420, 143);
            this.groupBox13.TabIndex = 0;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "background";
            // 
            // comboBox_background
            // 
            this.comboBox_background.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_background.FormattingEnabled = true;
            this.comboBox_background.Items.AddRange(new object[] {
            "image",
            "corner",
            "constant"});
            this.comboBox_background.Location = new System.Drawing.Point(6, 20);
            this.comboBox_background.Name = "comboBox_background";
            this.comboBox_background.Size = new System.Drawing.Size(121, 20);
            this.comboBox_background.TabIndex = 0;
            this.comboBox_background.SelectedIndexChanged += new System.EventHandler(this.comboBox_background_SelectedIndexChanged);
            // 
            // tabControl_background
            // 
            this.tabControl_background.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl_background.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl_background.Controls.Add(this.tabPage_back_image);
            this.tabControl_background.Controls.Add(this.tabPage_back_corner);
            this.tabControl_background.Controls.Add(this.tabPage_back_constant);
            this.tabControl_background.ItemSize = new System.Drawing.Size(30, 10);
            this.tabControl_background.Location = new System.Drawing.Point(6, 46);
            this.tabControl_background.Name = "tabControl_background";
            this.tabControl_background.SelectedIndex = 0;
            this.tabControl_background.Size = new System.Drawing.Size(408, 91);
            this.tabControl_background.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl_background.TabIndex = 1;
            // 
            // tabPage_back_image
            // 
            this.tabPage_back_image.BackColor = System.Drawing.Color.White;
            this.tabPage_back_image.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabPage_back_image.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage_back_image.Controls.Add(this.checkBox_back_image);
            this.tabPage_back_image.Controls.Add(this.button_background);
            this.tabPage_back_image.Controls.Add(this.label27);
            this.tabPage_back_image.Controls.Add(this.numericUpDown_back_image_frames);
            this.tabPage_back_image.Controls.Add(this.label6);
            this.tabPage_back_image.Location = new System.Drawing.Point(4, 14);
            this.tabPage_back_image.Name = "tabPage_back_image";
            this.tabPage_back_image.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_back_image.Size = new System.Drawing.Size(400, 73);
            this.tabPage_back_image.TabIndex = 0;
            // 
            // checkBox_back_image
            // 
            this.checkBox_back_image.AutoSize = true;
            this.checkBox_back_image.Location = new System.Drawing.Point(6, 2);
            this.checkBox_back_image.Name = "checkBox_back_image";
            this.checkBox_back_image.Size = new System.Drawing.Size(62, 16);
            this.checkBox_back_image.TabIndex = 3;
            this.checkBox_back_image.Text = "enable";
            this.checkBox_back_image.UseVisualStyleBackColor = true;
            this.checkBox_back_image.CheckedChanged += new System.EventHandler(this.checkBox_back_image_CheckedChanged);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(245, 30);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(44, 12);
            this.label27.TabIndex = 2;
            this.label27.Text = "frames";
            // 
            // numericUpDown_back_image_frames
            // 
            this.numericUpDown_back_image_frames.Location = new System.Drawing.Point(151, 28);
            this.numericUpDown_back_image_frames.Name = "numericUpDown_back_image_frames";
            this.numericUpDown_back_image_frames.Size = new System.Drawing.Size(88, 21);
            this.numericUpDown_back_image_frames.TabIndex = 1;
            this.numericUpDown_back_image_frames.ValueChanged += new System.EventHandler(this.numericUpDown_back_image_frames_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "Backgournd average";
            // 
            // tabPage_back_corner
            // 
            this.tabPage_back_corner.BackColor = System.Drawing.Color.White;
            this.tabPage_back_corner.Controls.Add(this.checkBox_back_corner);
            this.tabPage_back_corner.Controls.Add(this.checkBox_back_corner_overlay);
            this.tabPage_back_corner.Controls.Add(this.numericUpDown_back_corner_span);
            this.tabPage_back_corner.Controls.Add(this.label29);
            this.tabPage_back_corner.Location = new System.Drawing.Point(4, 14);
            this.tabPage_back_corner.Name = "tabPage_back_corner";
            this.tabPage_back_corner.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_back_corner.Size = new System.Drawing.Size(400, 73);
            this.tabPage_back_corner.TabIndex = 1;
            // 
            // checkBox_back_corner
            // 
            this.checkBox_back_corner.AutoSize = true;
            this.checkBox_back_corner.Location = new System.Drawing.Point(6, 2);
            this.checkBox_back_corner.Name = "checkBox_back_corner";
            this.checkBox_back_corner.Size = new System.Drawing.Size(62, 16);
            this.checkBox_back_corner.TabIndex = 4;
            this.checkBox_back_corner.Text = "enable";
            this.checkBox_back_corner.UseVisualStyleBackColor = true;
            this.checkBox_back_corner.CheckedChanged += new System.EventHandler(this.checkBox_back_corner_CheckedChanged);
            // 
            // checkBox_back_corner_overlay
            // 
            this.checkBox_back_corner_overlay.AutoSize = true;
            this.checkBox_back_corner_overlay.Location = new System.Drawing.Point(266, 37);
            this.checkBox_back_corner_overlay.Name = "checkBox_back_corner_overlay";
            this.checkBox_back_corner_overlay.Size = new System.Drawing.Size(101, 16);
            this.checkBox_back_corner_overlay.TabIndex = 2;
            this.checkBox_back_corner_overlay.Text = "Show overaly";
            this.checkBox_back_corner_overlay.UseVisualStyleBackColor = true;
            this.checkBox_back_corner_overlay.CheckedChanged += new System.EventHandler(this.checkBox_back_corner_overlay_CheckedChanged);
            // 
            // numericUpDown_back_corner_span
            // 
            this.numericUpDown_back_corner_span.Location = new System.Drawing.Point(70, 30);
            this.numericUpDown_back_corner_span.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDown_back_corner_span.Name = "numericUpDown_back_corner_span";
            this.numericUpDown_back_corner_span.Size = new System.Drawing.Size(85, 21);
            this.numericUpDown_back_corner_span.TabIndex = 1;
            this.numericUpDown_back_corner_span.ValueChanged += new System.EventHandler(this.numericUpDown_back_corner_span_ValueChanged);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(30, 32);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(34, 12);
            this.label29.TabIndex = 0;
            this.label29.Text = "Span";
            // 
            // tabPage_back_constant
            // 
            this.tabPage_back_constant.BackColor = System.Drawing.Color.White;
            this.tabPage_back_constant.Controls.Add(this.numericUpDown_back_constant_val);
            this.tabPage_back_constant.Controls.Add(this.label31);
            this.tabPage_back_constant.Controls.Add(this.checkBox_back_constant);
            this.tabPage_back_constant.Location = new System.Drawing.Point(4, 14);
            this.tabPage_back_constant.Name = "tabPage_back_constant";
            this.tabPage_back_constant.Size = new System.Drawing.Size(400, 73);
            this.tabPage_back_constant.TabIndex = 2;
            // 
            // numericUpDown_back_constant_val
            // 
            this.numericUpDown_back_constant_val.DecimalPlaces = 1;
            this.numericUpDown_back_constant_val.Location = new System.Drawing.Point(84, 32);
            this.numericUpDown_back_constant_val.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDown_back_constant_val.Name = "numericUpDown_back_constant_val";
            this.numericUpDown_back_constant_val.Size = new System.Drawing.Size(88, 21);
            this.numericUpDown_back_constant_val.TabIndex = 7;
            this.numericUpDown_back_constant_val.ValueChanged += new System.EventHandler(this.numericUpDown_back_constant_val_ValueChanged);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(41, 34);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(37, 12);
            this.label31.TabIndex = 6;
            this.label31.Text = "Value";
            // 
            // checkBox_back_constant
            // 
            this.checkBox_back_constant.AutoSize = true;
            this.checkBox_back_constant.Location = new System.Drawing.Point(3, 3);
            this.checkBox_back_constant.Name = "checkBox_back_constant";
            this.checkBox_back_constant.Size = new System.Drawing.Size(62, 16);
            this.checkBox_back_constant.TabIndex = 5;
            this.checkBox_back_constant.Text = "enable";
            this.checkBox_back_constant.UseVisualStyleBackColor = true;
            this.checkBox_back_constant.CheckedChanged += new System.EventHandler(this.checkBox_back_constant_CheckedChanged);
            // 
            // tabPage_cam
            // 
            this.tabPage_cam.Controls.Add(this.label35);
            this.tabPage_cam.Controls.Add(this.label36);
            this.tabPage_cam.Controls.Add(this.textBox_cam_pix_y);
            this.tabPage_cam.Controls.Add(this.label34);
            this.tabPage_cam.Controls.Add(this.label33);
            this.tabPage_cam.Controls.Add(this.textBox_cam_pix_x);
            this.tabPage_cam.Controls.Add(this.label32);
            this.tabPage_cam.Controls.Add(this.textBox_cam_id);
            this.tabPage_cam.Controls.Add(this.label11);
            this.tabPage_cam.Controls.Add(this.groupBox_property);
            this.tabPage_cam.Controls.Add(this.groupBox6);
            this.tabPage_cam.Location = new System.Drawing.Point(4, 22);
            this.tabPage_cam.Name = "tabPage_cam";
            this.tabPage_cam.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_cam.Size = new System.Drawing.Size(426, 416);
            this.tabPage_cam.TabIndex = 1;
            this.tabPage_cam.Text = "Cam";
            this.tabPage_cam.UseVisualStyleBackColor = true;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(354, 45);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(23, 12);
            this.label35.TabIndex = 14;
            this.label35.Text = "um";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(242, 39);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(23, 12);
            this.label36.TabIndex = 13;
            this.label36.Text = "(Y)";
            // 
            // textBox_cam_pix_y
            // 
            this.textBox_cam_pix_y.Location = new System.Drawing.Point(271, 36);
            this.textBox_cam_pix_y.Name = "textBox_cam_pix_y";
            this.textBox_cam_pix_y.ReadOnly = true;
            this.textBox_cam_pix_y.Size = new System.Drawing.Size(77, 21);
            this.textBox_cam_pix_y.TabIndex = 12;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(207, 45);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(23, 12);
            this.label34.TabIndex = 11;
            this.label34.Text = "um";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(95, 39);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(23, 12);
            this.label33.TabIndex = 10;
            this.label33.Text = "(X)";
            // 
            // textBox_cam_pix_x
            // 
            this.textBox_cam_pix_x.Location = new System.Drawing.Point(124, 36);
            this.textBox_cam_pix_x.Name = "textBox_cam_pix_x";
            this.textBox_cam_pix_x.ReadOnly = true;
            this.textBox_cam_pix_x.Size = new System.Drawing.Size(77, 21);
            this.textBox_cam_pix_x.TabIndex = 9;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(16, 39);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(73, 12);
            this.label32.TabIndex = 8;
            this.label32.Text = "Pixel size : ";
            // 
            // textBox_cam_id
            // 
            this.textBox_cam_id.Location = new System.Drawing.Point(95, 9);
            this.textBox_cam_id.Name = "textBox_cam_id";
            this.textBox_cam_id.ReadOnly = true;
            this.textBox_cam_id.Size = new System.Drawing.Size(151, 21);
            this.textBox_cam_id.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(61, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 12);
            this.label11.TabIndex = 5;
            this.label11.Text = "ID : ";
            // 
            // groupBox_property
            // 
            this.groupBox_property.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_property.Controls.Add(this.tableLayoutPanel3);
            this.groupBox_property.Location = new System.Drawing.Point(4, 158);
            this.groupBox_property.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_property.Name = "groupBox_property";
            this.groupBox_property.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_property.Size = new System.Drawing.Size(412, 148);
            this.groupBox_property.TabIndex = 4;
            this.groupBox_property.TabStop = false;
            this.groupBox_property.Text = "Camera property";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.23174F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.76826F));
            this.tableLayoutPanel3.Controls.Add(this.label26, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.numericUpDown_exposure_time, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label_exporsure_time, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label_gain, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.numericUpDown_gain, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label_trigger_delay, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.numericUpDown_trigger_delay, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.comboBox_auto_control, 1, 3);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(8, 25);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.06265F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.06265F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.06265F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.81203F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(397, 115);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label26.Location = new System.Drawing.Point(4, 84);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(247, 31);
            this.label26.TabIndex = 14;
            this.label26.Text = "Auto control : ";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDown_exposure_time
            // 
            this.numericUpDown_exposure_time.DecimalPlaces = 1;
            this.numericUpDown_exposure_time.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown_exposure_time.Location = new System.Drawing.Point(259, 32);
            this.numericUpDown_exposure_time.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDown_exposure_time.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericUpDown_exposure_time.Name = "numericUpDown_exposure_time";
            this.numericUpDown_exposure_time.Size = new System.Drawing.Size(134, 21);
            this.numericUpDown_exposure_time.TabIndex = 6;
            this.numericUpDown_exposure_time.ValueChanged += new System.EventHandler(this.numericUpDown_exposure_time_ValueChanged);
            // 
            // label_exporsure_time
            // 
            this.label_exporsure_time.AutoSize = true;
            this.label_exporsure_time.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_exporsure_time.Location = new System.Drawing.Point(4, 28);
            this.label_exporsure_time.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_exporsure_time.Name = "label_exporsure_time";
            this.label_exporsure_time.Size = new System.Drawing.Size(247, 28);
            this.label_exporsure_time.TabIndex = 2;
            this.label_exporsure_time.Text = "Exposure time :";
            this.label_exporsure_time.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_gain
            // 
            this.label_gain.AutoSize = true;
            this.label_gain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_gain.Location = new System.Drawing.Point(4, 0);
            this.label_gain.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_gain.Name = "label_gain";
            this.label_gain.Size = new System.Drawing.Size(247, 28);
            this.label_gain.TabIndex = 1;
            this.label_gain.Text = "Gain : ";
            this.label_gain.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDown_gain
            // 
            this.numericUpDown_gain.DecimalPlaces = 1;
            this.numericUpDown_gain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown_gain.Location = new System.Drawing.Point(259, 4);
            this.numericUpDown_gain.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDown_gain.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericUpDown_gain.Name = "numericUpDown_gain";
            this.numericUpDown_gain.Size = new System.Drawing.Size(134, 21);
            this.numericUpDown_gain.TabIndex = 5;
            this.numericUpDown_gain.ValueChanged += new System.EventHandler(this.numericUpDown_gain_ValueChanged);
            // 
            // label_trigger_delay
            // 
            this.label_trigger_delay.AutoSize = true;
            this.label_trigger_delay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_trigger_delay.Location = new System.Drawing.Point(4, 56);
            this.label_trigger_delay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_trigger_delay.Name = "label_trigger_delay";
            this.label_trigger_delay.Size = new System.Drawing.Size(247, 28);
            this.label_trigger_delay.TabIndex = 11;
            this.label_trigger_delay.Text = "Trigger delay : ";
            this.label_trigger_delay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDown_trigger_delay
            // 
            this.numericUpDown_trigger_delay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown_trigger_delay.Location = new System.Drawing.Point(259, 60);
            this.numericUpDown_trigger_delay.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDown_trigger_delay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericUpDown_trigger_delay.Name = "numericUpDown_trigger_delay";
            this.numericUpDown_trigger_delay.Size = new System.Drawing.Size(134, 21);
            this.numericUpDown_trigger_delay.TabIndex = 13;
            this.numericUpDown_trigger_delay.ValueChanged += new System.EventHandler(this.numericUpDown_trigger_delay_ValueChanged);
            // 
            // comboBox_auto_control
            // 
            this.comboBox_auto_control.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_auto_control.FormattingEnabled = true;
            this.comboBox_auto_control.Items.AddRange(new object[] {
            "AutoOff",
            "AutoExposure"});
            this.comboBox_auto_control.Location = new System.Drawing.Point(258, 87);
            this.comboBox_auto_control.Name = "comboBox_auto_control";
            this.comboBox_auto_control.Size = new System.Drawing.Size(135, 20);
            this.comboBox_auto_control.TabIndex = 15;
            this.comboBox_auto_control.SelectedIndexChanged += new System.EventHandler(this.comboBox_auto_control_SelectedIndexChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.tableLayoutPanel1);
            this.groupBox6.Location = new System.Drawing.Point(4, 70);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox6.Size = new System.Drawing.Size(415, 80);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Camera-ROI";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown_cam_roi_h, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label7, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown_cam_roi_w, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown_cam_roi_y, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label9, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown_cam_roi_x, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 18);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(407, 58);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // numericUpDown_cam_roi_h
            // 
            this.numericUpDown_cam_roi_h.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown_cam_roi_h.Location = new System.Drawing.Point(307, 33);
            this.numericUpDown_cam_roi_h.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDown_cam_roi_h.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown_cam_roi_h.Name = "numericUpDown_cam_roi_h";
            this.numericUpDown_cam_roi_h.Size = new System.Drawing.Size(96, 21);
            this.numericUpDown_cam_roi_h.TabIndex = 8;
            this.numericUpDown_cam_roi_h.ValueChanged += new System.EventHandler(this.numericUpDown_cam_roi_h_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(206, 29);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 29);
            this.label7.TabIndex = 7;
            this.label7.Text = "Height : ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericUpDown_cam_roi_w
            // 
            this.numericUpDown_cam_roi_w.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown_cam_roi_w.Location = new System.Drawing.Point(105, 33);
            this.numericUpDown_cam_roi_w.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDown_cam_roi_w.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown_cam_roi_w.Name = "numericUpDown_cam_roi_w";
            this.numericUpDown_cam_roi_w.Size = new System.Drawing.Size(93, 21);
            this.numericUpDown_cam_roi_w.TabIndex = 6;
            this.numericUpDown_cam_roi_w.ValueChanged += new System.EventHandler(this.numericUpDown_cam_roi_w_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(4, 29);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 29);
            this.label8.TabIndex = 5;
            this.label8.Text = "Width : ";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericUpDown_cam_roi_y
            // 
            this.numericUpDown_cam_roi_y.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown_cam_roi_y.Location = new System.Drawing.Point(307, 4);
            this.numericUpDown_cam_roi_y.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDown_cam_roi_y.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown_cam_roi_y.Name = "numericUpDown_cam_roi_y";
            this.numericUpDown_cam_roi_y.Size = new System.Drawing.Size(96, 21);
            this.numericUpDown_cam_roi_y.TabIndex = 4;
            this.numericUpDown_cam_roi_y.ValueChanged += new System.EventHandler(this.numericUpDown_cam_roi_y_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(206, 0);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 29);
            this.label9.TabIndex = 3;
            this.label9.Text = "Offset Y : ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(4, 0);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 29);
            this.label10.TabIndex = 0;
            this.label10.Text = "Offset X : ";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericUpDown_cam_roi_x
            // 
            this.numericUpDown_cam_roi_x.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown_cam_roi_x.Location = new System.Drawing.Point(105, 4);
            this.numericUpDown_cam_roi_x.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDown_cam_roi_x.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown_cam_roi_x.Name = "numericUpDown_cam_roi_x";
            this.numericUpDown_cam_roi_x.Size = new System.Drawing.Size(93, 21);
            this.numericUpDown_cam_roi_x.TabIndex = 1;
            this.numericUpDown_cam_roi_x.ValueChanged += new System.EventHandler(this.numericUpDown_cam_roi_x_ValueChanged);
            // 
            // tabPage_sections
            // 
            this.tabPage_sections.Controls.Add(this.groupBox12);
            this.tabPage_sections.Controls.Add(this.groupBox11);
            this.tabPage_sections.Controls.Add(this.checkBox_secs_beam);
            this.tabPage_sections.Controls.Add(this.groupBox10);
            this.tabPage_sections.Controls.Add(this.checkBox_secs_cross);
            this.tabPage_sections.Location = new System.Drawing.Point(4, 22);
            this.tabPage_sections.Name = "tabPage_sections";
            this.tabPage_sections.Size = new System.Drawing.Size(426, 416);
            this.tabPage_sections.TabIndex = 2;
            this.tabPage_sections.Text = "Sections";
            this.tabPage_sections.UseVisualStyleBackColor = true;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.numericUpDown_secs_border_right);
            this.groupBox12.Controls.Add(this.label25);
            this.groupBox12.Controls.Add(this.numericUpDown_secs_border_left);
            this.groupBox12.Controls.Add(this.label24);
            this.groupBox12.Controls.Add(this.button_secs_short_attr_apply);
            this.groupBox12.Controls.Add(this.button_secs_long_attr_apply);
            this.groupBox12.Controls.Add(this.numericUpDown_secs_border_offset);
            this.groupBox12.Controls.Add(this.label23);
            this.groupBox12.Controls.Add(this.numericUpDown_secs_border_ref);
            this.groupBox12.Controls.Add(this.label22);
            this.groupBox12.Controls.Add(this.button_secs_ver_attr_apply);
            this.groupBox12.Controls.Add(this.button_secs_hor_attr_apply);
            this.groupBox12.Controls.Add(this.label21);
            this.groupBox12.Controls.Add(this.comboBox_secs_border_mode);
            this.groupBox12.Location = new System.Drawing.Point(3, 262);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(420, 129);
            this.groupBox12.TabIndex = 4;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Border settings";
            // 
            // numericUpDown_secs_border_right
            // 
            this.numericUpDown_secs_border_right.DecimalPlaces = 3;
            this.numericUpDown_secs_border_right.Location = new System.Drawing.Point(317, 76);
            this.numericUpDown_secs_border_right.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDown_secs_border_right.Name = "numericUpDown_secs_border_right";
            this.numericUpDown_secs_border_right.Size = new System.Drawing.Size(97, 21);
            this.numericUpDown_secs_border_right.TabIndex = 13;
            this.numericUpDown_secs_border_right.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(270, 78);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(41, 12);
            this.label25.TabIndex = 12;
            this.label25.Text = "right : ";
            // 
            // numericUpDown_secs_border_left
            // 
            this.numericUpDown_secs_border_left.DecimalPlaces = 3;
            this.numericUpDown_secs_border_left.Location = new System.Drawing.Point(317, 49);
            this.numericUpDown_secs_border_left.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDown_secs_border_left.Name = "numericUpDown_secs_border_left";
            this.numericUpDown_secs_border_left.Size = new System.Drawing.Size(97, 21);
            this.numericUpDown_secs_border_left.TabIndex = 11;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(278, 51);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(33, 12);
            this.label24.TabIndex = 10;
            this.label24.Text = "left : ";
            // 
            // button_secs_short_attr_apply
            // 
            this.button_secs_short_attr_apply.Location = new System.Drawing.Point(333, 20);
            this.button_secs_short_attr_apply.Name = "button_secs_short_attr_apply";
            this.button_secs_short_attr_apply.Size = new System.Drawing.Size(79, 23);
            this.button_secs_short_attr_apply.TabIndex = 9;
            this.button_secs_short_attr_apply.Text = "short axis";
            this.button_secs_short_attr_apply.UseVisualStyleBackColor = true;
            this.button_secs_short_attr_apply.Click += new System.EventHandler(this.button_secs_short_attr_apply_Click);
            // 
            // button_secs_long_attr_apply
            // 
            this.button_secs_long_attr_apply.Location = new System.Drawing.Point(224, 20);
            this.button_secs_long_attr_apply.Name = "button_secs_long_attr_apply";
            this.button_secs_long_attr_apply.Size = new System.Drawing.Size(79, 23);
            this.button_secs_long_attr_apply.TabIndex = 8;
            this.button_secs_long_attr_apply.Text = "long axis";
            this.button_secs_long_attr_apply.UseVisualStyleBackColor = true;
            this.button_secs_long_attr_apply.Click += new System.EventHandler(this.button_secs_long_attr_apply_Click);
            // 
            // numericUpDown_secs_border_offset
            // 
            this.numericUpDown_secs_border_offset.Location = new System.Drawing.Point(109, 101);
            this.numericUpDown_secs_border_offset.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDown_secs_border_offset.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.numericUpDown_secs_border_offset.Name = "numericUpDown_secs_border_offset";
            this.numericUpDown_secs_border_offset.Size = new System.Drawing.Size(97, 21);
            this.numericUpDown_secs_border_offset.TabIndex = 7;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(6, 106);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(101, 12);
            this.label23.TabIndex = 6;
            this.label23.Text = "Ref. offset (px) : ";
            // 
            // numericUpDown_secs_border_ref
            // 
            this.numericUpDown_secs_border_ref.DecimalPlaces = 1;
            this.numericUpDown_secs_border_ref.Location = new System.Drawing.Point(109, 74);
            this.numericUpDown_secs_border_ref.Name = "numericUpDown_secs_border_ref";
            this.numericUpDown_secs_border_ref.Size = new System.Drawing.Size(97, 21);
            this.numericUpDown_secs_border_ref.TabIndex = 5;
            this.numericUpDown_secs_border_ref.Value = new decimal(new int[] {
            35,
            0,
            0,
            0});
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(6, 79);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(97, 12);
            this.label22.TabIndex = 4;
            this.label22.Text = "Ref. value (%) : ";
            // 
            // button_secs_ver_attr_apply
            // 
            this.button_secs_ver_attr_apply.Location = new System.Drawing.Point(115, 20);
            this.button_secs_ver_attr_apply.Name = "button_secs_ver_attr_apply";
            this.button_secs_ver_attr_apply.Size = new System.Drawing.Size(79, 23);
            this.button_secs_ver_attr_apply.TabIndex = 3;
            this.button_secs_ver_attr_apply.Text = "vertical";
            this.button_secs_ver_attr_apply.UseVisualStyleBackColor = true;
            this.button_secs_ver_attr_apply.Click += new System.EventHandler(this.button_secs_ver_attr_apply_Click);
            // 
            // button_secs_hor_attr_apply
            // 
            this.button_secs_hor_attr_apply.Location = new System.Drawing.Point(6, 20);
            this.button_secs_hor_attr_apply.Name = "button_secs_hor_attr_apply";
            this.button_secs_hor_attr_apply.Size = new System.Drawing.Size(79, 23);
            this.button_secs_hor_attr_apply.TabIndex = 2;
            this.button_secs_hor_attr_apply.Text = "horizontal";
            this.button_secs_hor_attr_apply.UseVisualStyleBackColor = true;
            this.button_secs_hor_attr_apply.Click += new System.EventHandler(this.button_secs_hor_attr_apply_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(6, 51);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(90, 12);
            this.label21.TabIndex = 1;
            this.label21.Text = "Border mode : ";
            // 
            // comboBox_secs_border_mode
            // 
            this.comboBox_secs_border_mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_secs_border_mode.FormattingEnabled = true;
            this.comboBox_secs_border_mode.Items.AddRange(new object[] {
            "By hand",
            "Percentage of Reference"});
            this.comboBox_secs_border_mode.Location = new System.Drawing.Point(109, 48);
            this.comboBox_secs_border_mode.Name = "comboBox_secs_border_mode";
            this.comboBox_secs_border_mode.Size = new System.Drawing.Size(98, 20);
            this.comboBox_secs_border_mode.TabIndex = 0;
            this.comboBox_secs_border_mode.SelectedIndexChanged += new System.EventHandler(this.comboBox_secs_border_mode_SelectedIndexChanged);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.tableLayoutPanel9);
            this.groupBox11.Controls.Add(this.tableLayoutPanel10);
            this.groupBox11.Location = new System.Drawing.Point(3, 163);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(420, 84);
            this.groupBox11.TabIndex = 3;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Beam sections";
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel9.ColumnCount = 2;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel9.Controls.Add(this.radioButton_secs_beam_manual, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.radioButton_secs_beam_centroid, 1, 0);
            this.tableLayoutPanel9.Location = new System.Drawing.Point(6, 52);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(408, 26);
            this.tableLayoutPanel9.TabIndex = 1;
            // 
            // radioButton_secs_beam_manual
            // 
            this.radioButton_secs_beam_manual.AutoSize = true;
            this.radioButton_secs_beam_manual.Location = new System.Drawing.Point(3, 3);
            this.radioButton_secs_beam_manual.Name = "radioButton_secs_beam_manual";
            this.radioButton_secs_beam_manual.Size = new System.Drawing.Size(65, 16);
            this.radioButton_secs_beam_manual.TabIndex = 0;
            this.radioButton_secs_beam_manual.TabStop = true;
            this.radioButton_secs_beam_manual.Tag = "0";
            this.radioButton_secs_beam_manual.Text = "manual";
            this.radioButton_secs_beam_manual.UseVisualStyleBackColor = true;
            this.radioButton_secs_beam_manual.MouseCaptureChanged += new System.EventHandler(this.radioButton_secs_beam_manual_MouseCaptureChanged);
            // 
            // radioButton_secs_beam_centroid
            // 
            this.radioButton_secs_beam_centroid.AutoSize = true;
            this.radioButton_secs_beam_centroid.Location = new System.Drawing.Point(207, 3);
            this.radioButton_secs_beam_centroid.Name = "radioButton_secs_beam_centroid";
            this.radioButton_secs_beam_centroid.Size = new System.Drawing.Size(86, 16);
            this.radioButton_secs_beam_centroid.TabIndex = 1;
            this.radioButton_secs_beam_centroid.TabStop = true;
            this.radioButton_secs_beam_centroid.Tag = "1";
            this.radioButton_secs_beam_centroid.Text = "auto center";
            this.radioButton_secs_beam_centroid.UseVisualStyleBackColor = true;
            this.radioButton_secs_beam_centroid.MouseCaptureChanged += new System.EventHandler(this.radioButton_secs_beam_manual_MouseCaptureChanged);
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel10.ColumnCount = 6;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel10.Controls.Add(this.label18, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.numericUpDown_secs_beam_row, 1, 0);
            this.tableLayoutPanel10.Controls.Add(this.label19, 2, 0);
            this.tableLayoutPanel10.Controls.Add(this.numericUpDown_secs_beam_col, 3, 0);
            this.tableLayoutPanel10.Controls.Add(this.label20, 4, 0);
            this.tableLayoutPanel10.Controls.Add(this.numericUpDown_secs_beam_angle, 5, 0);
            this.tableLayoutPanel10.Location = new System.Drawing.Point(6, 20);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 1;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(408, 26);
            this.tableLayoutPanel10.TabIndex = 0;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label18.Location = new System.Drawing.Point(3, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(62, 26);
            this.label18.TabIndex = 0;
            this.label18.Text = "row : ";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDown_secs_beam_row
            // 
            this.numericUpDown_secs_beam_row.Location = new System.Drawing.Point(71, 3);
            this.numericUpDown_secs_beam_row.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDown_secs_beam_row.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.numericUpDown_secs_beam_row.Name = "numericUpDown_secs_beam_row";
            this.numericUpDown_secs_beam_row.Size = new System.Drawing.Size(62, 21);
            this.numericUpDown_secs_beam_row.TabIndex = 1;
            this.numericUpDown_secs_beam_row.ValueChanged += new System.EventHandler(this.numericUpDown_secs_beam_row_ValueChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label19.Location = new System.Drawing.Point(139, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(62, 26);
            this.label19.TabIndex = 2;
            this.label19.Text = "colum : ";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDown_secs_beam_col
            // 
            this.numericUpDown_secs_beam_col.Location = new System.Drawing.Point(207, 3);
            this.numericUpDown_secs_beam_col.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDown_secs_beam_col.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.numericUpDown_secs_beam_col.Name = "numericUpDown_secs_beam_col";
            this.numericUpDown_secs_beam_col.Size = new System.Drawing.Size(62, 21);
            this.numericUpDown_secs_beam_col.TabIndex = 3;
            this.numericUpDown_secs_beam_col.ValueChanged += new System.EventHandler(this.numericUpDown_secs_beam_col_ValueChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label20.Location = new System.Drawing.Point(275, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(62, 26);
            this.label20.TabIndex = 4;
            this.label20.Text = "angle : ";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDown_secs_beam_angle
            // 
            this.numericUpDown_secs_beam_angle.DecimalPlaces = 1;
            this.numericUpDown_secs_beam_angle.Location = new System.Drawing.Point(343, 3);
            this.numericUpDown_secs_beam_angle.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDown_secs_beam_angle.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.numericUpDown_secs_beam_angle.Name = "numericUpDown_secs_beam_angle";
            this.numericUpDown_secs_beam_angle.Size = new System.Drawing.Size(62, 21);
            this.numericUpDown_secs_beam_angle.TabIndex = 5;
            this.numericUpDown_secs_beam_angle.ValueChanged += new System.EventHandler(this.numericUpDown_secs_beam_angle_ValueChanged);
            // 
            // checkBox_secs_beam
            // 
            this.checkBox_secs_beam.AutoSize = true;
            this.checkBox_secs_beam.Location = new System.Drawing.Point(3, 141);
            this.checkBox_secs_beam.Name = "checkBox_secs_beam";
            this.checkBox_secs_beam.Size = new System.Drawing.Size(110, 16);
            this.checkBox_secs_beam.TabIndex = 2;
            this.checkBox_secs_beam.Text = "Beam Sections";
            this.checkBox_secs_beam.UseVisualStyleBackColor = true;
            this.checkBox_secs_beam.CheckedChanged += new System.EventHandler(this.checkBox_secs_beam_CheckedChanged);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.tableLayoutPanel8);
            this.groupBox10.Controls.Add(this.tableLayoutPanel7);
            this.groupBox10.Location = new System.Drawing.Point(3, 36);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(420, 84);
            this.groupBox10.TabIndex = 1;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Cross sections";
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel8.Controls.Add(this.radioButton_sect_cross_manual, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.radioButton_sect_cross_centroid, 1, 0);
            this.tableLayoutPanel8.Location = new System.Drawing.Point(6, 52);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(408, 26);
            this.tableLayoutPanel8.TabIndex = 1;
            // 
            // radioButton_sect_cross_manual
            // 
            this.radioButton_sect_cross_manual.AutoSize = true;
            this.radioButton_sect_cross_manual.Location = new System.Drawing.Point(3, 3);
            this.radioButton_sect_cross_manual.Name = "radioButton_sect_cross_manual";
            this.radioButton_sect_cross_manual.Size = new System.Drawing.Size(65, 16);
            this.radioButton_sect_cross_manual.TabIndex = 0;
            this.radioButton_sect_cross_manual.TabStop = true;
            this.radioButton_sect_cross_manual.Tag = "0";
            this.radioButton_sect_cross_manual.Text = "manual";
            this.radioButton_sect_cross_manual.UseVisualStyleBackColor = true;
            this.radioButton_sect_cross_manual.MouseCaptureChanged += new System.EventHandler(this.radioButton_sect_cross_manual_MouseCaptureChanged);
            // 
            // radioButton_sect_cross_centroid
            // 
            this.radioButton_sect_cross_centroid.AutoSize = true;
            this.radioButton_sect_cross_centroid.Location = new System.Drawing.Point(207, 3);
            this.radioButton_sect_cross_centroid.Name = "radioButton_sect_cross_centroid";
            this.radioButton_sect_cross_centroid.Size = new System.Drawing.Size(86, 16);
            this.radioButton_sect_cross_centroid.TabIndex = 2;
            this.radioButton_sect_cross_centroid.TabStop = true;
            this.radioButton_sect_cross_centroid.Tag = "1";
            this.radioButton_sect_cross_centroid.Text = "auto center";
            this.radioButton_sect_cross_centroid.UseVisualStyleBackColor = true;
            this.radioButton_sect_cross_centroid.MouseCaptureChanged += new System.EventHandler(this.radioButton_sect_cross_manual_MouseCaptureChanged);
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel7.ColumnCount = 4;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel7.Controls.Add(this.label16, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.numericUpDown_sect_cross_row, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.label17, 2, 0);
            this.tableLayoutPanel7.Controls.Add(this.numericUpDown_sect_cross_col, 3, 0);
            this.tableLayoutPanel7.Location = new System.Drawing.Point(6, 20);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(408, 26);
            this.tableLayoutPanel7.TabIndex = 0;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label16.Location = new System.Drawing.Point(3, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(96, 26);
            this.label16.TabIndex = 0;
            this.label16.Text = "row : ";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDown_sect_cross_row
            // 
            this.numericUpDown_sect_cross_row.Location = new System.Drawing.Point(105, 3);
            this.numericUpDown_sect_cross_row.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDown_sect_cross_row.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.numericUpDown_sect_cross_row.Name = "numericUpDown_sect_cross_row";
            this.numericUpDown_sect_cross_row.Size = new System.Drawing.Size(96, 21);
            this.numericUpDown_sect_cross_row.TabIndex = 1;
            this.numericUpDown_sect_cross_row.ValueChanged += new System.EventHandler(this.numericUpDown_sect_cross_row_ValueChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.Location = new System.Drawing.Point(207, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(96, 26);
            this.label17.TabIndex = 2;
            this.label17.Text = "colum : ";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDown_sect_cross_col
            // 
            this.numericUpDown_sect_cross_col.Location = new System.Drawing.Point(309, 3);
            this.numericUpDown_sect_cross_col.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDown_sect_cross_col.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.numericUpDown_sect_cross_col.Name = "numericUpDown_sect_cross_col";
            this.numericUpDown_sect_cross_col.Size = new System.Drawing.Size(96, 21);
            this.numericUpDown_sect_cross_col.TabIndex = 3;
            this.numericUpDown_sect_cross_col.ValueChanged += new System.EventHandler(this.numericUpDown_sect_cross_col_ValueChanged);
            // 
            // checkBox_secs_cross
            // 
            this.checkBox_secs_cross.AutoSize = true;
            this.checkBox_secs_cross.Location = new System.Drawing.Point(3, 14);
            this.checkBox_secs_cross.Name = "checkBox_secs_cross";
            this.checkBox_secs_cross.Size = new System.Drawing.Size(111, 16);
            this.checkBox_secs_cross.TabIndex = 0;
            this.checkBox_secs_cross.Text = "Cross Sections";
            this.checkBox_secs_cross.UseVisualStyleBackColor = true;
            this.checkBox_secs_cross.CheckedChanged += new System.EventHandler(this.checkBox_secs_cross_CheckedChanged);
            // 
            // tabPage_roi
            // 
            this.tabPage_roi.Controls.Add(this.groupBox9);
            this.tabPage_roi.Controls.Add(this.groupBox8);
            this.tabPage_roi.Controls.Add(this.groupBox7);
            this.tabPage_roi.Controls.Add(this.checkBox_active_roi);
            this.tabPage_roi.Location = new System.Drawing.Point(4, 22);
            this.tabPage_roi.Name = "tabPage_roi";
            this.tabPage_roi.Size = new System.Drawing.Size(426, 416);
            this.tabPage_roi.TabIndex = 3;
            this.tabPage_roi.Text = "ROI";
            this.tabPage_roi.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.tableLayoutPanel6);
            this.groupBox9.Location = new System.Drawing.Point(4, 182);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(415, 54);
            this.groupBox9.TabIndex = 7;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Shape";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel6.Controls.Add(this.radioButton_roi_shp_rectangle, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.radioButton_roi_shp_circle, 1, 0);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(4, 20);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(403, 28);
            this.tableLayoutPanel6.TabIndex = 6;
            // 
            // radioButton_roi_shp_rectangle
            // 
            this.radioButton_roi_shp_rectangle.AutoSize = true;
            this.radioButton_roi_shp_rectangle.Location = new System.Drawing.Point(3, 3);
            this.radioButton_roi_shp_rectangle.Name = "radioButton_roi_shp_rectangle";
            this.radioButton_roi_shp_rectangle.Size = new System.Drawing.Size(75, 16);
            this.radioButton_roi_shp_rectangle.TabIndex = 0;
            this.radioButton_roi_shp_rectangle.TabStop = true;
            this.radioButton_roi_shp_rectangle.Tag = "0";
            this.radioButton_roi_shp_rectangle.Text = "rectangle";
            this.radioButton_roi_shp_rectangle.UseVisualStyleBackColor = true;
            this.radioButton_roi_shp_rectangle.MouseCaptureChanged += new System.EventHandler(this.radioButton_roi_shp_rectangle_MouseCaptureChanged);
            // 
            // radioButton_roi_shp_circle
            // 
            this.radioButton_roi_shp_circle.AutoSize = true;
            this.radioButton_roi_shp_circle.Location = new System.Drawing.Point(204, 3);
            this.radioButton_roi_shp_circle.Name = "radioButton_roi_shp_circle";
            this.radioButton_roi_shp_circle.Size = new System.Drawing.Size(54, 16);
            this.radioButton_roi_shp_circle.TabIndex = 1;
            this.radioButton_roi_shp_circle.TabStop = true;
            this.radioButton_roi_shp_circle.Tag = "1";
            this.radioButton_roi_shp_circle.Text = "circle";
            this.radioButton_roi_shp_circle.UseVisualStyleBackColor = true;
            this.radioButton_roi_shp_circle.MouseCaptureChanged += new System.EventHandler(this.radioButton_roi_shp_rectangle_MouseCaptureChanged);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.tableLayoutPanel5);
            this.groupBox8.Location = new System.Drawing.Point(4, 122);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(415, 54);
            this.groupBox8.TabIndex = 6;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Mode";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.Controls.Add(this.radioButton_roi_mod_manual, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.radioButton_roi_mod_centroid, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.radioButton_roi_mod_autoresize, 2, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(6, 20);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(403, 28);
            this.tableLayoutPanel5.TabIndex = 5;
            // 
            // radioButton_roi_mod_manual
            // 
            this.radioButton_roi_mod_manual.AutoSize = true;
            this.radioButton_roi_mod_manual.Location = new System.Drawing.Point(3, 3);
            this.radioButton_roi_mod_manual.Name = "radioButton_roi_mod_manual";
            this.radioButton_roi_mod_manual.Size = new System.Drawing.Size(65, 16);
            this.radioButton_roi_mod_manual.TabIndex = 0;
            this.radioButton_roi_mod_manual.TabStop = true;
            this.radioButton_roi_mod_manual.Tag = "0";
            this.radioButton_roi_mod_manual.Text = "Manual";
            this.radioButton_roi_mod_manual.UseVisualStyleBackColor = true;
            this.radioButton_roi_mod_manual.MouseCaptureChanged += new System.EventHandler(this.radioButton_roi_mod_manual_MouseCaptureChanged);
            // 
            // radioButton_roi_mod_centroid
            // 
            this.radioButton_roi_mod_centroid.AutoSize = true;
            this.radioButton_roi_mod_centroid.Location = new System.Drawing.Point(137, 3);
            this.radioButton_roi_mod_centroid.Name = "radioButton_roi_mod_centroid";
            this.radioButton_roi_mod_centroid.Size = new System.Drawing.Size(70, 16);
            this.radioButton_roi_mod_centroid.TabIndex = 1;
            this.radioButton_roi_mod_centroid.TabStop = true;
            this.radioButton_roi_mod_centroid.Tag = "1";
            this.radioButton_roi_mod_centroid.Text = "Centroid";
            this.radioButton_roi_mod_centroid.UseVisualStyleBackColor = true;
            this.radioButton_roi_mod_centroid.MouseCaptureChanged += new System.EventHandler(this.radioButton_roi_mod_manual_MouseCaptureChanged);
            // 
            // radioButton_roi_mod_autoresize
            // 
            this.radioButton_roi_mod_autoresize.AutoSize = true;
            this.radioButton_roi_mod_autoresize.Location = new System.Drawing.Point(271, 3);
            this.radioButton_roi_mod_autoresize.Name = "radioButton_roi_mod_autoresize";
            this.radioButton_roi_mod_autoresize.Size = new System.Drawing.Size(87, 16);
            this.radioButton_roi_mod_autoresize.TabIndex = 2;
            this.radioButton_roi_mod_autoresize.TabStop = true;
            this.radioButton_roi_mod_autoresize.Tag = "2";
            this.radioButton_roi_mod_autoresize.Text = "Auto resize";
            this.radioButton_roi_mod_autoresize.UseVisualStyleBackColor = true;
            this.radioButton_roi_mod_autoresize.MouseCaptureChanged += new System.EventHandler(this.radioButton_roi_mod_manual_MouseCaptureChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox7.Controls.Add(this.tableLayoutPanel4);
            this.groupBox7.Location = new System.Drawing.Point(4, 35);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox7.Size = new System.Drawing.Size(415, 80);
            this.groupBox7.TabIndex = 4;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Camera-ROI";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.Controls.Add(this.numericUpDown_roi_height, 3, 1);
            this.tableLayoutPanel4.Controls.Add(this.label12, 2, 1);
            this.tableLayoutPanel4.Controls.Add(this.numericUpDown_roi_width, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.label13, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.numericUpDown_roi_top, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.label14, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.label15, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.numericUpDown_roi_left, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(4, 18);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(407, 58);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // numericUpDown_roi_height
            // 
            this.numericUpDown_roi_height.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown_roi_height.Location = new System.Drawing.Point(307, 33);
            this.numericUpDown_roi_height.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDown_roi_height.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDown_roi_height.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.numericUpDown_roi_height.Name = "numericUpDown_roi_height";
            this.numericUpDown_roi_height.Size = new System.Drawing.Size(96, 21);
            this.numericUpDown_roi_height.TabIndex = 8;
            this.numericUpDown_roi_height.ValueChanged += new System.EventHandler(this.numericUpDown_roi_height_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(206, 29);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 29);
            this.label12.TabIndex = 7;
            this.label12.Text = "Height : ";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericUpDown_roi_width
            // 
            this.numericUpDown_roi_width.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown_roi_width.Location = new System.Drawing.Point(105, 33);
            this.numericUpDown_roi_width.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDown_roi_width.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDown_roi_width.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.numericUpDown_roi_width.Name = "numericUpDown_roi_width";
            this.numericUpDown_roi_width.Size = new System.Drawing.Size(93, 21);
            this.numericUpDown_roi_width.TabIndex = 6;
            this.numericUpDown_roi_width.ValueChanged += new System.EventHandler(this.numericUpDown_roi_width_ValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Location = new System.Drawing.Point(4, 29);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(93, 29);
            this.label13.TabIndex = 5;
            this.label13.Text = "Width : ";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericUpDown_roi_top
            // 
            this.numericUpDown_roi_top.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown_roi_top.Location = new System.Drawing.Point(307, 4);
            this.numericUpDown_roi_top.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDown_roi_top.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDown_roi_top.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.numericUpDown_roi_top.Name = "numericUpDown_roi_top";
            this.numericUpDown_roi_top.Size = new System.Drawing.Size(96, 21);
            this.numericUpDown_roi_top.TabIndex = 4;
            this.numericUpDown_roi_top.ValueChanged += new System.EventHandler(this.numericUpDown_roi_top_ValueChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Location = new System.Drawing.Point(206, 0);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(93, 29);
            this.label14.TabIndex = 3;
            this.label14.Text = "Top : ";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.Location = new System.Drawing.Point(4, 0);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(93, 29);
            this.label15.TabIndex = 0;
            this.label15.Text = "Left : ";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericUpDown_roi_left
            // 
            this.numericUpDown_roi_left.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown_roi_left.Location = new System.Drawing.Point(105, 4);
            this.numericUpDown_roi_left.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDown_roi_left.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDown_roi_left.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.numericUpDown_roi_left.Name = "numericUpDown_roi_left";
            this.numericUpDown_roi_left.Size = new System.Drawing.Size(93, 21);
            this.numericUpDown_roi_left.TabIndex = 1;
            this.numericUpDown_roi_left.ValueChanged += new System.EventHandler(this.numericUpDown_roi_left_ValueChanged);
            // 
            // checkBox_active_roi
            // 
            this.checkBox_active_roi.AutoSize = true;
            this.checkBox_active_roi.Location = new System.Drawing.Point(14, 12);
            this.checkBox_active_roi.Name = "checkBox_active_roi";
            this.checkBox_active_roi.Size = new System.Drawing.Size(122, 16);
            this.checkBox_active_roi.TabIndex = 0;
            this.checkBox_active_roi.Text = "Region of Interest";
            this.checkBox_active_roi.UseVisualStyleBackColor = true;
            this.checkBox_active_roi.CheckedChanged += new System.EventHandler(this.checkBox_active_roi_CheckedChanged);
            // 
            // contextMenuStrip_listview_click_menu
            // 
            this.contextMenuStrip_listview_click_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyClipboardToolStripMenuItem});
            this.contextMenuStrip_listview_click_menu.Name = "contextMenuStrip_listview_click_menu";
            this.contextMenuStrip_listview_click_menu.Size = new System.Drawing.Size(157, 26);
            this.contextMenuStrip_listview_click_menu.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_listview_click_menu_Opening);
            // 
            // copyClipboardToolStripMenuItem
            // 
            this.copyClipboardToolStripMenuItem.Name = "copyClipboardToolStripMenuItem";
            this.copyClipboardToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.copyClipboardToolStripMenuItem.Text = "Copy clipboard";
            // 
            // textBox_ip_addr
            // 
            this.textBox_ip_addr.Location = new System.Drawing.Point(12, 12);
            this.textBox_ip_addr.Name = "textBox_ip_addr";
            this.textBox_ip_addr.Size = new System.Drawing.Size(138, 21);
            this.textBox_ip_addr.TabIndex = 11;
            this.textBox_ip_addr.Text = "127.0.0.1";
            // 
            // numericUpDown_port
            // 
            this.numericUpDown_port.Location = new System.Drawing.Point(159, 12);
            this.numericUpDown_port.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numericUpDown_port.Name = "numericUpDown_port";
            this.numericUpDown_port.Size = new System.Drawing.Size(72, 21);
            this.numericUpDown_port.TabIndex = 12;
            this.numericUpDown_port.Value = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1008, 611);
            this.Controls.Add(this.numericUpDown_port);
            this.Controls.Add(this.textBox_ip_addr);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.textBox_version);
            this.Controls.Add(this.button_get_info);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox_conn_status);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button_disconnect);
            this.Controls.Add(this.button_connect);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExampleXMLInterface";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_interval)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_main.ResumeLayout(false);
            this.groupBox_img_process.ResumeLayout(false);
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_avg_float)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_num_restriction)).EndInit();
            this.groupBox_main_ctrl.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tabPage_image_correction.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.tabControl_background.ResumeLayout(false);
            this.tabPage_back_image.ResumeLayout(false);
            this.tabPage_back_image.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_back_image_frames)).EndInit();
            this.tabPage_back_corner.ResumeLayout(false);
            this.tabPage_back_corner.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_back_corner_span)).EndInit();
            this.tabPage_back_constant.ResumeLayout(false);
            this.tabPage_back_constant.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_back_constant_val)).EndInit();
            this.tabPage_cam.ResumeLayout(false);
            this.tabPage_cam.PerformLayout();
            this.groupBox_property.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_exposure_time)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_gain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_trigger_delay)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_cam_roi_h)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_cam_roi_w)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_cam_roi_y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_cam_roi_x)).EndInit();
            this.tabPage_sections.ResumeLayout(false);
            this.tabPage_sections.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_secs_border_right)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_secs_border_left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_secs_border_offset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_secs_border_ref)).EndInit();
            this.groupBox11.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_secs_beam_row)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_secs_beam_col)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_secs_beam_angle)).EndInit();
            this.groupBox10.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_sect_cross_row)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_sect_cross_col)).EndInit();
            this.tabPage_roi.ResumeLayout(false);
            this.tabPage_roi.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_roi_height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_roi_width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_roi_top)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_roi_left)).EndInit();
            this.contextMenuStrip_listview_click_menu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_port)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.Button button_disconnect;
        private System.Windows.Forms.Button button_get_info;
        private System.Windows.Forms.ListView listView_available_items;
        private System.Windows.Forms.ColumnHeader columnHeader_name;
        private System.Windows.Forms.ColumnHeader columnHeader_description;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Timer timer_connect_status;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_conn_status;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listView_use_items;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.ComponentModel.BackgroundWorker backgroundWorker_connect;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numericUpDown_interval;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox_continuous;
        private System.Windows.Forms.Button button_get;
        private System.Windows.Forms.TextBox textBox_value_unit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_key;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Button button_background;
        private System.Windows.Forms.Button button_stop;
        private System.Windows.Forms.TextBox textBox_version;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_main;
        private System.Windows.Forms.TabPage tabPage_cam;
        private System.Windows.Forms.TabPage tabPage_sections;
        private System.Windows.Forms.TabPage tabPage_roi;
        private System.Windows.Forms.GroupBox groupBox_main_ctrl;
        private System.Windows.Forms.Button button_test;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.RadioButton radioButton_ext_trigger;
        private System.Windows.Forms.RadioButton radioButton_oneshot;
        private System.Windows.Forms.RadioButton radioButton_continuous;
        private System.Windows.Forms.TabPage tabPage_image_correction;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.NumericUpDown numericUpDown_cam_roi_h;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDown_cam_roi_w;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDown_cam_roi_y;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericUpDown_cam_roi_x;
        private System.Windows.Forms.GroupBox groupBox_property;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.NumericUpDown numericUpDown_exposure_time;
        private System.Windows.Forms.Label label_exporsure_time;
        private System.Windows.Forms.Label label_gain;
        private System.Windows.Forms.NumericUpDown numericUpDown_gain;
        private System.Windows.Forms.Label label_trigger_delay;
        private System.Windows.Forms.NumericUpDown numericUpDown_trigger_delay;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox_cam_id;
        private System.Windows.Forms.CheckBox checkBox_active_roi;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.NumericUpDown numericUpDown_roi_height;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numericUpDown_roi_width;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown numericUpDown_roi_top;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown numericUpDown_roi_left;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.RadioButton radioButton_roi_mod_manual;
        private System.Windows.Forms.RadioButton radioButton_roi_mod_centroid;
        private System.Windows.Forms.RadioButton radioButton_roi_mod_autoresize;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.RadioButton radioButton_roi_shp_rectangle;
        private System.Windows.Forms.RadioButton radioButton_roi_shp_circle;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.CheckBox checkBox_secs_cross;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown numericUpDown_sect_cross_row;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown numericUpDown_sect_cross_col;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.RadioButton radioButton_secs_beam_manual;
        private System.Windows.Forms.RadioButton radioButton_secs_beam_centroid;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown numericUpDown_secs_beam_row;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown numericUpDown_secs_beam_col;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.NumericUpDown numericUpDown_secs_beam_angle;
        private System.Windows.Forms.CheckBox checkBox_secs_beam;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.RadioButton radioButton_sect_cross_manual;
        private System.Windows.Forms.RadioButton radioButton_sect_cross_centroid;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.Button button_secs_ver_attr_apply;
        private System.Windows.Forms.Button button_secs_hor_attr_apply;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox comboBox_secs_border_mode;
        private System.Windows.Forms.NumericUpDown numericUpDown_secs_border_ref;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button button_secs_short_attr_apply;
        private System.Windows.Forms.Button button_secs_long_attr_apply;
        private System.Windows.Forms.NumericUpDown numericUpDown_secs_border_offset;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.NumericUpDown numericUpDown_secs_border_right;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.NumericUpDown numericUpDown_secs_border_left;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ComboBox comboBox_auto_control;
        private System.Windows.Forms.GroupBox groupBox_img_process;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.CheckBox checkBox_avg_float;
        private System.Windows.Forms.CheckBox checkBox_num_restriction;
        private System.Windows.Forms.Label label_avg_float;
        private System.Windows.Forms.NumericUpDown numericUpDown_avg_float;
        private System.Windows.Forms.NumericUpDown numericUpDown_num_restriction;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.ComboBox comboBox_background;
        private System.Windows.Forms.TabControl tabControl_background;
        private System.Windows.Forms.TabPage tabPage_back_image;
        private System.Windows.Forms.TabPage tabPage_back_corner;
        private System.Windows.Forms.TabPage tabPage_back_constant;
        private System.Windows.Forms.CheckBox checkBox_back_image;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.NumericUpDown numericUpDown_back_image_frames;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBox_back_corner;
        private System.Windows.Forms.CheckBox checkBox_back_corner_overlay;
        private System.Windows.Forms.NumericUpDown numericUpDown_back_corner_span;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.NumericUpDown numericUpDown_back_constant_val;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.CheckBox checkBox_back_constant;
        private System.Windows.Forms.Button button_show_preview;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox textBox_cam_pix_y;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox textBox_cam_pix_x;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_listview_click_menu;
        private System.Windows.Forms.ToolStripMenuItem copyClipboardToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox_ip_addr;
        private System.Windows.Forms.NumericUpDown numericUpDown_port;
    }
}

