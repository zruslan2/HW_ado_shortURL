using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_ado_1.Entities
{
    public class Links
    {
        public int Id { get; set; }
        public string fullUrl { get; set; }
        public string shortUrl { get; set; }
        public int usCount { get; set; }
        public DateTime finishDate { get; set; }
        public string lDescription { get; set; }
    }

    public class shortLinks
    {
        public int Id { get; set; }
        public string lDescription { get; set; }
    }
}
