namespace Api.core.Entities
{

    public partial class User
    {
        public int UserId { get; set; }

        public string Name { get; set; } = "";

        public string LastName { get; set; } = "";

        public string Password { get; set; } = "";

        public string Username { get; set; } = "";
    }
}

