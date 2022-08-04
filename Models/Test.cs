using System.ComponentModel.DataAnnotations;

namespace Login.Models
{
    public class Test
    {
        [Required(ErrorMessage = "Número es Requerido")]
        public long Numero { get; set; }
    }
}
