using System;
using System.IO;

namespace CBProject.HelperClasses
{
    public static class StaticImfo
    {
        public static string CVPath { get; } = @"/CV/";
        public static string CVPathRegistration { get; } = @"/CVRegistration/";
        public static string VideoImageFolder { get; set; } = "VideoImages";
        public static string VideoFilesFolder { get; } = "VideoFiles";
        public static string UsersImagesFolder { get; } = "UsersImages";
        public static string RegistrationImagesFolder { get; } = "RegistrationUsersImages";
        public static string EbooksImagesFolder { get; } = "EbooksImages";
        public static string EbooksFilesFolder { get; } = "EbooksFiles";
        public static string VideoImagePath { get; } = $@"/{VideoImageFolder}/";
        public static string VideoPath { get; } = $@"/{VideoFilesFolder}/";
        public static string UsersImagesPath { get; } = $@"/{UsersImagesFolder}/";
        public static string RegistrationImagesPath { get; } = $@"/{RegistrationImagesFolder}/";
        public static string EbooksImagesPath { get; } = $@"/{EbooksImagesFolder}/";
        public static string EbooksFilesPath { get; } = $@"/{EbooksFilesFolder}/";
        public static int PageSize { get; set; } = 8;
        public static string CurrentPath { 
            get {
                var currentPath = AppDomain.CurrentDomain.BaseDirectory;
                currentPath = Path.Combine(currentPath.Remove(currentPath.Length - 4));
                return currentPath;
            }
        }
    }
}