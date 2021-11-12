
namespace Software_Design_Patterns
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.colorButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ballButton = new System.Windows.Forms.Button();
            this.carButton = new System.Windows.Forms.Button();
            this.createTimer = new System.Windows.Forms.Timer(this.components);
            this.conveyorTimer = new System.Windows.Forms.Timer(this.components);
            this.presentButton = new System.Windows.Forms.Button();
            this.boxColorButton = new System.Windows.Forms.Button();
            this.ribbonColorButton = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.ribbonColorButton);
            this.mainPanel.Controls.Add(this.boxColorButton);
            this.mainPanel.Controls.Add(this.presentButton);
            this.mainPanel.Controls.Add(this.colorButton);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.ballButton);
            this.mainPanel.Controls.Add(this.carButton);
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(801, 449);
            this.mainPanel.TabIndex = 0;
            // 
            // colorButton
            // 
            this.colorButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.colorButton.Location = new System.Drawing.Point(155, 88);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(94, 30);
            this.colorButton.TabIndex = 3;
            this.colorButton.UseVisualStyleBackColor = false;
            this.colorButton.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(403, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Coming next:";
            // 
            // ballButton
            // 
            this.ballButton.Location = new System.Drawing.Point(155, 22);
            this.ballButton.Name = "ballButton";
            this.ballButton.Size = new System.Drawing.Size(94, 59);
            this.ballButton.TabIndex = 1;
            this.ballButton.Text = "BALL";
            this.ballButton.UseVisualStyleBackColor = true;
            this.ballButton.Click += new System.EventHandler(this.ballButton_Click);
            // 
            // carButton
            // 
            this.carButton.Location = new System.Drawing.Point(41, 22);
            this.carButton.Name = "carButton";
            this.carButton.Size = new System.Drawing.Size(94, 59);
            this.carButton.TabIndex = 0;
            this.carButton.Text = "CAR";
            this.carButton.UseVisualStyleBackColor = true;
            this.carButton.Click += new System.EventHandler(this.carButton_Click);
            // 
            // createTimer
            // 
            this.createTimer.Enabled = true;
            this.createTimer.Interval = 3000;
            this.createTimer.Tick += new System.EventHandler(this.createTimer_Tick);
            // 
            // conveyorTimer
            // 
            this.conveyorTimer.Enabled = true;
            this.conveyorTimer.Interval = 10;
            this.conveyorTimer.Tick += new System.EventHandler(this.conveyorTimer_Tick);
            // 
            // presentButton
            // 
            this.presentButton.Location = new System.Drawing.Point(269, 22);
            this.presentButton.Name = "presentButton";
            this.presentButton.Size = new System.Drawing.Size(94, 59);
            this.presentButton.TabIndex = 4;
            this.presentButton.Text = "PRESENT";
            this.presentButton.UseVisualStyleBackColor = true;
            this.presentButton.Click += new System.EventHandler(this.presentButton_Click);
            // 
            // boxColorButton
            // 
            this.boxColorButton.BackColor = System.Drawing.Color.Red;
            this.boxColorButton.Location = new System.Drawing.Point(269, 88);
            this.boxColorButton.Name = "boxColorButton";
            this.boxColorButton.Size = new System.Drawing.Size(94, 30);
            this.boxColorButton.TabIndex = 5;
            this.boxColorButton.UseVisualStyleBackColor = false;
            this.boxColorButton.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // ribbonColorButton
            // 
            this.ribbonColorButton.BackColor = System.Drawing.Color.Yellow;
            this.ribbonColorButton.Location = new System.Drawing.Point(269, 124);
            this.ribbonColorButton.Name = "ribbonColorButton";
            this.ribbonColorButton.Size = new System.Drawing.Size(94, 30);
            this.ribbonColorButton.TabIndex = 6;
            this.ribbonColorButton.UseVisualStyleBackColor = false;
            this.ribbonColorButton.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Timer createTimer;
        private System.Windows.Forms.Timer conveyorTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ballButton;
        private System.Windows.Forms.Button carButton;
        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.Button ribbonColorButton;
        private System.Windows.Forms.Button boxColorButton;
        private System.Windows.Forms.Button presentButton;
    }
}

