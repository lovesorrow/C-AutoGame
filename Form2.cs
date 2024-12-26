using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;

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
        //System.IO.MemoryStream ms = new System.IO.MemoryStream();
        //Task timeout;
        //string fn = "";

        public Form2(Bitmap screenshot)
        {
            InitializeComponent();
            pictureBox1.Image = screenshot;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            // Gắn sự kiện Click cho nút Crop
            btnCrop.Click += btnAnalyzeRegion_Click;
        }
        private void BtnCrop_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng Crop đang được phát triển!", "Thông báo");
        }

      
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
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox1.Invalidate();
            CaculateCorn(e.X, e.Y, out int offX, out int offY);
            offxDown = offX;
            offyDown = offY;
            xDown = e.X;
            yDown = e.Y;
        }


        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            ////pictureBox1.Image.Clone();
            CaculateCorn(e.X, e.Y, out int offX, out int offY);

            offxUp = offX;
            offyUp = offY;
            xUp = e.X;
            yUp = e.Y;
            Rectangle rec = new Rectangle(xDown, yDown, Math.Abs(xUp - xDown), Math.Abs(yUp - yDown));
            using (Pen pen = new Pen(Color.YellowGreen, 3))
            {

                pictureBox1.CreateGraphics().DrawRectangle(pen, rec);
            }
            rectCropArea = rec;

        }

        private static Bitmap ConvertToGrayscale(Bitmap original)
        {
            // Create a blank bitmap with the same dimensions as the original
            Bitmap grayscale = new Bitmap(original.Width, original.Height);

            // Iterate through each pixel of the image
            for (int i = 0; i < original.Width; i++)
            {
                for (int j = 0; j < original.Height; j++)
                {
                    // Get the color of the current pixel
                    Color originalColor = original.GetPixel(i, j);

                    // Calculate the grayscale value (luminosity method)
                    int grayValue = (int)(originalColor.R * 0.3 + originalColor.G * 0.59 + originalColor.B * 0.11);

                    // Set the pixel to the new grayscale value
                    grayscale.SetPixel(i, j, Color.FromArgb(grayValue, grayValue, grayValue));
                }
            }

            return grayscale;
        }
        private void btnAnalyzeRegion_Click(object sender, EventArgs e)
        {
            try
            {
                if (pictureBox1.Image == null || rectCropArea.Width == 0 || rectCropArea.Height == 0)
                {
                    MessageBox.Show("Please select a valid region.");
                    return;
                }              
                var actualRec = new Rectangle(offxDown, offyDown, Math.Abs(offxUp - offxDown), Math.Abs(offyUp - offyDown));
                using (Bitmap target = new Bitmap(Math.Abs(offxUp - offxDown), Math.Abs(offyUp - offyDown)))
                {
                    using (Graphics g = Graphics.FromImage(target))
                    {
                        g.DrawImage(pictureBox1.Image, new Rectangle(0, 0, actualRec.Width, actualRec.Height),
                            actualRec,
                            //rectCropArea,
                            GraphicsUnit.Pixel);
                    }
                    string filePath = @"D:\ADBConnectionApp\currentImg.png";  // Adjust the path where you want to save the image
                    target.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
                    var text = PerformOCR(target);
                    FormCropResult cropResultForm = new FormCropResult(target, actualRec);
                    cropResultForm.ShowDialog();
                }





            }
            catch (Exception ex)
            {

            }
        }
        private string PerformOCR(Bitmap image)
        {
            try
            {
                // Load the image from file path  
                using (Bitmap grayscaleImage = ConvertToGrayscale(image))
                {
                    string tessDataPath = @"D:\ADBConnectionApp\engdata";

                    using (var engine = new TesseractEngine(tessDataPath, "eng", EngineMode.Default))
                    {
                        // Set page segmentation mode to single character
                        engine.SetVariable("tessedit_char_whitelist", "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"); // Adjust whitelist if needed
                        engine.SetVariable("tessedit_page_seg_mode", "6"); // PSM_SINGLE_BLOCK (may perform better for single characters than PSM_SINGLE_CHAR)

                        using (var pix = PixConverter.ToPix(grayscaleImage))
                        {
                            using (var page = engine.Process(pix, PageSegMode.SingleBlock)) // Use PSM_SINGLE_BLOCK for potentially better accuracy
                            {
                                var text = page.GetText();

                                // Extract the first character (or handle multiple characters if desired)
                                if (text.Length > 0)
                                {
                                    return text.Substring(0, 1);
                                }
                                else
                                {
                                    return string.Empty; // Handle no character detected
                                }
                            }
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"OCR Error: {ex.Message}"); // Consider logging or handling errors based on your application's needs
                return string.Empty;
            }
        }
        private string PerformSingleCharacterOCR(string imageFilePath)
        {
            using (Bitmap image = new Bitmap(imageFilePath))
            {
                return PerformOCR(image);
            }


        }
    }
}
