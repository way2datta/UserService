namespace RegisterUser.ClassLibrary
{
    public class User
    {
        public string Email { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Name : {Name}, Email: {Email}";
        }
    }
}