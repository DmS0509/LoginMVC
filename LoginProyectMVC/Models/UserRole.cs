using System.Data;

namespace LoginProyectMVC.Models
{
    public class UserRole
    {
        public int Id { get; set; }  //  Clave primaria

        public int UserId { get; set; }  // Clave foránea hacia User
        public User User { get; set; }

        public int RoleId { get; set; }  // Clave foránea hacia Role
        public Role Role { get; set; }
    }
}
