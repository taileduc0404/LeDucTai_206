using System;
using System.Collections.Generic;

#nullable disable

namespace LeDucTai_206.Models
{
    public partial class Chitietphieuthue
    {
        public string Sopt { get; set; }
        public string Maphong { get; set; }
        public double? Dongia { get; set; }
        public int? Songaythue { get; set; }

        public virtual Phong MaphongNavigation { get; set; }
        public virtual Phieuthue SoptNavigation { get; set; }
    }
}
