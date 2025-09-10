using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zeneszamok.Models
{
    public class Lemez
    {
        public int Id { get; set; }
        public string Cim { get; set; }
        public int KiadasEve { get; set; }
        public string? Kiado { get; set; }
         
        public override string ToString()
        {
            return $"{Id} Név:{Cim} ({KiadasEve}) ({Kiado}) ";
        }

        public Lemez() { }
    }
}
