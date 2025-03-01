using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginProyectMVC.Models
{
    public class User
    {

        public int Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public UserInfo UserInfo { get; set; }
    }

    //comando para crear las clases de la base de datos
    //dotnet ef dbcontext scaffold "Server=MEINLENOVO092;Database=LoginDB;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models
}
