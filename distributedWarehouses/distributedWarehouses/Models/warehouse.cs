using distributedWarehouses.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace distributedWarehouses
{
    public class warehouse
    {
        public warehouse(string warehouseName, string id, string warehouseDescription, double itemsLeft,double itemsDeliveredSoon, double reservedItem)
        {
            WarehouseName = warehouseName;
            Id = id;
            WarehouseDescription = warehouseDescription;
            ItemsLeft = itemsLeft;
            ItemsDeliveredSoon = itemsDeliveredSoon;
            ReservedItem = reservedItem;
        }

        public string WarehouseName { get; set; }
        public string Id { get; set; }
        [Required]
        public string WarehouseDescription { get; set; }
        public double ItemsLeft { get; set; }
        public double ItemsDeliveredSoon { get; set; }
        public double ReservedItem { get; set; }
        public int SkuId { get; set; }
        [ForeignKey("SkuId")]
        public SKU SKU { get; set; }
        public string GetInformation()
        {
            return $"{WarehouseName} {Id} {WarehouseDescription} {ItemsLeft} {ItemsDeliveredSoon}";
        }
    }
   
}
