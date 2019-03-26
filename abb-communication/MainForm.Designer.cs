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
            this.Button_MoveByOffset = new System.Windows.Forms.Button();
            this.Button_Rapid = new System.Windows.Forms.Button();
            this.Label_X = new System.Windows.Forms.Label();
            this.Label_Y = new System.Windows.Forms.Label();
            this.Label_Z = new System.Windows.Forms.Label();
            this.Button_Scan = new System.Windows.Forms.Button();
            this.LogBox = new System.Windows.Forms.TextBox();
            this.GroupBox_MoveByOffset = new System.Windows.Forms.GroupBox();
            this.NumericBox_OffsetZ = new Forms.NumericBox();
            this.NumericBox_OffsetY = new Forms.NumericBox();
            this.NumericBox_OffsetX = new Forms.NumericBox();
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
            this.RadioButton_XZ = new System.Windows.Forms.RadioButton();
            this.RadioButton_YZ = new System.Windows.Forms.RadioButton();
            this.RadioButton_XY = new System.Windows.Forms.RadioButton();
            this.GroupBox_DrawPlane = new System.Windows.Forms.GroupBox();
            this.GroupBox_Move = new System.Windows.Forms.GroupBox();
            this.NumericBox_PositionZ = new Forms.NumericBox();
            this.NumericBox_PositionY = new Forms.NumericBox();
            this.NumericBox_PositionX = new Forms.NumericBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Button_MoveToPosition = new System.Windows.Forms.Button();
            this.GroupBox_MoveByOffset.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBox_OffsetZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBox_OffsetY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBox_OffsetX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid_Controllers)).BeginInit();
            this.GroupBox_Circle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBox_CircleRadius)).BeginInit();
            this.GroupBox_DrawPlane.SuspendLayout();
            this.GroupBox_Move.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBox_PositionZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBox_PositionY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBox_PositionX)).BeginInit();
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
            // Button_MoveByOffset
            // 
            this.Button_MoveByOffset.Location = new System.Drawing.Point(26, 99);
            this.Button_MoveByOffset.Name = "Button_MoveByOffset";
            this.Button_MoveByOffset.Size = new System.Drawing.Size(107, 23);
            this.Button_MoveByOffset.TabIndex = 7;
            this.Button_MoveByOffset.Text = "Send command";
            this.Button_MoveByOffset.UseVisualStyleBackColor = true;
            this.Button_MoveByOffset.Click += new System.EventHandler(this.Button_MoveByOffset_Click);
            // 
            // Button_Rapid
            // 
            this.Button_Rapid.Enabled = false;
            this.Button_Rapid.Location = new System.Drawing.Point(174, 109);
            this.Button_Rapid.Name = "Button_Rapid";
            this.Button_Rapid.Size = new System.Drawing.Size(75, 23);
            this.Button_Rapid.TabIndex = 8;
            this.Button_Rapid.Text = "Start RAPID";
            this.Button_Rapid.UseVisualStyleBackColor = true;
            this.Button_Rapid.Click += new System.EventHandler(this.Button_Rapid_Click);
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
            this.LogBox.Size = new System.Drawing.Size(346, 215);
            this.LogBox.TabIndex = 17;
            // 
            // GroupBox_MoveByOffset
            // 
            this.GroupBox_MoveByOffset.Controls.Add(this.NumericBox_OffsetZ);
            this.GroupBox_MoveByOffset.Controls.Add(this.NumericBox_OffsetY);
            this.GroupBox_MoveByOffset.Controls.Add(this.NumericBox_OffsetX);
            this.GroupBox_MoveByOffset.Controls.Add(this.Label_X);
            this.GroupBox_MoveByOffset.Controls.Add(this.Label_Y);
            this.GroupBox_MoveByOffset.Controls.Add(this.Label_Z);
            this.GroupBox_MoveByOffset.Controls.Add(this.Button_MoveByOffset);
            this.GroupBox_MoveByOffset.Location = new System.Drawing.Point(521, 138);
            this.GroupBox_MoveByOffset.Name = "GroupBox_MoveByOffset";
            this.GroupBox_MoveByOffset.Size = new System.Drawing.Size(139, 131);
            this.GroupBox_MoveByOffset.TabIndex = 18;
            this.GroupBox_MoveByOffset.TabStop = false;
            this.GroupBox_MoveByOffset.Text = "Move by offset";
            // 
            // NumericBox_OffsetZ
            // 
            this.NumericBox_OffsetZ.CueText = null;
            this.NumericBox_OffsetZ.Location = new System.Drawing.Point(26, 73);
            this.NumericBox_OffsetZ.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.NumericBox_OffsetZ.Name = "NumericBox_OffsetZ";
            this.NumericBox_OffsetZ.Size = new System.Drawing.Size(107, 20);
            this.NumericBox_OffsetZ.TabIndex = 18;
            // 
            // NumericBox_OffsetY
            // 
            this.NumericBox_OffsetY.CueText = null;
            this.NumericBox_OffsetY.Location = new System.Drawing.Point(26, 47);
            this.NumericBox_OffsetY.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.NumericBox_OffsetY.Name = "NumericBox_OffsetY";
            this.NumericBox_OffsetY.Size = new System.Drawing.Size(107, 20);
            this.NumericBox_OffsetY.TabIndex = 17;
            // 
            // NumericBox_OffsetX
            // 
            this.NumericBox_OffsetX.CueText = null;
            this.NumericBox_OffsetX.Location = new System.Drawing.Point(26, 21);
            this.NumericBox_OffsetX.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.NumericBox_OffsetX.Name = "NumericBox_OffsetX";
            this.NumericBox_OffsetX.Size = new System.Drawing.Size(107, 20);
            this.NumericBox_OffsetX.TabIndex = 16;
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
            this.GroupBox_Circle.Location = new System.Drawing.Point(521, 275);
            this.GroupBox_Circle.Name = "GroupBox_Circle";
            this.GroupBox_Circle.Size = new System.Drawing.Size(149, 78);
            this.GroupBox_Circle.TabIndex = 20;
            this.GroupBox_Circle.TabStop = false;
            this.GroupBox_Circle.Text = "Circle";
            // 
            // NumericBox_CircleRadius
            // 
            this.NumericBox_CircleRadius.CueText = null;
            this.NumericBox_CircleRadius.Location = new System.Drawing.Point(52, 21);
            this.NumericBox_CircleRadius.Name = "NumericBox_CircleRadius";
            this.NumericBox_CircleRadius.Size = new System.Drawing.Size(91, 20);
            this.NumericBox_CircleRadius.TabIndex = 13;
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
            this.Button_Circle.Location = new System.Drawing.Point(52, 47);
            this.Button_Circle.Name = "Button_Circle";
            this.Button_Circle.Size = new System.Drawing.Size(91, 23);
            this.Button_Circle.TabIndex = 13;
            this.Button_Circle.Text = "Send command";
            this.Button_Circle.UseVisualStyleBackColor = true;
            this.Button_Circle.Click += new System.EventHandler(this.Button_Circle_Click);
            // 
            // RadioButton_XZ
            // 
            this.RadioButton_XZ.AutoSize = true;
            this.RadioButton_XZ.Enabled = false;
            this.RadioButton_XZ.Location = new System.Drawing.Point(100, 22);
            this.RadioButton_XZ.Margin = new System.Windows.Forms.Padding(2);
            this.RadioButton_XZ.Name = "RadioButton_XZ";
            this.RadioButton_XZ.Size = new System.Drawing.Size(39, 17);
            this.RadioButton_XZ.TabIndex = 21;
            this.RadioButton_XZ.TabStop = true;
            this.RadioButton_XZ.Text = "XZ";
            this.RadioButton_XZ.UseVisualStyleBackColor = true;
            // 
            // RadioButton_YZ
            // 
            this.RadioButton_YZ.AutoSize = true;
            this.RadioButton_YZ.Location = new System.Drawing.Point(57, 22);
            this.RadioButton_YZ.Margin = new System.Windows.Forms.Padding(2);
            this.RadioButton_YZ.Name = "RadioButton_YZ";
            this.RadioButton_YZ.Size = new System.Drawing.Size(39, 17);
            this.RadioButton_YZ.TabIndex = 21;
            this.RadioButton_YZ.TabStop = true;
            this.RadioButton_YZ.Text = "YZ";
            this.RadioButton_YZ.UseVisualStyleBackColor = true;
            // 
            // RadioButton_XY
            // 
            this.RadioButton_XY.AutoSize = true;
            this.RadioButton_XY.Checked = true;
            this.RadioButton_XY.Location = new System.Drawing.Point(14, 22);
            this.RadioButton_XY.Margin = new System.Windows.Forms.Padding(2);
            this.RadioButton_XY.Name = "RadioButton_XY";
            this.RadioButton_XY.Size = new System.Drawing.Size(39, 17);
            this.RadioButton_XY.TabIndex = 21;
            this.RadioButton_XY.TabStop = true;
            this.RadioButton_XY.Text = "XY";
            this.RadioButton_XY.UseVisualStyleBackColor = true;
            // 
            // GroupBox_DrawPlane
            // 
            this.GroupBox_DrawPlane.Controls.Add(this.RadioButton_XZ);
            this.GroupBox_DrawPlane.Controls.Add(this.RadioButton_YZ);
            this.GroupBox_DrawPlane.Controls.Add(this.RadioButton_XY);
            this.GroupBox_DrawPlane.Location = new System.Drawing.Point(366, 138);
            this.GroupBox_DrawPlane.Name = "GroupBox_DrawPlane";
            this.GroupBox_DrawPlane.Size = new System.Drawing.Size(149, 49);
            this.GroupBox_DrawPlane.TabIndex = 22;
            this.GroupBox_DrawPlane.TabStop = false;
            this.GroupBox_DrawPlane.Text = "Plane";
            // 
            // GroupBox_Move
            // 
            this.GroupBox_Move.Controls.Add(this.NumericBox_PositionZ);
            this.GroupBox_Move.Controls.Add(this.NumericBox_PositionY);
            this.GroupBox_Move.Controls.Add(this.NumericBox_PositionX);
            this.GroupBox_Move.Controls.Add(this.label1);
            this.GroupBox_Move.Controls.Add(this.label2);
            this.GroupBox_Move.Controls.Add(this.label3);
            this.GroupBox_Move.Controls.Add(this.Button_MoveToPosition);
            this.GroupBox_Move.Location = new System.Drawing.Point(366, 222);
            this.GroupBox_Move.Name = "GroupBox_Move";
            this.GroupBox_Move.Size = new System.Drawing.Size(149, 131);
            this.GroupBox_Move.TabIndex = 19;
            this.GroupBox_Move.TabStop = false;
            this.GroupBox_Move.Text = "Move to position";
            // 
            // NumericBox_PositionZ
            // 
            this.NumericBox_PositionZ.CueText = null;
            this.NumericBox_PositionZ.Location = new System.Drawing.Point(26, 73);
            this.NumericBox_PositionZ.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.NumericBox_PositionZ.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            -2147483648});
            this.NumericBox_PositionZ.Name = "NumericBox_PositionZ";
            this.NumericBox_PositionZ.Size = new System.Drawing.Size(117, 20);
            this.NumericBox_PositionZ.TabIndex = 18;
            // 
            // NumericBox_PositionY
            // 
            this.NumericBox_PositionY.CueText = null;
            this.NumericBox_PositionY.Location = new System.Drawing.Point(26, 47);
            this.NumericBox_PositionY.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.NumericBox_PositionY.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            -2147483648});
            this.NumericBox_PositionY.Name = "NumericBox_PositionY";
            this.NumericBox_PositionY.Size = new System.Drawing.Size(117, 20);
            this.NumericBox_PositionY.TabIndex = 17;
            // 
            // NumericBox_PositionX
            // 
            this.NumericBox_PositionX.CueText = null;
            this.NumericBox_PositionX.Location = new System.Drawing.Point(26, 21);
            this.NumericBox_PositionX.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.NumericBox_PositionX.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            -2147483648});
            this.NumericBox_PositionX.Name = "NumericBox_PositionX";
            this.NumericBox_PositionX.Size = new System.Drawing.Size(117, 20);
            this.NumericBox_PositionX.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Z";
            // 
            // Button_MoveToPosition
            // 
            this.Button_MoveToPosition.Location = new System.Drawing.Point(26, 99);
            this.Button_MoveToPosition.Name = "Button_MoveToPosition";
            this.Button_MoveToPosition.Size = new System.Drawing.Size(117, 23);
            this.Button_MoveToPosition.TabIndex = 7;
            this.Button_MoveToPosition.Text = "Send command";
            this.Button_MoveToPosition.UseVisualStyleBackColor = true;
            this.Button_MoveToPosition.Click += new System.EventHandler(this.Button_MoveToPosition_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 362);
            this.Controls.Add(this.GroupBox_Move);
            this.Controls.Add(this.GroupBox_DrawPlane);
            this.Controls.Add(this.GroupBox_Circle);
            this.Controls.Add(this.DataGrid_Controllers);
            this.Controls.Add(this.GroupBox_MoveByOffset);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.Button_Scan);
            this.Controls.Add(this.Button_Rapid);
            this.Controls.Add(this.Button_Connection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainForm";
            this.Text = "ABB robot controller manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.GroupBox_MoveByOffset.ResumeLayout(false);
            this.GroupBox_MoveByOffset.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBox_OffsetZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBox_OffsetY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBox_OffsetX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid_Controllers)).EndInit();
            this.GroupBox_Circle.ResumeLayout(false);
            this.GroupBox_Circle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBox_CircleRadius)).EndInit();
            this.GroupBox_DrawPlane.ResumeLayout(false);
            this.GroupBox_DrawPlane.PerformLayout();
            this.GroupBox_Move.ResumeLayout(false);
            this.GroupBox_Move.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBox_PositionZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBox_PositionY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBox_PositionX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Button_Connection;
        private System.Windows.Forms.Button Button_MoveByOffset;
        private System.Windows.Forms.Button Button_Rapid;
        private System.Windows.Forms.Label Label_X;
        private System.Windows.Forms.Label Label_Y;
        private System.Windows.Forms.Label Label_Z;
        private System.Windows.Forms.Button Button_Scan;
        private System.Windows.Forms.TextBox LogBox;
        private System.Windows.Forms.GroupBox GroupBox_MoveByOffset;
        private Forms.NumericBox NumericBox_OffsetZ;
        private Forms.NumericBox NumericBox_OffsetY;
        private Forms.NumericBox NumericBox_OffsetX;
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
        private System.Windows.Forms.RadioButton RadioButton_XZ;
        private System.Windows.Forms.RadioButton RadioButton_YZ;
        private System.Windows.Forms.RadioButton RadioButton_XY;
        private System.Windows.Forms.GroupBox GroupBox_DrawPlane;
        private System.Windows.Forms.GroupBox GroupBox_Move;
        private Forms.NumericBox NumericBox_PositionZ;
        private Forms.NumericBox NumericBox_PositionY;
        private Forms.NumericBox NumericBox_PositionX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Button_MoveToPosition;
    }
}

