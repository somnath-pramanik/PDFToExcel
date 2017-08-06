using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using PDFTOXLS.Models;
namespace PDFTOXLS.Helper
{
    public class ImageHelper
    {
        public string LocalFolder { get; set; }

        #region Code Generating full and small Image

        ////public void GenerateFullImage(Image original, Logo image, int someId, string filename)
        ////{
        ////    Size newSize = GenerateImageDimensions(original.Width, original.Height, 228, 42);

        ////    using (var resized = new Bitmap(original, newSize.Width, newSize.Height))
        ////    {
        ////        string[] words = filename.Split('.');
        ////        if (words[words.Length - 1].ToLower() == "png")
        ////        {
        ////            resized.Save(LocalFolder + filename, ImageFormat.Png);
        ////        }
        ////        else if (words[words.Length - 1].ToLower() == "jpg")
        ////        {
        ////            resized.Save(LocalFolder + filename, ImageFormat.Jpeg);
        ////        }
        ////        else if (words[words.Length - 1].ToLower() == "jpeg")
        ////        {
        ////            resized.Save(LocalFolder + filename, ImageFormat.Jpeg);
        ////        }
        ////        else if (words[words.Length - 1].ToLower() == "gif")
        ////        {
        ////            resized.Save(LocalFolder + filename, ImageFormat.Gif);
        ////        }

        ////    }


        ////    //image.Width = newSize.Width;
        ////    //image.Height = newSize.Height;
        ////    //image.ImagePath = +someId + "full.jpg";
        ////}

        ////public void GenerateSmallImage(Image original, Logo image, int someId)
        ////{
        ////    Size newSize = GenerateImageDimensions(original.Width, original.Height, 53, 72);

        ////    using (var resized = new Bitmap(original, newSize.Width, newSize.Height))
        ////    {
        ////        resized.Save(LocalFolder + someId + "small.jpg", ImageFormat.Jpeg);
        ////    }


        ////    //image.SmallHeight = newSize.Height;
        ////    //image.SmallWidth = newSize.Width;
        ////    //image.SmallImagePath = +someId + "small.jpg";
        ////}

        ////private void SaveSmallImage(Image original, Logo image)
        ////{
        ////    Size newSize = GenerateImageDimensions(original.Width, original.Height, 53, 72);

        ////    using (var resized = new Bitmap(original, newSize.Width, newSize.Height))
        ////    {
        ////        resized.Save(LocalFolder + "small.jpg", ImageFormat.Jpeg);
        ////    }


        ////    //image.SmallHeight = newSize.Height;
        ////    //image.SmallWidth = newSize.Width;
        ////    //image.SmallImagePath = "small.jpg";
        ////}


        private static Size GenerateImageDimensions(int currW, int currH, int destW, int destH)
        {
            //double to hold the final multiplier to use when scaling the image
            double multiplier = 0;

            //string for holding layout

            //determine if it's Portrait or Landscape
            string layout = currH > currW ? "portrait" : "landscape";

            switch (layout.ToLower())
            {
                case "portrait":
                    //calculate multiplier on heights
                    if (destH > destW)
                    {
                        multiplier = destW / (double)currW;
                    }

                    else
                    {
                        multiplier = destH / (double)currH;
                    }
                    break;
                case "landscape":
                    //calculate multiplier on widths
                    if (destH > destW)
                    {
                        multiplier = destW / (double)currW;
                    }

                    else
                    {
                        multiplier = destH / (double)currH;
                    }
                    break;
            }

            //return the new image dimensions
            return new Size((int)(currW * multiplier), (int)(currH * multiplier));
        }
        #endregion

        #region File Generating full and small Image

        public void FileFullPath(Image original, int someId, string filename)
        {
            Size newSize = GenerateImageDimensions(original.Width, original.Height, 150, 150);// 400, 250);

            using (var resized = new Bitmap(original, newSize.Width, newSize.Height))
            {
                string[] words = filename.Split('.');
                if (words[words.Length - 1].ToLower() == "png")
                {
                    resized.Save(LocalFolder + someId.ToString().Trim() + filename, ImageFormat.Png);
                }
                else if (words[words.Length - 1].ToLower() == "jpg")
                {
                    resized.Save(LocalFolder + someId.ToString().Trim() + filename, ImageFormat.Jpeg);
                }
                else if (words[words.Length - 1].ToLower() == "jpeg")
                {
                    resized.Save(LocalFolder + someId.ToString().Trim() + filename, ImageFormat.Jpeg);
                }
                else if (words[words.Length - 1].ToLower() == "gif")
                {
                    resized.Save(LocalFolder + someId.ToString().Trim() + filename, ImageFormat.Gif);
                }
                else if (words[words.Length - 1].ToLower() == "tiff")
                {
                    resized.Save(LocalFolder + someId.ToString().Trim() + filename, ImageFormat.Tiff);
                }
                else if (words[words.Length - 1].ToLower() == "bmp")
                {
                    resized.Save(LocalFolder + someId.ToString().Trim() + filename, ImageFormat.Bmp);
                }

            }
        }


        public void FileFullPath(Image original, Ex_user_new user, int someId, string filename)
        {
            Size newSize = GenerateImageDimensions(original.Width, original.Height, 188, 187);

            using (var resized = new Bitmap(original, newSize.Width, newSize.Height))
            {
                string[] words = filename.Split('.');
                if (words[words.Length - 1].ToLower() == "png")
                {
                    resized.Save(LocalFolder + filename, ImageFormat.Png);
                }
                else if (words[words.Length - 1].ToLower() == "jpg")
                {
                    resized.Save(LocalFolder + filename, ImageFormat.Jpeg);
                }
                else if (words[words.Length - 1].ToLower() == "jpeg")
                {
                    resized.Save(LocalFolder + filename, ImageFormat.Jpeg);
                }
                else if (words[words.Length - 1].ToLower() == "gif")
                {
                    resized.Save(LocalFolder + filename, ImageFormat.Gif);
                }

            }
        }

        #endregion
        public static readonly TimeZoneInfo DefaultTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
        public static DateTime GetUserLocalTime(DateTime originalTime, int Timezoneid)
        {
            MainContext _mc = new MainContext();
            TimeZoneInfo convertTo = DefaultTimeZone;
            string LocalTimeZone = _mc.tbTimeZoneInfo.Find(Timezoneid).ZoneId;
            TimeZoneInfo tst = TimeZoneInfo.FindSystemTimeZoneById(LocalTimeZone);

            DateTime now = DateTime.SpecifyKind(originalTime, DateTimeKind.Unspecified);

            //return String.Format("{0:d/M/yyyy HH:mm:ss}", TimeZoneInfo.ConvertTimeFromUtc(now, tst));
            return TimeZoneInfo.ConvertTimeFromUtc(now, tst);
        }

        public static DateTime GetUserLocalTimeStr(DateTime originalTime, string Timezoneid)
        {
            MainContext _mc = new MainContext();
            TimeZoneInfo convertTo = DefaultTimeZone;
            var LocalTimeZone = _mc.tbTimeZoneInfo.Where(c => c.timeoffset == Timezoneid).ToList();
            TimeZoneInfo tst = TimeZoneInfo.FindSystemTimeZoneById(LocalTimeZone[0].ZoneId);

            DateTime now = DateTime.SpecifyKind(originalTime, DateTimeKind.Unspecified);

            //return String.Format("{0:d/M/yyyy HH:mm:ss}", TimeZoneInfo.ConvertTimeFromUtc(now, tst));
            return TimeZoneInfo.ConvertTimeFromUtc(now, tst);
        }

       // private static DateTime? _dateTime;

       // public static readonly TimeZoneInfo DefaultTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");

        //public static DateTime GetUserLocalTime(DateTime originalTime, Int16 Timezoneid)
        //{
        //    MainContext _mc = new MainContext();
        //    TimeZoneInfo convertTo = DefaultTimeZone;
        //    string LocalTimeZone = _mc.tbTimeZoneInfo.Find(Timezoneid).Display;
        //    //if (user != null)
        //    //{
        //    //    convertTo = user.LocalTZone;
        //    //}
        //    // return TimeZoneInfo.ConvertTimeFromUtc(originalTime, LocalTimeZone);
        //}
    }

}