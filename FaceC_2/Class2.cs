using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace login_logout
{
    class Class2
    {
    }
    public interface IBitmapCompare
    {
        double GetSimilarity(Bitmap a, Bitmap b);
    }
    class AveragingBitmapCompare : IBitmapCompare
    {
        public struct RGBdata
        {
            public int r;
            public int g;
            public int b;

            public int GetLargest()
            {
                if (r > b)
                {
                    if (r > g)
                    {
                        return 1;
                    }
                    else
                    {
                        return 2;
                    }
                }
                else
                {
                    return 3;
                }
            }
        }

        private RGBdata ProcessBitmap(Bitmap a)
        {
            BitmapData bmpData = a.LockBits(new Rectangle(0, 0, a.Width, a.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            IntPtr ptr = bmpData.Scan0;
            RGBdata data = new RGBdata();

            unsafe
            {
                byte* p = (byte*)(void*)ptr;
                int offset = bmpData.Stride - a.Width * 3;
                int width = a.Width * 3;

                for (int y = 0; y < a.Height; ++y)
                {
                    for (int x = 0; x < width; ++x)
                    {
                        data.r += p[0]; //gets red values
                        data.g += p[1]; //gets green values
                        data.b += p[2]; //gets blue values
                        ++p;
                    }
                    p += offset;
                }
            }
            a.UnlockBits(bmpData);
            return data;
        }

        public double GetSimilarity(Bitmap a, Bitmap b)
        {
            RGBdata dataA = ProcessBitmap(a);
            RGBdata dataB = ProcessBitmap(b);
            double result = 0;
            int averageA = 0;
            int averageB = 0;
            int maxA = 0;
            int maxB = 0;

            maxA = ((a.Width * 3) * a.Height);
            maxB = ((b.Width * 3) * b.Height);

            switch (dataA.GetLargest()) //Find dominant color to compare
            {
                case 1:
                    {
                        averageA = Math.Abs(dataA.r / maxA);
                        averageB = Math.Abs(dataB.r / maxB);
                        result = (averageA - averageB) / 2;
                        break;
                    }
                case 2:
                    {
                        averageA = Math.Abs(dataA.g / maxA);
                        averageB = Math.Abs(dataB.g / maxB);
                        result = (averageA - averageB) / 2;
                        break;
                    }
                case 3:
                    {
                        averageA = Math.Abs(dataA.b / maxA);
                        averageB = Math.Abs(dataB.b / maxB);
                        result = (averageA - averageB) / 2;
                        break;
                    }
            }

            result = Math.Abs((result + 100) / 100);

            if (result > 1.0)
            {
                result -= 1.0;
            }

            return result;
        }
    }

    class HistogramBitmapCompare : IBitmapCompare
    {
        public struct RGBHistogram
        {
            public RGBHistogram(int s)
            {
                size = s;
                data = new byte[size, size, size];
                Clear();
            }

            public void Clear()
            {
                for (int x = 0; x < size; x++)
                {
                    for (int y = 0; y < size; y++)
                    {
                        for (int z = 0; z < size; z++)
                        {
                            data[x, y, z] = 0;
                        }
                    }
                }
            }

            public int GetSize()
            {
                return size;
            }

            public int Sum()
            {
                int sum = 0;
                for (int x = 0; x < size; x++)
                {
                    for (int y = 0; y < size; y++)
                    {
                        for (int z = 0; z < size; z++)
                        {
                            sum += data[x, y, z];
                        }
                    }
                }
                return sum;
            }
            public byte[, ,] data;
            int size;
        }

        private int Minimum(int a, int b)
        {
            if (a > b)
            {
                return b;
            }
            return a;
        }

        private RGBHistogram ProcessBitmap(Bitmap img)
        {
            BitmapData bmpData = img.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            IntPtr ptr = bmpData.Scan0;
            RGBHistogram histogram = new RGBHistogram(4);
            int[] color = new int[3];
            int lBound, uBound;
            int a = 0;
            int b = 0;
            int c = 0;


            unsafe
            {
                byte* p = (byte*)(void*)ptr;
                int offset = bmpData.Stride - img.Width * 3;
                int width = img.Width * 3;

                for (int y = 0; y < img.Height; ++y)
                {
                    for (int x = 0; x < width; ++x)
                    {
                        color[0] = p[0];
                        color[1] = p[1];
                        color[2] = p[2];

                        for (int i = 0; i < histogram.GetSize(); i++)
                        {
                            lBound = (i * 64);
                            uBound = (64 * i) + 63;

                            if ((lBound <= color[0]) && (uBound >= color[0]))
                            {
                                a = i;
                            }
                            if ((lBound <= color[1]) && (uBound >= color[1]))
                            {
                                b = i;
                            }
                            if ((lBound <= color[2]) && (uBound >= color[2]))
                            {
                                c = i;
                            }
                            histogram.data[a, b, c]++;
                        }
                        ++p;
                    }
                    p += offset;
                }
            }
            img.UnlockBits(bmpData);
            return histogram;
        }

        public double GetSimilarity(Bitmap a, Bitmap b)
        {
            RGBHistogram histogramA = ProcessBitmap(a);
            RGBHistogram histogramB = ProcessBitmap(b);
            double minSum = 0;
            double distance = 0;

            for (int x = 0; x < histogramA.GetSize(); x++)
            {
                for (int y = 0; y < histogramA.GetSize(); y++)
                {
                    for (int z = 0; z < histogramA.GetSize(); z++)
                    {
                        minSum += Minimum(histogramA.data[x, y, z], histogramB.data[x, y, z]);
                    }
                }
            }
            distance = minSum / Minimum(histogramA.Sum(), histogramB.Sum());
            return distance;
        }
    }
    //class Program1
    //{
    //    static IBitmapCompare CompareBox;
    //    static Bitmap searchImage;

    //    static private void Line()
    //    {
    //        for (int x = 0; x < Console.BufferWidth; x++)
    //        {
    //            Console.Write("*");
    //        }
    //    }

    //    static void CheckDirectory(string directory, double percentage, int method, Bitmap sImage)
    //    {
    //        DirectoryInfo dir = new DirectoryInfo(directory);
    //        FileInfo[] files = null;
    //        double sim = 0;

    //        try
    //        {
    //            files = dir.GetFiles("*.jpg");
    //        }
    //        catch (DirectoryNotFoundException)
    //        {
    //            Console.WriteLine("Bad directory specified");
    //            return;
    //        }

    //        foreach (FileInfo f in files)
    //        {
    //            if (method == 1)
    //            {
    //                CompareBox = new AveragingBitmapCompare();
    //            }
    //            if (method == 2)
    //            {
    //                CompareBox = new HistogramBitmapCompare();
    //            }
    //            sim = CompareBox.GetSimilarity(sImage, new Bitmap(f.FullName));

    //            if (sim >= percentage)
    //            {
    //                Console.WriteLine(f.Name);
    //                Console.WriteLine("Histogram Intersection");
    //                Console.WriteLine("Match of: {0}", sim);
    //                Line();
    //            }
    //        }
    //    }

    //    static void Main(string[] args)
    //    {
    //        int method = 0;
    //        double percentage = 0;
    //        Console.Write("Enter path to search image: ");
    //        try
    //        {
    //            searchImage = new Bitmap(Console.ReadLine());
    //        }
    //        catch (ArgumentException)
    //        {
    //            Console.WriteLine("Error: bad input!");
    //            return;
    //        }

    //        Console.Write("Enter directory to scan: ");
    //        string dir = Console.ReadLine();
    //        Console.Write("\nMethod of comparison:\n1 - Color percentages\n2 - Histogram intersection distance\nChoice: ");
    //        method = int.Parse(Console.ReadLine());
    //        if ((method != 1) && (method != 2))
    //        {
    //            Console.WriteLine("Error: bad input!");
    //            return;
    //        }
    //        Console.Write("Minimum percentage of similarity: ");
    //        percentage = double.Parse(Console.ReadLine()) / 100;

    //        Line();
    //        CheckDirectory(dir, percentage, method, searchImage);
    //    }
    //}
}
