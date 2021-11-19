using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace distributedWarehouses
{
    public class warehouse
    {
        public warehouse(string warehouseName, string id, string warehouseDescription, double itemsLeft,double itemsDeliveredSoon)
        {
            WarehouseName = warehouseName;
            Id = id;
            WarehouseDescription = warehouseDescription;
            ItemsLeft = itemsLeft;
            ItemsDeliveredSoon = itemsDeliveredSoon;
        }

        public string WarehouseName { get; }
        public string Id { get; }
        public string WarehouseDescription { get; }
        public double ItemsLeft { get; }
        public double ItemsDeliveredSoon { get; }
        public string GetInformation()
        {
            return $"{WarehouseName} {Id} {WarehouseDescription} {ItemsLeft} {ItemsDeliveredSoon}";
        }
    }
   
}
