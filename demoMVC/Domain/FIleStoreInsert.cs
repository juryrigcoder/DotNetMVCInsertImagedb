using System;
using System.Collections.Generic;
using System.IO;
using LiteDB;
using System.IO;

namespace demoMVC.Domain
{
    public class FIleStoreInsert
    {
        public static string Gallery {
            get { return "$/Gallery/"; }
        }

        public static void insertImages()
        {
            using (var db = new LiteDatabase(DbConnection.FileStorageLocation))
            {
                var path = @"C:\Users\Learning Clip\Documents\DotNetMVCInsertImagedb\demoMVC\Images\";
                var filePaths = Directory.GetFiles(path, "*.jpg");
                List<string> list = new List<string>();
                list.AddRange(filePaths);
                foreach (var file in list)
                {
                    var ext = Path.GetExtension(file);
                    var filename = Guid.NewGuid();
                    db.FileStorage.Upload(Gallery + filename + ext, file);
                }
            }
        }
    }
}