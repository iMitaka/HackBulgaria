using System.Drawing;
namespace SimpleCalculator
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
            this.firstNumberText = new System.Windows.Forms.TextBox();
            this.secondNumberText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonPlus = new System.Windows.Forms.Button();
            this.buttonMinus = new System.Windows.Forms.Button();
            this.buttonPower = new System.Windows.Forms.Button();
            this.buttonDivide = new System.Windows.Forms.Button();
            this.buttonSqrtFirst = new System.Windows.Forms.Button();
            this.buttonSqrtSecond = new System.Windows.Forms.Button();
            this.buttonLog2First = new System.Windows.Forms.Button();
            this.buttonLog2Seccond = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.errorLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // firstNumberText
            // 
            this.firstNumberText.Location = new System.Drawing.Point(105, 9);
            this.firstNumberText.Name = "firstNumberText";
            this.firstNumberText.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.firstNumberText.Size = new System.Drawing.Size(173, 20);
            this.firstNumberText.TabIndex = 0;
            // 
            // secondNumberText
            // 
            this.secondNumberText.Location = new System.Drawing.Point(105, 45);
            this.secondNumberText.Name = "secondNumberText";
            this.secondNumberText.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.secondNumberText.Size = new System.Drawing.Size(173, 20);
            this.secondNumberText.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "First Number:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Second Number:";
            // 
            // buttonPlus
            // 
            this.buttonPlus.Location = new System.Drawing.Point(15, 94);
            this.buttonPlus.Name = "buttonPlus";
            this.buttonPlus.Size = new System.Drawing.Size(75, 23);
            this.buttonPlus.TabIndex = 4;
            this.buttonPlus.Text = "+";
            this.buttonPlus.UseVisualStyleBackColor = true;
            this.buttonPlus.Click += new System.EventHandler(this.buttonPlus_Click);
            // 
            // buttonMinus
            // 
            this.buttonMinus.Location = new System.Drawing.Point(105, 94);
            this.buttonMinus.Name = "buttonMinus";
            this.buttonMinus.Size = new System.Drawing.Size(75, 23);
            this.buttonMinus.TabIndex = 5;
            this.buttonMinus.Text = "-";
            this.buttonMinus.UseVisualStyleBackColor = true;
            this.buttonMinus.Click += new System.EventHandler(this.buttonMinus_Click);
            // 
            // buttonPower
            // 
            this.buttonPower.Location = new System.Drawing.Point(203, 94);
            this.buttonPower.Name = "buttonPower";
            this.buttonPower.Size = new System.Drawing.Size(75, 23);
            this.buttonPower.TabIndex = 6;
            this.buttonPower.Text = "*";
            this.buttonPower.UseVisualStyleBackColor = true;
            this.buttonPower.Click += new System.EventHandler(this.buttonPower_Click);
            // 
            // buttonDivide
            // 
            this.buttonDivide.Location = new System.Drawing.Point(298, 94);
            this.buttonDivide.Name = "buttonDivide";
            this.buttonDivide.Size = new System.Drawing.Size(75, 23);
            this.buttonDivide.TabIndex = 7;
            this.buttonDivide.Text = "/";
            this.buttonDivide.UseVisualStyleBackColor = true;
            this.buttonDivide.Click += new System.EventHandler(this.buttonDivide_Click);
            // 
            // buttonSqrtFirst
            // 
            this.buttonSqrtFirst.Location = new System.Drawing.Point(285, 9);
            this.buttonSqrtFirst.Name = "buttonSqrtFirst";
            this.buttonSqrtFirst.Size = new System.Drawing.Size(42, 23);
            this.buttonSqrtFirst.TabIndex = 8;
            this.buttonSqrtFirst.Text = "Sqrt";
            this.buttonSqrtFirst.UseVisualStyleBackColor = true;
            this.buttonSqrtFirst.Click += new System.EventHandler(this.buttonSqrtFirst_Click);
            // 
            // buttonSqrtSecond
            // 
            this.buttonSqrtSecond.Location = new System.Drawing.Point(285, 41);
            this.buttonSqrtSecond.Name = "buttonSqrtSecond";
            this.buttonSqrtSecond.Size = new System.Drawing.Size(42, 24);
            this.buttonSqrtSecond.TabIndex = 9;
            this.buttonSqrtSecond.Text = "Sqrt";
            this.buttonSqrtSecond.UseVisualStyleBackColor = true;
            this.buttonSqrtSecond.Click += new System.EventHandler(this.buttonSqrtSecond_Click);
            // 
            // buttonLog2First
            // 
            this.buttonLog2First.Location = new System.Drawing.Point(333, 9);
            this.buttonLog2First.Name = "buttonLog2First";
            this.buttonLog2First.Size = new System.Drawing.Size(43, 23);
            this.buttonLog2First.TabIndex = 10;
            this.buttonLog2First.Text = "Log2";
            this.buttonLog2First.UseVisualStyleBackColor = true;
            this.buttonLog2First.Click += new System.EventHandler(this.buttonLog2First_Click);
            // 
            // buttonLog2Seccond
            // 
            this.buttonLog2Seccond.Location = new System.Drawing.Point(333, 42);
            this.buttonLog2Seccond.Name = "buttonLog2Seccond";
            this.buttonLog2Seccond.Size = new System.Drawing.Size(43, 23);
            this.buttonLog2Seccond.TabIndex = 11;
            this.buttonLog2Seccond.Text = "Log2";
            this.buttonLog2Seccond.UseVisualStyleBackColor = true;
            this.buttonLog2Seccond.Click += new System.EventHandler(this.buttonLog2Seccond_Click);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.ForeColor = System.Drawing.Color.Red;
            this.resultLabel.Location = new System.Drawing.Point(102, 137);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(40, 13);
            this.resultLabel.TabIndex = 12;
            this.resultLabel.Text = "Result:";
            // 
            // resultTextBox
            // 
            this.resultTextBox.Location = new System.Drawing.Point(148, 137);
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.ReadOnly = true;
            this.resultTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.resultTextBox.Size = new System.Drawing.Size(197, 20);
            this.resultTextBox.TabIndex = 13;
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Location = new System.Drawing.Point(102, 68);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(0, 13);
            this.errorLabel.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ClientSize = new System.Drawing.Size(385, 169);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.resultTextBox);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.buttonLog2Seccond);
            this.Controls.Add(this.buttonLog2First);
            this.Controls.Add(this.buttonSqrtSecond);
            this.Controls.Add(this.buttonSqrtFirst);
            this.Controls.Add(this.buttonDivide);
            this.Controls.Add(this.buttonPower);
            this.Controls.Add(this.buttonMinus);
            this.Controls.Add(this.buttonPlus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.secondNumberText);
            this.Controls.Add(this.firstNumberText);
            this.Name = "Form1";
            this.Text = "My Simple Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox firstNumberText;
        private System.Windows.Forms.TextBox secondNumberText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonPlus;
        private System.Windows.Forms.Button buttonMinus;
        private System.Windows.Forms.Button buttonPower;
        private System.Windows.Forms.Button buttonDivide;
        private System.Windows.Forms.Button buttonSqrtFirst;
        private System.Windows.Forms.Button buttonSqrtSecond;
        private System.Windows.Forms.Button buttonLog2First;
        private System.Windows.Forms.Button buttonLog2Seccond;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.TextBox resultTextBox;
        private System.Windows.Forms.Label errorLabel;
    }
}

