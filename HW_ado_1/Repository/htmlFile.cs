using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HW_ado_1.Repository
{
    public class htmlFile
    {
        public static void createFile(string hash, string longUrl)
        {
            string html = $"<head>\n<meta http-equiv=\"refresh\" content=\"0.5;URL={longUrl}/\">\n</head>";
            if (!Directory.Exists(@"C:\redirects"))
            {
                Directory.CreateDirectory(@"C:\redirects");
            }                
            using (StreamWriter sw = new StreamWriter(@"C:\redirects\"+hash+".html", false, System.Text.Encoding.Default))
            {
                sw.WriteLine(html);
            }
        }
    }
}
