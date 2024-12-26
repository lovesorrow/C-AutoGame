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
    public partial class FormCropResult : Form
    {
        public FormCropResult(Bitmap croppedImage, Rectangle cropCoordinates)
        {
            InitializeComponent();

            //// Hiển thị ảnh
            //PictureBox pictureBox = new PictureBox
            //{
            //    Image = croppedImage,
            //    SizeMode = PictureBoxSizeMode.Zoom,
            //    Dock = DockStyle.Top,
            //    Height = 300
            //};

            //// Hiển thị thông tin tọa độ
            //Label label = new Label
            //{
            //    Text = $"Coordinates: X = {cropCoordinates.X}, Y = {cropCoordinates.Y}, Width = {cropCoordinates.Width}, Height = {cropCoordinates.Height}",
            //    Dock = DockStyle.Bottom,
            //    Height = 50,
            //    TextAlign = ContentAlignment.MiddleCenter
            //};

            //// Thêm các control vào Form
            //Controls.Add(pictureBox);
            //Controls.Add(label);

            //Text = "Cropped Image Result";
            //AutoSize = true;
            //AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }
    }

}
