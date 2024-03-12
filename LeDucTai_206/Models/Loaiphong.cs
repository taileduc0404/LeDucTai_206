using System;
using System.Collections.Generic;

#nullable disable

namespace LeDucTai_206.Models
{
    public partial class Loaiphong
    {
        public Loaiphong()
        {
            Phongs = new HashSet<Phong>();
        }

        public string Maloai { get; set; }
        public int? Songuoi { get; set; }
        public double? Dongia { get; set; }

        public virtual ICollection<Phong> Phongs { get; set; }
    }
}
