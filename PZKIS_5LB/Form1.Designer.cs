namespace PZKIS_5LB
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            pictureBox = new PictureBox();
            diameterTextBox = new TextBox();
            button1 = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(27, 55);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(716, 347);
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // 
            // diameterTextBox
            // 
            diameterTextBox.Location = new Point(767, 97);
            diameterTextBox.Name = "diameterTextBox";
            diameterTextBox.Size = new Size(100, 23);
            diameterTextBox.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(767, 135);
            button1.Name = "button1";
            button1.Size = new Size(100, 23);
            button1.TabIndex = 2;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(778, 45);
            label1.Name = "label1";
            label1.Size = new Size(75, 15);
            label1.TabIndex = 3;
            label1.Text = "5, 15, 25 only";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(965, 450);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(diameterTextBox);
            Controls.Add(pictureBox);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox;
        private TextBox diameterTextBox;
        private Button button1;
        private System.Windows.Forms.Timer timer1;
        private Label label1;
    }
}