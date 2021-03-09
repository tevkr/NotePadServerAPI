using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotePadServerAPI.Models.RequestCreators
{
    public class CreatePurchaseRequest
    {
        public DateTime purchaseTime { get; set; }
        public string name { get; set; }
        public double cost { get; set; }
        public CreatePurchaseRequest() { }
        public CreatePurchaseRequest(DateTime purchaseTime, string name, double cost)
        {
            this.purchaseTime = purchaseTime;
            this.name = name;
            this.cost = cost;
        }
    }
}
