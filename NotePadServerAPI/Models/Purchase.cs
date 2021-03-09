using System;

namespace NotePadServerAPI.Models
{
    public class Purchase
    {
        public uint userId { get; set; }
        public uint id { get; set; }
        public DateTime purchaseTime { get; set; }
        public string name { get; set; }
        public double cost { get; set; }
        public Purchase() { }
        public Purchase(uint userId, DateTime purchaseTime, string name, double cost)
        {
            this.userId = userId;
            this.purchaseTime = purchaseTime;
            this.name = name;
            this.cost = cost;
        }
        public Purchase(uint userId, uint id, DateTime purchaseTime, string name, double cost)
        {
            this.userId = userId;
            this.id = id;
            this.purchaseTime = purchaseTime;
            this.name = name;
            this.cost = cost;
        }
    }
}
