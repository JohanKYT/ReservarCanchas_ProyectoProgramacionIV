using System.ComponentModel.DataAnnotations;

namespace ReservarCanchas_ProyectoProgramacionIV.Models
{
    public class Facultad
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Nombre { get; set; }
    }
}
