using distributedWarehouses.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace distributedWarehouses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create(warehouse warehouse)
        {
            if (warehouse.WarehouseName == "")
            {
                return ValidationProblem("Neivedėte sandelio pavadinimo! :)");
            }
            if(warehouse.Id == "")
            {
                return ValidationProblem("Neivedėte sandelio id! :)");
            }
            if(warehouse.WarehouseDescription == "")
            {
                return ValidationProblem("Neidėte sandelio aprašymo");
            }
            if(warehouse.ItemsLeft < 0)
            {
                return ValidationProblem("Likutis negali būti neigiamas! :)");
            }
            if(warehouse.ItemsDeliveredSoon < 0 )
            {
                return ValidationProblem("Atvežamų prekių skaičius negali būti neigiamas! :)");
            }
            return Ok();
        }
        [HttpGet("Warehouses list")]
        public IActionResult List()
        {
            var service = new WarehouseService();

            var warehouses = service.GetWarehouses();

            return new OkObjectResult(warehouses);
        }
        [HttpGet("Search WareHouse by Id")]
        public IActionResult Get(string id)
        {
            var service = new WarehouseService();

            var warehouses = service.GetWarehouses();

            foreach (var warehouse in warehouses)
            {
                if (warehouse.Id == id)
                {
                    return new OkObjectResult(warehouse);
                }
            }return NotFound();
        }
        [HttpGet("Search by any element")]
        public IActionResult Filter(string text)
        {
            var service = new WarehouseService();

            var warehouses = service.GetWarehouses();

            var filteredWarehouses = new List<warehouse>();
            foreach(var warehouse in warehouses)
            {
                if (warehouse.GetInformation().Contains(text))
                {
                    filteredWarehouses.Add(warehouse);
                }
            }
            return new OkObjectResult(filteredWarehouses);
        }

    }
}
