using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class MedicineDAO
    {
        public List<Medicine> SearchMedicines(string searchText)
        {
            using (OUCareEntities2 db = new OUCareEntities2())
            {
                return db.Medicines
                    .Where(m => m.name.Contains(searchText))
                    .ToList();
            }
        }
    }

}
