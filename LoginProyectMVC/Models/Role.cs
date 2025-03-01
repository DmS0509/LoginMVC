namespace LoginProyectMVC.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Relación muchos a muchos con User
        public List<UserRole> UserRoles { get; set; }
    }
}
