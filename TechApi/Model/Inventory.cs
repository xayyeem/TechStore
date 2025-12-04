namespace TechApi.Model
{
    public class InventoryRequest
    {
        #region
        public int productId { get; set; }
        public string productName { get; set; } = String.Empty;
        public  int stockAvailable { get; set; }
        public int reOrderStock { get; set; }
        #endregion
    }

    public class InventoryResponse
    {
        public bool isSuccess { get; set; }
        public string message { get; set; } = String.Empty;
    }

}
