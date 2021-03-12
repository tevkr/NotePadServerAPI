namespace NotePadServerAPI.Models
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public User() { }
        public User(string name)
        {
            this.name = name;
        }
        public User(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
