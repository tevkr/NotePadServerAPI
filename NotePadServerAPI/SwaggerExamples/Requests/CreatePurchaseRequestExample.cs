using NotePadServerAPI.Models.RequestCreators;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotePadServerAPI.SwaggerExamples.Requests
{
    public class CreatePurchaseRequestExample : IExamplesProvider<CreatePurchaseRequest>
    {
        public CreatePurchaseRequest GetExamples()
        {
            return new CreatePurchaseRequest
            {
                purchaseTime = new DateTime(2021, 3, 8, 19, 14, 34),
                name = "purchase name",
                cost = 1337.99
            };
        }
    }
}
