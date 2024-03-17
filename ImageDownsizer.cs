using System.Diagnostics;
using System.Drawing.Imaging;

namespace ImageDownsizer
{
    public partial class ImageDownsizer : Form
    {
        DownsizingService? downsizingService;
        public ImageDownsizer()
        {
            InitializeComponent();
        }

        private void uploadBtn_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    downsizingService = new (new Bitmap(openFileDialog.FileName));

                    imageLbl.Text = openFileDialog.SafeFileName;
                    factorUpDown.Enabled = true;

                }
            }

        }

        private void Downsize(bool parallel)
        {
            Stopwatch sw = new Stopwatch();

            sw.Restart();

            var newImage = downsizingService!.Resize((int)factorUpDown.Value, parallel);

            sw.Stop();

            timeLbl.Text = sw.ElapsedMilliseconds.ToString() + "ms";

            saveFile(newImage);
        }

        private void saveFile(Bitmap newImage)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {

                ImageFormat format = downsizingService!.Format;

                string filter = "JPEG Image (*jpeg, *jpg)|*jpeg;*jpg";

                if (format.Guid == ImageFormat.Png.Guid)
                {
                    filter = "PNG Image (*.png)|*.png";
                }
                else if (format.Guid == ImageFormat.Bmp.Guid)
                {
                    filter = "BMP Image (*bmp)|*bmp";
                }

                saveFileDialog.Filter = filter;
                saveFileDialog.FileName = "resized_" + imageLbl.Text;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    newImage.Save(saveFileDialog.FileName, format);
                }
            }
        }
        private void factorUpDown_Change(object sender, EventArgs e)
        {
            downsizeBtn.Enabled = true;
            parallelDownsizeBtn.Enabled = true;
        }

        private void downsizeBtn_Click(object sender, EventArgs e)
        {
            Downsize(false);
        }


        private void parallelDownsizeBtn_Click(object sender, EventArgs e)
        {
            Downsize(true);
        }
    }
}