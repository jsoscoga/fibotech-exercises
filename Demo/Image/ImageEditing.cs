using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web;

namespace Demo.Image
{
    /// <summary>
    /// Class for editing images
    /// </summary>
    public class ImageEditing
    {
        /// <summary>
        /// Add a frame for each face found
        /// </summary>
        /// <param name="imageFile"></param>
        /// <param name="faces"></param>
        /// <returns>bitmapImage</returns>
        public static Bitmap AddFrames(HttpPostedFileBase imageFile, List<Models.Face> faces)
        {
            Bitmap bitmapImage = new Bitmap(imageFile.InputStream);

            System.Drawing.Image newImage = new Bitmap(bitmapImage.Width, bitmapImage.Height);
            using (Graphics imageGraphics = Graphics.FromImage(bitmapImage))
            {
                foreach(var face in faces)
                {
                    using (Brush brush = new SolidBrush(Color.LimeGreen))
                    {
                        Pen pen = new Pen(brush, 5);
                        imageGraphics.DrawLine(
                            pen, 
                            new Point(face.FaceRectangle.Left, face.FaceRectangle.Top), 
                            new Point(face.FaceRectangle.Left + face.FaceRectangle.Width, face.FaceRectangle.Top)
                        );
                        imageGraphics.DrawLine(
                            pen,
                            new Point(face.FaceRectangle.Left + face.FaceRectangle.Width, face.FaceRectangle.Top),
                            new Point(face.FaceRectangle.Left + face.FaceRectangle.Width, face.FaceRectangle.Top + face.FaceRectangle.Width)
                        );
                        imageGraphics.DrawLine(
                            pen,
                            new Point(face.FaceRectangle.Left + face.FaceRectangle.Width, face.FaceRectangle.Top + face.FaceRectangle.Width),
                            new Point(face.FaceRectangle.Left, face.FaceRectangle.Top + face.FaceRectangle.Width)
                        );
                        imageGraphics.DrawLine(
                            pen,
                            new Point(face.FaceRectangle.Left, face.FaceRectangle.Top + face.FaceRectangle.Width),
                            new Point(face.FaceRectangle.Left, face.FaceRectangle.Top)
                        );
                        Font scaledFont = GetScaledFont(imageGraphics, face.FaceId.Substring(0, 8), new Font(FontFamily.GenericSansSerif, 2), face.FaceRectangle.Width, face.FaceRectangle.Height);
                        imageGraphics.DrawString(face.FaceId.Substring(0, 8), scaledFont, brush, new Point(face.FaceRectangle.Left + 3, face.FaceRectangle.Top + face.FaceRectangle.Width - 30));
                    }
                }
            }

            return bitmapImage;
        }

        /// <summary>
        /// Returns an instance of Font with scaled font size
        /// </summary>
        /// <param name="imageGraphics"></param>
        /// <param name="textToShow"></param>
        /// <param name="selectedFont"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns>new Font</returns>
        private static Font GetScaledFont(Graphics imageGraphics, string textToShow, Font selectedFont, int width, int height)
        {
            SizeF realSize = imageGraphics.MeasureString(textToShow, selectedFont);
            float scaledWidthRatio = width / realSize.Width;
            float scaledHeightRatio = height / realSize.Height;

            float scaledRatio = (scaledHeightRatio < scaledWidthRatio) ? scaledHeightRatio : scaledWidthRatio;

            float scaledFontSize = selectedFont.Size * scaledRatio;

            return new Font(FontFamily.GenericSansSerif, scaledFontSize);
        }

        /// <summary>
        /// Returns a response of saving bitmap instance as image file
        /// </summary>
        /// <param name="bitmapImageFile"></param>
        /// <param name="physicalPath"></param>
        /// <returns>failed</returns>
        public static string SaveImage(Bitmap bitmapImageFile, string physicalPath)
        {
            string failed;
            try
            {
                bitmapImageFile.Save(physicalPath);
                failed = "";
            } catch (ArgumentNullException ex)
            {
                failed = "Filename is null";
            } catch (System.Runtime.InteropServices.ExternalException ex)
            {
                failed = "Image either saved in wrong format or saved on same file was created from";
            }
            return failed;
        }
    }
}