using Plugin.Settings;
using Plugin.Settings.Abstractions;
using SII.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SII
{
    public static class Settings
    {

        private static ISettings AppSettings =>
            CrossSettings.Current;

        public static string UserName
        {
            get => AppSettings.GetValueOrDefault(nameof(UserName), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(UserName), value);
        }
        public static string iduser
        {
            get => AppSettings.GetValueOrDefault(nameof(iduser), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(iduser), value);
        }
        public static String token
        {
            get => AppSettings.GetValueOrDefault(nameof(token), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(token), value);
        }
        public static string password
        {
            get => AppSettings.GetValueOrDefault(nameof(password), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(password), value);
        }
        public static string idStudent
        {
            get => AppSettings.GetValueOrDefault(nameof(idStudent), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(idStudent), value);
        }
        public static string ip
        {
            get => AppSettings.GetValueOrDefault(nameof(ip), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(ip), value);
        }
        public static String user_image
        {
            get => AppSettings.GetValueOrDefault(nameof(user_image), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(user_image), value);
        }
        public static String user_name
        {
            get => AppSettings.GetValueOrDefault(nameof(user_name), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(user_name), value);
        }
        public static String user_email
        {
            get => AppSettings.GetValueOrDefault(nameof(user_email), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(user_email), value);
        }
        public static String user_num_co
        {
            get => AppSettings.GetValueOrDefault(nameof(user_num_co), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(user_num_co), value);
        }

    }
}
