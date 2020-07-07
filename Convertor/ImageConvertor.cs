using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Convertor
{
    class ImageConvertor
    {
        private string filePath;
        private string savePath;
        private ImageFormat imageFormat;

        public ImageConvertor(string filePath, ImageFormat imageFormat)
        {
            this.filePath = filePath;
            this.imageFormat = imageFormat;
        }
        public ImageConvertor(string filePath, string savePath, ImageFormat imageFormat): this(filePath, imageFormat)
        {
            this.savePath = savePath;
        }

        public void SaveImageAs()
        {
            ImageConvertor.SaveImageAs(this.filePath, this.savePath, this.imageFormat);
            Console.WriteLine("done at "+DateTime.Now.ToLongTimeString());
        }

        /// <summary>
        /// saves the image in path 'filePath' to the same folder with the new format, but with the new format extention
        /// </summary>
        /// <param name="filePath">image file path to convert</param>
        /// <param name="imageFormat">converts to this image format</param>
        public static void SaveImageAs(string filePath, ImageFormat imageFormat)
        {
            using (Image image = new Bitmap(filePath))
            {
                string folderPath = Path.GetDirectoryName(filePath);
                string fileName = Path.GetFileNameWithoutExtension(filePath);
                string convertedExtention = imageFormat.ToString().ToLower();
                string savePath = string.Format("{0}\\{1}.{2}", folderPath, fileName, convertedExtention);

                image.Save(savePath, imageFormat);
            }
        }

        /// <summary>
        /// saves the image in path 'filePath' to 'savePath' with the new format
        /// </summary>
        /// <param name="filePath">image file path to convert</param>
        /// <param name="savePath">file path to save new image</param>
        /// <param name="imageFormat">converts to this image format</param>
        public static void SaveImageAs(string filePath, string savePath, ImageFormat imageFormat)
        {
            if (savePath == null)
            {
                SaveImageAs(filePath, imageFormat);
                return;
            }

            using (Image image = new Bitmap(filePath))
            {
                image.Save(savePath, imageFormat);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath">image file path to convert</param>
        /// <param name="savePath">file path to save new image</param>>
        /// <param name="quality">positive number between 0 and 1 , 1 is the same quality as source(removes compression), 0 is no quality, this will determine how big the file size is</param>
        public static void SaveImageAsJpg(string filePath, string savePath, float quality)
        {
            using (Image image = new Bitmap(filePath))
            {
                EncoderParameters es = new EncoderParameters();
                EncoderParameter e1 = new EncoderParameter(Encoder.Quality, (long)(quality * 100));

                es.Param = new EncoderParameter[] { e1 };
                image.Save(savePath, GetJpgCodec(), es);
            }
        }

        private static ImageCodecInfo JpgCodec = null;
        private static ImageCodecInfo GetJpgCodec()
        {
            if (JpgCodec != null)
                return JpgCodec;

            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == ImageFormat.Jpeg.Guid)
                {
                    JpgCodec = codec;
                    return codec;
                }
            }
            return null;
        }
    }
}
