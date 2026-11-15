namespace Grid_Reconcile
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            panInstr = new Panel();
            panOpen = new Panel();
            label2 = new Label();
            butOpenInst = new Grid_Reconcile.GRUI.GRButton();
            labInst = new Label();
            labData = new Label();
            butOpenData = new Grid_Reconcile.GRUI.GRButton();
            panel2 = new Panel();
            label3 = new Label();
            butStart = new Grid_Reconcile.GRUI.GRButton();
            panResults = new Panel();
            dgvResults = new DataGridView();
            panel7 = new Panel();
            panel6 = new Panel();
            panel5 = new Panel();
            panel4 = new Panel();
            panResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResults).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(59, 43);
            label1.Name = "label1";
            label1.Size = new Size(165, 17);
            label1.TabIndex = 0;
            label1.Text = "Upload receipt instructions";
            // 
            // panInstr
            // 
            panInstr.Anchor = AnchorStyles.None;
            panInstr.BackColor = SystemColors.ActiveBorder;
            panInstr.Location = new Point(244, 53);
            panInstr.Name = "panInstr";
            panInstr.Size = new Size(489, 1);
            panInstr.TabIndex = 1;
            // 
            // panOpen
            // 
            panOpen.Anchor = AnchorStyles.None;
            panOpen.BackColor = SystemColors.ActiveBorder;
            panOpen.Location = new Point(219, 221);
            panOpen.Name = "panOpen";
            panOpen.Size = new Size(518, 1);
            panOpen.TabIndex = 3;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(63, 212);
            label2.Name = "label2";
            label2.Size = new Size(137, 17);
            label2.TabIndex = 2;
            label2.Text = "Upload receipt details";
            // 
            // butOpenInst
            // 
            butOpenInst.Anchor = AnchorStyles.None;
            butOpenInst.BackColor = Color.LightSeaGreen;
            butOpenInst.FlatAppearance.BorderSize = 0;
            butOpenInst.FlatStyle = FlatStyle.Flat;
            butOpenInst.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            butOpenInst.ForeColor = Color.White;
            butOpenInst.Location = new Point(100, 106);
            butOpenInst.Name = "butOpenInst";
            butOpenInst.Size = new Size(163, 56);
            butOpenInst.TabIndex = 4;
            butOpenInst.Text = "Open Excel File";
            butOpenInst.UseVisualStyleBackColor = false;
            butOpenInst.Click += butOpenInst_Click;
            // 
            // labInst
            // 
            labInst.Anchor = AnchorStyles.None;
            labInst.AutoSize = true;
            labInst.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labInst.Location = new Point(305, 128);
            labInst.Name = "labInst";
            labInst.Size = new Size(232, 17);
            labInst.TabIndex = 5;
            labInst.Text = "                                                        ";
            // 
            // labData
            // 
            labData.Anchor = AnchorStyles.None;
            labData.AutoSize = true;
            labData.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labData.Location = new Point(305, 292);
            labData.Name = "labData";
            labData.Size = new Size(228, 17);
            labData.TabIndex = 7;
            labData.Text = "                                                       ";
            // 
            // butOpenData
            // 
            butOpenData.Anchor = AnchorStyles.None;
            butOpenData.BackColor = Color.LightSeaGreen;
            butOpenData.FlatAppearance.BorderSize = 0;
            butOpenData.FlatStyle = FlatStyle.Flat;
            butOpenData.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            butOpenData.ForeColor = Color.White;
            butOpenData.Location = new Point(100, 270);
            butOpenData.Name = "butOpenData";
            butOpenData.Size = new Size(163, 56);
            butOpenData.TabIndex = 6;
            butOpenData.Text = "Open Excel File";
            butOpenData.UseVisualStyleBackColor = false;
            butOpenData.Click += butOpenData_Click;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.None;
            panel2.BackColor = SystemColors.ActiveBorder;
            panel2.Location = new Point(200, 381);
            panel2.Name = "panel2";
            panel2.Size = new Size(537, 1);
            panel2.TabIndex = 5;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(63, 372);
            label3.Name = "label3";
            label3.Size = new Size(119, 17);
            label3.TabIndex = 4;
            label3.Text = "Start Reconciliation";
            // 
            // butStart
            // 
            butStart.Anchor = AnchorStyles.None;
            butStart.BackColor = Color.DodgerBlue;
            butStart.FlatAppearance.BorderSize = 0;
            butStart.FlatStyle = FlatStyle.Flat;
            butStart.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            butStart.ForeColor = Color.White;
            butStart.Location = new Point(329, 421);
            butStart.Name = "butStart";
            butStart.Size = new Size(163, 56);
            butStart.TabIndex = 8;
            butStart.Text = "Start";
            butStart.UseVisualStyleBackColor = false;
            // 
            // panResults
            // 
            panResults.Controls.Add(dgvResults);
            panResults.Controls.Add(panel7);
            panResults.Controls.Add(panel6);
            panResults.Controls.Add(panel5);
            panResults.Controls.Add(panel4);
            panResults.Location = new Point(521, 148);
            panResults.Name = "panResults";
            panResults.Size = new Size(251, 178);
            panResults.TabIndex = 9;
            // 
            // dgvResults
            // 
            dgvResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResults.Dock = DockStyle.Fill;
            dgvResults.Location = new Point(10, 10);
            dgvResults.Name = "dgvResults";
            dgvResults.Size = new Size(231, 158);
            dgvResults.TabIndex = 4;
            // 
            // panel7
            // 
            panel7.Dock = DockStyle.Right;
            panel7.Location = new Point(241, 10);
            panel7.Name = "panel7";
            panel7.Size = new Size(10, 158);
            panel7.TabIndex = 3;
            // 
            // panel6
            // 
            panel6.Dock = DockStyle.Left;
            panel6.Location = new Point(0, 10);
            panel6.Name = "panel6";
            panel6.Size = new Size(10, 158);
            panel6.TabIndex = 2;
            // 
            // panel5
            // 
            panel5.Dock = DockStyle.Bottom;
            panel5.Location = new Point(0, 168);
            panel5.Name = "panel5";
            panel5.Size = new Size(251, 10);
            panel5.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(251, 10);
            panel4.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(800, 527);
            Controls.Add(panResults);
            Controls.Add(butStart);
            Controls.Add(panel2);
            Controls.Add(label3);
            Controls.Add(labData);
            Controls.Add(butOpenData);
            Controls.Add(labInst);
            Controls.Add(butOpenInst);
            Controls.Add(panOpen);
            Controls.Add(label2);
            Controls.Add(panInstr);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm";
            Text = "Grid Reconcile";
            panResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvResults).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panInstr;
        private Panel panOpen;
        private Label label2;
        private GRUI.GRButton butOpenInst;
        private Label labInst;
        private Label labData;
        private GRUI.GRButton butOpenData;
        private Panel panel2;
        private Label label3;
        private GRUI.GRButton butStart;
        private Panel panResults;
        private DataGridView dgvResults;
        private Panel panel7;
        private Panel panel6;
        private Panel panel5;
        private Panel panel4;
    }
}
