using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ADBConnectionApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string ExecuteADBCommand(string command)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "cmd.exe";
                psi.Arguments = $"/c adb {command}";
                psi.RedirectStandardOutput = true;
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;

                Process process = Process.Start(psi);

                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                return output;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}");
                return "Error";
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ExecuteADBCommand("devices");
        }

        private void btnRunCommand_Click(object sender, EventArgs e)
        {
            ExecuteADBCommand("shell am start -n com.example.package/.MainActivity");
        }
        List<Device> ParseADBOutput(string output)
        {
            var devices = new List<Device>();
            var lines = output.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            // Skip the first line ("List of devices attached")
            foreach (var line in lines.Skip(1))
            {
                var parts = line.Split('\t');
                if (parts.Length == 2) // Check if the line contains device info
                {
                    devices.Add(new Device
                    {
                        DeviceName = parts[0],
                        //Status = parts[1]
                    });
                }
            }

            return devices;
        }
        private List<Device> GetConnectedDevice()
        {
            return ParseADBOutput(ExecuteADBCommand("devices"));

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            Task.Run(() =>
            {
                try
                {
                    // Chụp ảnh màn hình từ điện thoại
                    var screenshot = CaptureScreenshot();

                    // Hiển thị ảnh trên giao diện chính
                    this.Invoke((MethodInvoker)(() =>
                    {
                        if (screenshot != null)
                        {
                            Form2 imageForm = new Form2(screenshot);
                            imageForm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Không thể chụp màn hình. Hãy kiểm tra kết nối thiết bị.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }));
                }
                catch (Exception ex)
                {
                    this.Invoke((MethodInvoker)(() =>
                    {
                        MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                }
                finally
                {
                    // Khôi phục con trỏ chuột mặc định
                    this.Invoke((MethodInvoker)(() =>
                    {
                        this.Cursor = Cursors.Default;
                    }));
                }
            });
        }
        private Bitmap CaptureScreenshot()
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = "/C adb exec-out screencap -p";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.CreateNoWindow = true;
                process.Start();

                using (var ms = new MemoryStream())
                {
                    var buffer = new byte[1024];
                    int bytesRead;

                    while ((bytesRead = process.StandardOutput.BaseStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, bytesRead);
                    }

                    process.WaitForExit();

                    return new Bitmap(ms);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
