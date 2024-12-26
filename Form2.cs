using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADBConnectionApp
{
    public partial class Form2 : Form
    {
        int xDown = 0;
        int yDown = 0;
        int xUp = 0;
        int yUp = 0;
        int offxDown = 0;
        int offyDown = 0;
        int offxUp = 0;
        int offyUp = 0;


        Rectangle rectCropArea = new Rectangle();
        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        Task timeout;
        string fn = "";

        public Form2()
        {
            InitializeComponent();
        }
        private void CaculateCorn(int x, int y, out int w, out int h)
        {
            w = 0; h = 0;
            var imageWidth = pictureBox1.Image.Width;
            var imageHeight = pictureBox1.Image.Height;

            // Kích thước hiển thị trong PictureBox (sau khi co giãn)
            var displayWidth = pictureBox1.ClientSize.Width;
            var displayHeight = pictureBox1.ClientSize.Height;

            // Tính toán vùng hiển thị thực tế của ảnh (do SizeMode.Zoom)
            float ratioWidth = (float)displayWidth / imageWidth;
            float ratioHeight = (float)displayHeight / imageHeight;
            float ratio = Math.Min(ratioWidth, ratioHeight);

            var actualWidth = imageWidth * ratio;
            var actualHeight = imageHeight * ratio;

            var offsetX = (displayWidth - actualWidth) / 2;
            var offsetY = (displayHeight - actualHeight) / 2;

            // Kiểm tra nếu chuột nằm trong vùng ảnh
            if (x >= offsetX && x <= offsetX + actualWidth &&
                y >= offsetY && y <= offsetY + actualHeight)
            {
                // Ánh xạ tọa độ từ PictureBox sang ảnh
                w = (int)((x - offsetX) / ratio);
                h = (int)((y - offsetY) / ratio);

                // Hiển thị tọa độ trong ảnh
                Console.WriteLine($"Mouse in Image: ({w}, {h})");
            }
            else
            {
                Console.WriteLine("Mouse is outside the image.");
            }

        }
        public Form2(Bitmap screenshot)
        {
            InitializeComponent();
            pictureBox1.Image = screenshot;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            // Gắn sự kiện Click cho nút Crop
            btnCrop.Click += BtnCrop_Click;
        }
        private void BtnCrop_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng Crop đang được phát triển!", "Thông báo");
        }
    }
}
