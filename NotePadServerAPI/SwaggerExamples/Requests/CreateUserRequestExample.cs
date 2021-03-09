using NotePadServerAPI.Models.RequestCreators;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotePadServerAPI.SwaggerExamples.Requests
{
    public class CreateUserRequestExample : IExamplesProvider<CreateUserRequest>
    {
        public CreateUserRequest GetExamples()
        {
            return new CreateUserRequest
            {
                name = "some name"
            };
        }
    }
}
