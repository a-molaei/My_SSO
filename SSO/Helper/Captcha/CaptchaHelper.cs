using SSO.ViewModels.Captcha;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.Helper.Captcha
{
    public static class CaptchaHelper
    {
        public static CaptchaResponseDto GenerateCaptcha()
        {
            var captchaValue = new CaptchaValue()
            {
                Value = new RandomNumber().GenerateRandomNumber(4),
                LastTimeAttempted = DateTime.Now,
                FirstTimeAttempted = DateTime.Now,
                NumberOfTimesAttempted = 0
            };
            int width = 190;
            int height = 80;

            var fontEmSizes = new int[] { 15, 20, 25, 30, 35 };

            var fontNames = new string[]
            {
            "Trebuchet MS",
            "Arial",
            "Times New Roman",
            "Georgia",
            "Verdana",
            "Geneva"
            };

            FontStyle[] fontStyles =
            {
            FontStyle.Bold,
            FontStyle.Italic,
            FontStyle.Regular,
            FontStyle.Strikeout,
            FontStyle.Underline
        };

            HatchStyle[] hatchStyles =
            {
            HatchStyle.BackwardDiagonal, HatchStyle.Cross,
            HatchStyle.DashedDownwardDiagonal, HatchStyle.DashedHorizontal,
            HatchStyle.DashedUpwardDiagonal, HatchStyle.DashedVertical,
            HatchStyle.DiagonalBrick, HatchStyle.DiagonalCross,
            HatchStyle.Divot, HatchStyle.DottedDiamond, HatchStyle.DottedGrid,
            HatchStyle.ForwardDiagonal, HatchStyle.Horizontal,
            HatchStyle.HorizontalBrick, HatchStyle.LargeCheckerBoard,
            HatchStyle.LargeConfetti, HatchStyle.LargeGrid,
            HatchStyle.LightDownwardDiagonal, HatchStyle.LightHorizontal,
            HatchStyle.LightUpwardDiagonal, HatchStyle.LightVertical,
            HatchStyle.Max, HatchStyle.Min, HatchStyle.NarrowHorizontal,
            HatchStyle.NarrowVertical, HatchStyle.OutlinedDiamond,
            HatchStyle.Plaid, HatchStyle.Shingle, HatchStyle.SmallCheckerBoard,
            HatchStyle.SmallConfetti, HatchStyle.SmallGrid,
            HatchStyle.SolidDiamond, HatchStyle.Sphere, HatchStyle.Trellis,
            HatchStyle.Vertical, HatchStyle.Wave, HatchStyle.Weave,
            HatchStyle.WideDownwardDiagonal, HatchStyle.WideUpwardDiagonal, HatchStyle.ZigZag
        };

            var bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            var graphics = Graphics.FromImage(bitmap);
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

            var rectangleF = new RectangleF(0, 0, width, height);

            var random = new Random();

            //Draw background (Lighter colors RGB 100 to 255)
            var brush = new HatchBrush(hatchStyles[random.Next
                (hatchStyles.Length - 1)], Color.FromArgb((random.Next(100, 255)),
                (random.Next(100, 255)), (random.Next(100, 255))), Color.White);
            graphics.FillRectangle(brush, rectangleF);

            // There is no spoon
            var theMatrix = new Matrix();

            for (var i = 0; i <= captchaValue.Value.Length - 1; i++)
            {
                theMatrix.Reset();

                var charLength = captchaValue.Value.Length;
                var x = width / (charLength + 1) * i;
                var y = height / 2;

                //Rotate text Random
                theMatrix.RotateAt(random.Next(-40, 40), new PointF(x, y));

                graphics.Transform = theMatrix;

                //Draw the letters with Random Font Type, Size and Color
                graphics.DrawString
                (
                    //Text
                    captchaValue.Value.Substring(i, 1),

                    //Random Font Name and Style
                    new Font(fontNames[random.Next(fontNames.Length - 1)],
                        fontEmSizes[random.Next(fontEmSizes.Length - 1)],
                        fontStyles[random.Next(fontStyles.Length - 1)]),

                    //Random Color (Darker colors RGB 0 to 100)
                    new SolidBrush(Color.FromArgb(random.Next(0, 100),
                        random.Next(0, 100), random.Next(0, 100))),
                    x,

                    random.Next(10, 40)
                );

                graphics.ResetTransform();
            }

            var buffer = new byte[16 * 1024];

            // Create the base64 string from the bitmap
            using (var ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Png);

                int read;

                while ((read = ms.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }

                var base64String = Convert.ToBase64String(ms.ToArray());

                CaptchaResponseDto dto = new CaptchaResponseDto()
                {
                    CaptchaImage = $"data:image/png;base64,{base64String}",
                    Key = CryptographyHelper.Crypt(captchaValue.Value)
                };

                return dto;
            }
        }
        public static bool ValidateCaptcha(string key, string userInput)
        {
            if (CryptographyHelper.Decrypt(key) == userInput)
                return true;
            else return false;
        }
    }

    //public class Captcha
    //{
    //    public string ValueString { get; set; }

    //    public bool AttemptSucceeded { get; set; }

    //    public bool AttemptFailed { get; set; }

    //    public string AttemptFailedMessage { get; set; }
    //}

    [Serializable]
    public class CaptchaValue
    {
        public string Value { get; set; }

        public DateTime FirstTimeAttempted { get; set; }

        public DateTime LastTimeAttempted { get; set; }

        public int NumberOfTimesAttempted { get; set; }
    }

}
