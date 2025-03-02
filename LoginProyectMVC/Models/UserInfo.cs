using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LoginProyectMVC.Models
{
    public class UserInfo
    {
        public int Id { get; set; }  // Primary Key, debe coincidir con User.Id
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Estado { get; set; }

        // Clave foránea para User
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
