using System.Web;

namespace Demo.Image
{
    /// <summary>
    /// Class for encoding images
    /// </summary>
    public class ImageEncoding
    {
        /// <summary>
        /// Encodes an image to Base64
        /// </summary>
        /// <param name="imageFile"></param>
        /// <returns>imageBase64</returns>
        public static byte[] EncodingToBase64 (HttpPostedFileBase imageFile)
        {
            byte[] imageBase64 = new byte[imageFile.ContentLength];
            imageFile.InputStream.Read(imageBase64, 0, imageBase64.Length);

            return imageBase64;
        }
    }
}