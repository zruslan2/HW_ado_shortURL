using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace HW_ado_1.Repository
{
    public class ftp
    {
        public static void uploadFile(string hash)
        {
            try
            {
                string path = @"C:\redirects\"+hash+".html";
                FileInfo toUpload = new FileInfo(path);
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://ftp.f0287337.xsph.ru/domains/f0287337.xsph.ru/public_html/" + toUpload.Name);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential("f0287337", "unratupazu");
                Stream ftpStream = request.GetRequestStream();
                FileStream fileStream = File.OpenRead(path);
                byte[] buffer = new byte[1024];
                int bytesRead = 0;
                do
                {
                    bytesRead = fileStream.Read(buffer, 0, 1024);
                    ftpStream.Write(buffer, 0, bytesRead);
                }
                while (bytesRead != 0);
                fileStream.Close();
                ftpStream.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
