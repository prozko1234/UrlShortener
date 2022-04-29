using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Link
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Code { get; set; }
        public string GeneratedLink { get; set; }
    }
}
