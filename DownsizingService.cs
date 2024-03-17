using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace ImageDownsizer
{
    public class DownsizingService
    {
        private readonly Bitmap original;
        public ImageFormat Format { get; }

        public DownsizingService(Bitmap bitmap) 
        {
            original = bitmap;
            Format = original.RawFormat;
        }


        public Bitmap Resize(int percentage, bool parallel)
        {

            BitmapData originalData = original.LockBits(new Rectangle(Point.Empty, original.Size),
               ImageLockMode.ReadOnly, original.PixelFormat);

            int newWidth = (int)(originalData.Width * percentage / 100.0);
            int newHeight = (int)(originalData.Height * percentage / 100.0);

            Bitmap newImage = new Bitmap(newWidth, newHeight);

            BitmapData newImageData = newImage.LockBits(new Rectangle(0, 0, newWidth, newHeight),
            ImageLockMode.WriteOnly, originalData.PixelFormat);

            var pixelSize = originalData.PixelFormat == PixelFormat.Format32bppArgb ? 4 : 3;

            byte[] originalBytes = new byte[originalData.Height * originalData.Stride];

            Marshal.Copy(originalData.Scan0, originalBytes, 0, originalBytes.Length);

            byte[] newImageBytes = new byte[newImageData.Stride * newImageData.Height];

            double ratio = (double)original.Width / newWidth;

            if (parallel)
            {
                ParallelResizing(originalData, newWidth, newHeight, newImageData, pixelSize, originalBytes, newImageBytes, ratio);
            }
            else
            {
                NearestNeihborInterpolation(originalData, newWidth, newHeight, newImageData, pixelSize, originalBytes, newImageBytes, ratio);
            }

            Marshal.Copy(newImageBytes, 0, newImageData.Scan0, newImageBytes.Length);

            original.UnlockBits(originalData);
            newImage.UnlockBits(newImageData);

            return newImage;
        }

        private void ParallelResizing(BitmapData originalData, int newWidth, int newHeight, BitmapData newImageData, int pixelSize, byte[] originalBytes, byte[] newImageBytes, double ratio)
        {
            int numThreads = 8;

            int chunkHeight = newHeight / numThreads;

            Thread[] threads = new Thread[numThreads];

            for (int i = 0; i < numThreads; i++)
            {
                int startY = i * chunkHeight;
                int endY = (i == numThreads - 1) ? newHeight : (i + 1) * chunkHeight;

                threads[i] = new Thread(() => NearestNeihborInterpolation(originalData, newWidth, newHeight, newImageData, pixelSize, originalBytes, newImageBytes, ratio, startY, endY));
                threads[i].Start();
            }

            foreach (Thread thread in threads)
            {
                thread.Join();
            }
        }

        private void NearestNeihborInterpolation(BitmapData originalData, int newWidth, int newHeight, BitmapData newImageData, int pixelSize, byte[] originalBytes, byte[] newImageBytes, double ratio, int startY = 0, int endY = -1)
        {
            if (endY == -1)
                endY = newHeight;

            for (int y = startY; y < endY; y++)
            {
                for (int x = 0; x < newWidth; x++)
                {
                    int x1 = (int)(x * ratio);
                    int y1 = (int)(y * ratio);
                    int x2 = Math.Min((int)((x + 1) * ratio), originalData.Width - 1);
                    int y2 = Math.Min((int)((y + 1) * ratio), originalData.Height - 1);

                    byte[] avgColor = WeightedAverageColor(originalBytes, originalData.Stride, x1, y1, x2, y2, ratio, pixelSize);

                    int index = y * newImageData.Stride + x * pixelSize;

                    newImageBytes[index] = avgColor[0];
                    newImageBytes[index + 1] = avgColor[1];
                    newImageBytes[index + 2] = avgColor[2];

                    if (pixelSize == 4)
                    {
                        newImageBytes[index + 3] = avgColor[3];
                    }


                }
            }
        }


        private byte[] WeightedAverageColor(byte[] originalPixels, int originalStride, int x1, int y1, int x2, int y2, double ratio, int pixelSize)
        {
            double totalWeight = 0;
            double totalB = 0;
            double totalG = 0;
            double totalR = 0;
            double totalA = 0;


            for (int y = y1; y <= y2; y++)
            {
                for (int x = x1; x <= x2; x++)
                {
                    double weightX = 1 - Math.Abs(x / ratio - Math.Floor(x / ratio));
                    double weightY = 1 - Math.Abs(y / ratio - Math.Floor(y / ratio));
                    double weight = weightX * weightY;

                    totalWeight += weight;

                    int index = y * originalStride + x * pixelSize;

                    totalB += originalPixels[index] * weight;
                    totalG += originalPixels[index + 1] * weight;
                    totalR += originalPixels[index + 2] * weight;

                    if (pixelSize == 4)
                    {
                        totalA += originalPixels[index + 3] * weight;
                    }

                }
            }

            byte avgB = (byte)(totalB / totalWeight);
            byte avgG = (byte)(totalG / totalWeight);
            byte avgR = (byte)(totalR / totalWeight);
            byte avgA = 255; 

            if (pixelSize == 4)
            {
                avgA = (byte)(totalA / totalWeight);
            }

            return new byte[] { avgB, avgG, avgR, avgA };
        }

    }
}
