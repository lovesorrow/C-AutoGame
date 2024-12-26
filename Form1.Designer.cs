namespace ADBConnectionApp
{
    partial class Form1 : Form
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnConnect;
        private Button btnRunCommand;
        private TextBox txtOutput;
        private Label lblInstruction;

        // Dispose method
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        // Form initialization
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            label1 = new Label();
            comboBox1 = new ComboBox();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            label2 = new Label();
            dataGridView1 = new DataGridView();
            DeviceName = new DataGridViewTextBoxColumn();
            Script = new DataGridViewTextBoxColumn();
            Action = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(287, 22);
            button1.Name = "button1";
            button1.Size = new Size(46, 41);
            button1.TabIndex = 0;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(380, 35);
            label1.Name = "label1";
            label1.Size = new Size(53, 15);
            label1.TabIndex = 1;
            label1.Text = "Kịch bản";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(449, 32);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(168, 23);
            comboBox1.TabIndex = 2;
            // 
            // button2
            // 
            button2.Location = new Point(646, 32);
            button2.Name = "button2";
            button2.Size = new Size(70, 29);
            button2.TabIndex = 3;
            button2.Text = "New";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(737, 32);
            button3.Name = "button3";
            button3.Size = new Size(75, 29);
            button3.TabIndex = 4;
            button3.Text = "Edit";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(839, 32);
            button4.Name = "button4";
            button4.Size = new Size(82, 29);
            button4.TabIndex = 5;
            button4.Text = "Load";
            button4.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(324, 115);
            label2.Name = "label2";
            label2.Size = new Size(196, 25);
            label2.TabIndex = 6;
            label2.Text = "Danh sách điện thoại";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(28, 170);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(895, 429);
            dataGridView1.TabIndex = 7;
            // 
            // DeviceName
            // 
            DeviceName.HeaderText = "Tên thiết bi";
            DeviceName.Name = "DeviceName";
            DeviceName.Width = 200;
            // 
            // Script
            // 
            Script.HeaderText = "Tên kịch bản";
            Script.Name = "Script";
            Script.Width = 200;
            // 
            // Action
            // 
            Action.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Action.HeaderText = "Hành động";
            Action.Name = "Action";
            Action.Resizable = DataGridViewTriState.True;
            Action.SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridView1.DataSource = GetConnectedDevice();
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(941, 637);
            Controls.Add(dataGridView1);
            Controls.Add(label2);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Controls.Add(button1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Button button1;
        private Label label1;
        private ComboBox comboBox1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label label2;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn DeviceName;
        private DataGridViewTextBoxColumn Script;
        private DataGridViewButtonColumn Action;
    }
    // Define a sample class for demonstration
    public class Device
    {
        public string DeviceName { get; set; }
        public string Script { get; set; }
        public string Action { get; set; }
        public string Status { get; set; }
    }
}

