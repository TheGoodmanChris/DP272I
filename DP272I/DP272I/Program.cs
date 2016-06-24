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
            Bitmap OriginalImage = new Bitmap(@"C:\Users\cgoodman\Source\Repos\DP272I\DP272I\DP272I\kjWn2Q1.png");
            Bitmap newImage = new Bitmap(OriginalImage.Width, OriginalImage.Height);

            for(int y = 0; y < OriginalImage.Height; y++)
            {
                for(int x = 0; x < OriginalImage.Width; x++)
                {
                    Color pixel = OriginalImage.GetPixel(x, y);
                    byte greyscaleVal = (byte)((pixel.R + pixel.G + pixel.B) / 3);

                    if(greyscaleVal < 128)
                    {
                        newImage.SetPixel(x, y, Color.Black);

                        byte errorDiff = (byte)(128 - greyscaleVal);
                        if (x+1 <= OriginalImage.Width)
                        {
                            Color errorPropogation = OriginalImage.GetPixel(x + 1, y);
                            //OriginalImage.SetPixel(x + 1, y, OriginalImage.GetPixel(x + 1, y)

                        }
                    }

                }
            }
        }
    }
}
