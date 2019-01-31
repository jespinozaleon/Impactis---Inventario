using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Storage
{
    public class FileManager
    {
        private string Root { get; set; }

        public FileManager()
        {
            this.Root = Utilities.Parameter.GetValue("Storage");
        }

        public byte[] GetBytes(string container, string name)
        {
            try
            {
                var fileName = this.Root + container + @"/" + name;

                var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                var bytes = ReadFully(stream);
                stream.Close();
                return bytes;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Exists(string container, string name)
        {
            try
            {
                var fileName = this.Root + container + @"/" + name;
                return System.IO.File.Exists(fileName);
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public static byte[] ReadFully(Stream input)
        {
            input.Position = 0;
            using (var ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }

        public void CreateDirectory(string container, string directory)
        {
            if (System.IO.Directory.Exists(this.Root + container + @"/" + directory) == false)
            {
                System.IO.Directory.CreateDirectory(this.Root + container + @"/" + directory);
            }
        }

        public bool Upload(string container, string name, byte[] content)
        {
            if (System.IO.Directory.Exists(this.Root + container) == false)
            {
                System.IO.Directory.CreateDirectory(this.Root + container);
            }

            var fileName = this.Root + container + @"/" + name;
            var file = System.IO.File.Create(fileName);

            file.Write(content, 0, content.Length);
            file.Close();

            return true;
        }

        public bool Delete(string name)
        {
            var fileName = this.Root + @"/" + name;
            var fi = new System.IO.FileInfo(fileName);
            try
            {
                fi.Delete();
                return true;
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool Delete(string container, string name)
        {
            var fileName = this.Root + container + @"/" + name;
            var fi = new System.IO.FileInfo(fileName);
            try
            {
                fi.Delete();
                return true;
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool DeleteContainer(string container)
        {
            try
            {
                var list = this.GetFilesDirectory(container);
                foreach (var fi in list)
                {
                    Delete(container, fi);
                }

                System.IO.Directory.Delete(this.Root + container);
                return true;
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool DeleteDiretory(string container, string directory)
        {
            try
            {
                var list = this.GetFilesDirectory(container, directory);
                foreach (var fi in list)
                {
                    Delete(container + @"/" + directory, fi);
                }

                System.IO.Directory.Delete(this.Root + container + @"/" + directory);
                return true;
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public List<string> GetFilesDirectory(string container)
        {
            var list = new List<string>();

            var di = new DirectoryInfo(this.Root + container);

            foreach (var fi in di.GetFiles())
            {
                list.Add(fi.Name);
            }

            return list;
        }

        public List<string> GetFilesDirectory(string container, string directory)
        {
            var list = new List<string>();

            var di = new DirectoryInfo(this.Root + container + @"/" + directory);

            foreach (var fi in di.GetFiles())
            {
                list.Add(fi.Name);
            }

            return list;
        }

        public string GetText(string container, string name)
        {
            try
            {

                var fileName = this.Root + container + @"/" + name;

                var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);

                var text = System.Text.Encoding.UTF8.GetString(ReadFully(stream));

                return text;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public byte[] GetBytes(string localRoot, string container, string name)
        {
            try
            {
                var fileName = this.Root + localRoot + @"/" + container + @"/" + name;

                var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);

                return ReadFully(stream);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Delete(string localRoot, string container, string name)
        {
            var fileName = this.Root + localRoot + @"/" + container + @"/" + name; //@"\"
            var fi = new System.IO.FileInfo(fileName);
            try
            {
                fi.Delete();
                return true;
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool Upload(string localRoot, string container, string name, byte[] content)
        {
            if (System.IO.Directory.Exists(this.Root + localRoot + @"/" + container) == false)
            {
                System.IO.Directory.CreateDirectory(this.Root + localRoot + @"/" + container);
            }

            var fileName = this.Root + localRoot + @"/" + container + @"/" + name;
            var file = System.IO.File.Create(fileName);

            file.Write(content, 0, content.Length);
            file.Close();

            return true;
        }

        public string GetFileName(string folder, string name)
        {
            var fileName = this.Root + @"/" + folder + @"/" + name;
            return fileName;
        }
    }
}
