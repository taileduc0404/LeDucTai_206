using System;
using System.Collections.Generic;

#nullable disable

namespace LeDucTai_206.Models
{
    public partial class Khachthue
    {
        public Khachthue()
        {
            Phieuthues = new HashSet<Phieuthue>();
        }

        public string Makh { get; set; }
        public string Tenkh { get; set; }
        public string Socmnd { get; set; }
        public string Sodienthoai { get; set; }

        public virtual ICollection<Phieuthue> Phieuthues { get; set; }
    }
}
