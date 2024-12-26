namespace ADBConnectionApp
{
    partial class FormCropResult
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCropResult));
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            DetailInfo = new Label();
            textBox2 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 26);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 0;
            label1.Text = "Tọa độ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(124, 17);
            label2.Name = "label2";
            label2.Size = new Size(0, 15);
            label2.TabIndex = 1;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(80, 47);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(621, 23);
            textBox1.TabIndex = 2;
            // 
            // button1
            // 
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(707, 17);
            button1.Name = "button1";
            button1.Size = new Size(69, 53);
            button1.TabIndex = 3;
            button1.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(17, 88);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(759, 84);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // DetailInfo
            // 
            DetailInfo.AutoSize = true;
            DetailInfo.Location = new Point(17, 203);
            DetailInfo.Name = "DetailInfo";
            DetailInfo.Size = new Size(97, 15);
            DetailInfo.TabIndex = 5;
            DetailInfo.Text = "Thông tin chi tiết";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(17, 226);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(759, 23);
            textBox2.TabIndex = 6;
            // 
            // FormCropResult
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 530);
            Controls.Add(textBox2);
            Controls.Add(DetailInfo);
            Controls.Add(pictureBox1);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormCropResult";
            Text = "FormCropResult";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private Button button1;
        private PictureBox pictureBox1;
        private Label DetailInfo;
        private TextBox textBox2;
    }
}