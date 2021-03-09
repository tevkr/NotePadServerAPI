namespace NotePadServerAPI.Models.RequestCreators
{
    public class CreateUserRequest
    {
        public string name { get; set; }
        public CreateUserRequest() { }
        public CreateUserRequest(string name)
        {
            this.name = name;
        }
    }
}
