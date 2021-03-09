namespace NotePadServerAPI.Models
{
    public class User
    {
        public uint id { get; set; }
        public string name { get; set; }
        public User() { }
        public User(string name)
        {
            this.name = name;
        }
        public User(uint id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
