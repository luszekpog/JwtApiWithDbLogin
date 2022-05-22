using System;

namespace CryptoAPI.Modules
{
    public class Crypto
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public DateTime UpdateDate { get; set; }
    }
    public class CryptoWithoutPrice
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime UpdateDate { get; set; }
    }

}
