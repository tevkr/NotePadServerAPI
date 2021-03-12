using NotePadServerAPI.Models.RequestCreators;
using Swashbuckle.AspNetCore.Filters;

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
