using System.ComponentModel.DataAnnotations.Schema;

namespace shop_api.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")]
        public decimal ProductPrice { get; set; }
    }
}
