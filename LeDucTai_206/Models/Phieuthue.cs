using System;
using System.Collections.Generic;

#nullable disable

namespace LeDucTai_206.Models
{
    public partial class Phieuthue
    {
        public Phieuthue()
        {
            Chitietphieuthues = new HashSet<Chitietphieuthue>();
        }

        public string Sopt { get; set; }
        public DateTime? Ngaythue { get; set; }
        public string Makh { get; set; }

        public virtual Khachthue MakhNavigation { get; set; }
        public virtual ICollection<Chitietphieuthue> Chitietphieuthues { get; set; }
    }
}
