using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

//Challenge from here: https://www.reddit.com/r/dailyprogrammer/comments/4paxp4/20160622_challenge_272_intermediate_dither_that/
//Input
//Your program will take a color or grayscale image as its input.
//Output
//Output a two-color (e.g.Black and White) dithered image in your choice of format.

namespace DP272I
{
    class Program
    {
        static void Main(string[] args)
        {
            string mode = "FloydSteinberg";

            Bitmap OriginalImage = new Bitmap(@"C:\Users\coper\Source\Repos\DP272I\DP272I\DP272I\kjWn2Q1.png");
            Bitmap newImage = new Bitmap(OriginalImage.Width, OriginalImage.Height);

            for(int y = 0; y < OriginalImage.Height; y++)
            {
                for(int x = 0; x < OriginalImage.Width; x++)
                {
                    Color pixel = OriginalImage.GetPixel(x, y);
                    byte greyscaleVal = (byte)((pixel.R + pixel.G + pixel.B) / 3);

                    if (mode == "Grey")
                    {
                        Color greyscaleColor = Color.FromArgb((int)greyscaleVal, (int)greyscaleVal, (int)greyscaleVal);
                        newImage.SetPixel(x, y, greyscaleColor);
                    }

                    if(mode == "FloydSteinberg")
                    {
                        if (greyscaleVal < 128)
                        {
                            newImage.SetPixel(x, y, Color.Black);

                            int errorDiff = greyscaleVal;

                            if (x + 1 < OriginalImage.Width)
                            {
                                float FloydSteinbergConstant = 7f / 16;
                                Color originalNextPixel = OriginalImage.GetPixel(x + 1, y);
                                Color newNextPixel = nextPixel(FloydSteinbergConstant, originalNextPixel, errorDiff);

                                OriginalImage.SetPixel(x + 1, y, newNextPixel);
                            }

                            if (x - 1 >= 0 && y + 1 < OriginalImage.Height)
                            {
                                float FloydSteinbergConstant = 3f / 16;
                                Color originalNextPixel = OriginalImage.GetPixel(x - 1, y + 1);
                                Color newNextPixel = nextPixel(FloydSteinbergConstant, originalNextPixel, errorDiff);

                                OriginalImage.SetPixel(x - 1, y + 1, newNextPixel);
                            }

                            if (y + 1 < OriginalImage.Height)
                            {
                                float FloydSteinbergConstant = 5f / 16;
                                Color originalNextPixel = OriginalImage.GetPixel(x, y + 1);
                                Color newNextPixel = nextPixel(FloydSteinbergConstant, originalNextPixel, errorDiff);

                                OriginalImage.SetPixel(x, y + 1, newNextPixel);
                            }

                            if (x + 1 < OriginalImage.Width && y + 1 < OriginalImage.Height)
                            {
                                float FloydSteinbergConstant = 1f / 16;
                                Color originalNextPixel = OriginalImage.GetPixel(x + 1, y + 1);
                                Color newNextPixel = nextPixel(FloydSteinbergConstant, originalNextPixel, errorDiff);

                                OriginalImage.SetPixel(x + 1, y + 1, newNextPixel);
                            }
                        }

                        else
                        {
                            newImage.SetPixel(x, y, Color.White);

                            int errorDiff = greyscaleVal - 255;

                            if (x + 1 < OriginalImage.Width)
                            {
                                float FloydSteinbergConstant = 7f / 16;
                                Color originalNextPixel = OriginalImage.GetPixel(x + 1, y);
                                Color newNextPixel = nextPixel(FloydSteinbergConstant, originalNextPixel, errorDiff);

                                OriginalImage.SetPixel(x + 1, y, newNextPixel);
                            }

                            if (x - 1 >= 0 && y + 1 < OriginalImage.Height)
                            {
                                float FloydSteinbergConstant = 3f / 16;
                                Color originalNextPixel = OriginalImage.GetPixel(x - 1, y + 1);
                                Color newNextPixel = nextPixel(FloydSteinbergConstant, originalNextPixel, errorDiff);

                                OriginalImage.SetPixel(x - 1, y + 1, newNextPixel);
                            }

                            if (y + 1 < OriginalImage.Height)
                            {
                                float FloydSteinbergConstant = 5f / 16;
                                Color originalNextPixel = OriginalImage.GetPixel(x, y + 1);
                                Color newNextPixel = nextPixel(FloydSteinbergConstant, originalNextPixel, errorDiff);

                                OriginalImage.SetPixel(x, y + 1, newNextPixel);
                            }

                            if (x + 1 < OriginalImage.Width && y + 1 < OriginalImage.Height)
                            {
                                float FloydSteinbergConstant = 1f / 16;
                                Color originalNextPixel = OriginalImage.GetPixel(x + 1, y + 1);
                                Color newNextPixel = nextPixel(FloydSteinbergConstant, originalNextPixel, errorDiff);

                                OriginalImage.SetPixel(x + 1, y + 1, newNextPixel);
                            }
                        }
                    }                    
                }
            }

            newImage.Save(@"C:\Users\coper\Source\Repos\DP272I\DP272I\DP272I\shapesOutput.png");
        }

        static int Clamp(int val, int min, int max)
        {
            if (val.CompareTo(min) < 0) return min;
            else if (val.CompareTo(max) > 0) return max;
            else return val;
        }

        static Color nextPixel(float FloydSteinbergConstant, Color originalPixel, int errorDiff)
        {
            byte newGreyscaleVal = (byte)((originalPixel.R + originalPixel.G + originalPixel.B) / 3);
            int newRGB = (int)(Clamp((int)(newGreyscaleVal + (errorDiff * FloydSteinbergConstant)), 0, 255));

            return Color.FromArgb(newRGB, newRGB, newRGB);
        }
    }
}
