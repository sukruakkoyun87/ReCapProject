﻿using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Text;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.FileHelper
{
    public class FileHelper
    {
        public static string Add(IFormFile file)
        {
            var sourcepath = Path.GetTempFileName();
            if (file.Length > 0)
            {
                using (var stream = new FileStream(sourcepath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            var result = newPath(file);
            File.Move(sourcepath, result);
            return result;
        }
        public static void Delete(string path)
        {
            File.Delete(path);
        }
        public static string Update(string sourcePath, IFormFile file)
        {
            var result = newPath(file);
            if (sourcePath.Length > 0)
            {
                using (var stream = new FileStream(result, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            File.Delete(sourcePath);
            return result;
        }
        public static string newPath(IFormFile file)
        {
            FileInfo ff = new FileInfo(file.FileName);
            string fileExtension = ff.Extension;

            string path = Environment.CurrentDirectory + @"\Images\Cars";
            var newPath = Guid.NewGuid().ToString() + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Year + fileExtension;
          
            if (!Directory.Exists(file.Name))
            {
                Directory.CreateDirectory(path);
            }
            string result = $@"{path}\{newPath}";
            return result;
        }

    }
}
