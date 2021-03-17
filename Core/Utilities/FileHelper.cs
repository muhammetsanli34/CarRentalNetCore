using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities
{

    public class FileHelper
    {
        public static string Add(IFormFile file)
        {
            string newPath = NewPath(file);
            var path = Path.GetTempFileName();
            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            File.Move(path, newPath);
            return newPath;
        }

        public static string Update(IFormFile file,string oldPath)
        {
            var newPath = NewPath(file);
            using (var stream = new FileStream(newPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            File.Delete(oldPath);
            return newPath;
        }

        public static IResult Delete (string path)
        {
            File.Delete(path);
            return new SuccessResult();
        }

        public static string NewPath(IFormFile file)
        {
            System.IO.FileInfo ff = new System.IO.FileInfo(file.FileName);
            var createfileName = Guid.NewGuid() + ff.Extension;
            string newPath = Environment.CurrentDirectory + @"\Static\Images\" + createfileName;
            return newPath;
        }



    }
}
    
