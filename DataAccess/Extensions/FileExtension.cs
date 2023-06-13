using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Extensions
{
    public static class FileExtension
    {
        public static bool CheckSize(this IFormFile file, double kb)
        {
            return file.ContentType.Length / 1024 > kb;
        }
        public static bool CheckType(this IFormFile file, string type)
        {
            return file.ContentType.Contains(type);
        }
        public static async Task<string> Upload(this IFormFile file, params string[] folders)
        {
            string FileName = Guid.NewGuid().ToString() + file.FileName;
            string pathFolders = Path.Combine(folders);
            string path = Path.Combine(pathFolders, FileName);
            using(FileStream fs=new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(fs);
            }
            return FileName;
        }
    }
}
