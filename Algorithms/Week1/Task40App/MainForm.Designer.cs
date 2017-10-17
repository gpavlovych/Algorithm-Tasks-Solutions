namespace Task40App
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

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
            this.radiusNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.drawingPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.drawSolverCheckBox = new System.Windows.Forms.CheckBox();
            this.drawGraphicsEllipseCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.radiusNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // radiusNumericUpDown
            // 
            this.radiusNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radiusNumericUpDown.Location = new System.Drawing.Point(58, 5);
            this.radiusNumericUpDown.Name = "radiusNumericUpDown";
            this.radiusNumericUpDown.Size = new System.Drawing.Size(533, 20);
            this.radiusNumericUpDown.TabIndex = 0;
            this.radiusNumericUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.radiusNumericUpDown.ValueChanged += new System.EventHandler(this.radiusNumericUpDown_ValueChanged);
            // 
            // drawingPanel
            // 
            this.drawingPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drawingPanel.Location = new System.Drawing.Point(12, 31);
            this.drawingPanel.Name = "drawingPanel";
            this.drawingPanel.Size = new System.Drawing.Size(579, 195);
            this.drawingPanel.TabIndex = 1;
            this.drawingPanel.SizeChanged += new System.EventHandler(this.drawingPanel_SizeChanged);
            this.drawingPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.drawingPanel_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Radius";
            // 
            // drawSolverCheckBox
            // 
            this.drawSolverCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.drawSolverCheckBox.AutoSize = true;
            this.drawSolverCheckBox.Checked = true;
            this.drawSolverCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.drawSolverCheckBox.ForeColor = System.Drawing.Color.Black;
            this.drawSolverCheckBox.Location = new System.Drawing.Point(12, 232);
            this.drawSolverCheckBox.Name = "drawSolverCheckBox";
            this.drawSolverCheckBox.Size = new System.Drawing.Size(110, 17);
            this.drawSolverCheckBox.TabIndex = 3;
            this.drawSolverCheckBox.Text = "Draw solver circle";
            this.drawSolverCheckBox.UseVisualStyleBackColor = true;
            this.drawSolverCheckBox.CheckedChanged += new System.EventHandler(this.drawSolverCheckBox_CheckedChanged);
            // 
            // drawGraphicsEllipseCheckBox
            // 
            this.drawGraphicsEllipseCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.drawGraphicsEllipseCheckBox.AutoSize = true;
            this.drawGraphicsEllipseCheckBox.Checked = true;
            this.drawGraphicsEllipseCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.drawGraphicsEllipseCheckBox.ForeColor = System.Drawing.Color.Red;
            this.drawGraphicsEllipseCheckBox.Location = new System.Drawing.Point(12, 255);
            this.drawGraphicsEllipseCheckBox.Name = "drawGraphicsEllipseCheckBox";
            this.drawGraphicsEllipseCheckBox.Size = new System.Drawing.Size(191, 17);
            this.drawGraphicsEllipseCheckBox.TabIndex = 4;
            this.drawGraphicsEllipseCheckBox.Text = "Draw e.Graphics.DrawEllipse circle";
            this.drawGraphicsEllipseCheckBox.UseVisualStyleBackColor = true;
            this.drawGraphicsEllipseCheckBox.CheckedChanged += new System.EventHandler(this.drawGraphicsEllipseCheckBox_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 284);
            this.Controls.Add(this.drawGraphicsEllipseCheckBox);
            this.Controls.Add(this.drawSolverCheckBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.drawingPanel);
            this.Controls.Add(this.radiusNumericUpDown);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "MainForm";
            this.Text = "Check circle drawing (Task 40)";
            ((System.ComponentModel.ISupportInitialize)(this.radiusNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NumericUpDown radiusNumericUpDown;
        private Panel drawingPanel;
        private Label label1;
        private CheckBox drawSolverCheckBox;
        private CheckBox drawGraphicsEllipseCheckBox;
    }
}

