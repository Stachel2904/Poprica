using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poprica
{
    public sealed class ContentLoader
    {

        #region Singleton
        private static ContentLoader main;

        public static ContentLoader Main
        {
            get
            {
                if (main == null)
                {
                    main = new ContentLoader();
                }

                return main;
            }
        }
        #endregion

        private string path;
        private string[] directories;
        public Dictionary<ImageType, dynamic> files;

        private ContentLoader()
        {
            path = "Content/Sprites/";
            
        }

        public void LoadContent()
        {
            directories = Directory.GetDirectories(path);

            files = new Dictionary<ImageType, dynamic>();

            for (int i = 0; i < directories.Length; i++)
            {
                string name = new DirectoryInfo(directories[i]).Name;

                if (directories[i] == "Content/Sprites/Poprica")
                {
                    string[] subDirectories = Directory.GetDirectories(directories[i]);

                    for (int j = 0; j < subDirectories.Length; j++)
                    {
                        string subName = new DirectoryInfo(subDirectories[j]).Name;

                        string[] filePaths = Directory.GetFiles(path + name + "/" + subName);
                        string[] fileNames = new string[filePaths.Length];

                        for (int k = 0; k < filePaths.Length; k++)
                        {
                            //fileNames[k] = subDirectories[j].Remove(0, 8) + "/" + new FileInfo(filePaths[k]).Name;
                            //Console.WriteLine(fileNames[k]);
                            fileNames[k] = filePaths[k].Substring(8, (filePaths[k].Length - 4 - 8));
                        }

                        files.Add((ImageType)Enum.Parse(typeof(ImageType), subName), fileNames);
                    }
                }
                else
                {
                    string[] filePaths = Directory.GetFiles(path + name);
                    string[] fileNames = new string[filePaths.Length];

                    for (int j = 0; j < filePaths.Length; j++)
                    {
                        //fileNames[j] = directories[i].Remove(0, 8) + "/" + new FileInfo(filePaths[j]).Name;
                        //Console.WriteLine(filePaths[j]);
                        fileNames[j] = filePaths[j].Substring(8, (filePaths[j].Length-4-8));
                    }

                    //Console.WriteLine(path + name);

                    files.Add((ImageType) Enum.Parse(typeof(ImageType), name), fileNames);
                }
                
                //Console.WriteLine(new DirectoryInfo(directories[i]).Name);
            }

            Maps.ImageMap = files;
        }
    }
}
