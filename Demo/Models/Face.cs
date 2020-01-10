using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.Models
{
    /// <summary>
    /// Class for parsing Json response from Face API V1.0
    /// </summary>
    public class Face
    {
        public class FRectangle
        {
            public int Top { get; set; }
            public int Left { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }

        }

        public class FAttributes
        {
            public class FEmotion
            {
                public decimal Anger { get; set; }
                public decimal Contempt { get; set; }
                public decimal Disgust { get; set; }
                public decimal Fear { get; set; }
                public decimal Happiness { get; set; }
                public decimal Neutral { get; set; }
                public decimal Sadness { get; set; }
                public decimal Surprise { get; set; }
            }

            public class FEmotionMajor
            {
                public bool Anger { get; set; }
                public bool Contempt { get; set; }
                public bool Disgust { get; set; }
                public bool Fear { get; set; }
                public bool Happiness { get; set; }
                public bool Neutral { get; set; }
                public bool Sadness { get; set; }
                public bool Surprise { get; set; }

                public FEmotionMajor()
                {
                    Anger = false;
                    Contempt = false;
                    Disgust = false;
                    Fear = false;
                    Happiness = false;
                    Neutral = false;
                    Sadness = false;
                    Surprise = false;
                }
            }

            public FEmotion Emotion { get; set; }
            public FEmotionMajor EmotionMajor { get; set; }

            /// <summary>
            /// Sets values of EmotionMajor instance
            /// </summary>
            public void SetEmotionMajors()
            {
                string[] emotions =
                {
                    "Anger",
                    "Contempt",
                    "Disgust",
                    "Fear",
                    "Happiness",
                    "Neutral",
                    "Sadness",
                    "Surprise",
                };

                decimal[] values = {
                    Emotion.Anger,
                    Emotion.Contempt,
                    Emotion.Disgust,
                    Emotion.Fear,
                    Emotion.Happiness,
                    Emotion.Neutral ,
                    Emotion.Sadness ,
                    Emotion.Surprise,
                    0
                };

                decimal first = 0, second = 0, third = 0;
                int pFirst = 0, pSecond = 0, pThird = 0;

                for (int i = 0; i < emotions.Length; i++)
                {
                    if (first < values[i])
                    {
                        third = second;
                        second = first;
                        first = values[i];
                        pThird = pSecond;
                        pSecond = pFirst;
                        pFirst = i;
                    }
                    else if (second < values[i])
                    {
                        third = second;
                        second = values[i];
                        pThird = pSecond;
                        pSecond = i;
                    }
                    else if (third < values[i])
                    {
                        third = values[i];
                        pThird = i;
                    }
                }

                EmotionMajor = new FEmotionMajor();
                EmotionMajor.GetType().GetProperty(emotions[pFirst]).SetValue(EmotionMajor, true);
                EmotionMajor.GetType().GetProperty(emotions[pSecond]).SetValue(EmotionMajor, true);
                EmotionMajor.GetType().GetProperty(emotions[pThird]).SetValue(EmotionMajor, true);
            }
        }

        public string FaceId { get; set; }
        public FRectangle FaceRectangle { get; set; }
        public FAttributes FaceAttributes { get; set; }
    }
}