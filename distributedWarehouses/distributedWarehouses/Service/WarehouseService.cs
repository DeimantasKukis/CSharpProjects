using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace distributedWarehouses.Service
{
    public class WarehouseService
    {
        public List<warehouse> GetWarehouses()
        {
            var warehouses = new List<warehouse>();
            warehouses.Add(
                new warehouse(
                    "Depo",
                    "000001",
                    "Žaliavų sandelis",
                    100,
                    200,
                    0));
            warehouses.Add(
                new warehouse(
                    "Hyper",
                    "000002",
                    "Statybiniu prekių sandelis",
                    200,
                    100,
                    0));
            warehouses.Add(
                new warehouse(
                    "Test",
                    "000003",
                    "Testtest",
                    500,
                    600,
                    5));
            return warehouses;
        }
    }
}
