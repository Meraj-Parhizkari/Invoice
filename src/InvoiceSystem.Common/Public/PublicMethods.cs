using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceSystem.Common.Public
{
    public static class PublicMethods
    {
        public enum LanguageEnum
        {
            Fa = 1,
            En = 2,
        }

        public static Dictionary<byte, string> Languages()
        {
            return new Dictionary<byte, string>() {
                {1 , "فارسی" },
                {2 , "انگلیسی" },

            };
        }
public enum DivisionEnum
        {
            Province = 1,
            City = 2,
        }

        public static Dictionary<int, string> Division()
        {
            return new Dictionary<int, string>() {
                {1 , "استان" },
                {2 , "شهر" },

            };
        }

        public static Dictionary<int, string> PersonType()
        {
            return new Dictionary<int, string>() {
                {1 , "حقیقی" },
                {2 , "حقوقی" },

            };
        }


        public enum PersonTypeEnum { 
            Real = 1,
            Legal = 2
        }
        public enum PostTypeEnum
        {
            Post = 1,
            Page = 2,
            //File = 2,
            //Product = 3,
            //Catalogue = 5,
            //Software = 6,
            //Application = 7,
            //Course = 8,
        }

        public enum MenuTypeEnum
        {
            all,
            adminpanel,
            topmenu,
            mainmenu,
            footermenu
            //File = 2,
            //Product = 3,
            //Catalogue = 5,
            //Software = 6,
            //Application = 7,
            //Course = 8,
        }
        public static Dictionary<byte, string> PostTypes()
        {
            return new Dictionary<byte, string>() {
                { 1 , "نوشته" },
                {2, "صفحه" },
                //{ 2 , "فایل" },
                //{ 3 , "محصول" },
                //{5, "کاتالوگ" },
                //{6, "نرم افزار" },
                //{7, "اپلیکیشن برنا" },
                //{8, "دوره" },
            };
        }

        public enum GenderTypeEnum
        {
            Female = 0,
            Male = 1
        }
        public static Dictionary<byte, string> GenderType()
        {
            return new Dictionary<byte, string>
            {
                {0,"زن" },
                { 1,"مرد" }
            };
        }
        public enum ContactUsStatusEnum
        {
            /// <summary>
            /// جدید
            /// </summary>
            New = 1,
            /// <summary>
            /// مشاهده شده
            /// </summary>
            Seen = 2,
            /// <summary>
            /// پاسخ داده شده
            /// </summary>
            Replied = 3,
            /// <summary>
            /// در حال بررسی
            /// </summary>
            Pending = 4,
            /// <summary>
            /// باطل شده
            /// </summary>
            Void = 5,
        }
        public static Dictionary<int, string> ContactUsStatus()
        {
            return new Dictionary<int, string>() {
                {1, "جدید"},
                {2, "مشاهده شده"},
                {3, "پاسخ داده شده"},
                {4, "در حال بررسی"},
                {5, "باطل شده"},
            };
        }
        public enum CarStatusEnum
        {
            /// <summary>
            /// جدید
            /// </summary>
            New = 1,
            /// <summary>
            /// در حال بررسی
            /// </summary>
            Pending = 2,
            /// <summary>
            /// ویرایش شده
            /// </summary>
            Edited = 3,
            /// <summary>
            /// تایید شده
            /// </summary>
            Confirmed = 4,
            /// <summary>
            /// باطل شده
            /// </summary>
            Void = 5,
            /// <summary>
            /// انصراف شده
            /// </summary>
            Canceled = 6
        }
        /// <summary>
        /// نوع آگهی 
        /// </summary>
        public enum CarTypeStatusEnum
        {
            /// <summary>
            /// خرید خودرو
            /// </summary>
            Buy = 0,
            /// <summary>
            /// فروش خودرو
            /// </summary>
            Sale = 1,
        }
        public static Dictionary<int, string> CarStatus()
        {
            return new Dictionary<int, string>() {
                {1, "جدید"},
                {2, "در حال بررسی"},
                {3, "ویرایش شده"},
                {4, "تایید شده"},
                {5, "باطل شده"},
                {6, "انصراف شده"},
            };
        }



        public enum SliderTypeEnum
        {
            Type1 = 1,
            Typq2 = 2,
        }
        public enum DivisionTypeEnum
        {
            Country = 1,
            Province = 2,
            City = 3,
        }
        public enum CarFTypeEnum
        {
            Brand = 1,
            Model = 2,
            Tip = 3,
        }
        public static Dictionary<int, string> CarFType()
        {
            return new Dictionary<int, string>() {
                {1, "برند" },
                {2, "مدل" },
                {3, "تیپ" }

            };
        }


        public enum BuyTypeEnum
        {
            /// <summary>
            /// نقدی
            /// </summary>
            ByCash,
            /// <summary>
            /// امانی
            /// </summary>
            Lending,
            /// <summary>
            /// ثبت نامی
            /// </summary>
            Registration,
            /// <summary>
            /// تاکسی
            /// </summary>
            Taxi,
            /// <summary>
            /// فرسوده
            /// </summary>
            Obsolete,
        }
        public static Dictionary<byte, string> BuyType()
        {
            return new Dictionary<byte, string>
            {
                {1,"نقدی" },
                {2,"امانی" },
                {3,"ثبت نام" },
                {4,"تاکسی" },
                {5,"فرسوده" },
            };
        }

        /// <summary>
        /// وضعیت خودرو
        /// </summary>
        public enum CarStatusIdEnum
        {
            New = 1,
            Used = 2
        }
        /// <summary>
        /// وضعیت خودرو
        /// </summary>
        /// <returns></returns>
        public static Dictionary<byte, string> CarStatusId()
        {
            return new Dictionary<byte, string>
            {
                { 1,"صفر" },
                {2,"کارکرده" },
            };
        }

        /// <summary>
        /// نوع پلاک
        /// </summary>
        public enum CarPlateTypeEnum
        {
            Meli = 1,
            Kardex = 2,
            Azad = 3
        }
        /// <summary>
        /// نوع پلاک
        /// </summary>
        /// <returns></returns>
        public static Dictionary<byte, string> CarPlateType()
        {
            return new Dictionary<byte, string>
            {
                { 1,"ملی" },
                {2,"کاردکس" },
                {3,"آزاد" },
            };
        }


        /// <summary>
        /// نوع یا نحوه پرداخت 
        /// </summary>
        public enum CarPayStatusEnum
        {
            Cash = 1,
            Installment = 2,
            Changable = 3
        }
        /// <summary>
        /// نوع یا نحوه پرداخت
        /// </summary>
        /// <returns></returns>
        public static Dictionary<byte, string> CarPayStatus()
        {
            return new Dictionary<byte, string>
            {
                { 1,"نقد" },
                {2,"اقساط" },
                {3,"قابل معاوضه" },
            };
        }

        /// <summary>
        /// نوع رنگ 
        /// </summary>
        public enum ColorTypeEnum
        {
            BodyColor = 1,
            InsideColor = 2,
        }
        /// <summary>
        /// نوع رنگ
        /// </summary>
        /// <returns></returns>
        public static Dictionary<byte, string> ColorType()
        {
            return new Dictionary<byte, string>
            {
                { 1,"رنگ بدنه" },
                {2,"رنگ داخل" },

            };
        }

        public static class Paths
        {
            public static string SliderImages = @"Uploads/Images/Sliders/";
            public static string SliderThumbnailImages = @"Uploads/Images/Sliders/Thumbnails/";
            public static string SectionImages = @"Uploads/Images/Sections/";
            public static string SectionThumbnailImages = @"Uploads/Images/Sections/Thumbnails/";
            public static string CarImages = @"Uploads/Images/Ads/";
            public static string CarThumbnailImages = @"Uploads/Images/Ads/Thumbnails/";
            public static string PostImages = @"Uploads/Images/Posts/";
            public static string PostThumbnailImages = @"Uploads/Images/Posts/Thumbnails/";
        }

        public static class SystemSettingNames
        {
            public static string SectionA = nameof(SectionA);
            public static string SectionB = nameof(SectionB);
            public static string SectionC = nameof(SectionC);
            public static string SectionD = nameof(SectionD);
            public static string SectionE = nameof(SectionE);
            public static string SectionFooter = nameof(SectionFooter);
            public static string MainSlider = nameof(MainSlider);
        }
    }
}
