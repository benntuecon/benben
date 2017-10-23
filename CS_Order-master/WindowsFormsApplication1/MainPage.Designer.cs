namespace SimpleCase
{
    partial class MainPage
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
            this.queryBtn = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.SavedListView = new System.Windows.Forms.ListView();
            this.conditionPanel = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.loop_or_not = new System.Windows.Forms.CheckBox();
            this.Valid_duration = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Order_q = new System.Windows.Forms.NumericUpDown();
            this.delay_sec = new System.Windows.Forms.NumericUpDown();
            this.Offset_point = new System.Windows.Forms.NumericUpDown();
            this.Option_target = new System.Windows.Forms.NumericUpDown();
            this.Trigger_point = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Dlt_btn = new System.Windows.Forms.Button();
            this.Order_p = new System.Windows.Forms.ComboBox();
            this.Monitoring_condition = new System.Windows.Forms.ComboBox();
            this.Order_typ = new System.Windows.Forms.ComboBox();
            this.Monitoring_Target = new System.Windows.Forms.ComboBox();
            this.Save_Btn = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.Option_month = new System.Windows.Forms.NumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.buy_or_sell = new System.Windows.Forms.ComboBox();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.conditionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Order_q)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.delay_sec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Offset_point)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Option_target)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Trigger_point)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Option_month)).BeginInit();
            this.SuspendLayout();
            // 
            // queryBtn
            // 
            this.queryBtn.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.queryBtn.ForeColor = System.Drawing.Color.Blue;
            this.queryBtn.Location = new System.Drawing.Point(723, 32);
            this.queryBtn.Margin = new System.Windows.Forms.Padding(6);
            this.queryBtn.Name = "queryBtn";
            this.queryBtn.Size = new System.Drawing.Size(100, 33);
            this.queryBtn.TabIndex = 0;
            this.queryBtn.Text = "檢查庫存";
            this.queryBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.queryBtn.UseVisualStyleBackColor = true;
            this.queryBtn.Click += new System.EventHandler(this.queryBtn_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Location = new System.Drawing.Point(27, 101);
            this.tabControl.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl.MinimumSize = new System.Drawing.Size(800, 400);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(852, 528);
            this.tabControl.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 33);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(6);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(6);
            this.tabPage1.Size = new System.Drawing.Size(844, 491);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "保險單";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.SavedListView, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.conditionPanel, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 9);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.47942F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.52058F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(825, 438);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // SavedListView
            // 
            this.SavedListView.AllowDrop = true;
            this.SavedListView.BackColor = System.Drawing.SystemColors.Info;
            this.SavedListView.BackgroundImageTiled = true;
            this.SavedListView.CheckBoxes = true;
            this.SavedListView.Cursor = System.Windows.Forms.Cursors.Default;
            this.SavedListView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SavedListView.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.SavedListView.FullRowSelect = true;
            this.SavedListView.GridLines = true;
            this.SavedListView.Location = new System.Drawing.Point(5, 256);
            this.SavedListView.MultiSelect = false;
            this.SavedListView.Name = "SavedListView";
            this.SavedListView.Size = new System.Drawing.Size(815, 174);
            this.SavedListView.TabIndex = 0;
            this.SavedListView.UseCompatibleStateImageBehavior = false;
            this.SavedListView.View = System.Windows.Forms.View.Details;
            this.SavedListView.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.SaveListView_Check);
            this.SavedListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.SaveListView_Uncheck);
            this.SavedListView.SelectedIndexChanged += new System.EventHandler(this.SavedListView_SelectedIndexChanged);
            this.SavedListView.Click += new System.EventHandler(this.SaveListView_click);
            // 
            // conditionPanel
            // 
            this.conditionPanel.Controls.Add(this.label22);
            this.conditionPanel.Controls.Add(this.label21);
            this.conditionPanel.Controls.Add(this.label18);
            this.conditionPanel.Controls.Add(this.label17);
            this.conditionPanel.Controls.Add(this.label13);
            this.conditionPanel.Controls.Add(this.loop_or_not);
            this.conditionPanel.Controls.Add(this.Valid_duration);
            this.conditionPanel.Controls.Add(this.label16);
            this.conditionPanel.Controls.Add(this.label15);
            this.conditionPanel.Controls.Add(this.label14);
            this.conditionPanel.Controls.Add(this.label7);
            this.conditionPanel.Controls.Add(this.Order_q);
            this.conditionPanel.Controls.Add(this.delay_sec);
            this.conditionPanel.Controls.Add(this.Offset_point);
            this.conditionPanel.Controls.Add(this.Option_month);
            this.conditionPanel.Controls.Add(this.Option_target);
            this.conditionPanel.Controls.Add(this.Trigger_point);
            this.conditionPanel.Controls.Add(this.label8);
            this.conditionPanel.Controls.Add(this.label11);
            this.conditionPanel.Controls.Add(this.label10);
            this.conditionPanel.Controls.Add(this.label12);
            this.conditionPanel.Controls.Add(this.label9);
            this.conditionPanel.Controls.Add(this.Dlt_btn);
            this.conditionPanel.Controls.Add(this.Order_p);
            this.conditionPanel.Controls.Add(this.Monitoring_condition);
            this.conditionPanel.Controls.Add(this.buy_or_sell);
            this.conditionPanel.Controls.Add(this.Order_typ);
            this.conditionPanel.Controls.Add(this.Monitoring_Target);
            this.conditionPanel.Controls.Add(this.Save_Btn);
            this.conditionPanel.Location = new System.Drawing.Point(5, 25);
            this.conditionPanel.Name = "conditionPanel";
            this.conditionPanel.Size = new System.Drawing.Size(815, 211);
            this.conditionPanel.TabIndex = 1;
            this.conditionPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.conditionPanel_Paint);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(188, 127);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(34, 24);
            this.label18.TabIndex = 13;
            this.label18.Text = "---";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(117, 127);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(34, 24);
            this.label17.TabIndex = 13;
            this.label17.Text = "---";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(117, 127);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(0, 24);
            this.label13.TabIndex = 12;
            // 
            // loop_or_not
            // 
            this.loop_or_not.AutoSize = true;
            this.loop_or_not.Location = new System.Drawing.Point(658, 123);
            this.loop_or_not.Name = "loop_or_not";
            this.loop_or_not.Size = new System.Drawing.Size(67, 28);
            this.loop_or_not.TabIndex = 11;
            this.loop_or_not.Text = "循環";
            this.loop_or_not.UseVisualStyleBackColor = true;
            this.loop_or_not.CheckedChanged += new System.EventHandler(this.loop_or_not_CheckedChanged);
            // 
            // Valid_duration
            // 
            this.Valid_duration.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Valid_duration.Location = new System.Drawing.Point(109, 171);
            this.Valid_duration.Name = "Valid_duration";
            this.Valid_duration.Size = new System.Drawing.Size(200, 33);
            this.Valid_duration.TabIndex = 10;
            this.Valid_duration.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(15, 177);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(105, 24);
            this.label16.TabIndex = 9;
            this.label16.Text = "有效期間：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(600, 127);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 24);
            this.label15.TabIndex = 8;
            this.label15.Text = "秒";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(371, 127);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(105, 24);
            this.label14.TabIndex = 7;
            this.label14.Text = "點，延遲：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(526, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 24);
            this.label7.TabIndex = 3;
            this.label7.Text = "時觸發";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // Order_q
            // 
            this.Order_q.Location = new System.Drawing.Point(604, 71);
            this.Order_q.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.Order_q.Name = "Order_q";
            this.Order_q.Size = new System.Drawing.Size(90, 33);
            this.Order_q.TabIndex = 1;
            this.Order_q.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // delay_sec
            // 
            this.delay_sec.Location = new System.Drawing.Point(486, 125);
            this.delay_sec.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.delay_sec.Name = "delay_sec";
            this.delay_sec.Size = new System.Drawing.Size(90, 33);
            this.delay_sec.TabIndex = 1;
            this.delay_sec.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // Offset_point
            // 
            this.Offset_point.Location = new System.Drawing.Point(254, 125);
            this.Offset_point.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.Offset_point.Name = "Offset_point";
            this.Offset_point.Size = new System.Drawing.Size(111, 33);
            this.Offset_point.TabIndex = 1;
            this.Offset_point.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // Option_target
            // 
            this.Option_target.Location = new System.Drawing.Point(254, 86);
            this.Option_target.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.Option_target.Name = "Option_target";
            this.Option_target.Size = new System.Drawing.Size(88, 33);
            this.Option_target.TabIndex = 1;
            this.Option_target.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // Trigger_point
            // 
            this.Trigger_point.Location = new System.Drawing.Point(386, 16);
            this.Trigger_point.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.Trigger_point.Name = "Trigger_point";
            this.Trigger_point.Size = new System.Drawing.Size(120, 33);
            this.Trigger_point.TabIndex = 1;
            this.Trigger_point.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 24);
            this.label8.TabIndex = 5;
            this.label8.Text = "觸發條件：";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(545, 73);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 24);
            this.label11.TabIndex = 5;
            this.label11.Text = "量：";
            this.label11.Click += new System.EventHandler(this.label9_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(408, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 24);
            this.label10.TabIndex = 5;
            this.label10.Text = "價：";
            this.label10.Click += new System.EventHandler(this.label9_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 73);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(105, 24);
            this.label12.TabIndex = 5;
            this.label12.Text = "下單內容：";
            this.label12.Click += new System.EventHandler(this.label9_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 127);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 24);
            this.label9.TabIndex = 5;
            this.label9.Text = "平倉條件：";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // Dlt_btn
            // 
            this.Dlt_btn.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.Dlt_btn.Location = new System.Drawing.Point(728, 17);
            this.Dlt_btn.Name = "Dlt_btn";
            this.Dlt_btn.Size = new System.Drawing.Size(84, 29);
            this.Dlt_btn.TabIndex = 2;
            this.Dlt_btn.Text = "刪除條件";
            this.Dlt_btn.UseVisualStyleBackColor = true;
            this.Dlt_btn.Click += new System.EventHandler(this.button2_Click);
            // 
            // Order_p
            // 
            this.Order_p.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Order_p.FormattingEnabled = true;
            this.Order_p.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Order_p.Items.AddRange(new object[] {
            "買價",
            "賣價",
            "成交價"});
            this.Order_p.Location = new System.Drawing.Point(462, 71);
            this.Order_p.Name = "Order_p";
            this.Order_p.Size = new System.Drawing.Size(77, 32);
            this.Order_p.TabIndex = 0;
            this.Order_p.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // Monitoring_condition
            // 
            this.Monitoring_condition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Monitoring_condition.FormattingEnabled = true;
            this.Monitoring_condition.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Monitoring_condition.Items.AddRange(new object[] {
            "大於等於",
            "小於等於"});
            this.Monitoring_condition.Location = new System.Drawing.Point(265, 15);
            this.Monitoring_condition.Name = "Monitoring_condition";
            this.Monitoring_condition.Size = new System.Drawing.Size(91, 32);
            this.Monitoring_condition.TabIndex = 0;
            this.Monitoring_condition.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // Order_typ
            // 
            this.Order_typ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Order_typ.FormattingEnabled = true;
            this.Order_typ.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Order_typ.Items.AddRange(new object[] {
            "期貨",
            "買權",
            "賣權"});
            this.Order_typ.Location = new System.Drawing.Point(126, 55);
            this.Order_typ.Name = "Order_typ";
            this.Order_typ.Size = new System.Drawing.Size(113, 32);
            this.Order_typ.TabIndex = 0;
            this.Order_typ.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // Monitoring_Target
            // 
            this.Monitoring_Target.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Monitoring_Target.FormattingEnabled = true;
            this.Monitoring_Target.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Monitoring_Target.Items.AddRange(new object[] {
            "台指{0}",
            "台指{1}"
            });
            this.Monitoring_Target.Location = new System.Drawing.Point(126, 15);
            this.Monitoring_Target.Name = "Monitoring_Target";
            this.Monitoring_Target.Size = new System.Drawing.Size(113, 32);
            this.Monitoring_Target.TabIndex = 0;
            this.Monitoring_Target.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // Save_Btn
            // 
            this.Save_Btn.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.Save_Btn.Location = new System.Drawing.Point(728, 52);
            this.Save_Btn.Name = "Save_Btn";
            this.Save_Btn.Size = new System.Drawing.Size(84, 29);
            this.Save_Btn.TabIndex = 0;
            this.Save_Btn.Text = "儲存條件";
            this.Save_Btn.UseVisualStyleBackColor = true;
            this.Save_Btn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 33);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(6);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(6);
            this.tabPage2.Size = new System.Drawing.Size(792, 491);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "others";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 33);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(6);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(792, 491);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "...";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "加權：";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 59);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "台指近1：";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(188, 59);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "摩台指：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(92, 32);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "19283";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(114, 59);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 25);
            this.label5.TabIndex = 6;
            this.label5.Text = "19283";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(290, 59);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 25);
            this.label6.TabIndex = 7;
            this.label6.Text = "19283";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(188, 32);
            this.label19.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(112, 25);
            this.label19.TabIndex = 3;
            this.label19.Text = "台指近2：";
            this.label19.Click += new System.EventHandler(this.label2_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Red;
            this.label20.Location = new System.Drawing.Point(290, 34);
            this.label20.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(76, 25);
            this.label20.TabIndex = 6;
            this.label20.Text = "19283";
            // 
            // Option_month
            // 
            this.Option_month.Location = new System.Drawing.Point(254, 53);
            this.Option_month.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.Option_month.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Option_month.Name = "Option_month";
            this.Option_month.Size = new System.Drawing.Size(88, 33);
            this.Option_month.TabIndex = 1;
            this.Option_month.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Option_month.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(348, 55);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(29, 24);
            this.label21.TabIndex = 14;
            this.label21.Text = "月";
            this.label21.Click += new System.EventHandler(this.label21_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(348, 89);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(48, 24);
            this.label22.TabIndex = 15;
            this.label22.Text = "標的";
            // 
            // buy_or_sell
            // 
            this.buy_or_sell.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.buy_or_sell.FormattingEnabled = true;
            this.buy_or_sell.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buy_or_sell.Items.AddRange(new object[] {
            "買",
            "賣"});
            this.buy_or_sell.Location = new System.Drawing.Point(126, 93);
            this.buy_or_sell.Name = "buy_or_sell";
            this.buy_or_sell.Size = new System.Drawing.Size(113, 32);
            this.buy_or_sell.TabIndex = 0;
            this.buy_or_sell.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 637);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.queryBtn);
            this.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "MainPage";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "MainPage";
            this.Load += new System.EventHandler(this.MainPage_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.conditionPanel.ResumeLayout(false);
            this.conditionPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Order_q)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.delay_sec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Offset_point)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Option_target)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Trigger_point)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Option_month)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button queryBtn;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView SavedListView;
        private System.Windows.Forms.Panel conditionPanel;
        private System.Windows.Forms.Button Dlt_btn;
        private System.Windows.Forms.Button Save_Btn;
        private System.Windows.Forms.ComboBox Monitoring_Target;
        private System.Windows.Forms.NumericUpDown Trigger_point;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox Monitoring_condition;
        private System.Windows.Forms.NumericUpDown Order_q;
        private System.Windows.Forms.NumericUpDown Option_target;
        private System.Windows.Forms.ComboBox Order_typ;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown Offset_point;
        private System.Windows.Forms.DateTimePicker Valid_duration;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown delay_sec;
        private System.Windows.Forms.ComboBox Order_p;
        private System.Windows.Forms.CheckBox loop_or_not;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.NumericUpDown Option_month;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox buy_or_sell;
    }
}