using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class MedicineDTO
    {
        public int ID {get; set;}
        public int? medCode { get; set; }
        public string name { get; set; }
        public double? price { get; set; }
        public int? quantity { get; set; }
        public DateTime? expiryDate { get; set; }
        public string instruction { get; set; }
        public DateTime? createdDate { get; set; }
        public DateTime? lastUpdated { get; set; }

    }
}
