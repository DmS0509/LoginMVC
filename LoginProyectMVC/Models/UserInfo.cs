using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LoginProyectMVC.Models
{
    public class UserInfo
    {
        public int Id { get; set; }  // FK de User
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreationDate { get; set; }
        public string Status { get; set; }
        public User User { get; set; }
    }
}
