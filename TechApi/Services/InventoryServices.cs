using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using TechApi.Model;

namespace TechApi.Services
{
    public class InventoryServices
    {
        private readonly string _connStr;
        public InventoryServices(IConfiguration configuration)
        {
            _connStr = configuration.GetConnectionString("TechDbConnection");
        }
        public InventoryResponse saveInventory(InventoryRequest inventory)
        {
            InventoryResponse response = new InventoryResponse();
            try
            {

                using (SqlConnection connection = new SqlConnection(_connStr))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.sp_SaveInventory";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@productId", inventory.productId);
                        command.Parameters.AddWithValue("@productName", inventory.productName);
                        command.Parameters.AddWithValue("@stockAvailable", inventory.stockAvailable);
                        command.Parameters.AddWithValue("@reOrderStock", inventory.reOrderStock);

                        connection.Open();
                        command.ExecuteNonQuery();
                        response.message = "Inventory saved successfully.";
                        response.isSuccess = true;
                    }
                }
            }
            catch (Exception ex)
            {
                response.isSuccess = false;
                response.message = ex.Message + ex.Message;
                throw ex;
            }
            return response;
        }
    }
}
