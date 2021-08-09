
namespace withdraw.Models
{
    public class Customer
    {
        public int id { get; set; }
        public string name  { get; set; }
        public string email { get; set; }
        public string passwd { get; set; }
        public int bankBalance{ get; set; }
        public bool admin{ get; set; }
    }
}
