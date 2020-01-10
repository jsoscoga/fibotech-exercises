using EmotionAPI;

namespace WCFImage
{
    /// <summary>
    /// Implementation class of Interface IUploadImage
    /// </summary>
    public class UploadImage : IUploadImage
    {
        /// <summary>
        /// WebService method for using EmotionAPI
        /// </summary>
        /// <param name="imageFile"></param>
        /// <param name="fileName"></param>
        /// <returns>string</returns>
        public string Upload(byte[] imageFile, string fileName) => Emotions.GetImage(imageFile);
    }
}
