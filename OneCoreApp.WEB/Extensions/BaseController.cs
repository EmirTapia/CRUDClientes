using Microsoft.AspNetCore.Mvc;
using OneCore.API.Models;
using OneCore.WEB.Extensions;
using OneCore.WEB.Services.OneCoreAppAPI;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace OneCore.WEB.Extensions
{
    public class BaseController:Controller
    {
        public enum NotificationType {
            Success,
            Error        
        }
        public void BasicNotification(string message, NotificationType type, string title ="") 
        {
            TempData["notification"] = "<script language='javascript'> Swal.fire('"+ type.ToString().ToUpper() + "', '" + ReplaceNonAlphanumericCharacters(message) + "', '" + type.ToString().ToLower() + "')" + " </script>";
        }
        public string ReplaceNonAlphanumericCharacters(string str) 
            => Regex.Replace(str.ToLower(), "[^a-z0-9áéíóú -]", string.Empty).ToUpper();
        public void BasicNotification(string[] message, NotificationType type, string title = "")
        {
            TempData["notification"] = "<script language='javascript'> Swal.fire('" + type.ToString().ToUpper() + "', '" + message + "'.join(','), '" + type.ToString().ToLower() + "')" + " </script>";
        }
    }
}
