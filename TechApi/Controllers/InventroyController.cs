using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using TechApi.Model;
using TechApi.Services;

namespace TechApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly InventoryServices _inventoryServices;

        public InventoryController(IConfiguration configuration)
        {
            _inventoryServices = new InventoryServices(configuration);
        }

        [HttpPost]
        [Route("SaveInventory")]
        public InventoryResponse SaveInventory(InventoryRequest dto)
        {
            return _inventoryServices.saveInventory(dto);
        }
    }

}

