﻿namespace ou_care.AdminUC
{
    partial class ActivityLog_UC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.cboActionType = new System.Windows.Forms.ComboBox();
            this.cboUsers = new System.Windows.Forms.ComboBox();
            this.cboEntityType = new System.Windows.Forms.ComboBox();
            this.dgvLogs = new System.Windows.Forms.DataGridView();
            this.lblTotalRecords = new System.Windows.Forms.Label();
            this.btnApplyFilter = new System.Windows.Forms.Button();
            this.btnExportPDF = new System.Windows.Forms.Button();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3_39_Khanh = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndDate.CustomFormat = "MMM dd, yyyy";
            this.dtpEndDate.Enabled = false;
            this.dtpEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(726, 44);
            this.dtpEndDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(183, 23);
            this.dtpEndDate.TabIndex = 39;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "MMM dd, yyyy";
            this.dtpStartDate.Enabled = false;
            this.dtpStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(531, 44);
            this.dtpStartDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(187, 23);
            this.dtpStartDate.TabIndex = 38;
            this.dtpStartDate.Value = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
            // 
            // cboActionType
            // 
            this.cboActionType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboActionType.FormattingEnabled = true;
            this.cboActionType.Location = new System.Drawing.Point(413, 137);
            this.cboActionType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboActionType.Name = "cboActionType";
            this.cboActionType.Size = new System.Drawing.Size(160, 28);
            this.cboActionType.TabIndex = 40;
            this.cboActionType.SelectedIndexChanged += new System.EventHandler(this.cboActionType_SelectedIndexChanged);
            // 
            // cboUsers
            // 
            this.cboUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboUsers.FormattingEnabled = true;
            this.cboUsers.Location = new System.Drawing.Point(581, 137);
            this.cboUsers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboUsers.Name = "cboUsers";
            this.cboUsers.Size = new System.Drawing.Size(160, 28);
            this.cboUsers.TabIndex = 41;
            // 
            // cboEntityType
            // 
            this.cboEntityType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEntityType.FormattingEnabled = true;
            this.cboEntityType.Location = new System.Drawing.Point(749, 137);
            this.cboEntityType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboEntityType.Name = "cboEntityType";
            this.cboEntityType.Size = new System.Drawing.Size(160, 28);
            this.cboEntityType.TabIndex = 42;
            // 
            // dgvLogs
            // 
            this.dgvLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLogs.Location = new System.Drawing.Point(28, 247);
            this.dgvLogs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvLogs.Name = "dgvLogs";
            this.dgvLogs.RowHeadersWidth = 51;
            this.dgvLogs.Size = new System.Drawing.Size(891, 469);
            this.dgvLogs.TabIndex = 43;
            this.dgvLogs.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLogs_CellClick);
            // 
            // lblTotalRecords
            // 
            this.lblTotalRecords.AutoSize = true;
            this.lblTotalRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRecords.ForeColor = System.Drawing.Color.Navy;
            this.lblTotalRecords.Location = new System.Drawing.Point(24, 214);
            this.lblTotalRecords.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalRecords.Name = "lblTotalRecords";
            this.lblTotalRecords.Size = new System.Drawing.Size(53, 20);
            this.lblTotalRecords.TabIndex = 44;
            this.lblTotalRecords.Text = "label1";
            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.BackColor = System.Drawing.Color.Navy;
            this.btnApplyFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplyFilter.ForeColor = System.Drawing.Color.White;
            this.btnApplyFilter.Location = new System.Drawing.Point(787, 183);
            this.btnApplyFilter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(122, 39);
            this.btnApplyFilter.TabIndex = 45;
            this.btnApplyFilter.Text = "Lọc";
            this.btnApplyFilter.UseVisualStyleBackColor = false;
            this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
            // 
            // btnExportPDF
            // 
            this.btnExportPDF.BackColor = System.Drawing.Color.Navy;
            this.btnExportPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportPDF.ForeColor = System.Drawing.Color.White;
            this.btnExportPDF.Location = new System.Drawing.Point(161, 132);
            this.btnExportPDF.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExportPDF.Name = "btnExportPDF";
            this.btnExportPDF.Size = new System.Drawing.Size(124, 37);
            this.btnExportPDF.TabIndex = 46;
            this.btnExportPDF.Text = "Xuất PDF";
            this.btnExportPDF.UseVisualStyleBackColor = false;
            this.btnExportPDF.Click += new System.EventHandler(this.btnExportPDF_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.BackColor = System.Drawing.Color.Navy;
            this.btnExportExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportExcel.Location = new System.Drawing.Point(28, 132);
            this.btnExportExcel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(125, 37);
            this.btnExportExcel.TabIndex = 47;
            this.btnExportExcel.Text = "Xuất Excel";
            this.btnExportExcel.UseVisualStyleBackColor = false;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(21, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(336, 38);
            this.label1.TabIndex = 48;
            this.label1.Text = "THEO DÕI HOẠT ĐỘNG";
            // 
            // label3_39_Khanh
            // 
            this.label3_39_Khanh.AutoSize = true;
            this.label3_39_Khanh.BackColor = System.Drawing.Color.Transparent;
            this.label3_39_Khanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3_39_Khanh.ForeColor = System.Drawing.Color.Navy;
            this.label3_39_Khanh.Location = new System.Drawing.Point(409, 104);
            this.label3_39_Khanh.Name = "label3_39_Khanh";
            this.label3_39_Khanh.Size = new System.Drawing.Size(81, 20);
            this.label3_39_Khanh.TabIndex = 49;
            this.label3_39_Khanh.Text = "Tài khoản";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(577, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 50;
            this.label2.Text = "Tài khoản";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(745, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 20);
            this.label3.TabIndex = 51;
            this.label3.Text = "Tài khoản";
            // 
            // ActivityLog_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3_39_Khanh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.btnExportPDF);
            this.Controls.Add(this.btnApplyFilter);
            this.Controls.Add(this.lblTotalRecords);
            this.Controls.Add(this.dgvLogs);
            this.Controls.Add(this.cboEntityType);
            this.Controls.Add(this.cboUsers);
            this.Controls.Add(this.cboActionType);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ActivityLog_UC";
            this.Size = new System.Drawing.Size(947, 736);
            this.Load += new System.EventHandler(this.ActivityLog_UC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.ComboBox cboActionType;
        private System.Windows.Forms.ComboBox cboUsers;
        private System.Windows.Forms.ComboBox cboEntityType;
        private System.Windows.Forms.DataGridView dgvLogs;
        private System.Windows.Forms.Label lblTotalRecords;
        private System.Windows.Forms.Button btnApplyFilter;
        private System.Windows.Forms.Button btnExportPDF;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3_39_Khanh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
