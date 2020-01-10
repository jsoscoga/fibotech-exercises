using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace EmotionAPI
{
    /// <summary>
    /// Class for connect to Face API V1.0
    /// </summary>
    public class Emotions
    {
        // Replace value of subscription key with a valid subscription key
        const string subscriptionKey = "eddb273a7cd2461084c02d0ec5a4d9c8";

        // Replace value of uriBase with a valid endpoint URL
        const string uriEndpoint = "https://westcentralus.api.cognitive.microsoft.com/face/v1.0/detect";

        // Request parameters to be returned in response content
        const string requestParameters = "returnFaceId=true&returnFaceLandmarks=false" +
                "&returnFaceAttributes=emotion";

        /// <summary>
        /// Main method for getting image result
        /// </summary>
        /// <param name="imageFile"></param>
        /// <returns>string result</returns>
        public static string GetImage(byte[] imageFile)
        {
            return MakeAnalysisRequest(imageFile).Result;
        }

        /// <summary>
        /// Async method for connecting to API
        /// </summary>
        /// <param name="imageFile"></param>
        /// <returns></returns>
        static async Task<string> MakeAnalysisRequest(byte[] imageFile)
        {
            string uri = uriEndpoint + "?" + requestParameters;

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

            HttpResponseMessage response;
            using (ByteArrayContent content = new ByteArrayContent(imageFile))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response = await client.PostAsync(uri, content);
                string responseContent = await response.Content.ReadAsStringAsync();
                return responseContent;
            }
        }
    }
}
