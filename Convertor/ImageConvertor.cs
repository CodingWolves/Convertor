using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;

namespace Convertor
{
    class ImageConvertor
    {
        private readonly string filePath;
        private readonly string savePath;
        private readonly ImageFormat imageFormat;

        /// <summary>
        /// class for multithread use of SaveImageAs
        /// </summary>
        /// <param name="filePath">image file path to convert</param>
        /// <param name="imageFormat">converts to this image format</param>
        public ImageConvertor(string filePath, ImageFormat imageFormat)
        {
            this.filePath = filePath;
            this.imageFormat = imageFormat;
        }

        /// <summary>
        /// class for multithread use of SaveImageAs
        /// </summary>
        /// <param name="filePath">image file path to convert</param>
        /// <param name="savePath">file path to save new image</param>
        /// <param name="imageFormat">converts to this image format</param>
        public ImageConvertor(string filePath, string savePath, ImageFormat imageFormat) : this(filePath, imageFormat)
        {
            this.savePath = savePath;
        }

        /// <summary>
        /// converts the image in path 'filePath' to 'imageFormat' and saves it in 'savePath'
        /// </summary>
        public void SaveImageAs()
        {
            ImageConvertor.SaveImageAs(this.filePath, this.savePath, this.imageFormat);
        }

        /// <summary>
        /// converts the image in path 'filePath' to 'imageFormat' and saves it in 'filePath' but with a the extention
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
        /// converts the image in path 'filePath' to 'imageFormat' and saves it in 'savePath'
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
        /// converts the image in path 'filePath' to 'imageFormat' and saves it in 'savePath'
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
