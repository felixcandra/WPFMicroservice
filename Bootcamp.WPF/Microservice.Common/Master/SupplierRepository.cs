using Microservice.DataAccess.Model;
using Microservice.DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Common.Master
{
    public class SupplierRepository : iSupplierRepository
    {
        bool status = false;
        MyContext _context = new MyContext();

        public bool Delete(int? id)
        {

            var result = 0;
            Supplier supplier = Get(id);
            supplier.IsDelete = true;
            supplier.DeleteDate = DateTimeOffset.UtcNow.LocalDateTime;
            result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;

        }

        public List<Supplier> Get()
        {

            var getAll = _context.Suppliers.Where(x => x.IsDelete == false).ToList();
            return getAll;
        }

        public Supplier Get(int? id)
        {
            Supplier supplier = new Supplier();
            var get = _context.Suppliers.Find(id);
            return get;
        }

        public bool Insert(SupplierParam supplierParam)
        {
            Supplier supplier = new Supplier();
            supplier.Nama = supplierParam.Name;
            supplier.JoinDate = DateTimeOffset.Now.LocalDateTime;
            supplier.CreateDate = DateTimeOffset.Now.LocalDateTime;
            _context.Suppliers.Add(supplier);
            var result = 0;
            result = _context.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool Update(int? id, SupplierParam supplierparam)
        {
            Supplier supplier = Get(id);
            supplier.Nama = supplierparam.Name;
            supplier.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            var result = 0;
            result = _context.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
