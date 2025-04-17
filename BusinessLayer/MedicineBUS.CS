using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class MedicineBUS
    {
        private MedicineDAO medicineDAO = new MedicineDAO();

        public List<Medicine> SearchMedicines(string searchText)
        {
            return medicineDAO.SearchMedicines(searchText);
        }
        public Medicine GetMedicineById(int id)
        {
            using (OUCareEntities2 db = new OUCareEntities2())
            {
                return db.Medicines.FirstOrDefault(m => m.ID == id);
            }
        }
    }
}
