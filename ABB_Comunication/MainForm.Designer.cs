namespace ABB_Comunication
{
    partial class MainForm
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
            this.Button_Connection = new System.Windows.Forms.Button();
            this.Button_Move = new System.Windows.Forms.Button();
            this.Button_StartRapid = new System.Windows.Forms.Button();
            this.Button_StopRapid = new System.Windows.Forms.Button();
            this.Label_X = new System.Windows.Forms.Label();
            this.Label_Y = new System.Windows.Forms.Label();
            this.Label_Z = new System.Windows.Forms.Label();
            this.Button_Square = new System.Windows.Forms.Button();
            this.Label_SquareSide = new System.Windows.Forms.Label();
            this.Button_Scan = new System.Windows.Forms.Button();
            this.LogBox = new System.Windows.Forms.TextBox();
            this.GroupBox_Move = new System.Windows.Forms.GroupBox();
            this.NumericBox_Z = new Forms.NumericBox();
            this.NumericBox_Y = new Forms.NumericBox();
            this.NumericBox_X = new Forms.NumericBox();
            this.GroupBox_Square = new System.Windows.Forms.GroupBox();
            this.NumericBox_SquareSide = new Forms.NumericBox();
            this.DataGrid_Controllers = new System.Windows.Forms.DataGridView();
            this.Column_IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Availability = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_SystemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ControllerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupBox_Circle = new System.Windows.Forms.GroupBox();
            this.NumericBox_CircleRadius = new Forms.NumericBox();
            this.Label_CircleRadius = new System.Windows.Forms.Label();
            this.Button_Circle = new System.Windows.Forms.Button();
            this.GroupBox_Move.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBox_Z)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBox_Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBox_X)).BeginInit();
            this.GroupBox_Square.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBox_SquareSide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid_Controllers)).BeginInit();
            this.GroupBox_Circle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBox_CircleRadius)).BeginInit();
            this.SuspendLayout();
            // 
            // Button_Connection
            // 
            this.Button_Connection.Enabled = false;
            this.Button_Connection.Location = new System.Drawing.Point(12, 109);
            this.Button_Connection.Name = "Button_Connection";
            this.Button_Connection.Size = new System.Drawing.Size(75, 23);
            this.Button_Connection.TabIndex = 1;
            this.Button_Connection.Text = "Connect";
            this.Button_Connection.UseVisualStyleBackColor = true;
            this.Button_Connection.Click += new System.EventHandler(this.Button_Connection_Click);
            // 
            // Button_Move
            // 
            this.Button_Move.Enabled = false;
            this.Button_Move.Location = new System.Drawing.Point(26, 99);
            this.Button_Move.Name = "Button_Move";
            this.Button_Move.Size = new System.Drawing.Size(90, 23);
            this.Button_Move.TabIndex = 7;
            this.Button_Move.Text = "Send command";
            this.Button_Move.UseVisualStyleBackColor = true;
            this.Button_Move.Click += new System.EventHandler(this.Button_Move_Click);
            // 
            // Button_StartRapid
            // 
            this.Button_StartRapid.Enabled = false;
            this.Button_StartRapid.Location = new System.Drawing.Point(174, 109);
            this.Button_StartRapid.Name = "Button_StartRapid";
            this.Button_StartRapid.Size = new System.Drawing.Size(75, 23);
            this.Button_StartRapid.TabIndex = 8;
            this.Button_StartRapid.Text = "Start RAPID";
            this.Button_StartRapid.UseVisualStyleBackColor = true;
            this.Button_StartRapid.Click += new System.EventHandler(this.Button_StartRapid_Click);
            // 
            // Button_StopRapid
            // 
            this.Button_StopRapid.Enabled = false;
            this.Button_StopRapid.Location = new System.Drawing.Point(255, 109);
            this.Button_StopRapid.Name = "Button_StopRapid";
            this.Button_StopRapid.Size = new System.Drawing.Size(75, 23);
            this.Button_StopRapid.TabIndex = 9;
            this.Button_StopRapid.Text = "Stop RAPID";
            this.Button_StopRapid.UseVisualStyleBackColor = true;
            this.Button_StopRapid.Click += new System.EventHandler(this.Button_StopRapid_Click);
            // 
            // Label_X
            // 
            this.Label_X.AutoSize = true;
            this.Label_X.Location = new System.Drawing.Point(6, 23);
            this.Label_X.Name = "Label_X";
            this.Label_X.Size = new System.Drawing.Size(14, 13);
            this.Label_X.TabIndex = 10;
            this.Label_X.Text = "X";
            // 
            // Label_Y
            // 
            this.Label_Y.AutoSize = true;
            this.Label_Y.Location = new System.Drawing.Point(6, 49);
            this.Label_Y.Name = "Label_Y";
            this.Label_Y.Size = new System.Drawing.Size(14, 13);
            this.Label_Y.TabIndex = 11;
            this.Label_Y.Text = "Y";
            // 
            // Label_Z
            // 
            this.Label_Z.AutoSize = true;
            this.Label_Z.Location = new System.Drawing.Point(6, 75);
            this.Label_Z.Name = "Label_Z";
            this.Label_Z.Size = new System.Drawing.Size(14, 13);
            this.Label_Z.TabIndex = 12;
            this.Label_Z.Text = "Z";
            // 
            // Button_Square
            // 
            this.Button_Square.Enabled = false;
            this.Button_Square.Location = new System.Drawing.Point(52, 46);
            this.Button_Square.Name = "Button_Square";
            this.Button_Square.Size = new System.Drawing.Size(91, 23);
            this.Button_Square.TabIndex = 13;
            this.Button_Square.Text = "Send command";
            this.Button_Square.UseVisualStyleBackColor = true;
            this.Button_Square.Click += new System.EventHandler(this.Button_Square_Click);
            // 
            // Label_SquareSide
            // 
            this.Label_SquareSide.AutoSize = true;
            this.Label_SquareSide.Location = new System.Drawing.Point(6, 23);
            this.Label_SquareSide.Name = "Label_SquareSide";
            this.Label_SquareSide.Size = new System.Drawing.Size(28, 13);
            this.Label_SquareSide.TabIndex = 15;
            this.Label_SquareSide.Text = "Side";
            // 
            // Button_Scan
            // 
            this.Button_Scan.Location = new System.Drawing.Point(93, 109);
            this.Button_Scan.Name = "Button_Scan";
            this.Button_Scan.Size = new System.Drawing.Size(75, 23);
            this.Button_Scan.TabIndex = 16;
            this.Button_Scan.Text = "Scan";
            this.Button_Scan.UseVisualStyleBackColor = true;
            this.Button_Scan.Click += new System.EventHandler(this.Button_Scan_Click);
            // 
            // LogBox
            // 
            this.LogBox.Location = new System.Drawing.Point(12, 138);
            this.LogBox.Multiline = true;
            this.LogBox.Name = "LogBox";
            this.LogBox.ReadOnly = true;
            this.LogBox.Size = new System.Drawing.Size(346, 174);
            this.LogBox.TabIndex = 17;
            // 
            // GroupBox_Move
            // 
            this.GroupBox_Move.Controls.Add(this.NumericBox_Z);
            this.GroupBox_Move.Controls.Add(this.NumericBox_Y);
            this.GroupBox_Move.Controls.Add(this.NumericBox_X);
            this.GroupBox_Move.Controls.Add(this.Label_X);
            this.GroupBox_Move.Controls.Add(this.Label_Y);
            this.GroupBox_Move.Controls.Add(this.Label_Z);
            this.GroupBox_Move.Controls.Add(this.Button_Move);
            this.GroupBox_Move.Location = new System.Drawing.Point(377, 138);
            this.GroupBox_Move.Name = "GroupBox_Move";
            this.GroupBox_Move.Size = new System.Drawing.Size(122, 131);
            this.GroupBox_Move.TabIndex = 18;
            this.GroupBox_Move.TabStop = false;
            this.GroupBox_Move.Text = "Move";
            // 
            // NumericBox_Z
            // 
            this.NumericBox_Z.CueText = null;
            this.NumericBox_Z.Location = new System.Drawing.Point(26, 73);
            this.NumericBox_Z.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.NumericBox_Z.Name = "NumericBox_Z";
            this.NumericBox_Z.Size = new System.Drawing.Size(90, 20);
            this.NumericBox_Z.TabIndex = 18;
            this.NumericBox_Z.ValueChanged += new System.EventHandler(this.NumericBox_Z_ValueChanged);
            // 
            // NumericBox_Y
            // 
            this.NumericBox_Y.CueText = null;
            this.NumericBox_Y.Location = new System.Drawing.Point(26, 47);
            this.NumericBox_Y.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.NumericBox_Y.Name = "NumericBox_Y";
            this.NumericBox_Y.Size = new System.Drawing.Size(90, 20);
            this.NumericBox_Y.TabIndex = 17;
            this.NumericBox_Y.ValueChanged += new System.EventHandler(this.NumericBox_Y_ValueChanged);
            // 
            // NumericBox_X
            // 
            this.NumericBox_X.CueText = null;
            this.NumericBox_X.Location = new System.Drawing.Point(26, 21);
            this.NumericBox_X.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.NumericBox_X.Name = "NumericBox_X";
            this.NumericBox_X.Size = new System.Drawing.Size(90, 20);
            this.NumericBox_X.TabIndex = 16;
            this.NumericBox_X.ValueChanged += new System.EventHandler(this.NumericBox_X_ValueChanged);
            // 
            // GroupBox_Square
            // 
            this.GroupBox_Square.Controls.Add(this.NumericBox_SquareSide);
            this.GroupBox_Square.Controls.Add(this.Label_SquareSide);
            this.GroupBox_Square.Controls.Add(this.Button_Square);
            this.GroupBox_Square.Location = new System.Drawing.Point(505, 219);
            this.GroupBox_Square.Name = "GroupBox_Square";
            this.GroupBox_Square.Size = new System.Drawing.Size(149, 75);
            this.GroupBox_Square.TabIndex = 19;
            this.GroupBox_Square.TabStop = false;
            this.GroupBox_Square.Text = "Square";
            // 
            // NumericBox_SquareSide
            // 
            this.NumericBox_SquareSide.CueText = null;
            this.NumericBox_SquareSide.Location = new System.Drawing.Point(52, 21);
            this.NumericBox_SquareSide.Name = "NumericBox_SquareSide";
            this.NumericBox_SquareSide.Size = new System.Drawing.Size(91, 20);
            this.NumericBox_SquareSide.TabIndex = 13;
            this.NumericBox_SquareSide.ValueChanged += new System.EventHandler(this.NumericBox_SquareSide_ValueChanged);
            // 
            // DataGrid_Controllers
            // 
            this.DataGrid_Controllers.AllowUserToAddRows = false;
            this.DataGrid_Controllers.AllowUserToDeleteRows = false;
            this.DataGrid_Controllers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGrid_Controllers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_IP,
            this.Column_ID,
            this.Column_Availability,
            this.Column_SystemName,
            this.Column_Version,
            this.Column_ControllerName});
            this.DataGrid_Controllers.Location = new System.Drawing.Point(12, 12);
            this.DataGrid_Controllers.MultiSelect = false;
            this.DataGrid_Controllers.Name = "DataGrid_Controllers";
            this.DataGrid_Controllers.ReadOnly = true;
            this.DataGrid_Controllers.RowHeadersVisible = false;
            this.DataGrid_Controllers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGrid_Controllers.Size = new System.Drawing.Size(654, 91);
            this.DataGrid_Controllers.TabIndex = 20;
            this.DataGrid_Controllers.SelectionChanged += new System.EventHandler(this.DataGrid_Controllers_SelectionChanged);
            // 
            // Column_IP
            // 
            this.Column_IP.HeaderText = "IP Address";
            this.Column_IP.Name = "Column_IP";
            this.Column_IP.ReadOnly = true;
            // 
            // Column_ID
            // 
            this.Column_ID.HeaderText = "ID";
            this.Column_ID.Name = "Column_ID";
            this.Column_ID.ReadOnly = true;
            this.Column_ID.Width = 50;
            // 
            // Column_Availability
            // 
            this.Column_Availability.HeaderText = "Availability";
            this.Column_Availability.Name = "Column_Availability";
            this.Column_Availability.ReadOnly = true;
            // 
            // Column_SystemName
            // 
            this.Column_SystemName.HeaderText = "System Name";
            this.Column_SystemName.Name = "Column_SystemName";
            this.Column_SystemName.ReadOnly = true;
            // 
            // Column_Version
            // 
            this.Column_Version.HeaderText = "RobotWare Version";
            this.Column_Version.Name = "Column_Version";
            this.Column_Version.ReadOnly = true;
            this.Column_Version.Width = 150;
            // 
            // Column_ControllerName
            // 
            this.Column_ControllerName.HeaderText = "Controller Name";
            this.Column_ControllerName.Name = "Column_ControllerName";
            this.Column_ControllerName.ReadOnly = true;
            this.Column_ControllerName.Width = 150;
            // 
            // GroupBox_Circle
            // 
            this.GroupBox_Circle.Controls.Add(this.NumericBox_CircleRadius);
            this.GroupBox_Circle.Controls.Add(this.Label_CircleRadius);
            this.GroupBox_Circle.Controls.Add(this.Button_Circle);
            this.GroupBox_Circle.Location = new System.Drawing.Point(505, 138);
            this.GroupBox_Circle.Name = "GroupBox_Circle";
            this.GroupBox_Circle.Size = new System.Drawing.Size(149, 75);
            this.GroupBox_Circle.TabIndex = 20;
            this.GroupBox_Circle.TabStop = false;
            this.GroupBox_Circle.Text = "Circle";
            // 
            // NumericBox_CircleRadius
            // 
            this.NumericBox_CircleRadius.CueText = null;
            this.NumericBox_CircleRadius.Location = new System.Drawing.Point(52, 21);
            this.NumericBox_CircleRadius.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.NumericBox_CircleRadius.Name = "NumericBox_CircleRadius";
            this.NumericBox_CircleRadius.Size = new System.Drawing.Size(91, 20);
            this.NumericBox_CircleRadius.TabIndex = 13;
            this.NumericBox_CircleRadius.ValueChanged += new System.EventHandler(this.NumericBox_CircleRadius_ValueChanged);
            // 
            // Label_CircleRadius
            // 
            this.Label_CircleRadius.AutoSize = true;
            this.Label_CircleRadius.Location = new System.Drawing.Point(6, 23);
            this.Label_CircleRadius.Name = "Label_CircleRadius";
            this.Label_CircleRadius.Size = new System.Drawing.Size(40, 13);
            this.Label_CircleRadius.TabIndex = 15;
            this.Label_CircleRadius.Text = "Radius";
            // 
            // Button_Circle
            // 
            this.Button_Circle.Location = new System.Drawing.Point(52, 44);
            this.Button_Circle.Name = "Button_Circle";
            this.Button_Circle.Size = new System.Drawing.Size(91, 23);
            this.Button_Circle.TabIndex = 13;
            this.Button_Circle.Text = "Send command";
            this.Button_Circle.UseVisualStyleBackColor = true;
            this.Button_Circle.Click += new System.EventHandler(this.Button_Circle_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 327);
            this.Controls.Add(this.GroupBox_Circle);
            this.Controls.Add(this.DataGrid_Controllers);
            this.Controls.Add(this.GroupBox_Square);
            this.Controls.Add(this.GroupBox_Move);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.Button_Scan);
            this.Controls.Add(this.Button_StopRapid);
            this.Controls.Add(this.Button_StartRapid);
            this.Controls.Add(this.Button_Connection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainForm";
            this.Text = "ABB robot controller manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.GroupBox_Move.ResumeLayout(false);
            this.GroupBox_Move.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBox_Z)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBox_Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBox_X)).EndInit();
            this.GroupBox_Square.ResumeLayout(false);
            this.GroupBox_Square.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBox_SquareSide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid_Controllers)).EndInit();
            this.GroupBox_Circle.ResumeLayout(false);
            this.GroupBox_Circle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBox_CircleRadius)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Button_Connection;
        private System.Windows.Forms.Button Button_Move;
        private System.Windows.Forms.Button Button_StartRapid;
        private System.Windows.Forms.Button Button_StopRapid;
        private System.Windows.Forms.Label Label_X;
        private System.Windows.Forms.Label Label_Y;
        private System.Windows.Forms.Label Label_Z;
        private System.Windows.Forms.Button Button_Square;
        private System.Windows.Forms.Label Label_SquareSide;
        private System.Windows.Forms.Button Button_Scan;
        private System.Windows.Forms.TextBox LogBox;
        private System.Windows.Forms.GroupBox GroupBox_Move;
        private System.Windows.Forms.GroupBox GroupBox_Square;
        private Forms.NumericBox NumericBox_SquareSide;
        private Forms.NumericBox NumericBox_Z;
        private Forms.NumericBox NumericBox_Y;
        private Forms.NumericBox NumericBox_X;
        private System.Windows.Forms.DataGridView DataGrid_Controllers;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_IP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Availability;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_SystemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Version;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ControllerName;
        private System.Windows.Forms.GroupBox GroupBox_Circle;
        private Forms.NumericBox NumericBox_CircleRadius;
        private System.Windows.Forms.Label Label_CircleRadius;
        private System.Windows.Forms.Button Button_Circle;
    }
}

