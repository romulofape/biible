using System.ComponentModel.DataAnnotations.Schema;

namespace BiibleAPI.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        public int UsuarioId { get; set; }  
        public string Nome {get ; set; }
        public string Senha {get ; set; }
        public string Email {get ; set; }
    }
}