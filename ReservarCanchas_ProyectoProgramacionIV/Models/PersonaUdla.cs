using System.ComponentModel.DataAnnotations;

namespace ReservarCanchas_ProyectoProgramacionIV.Models
{
    public class PersonaUdla
    {
        [Key]
        public int BannerId { get; set; }
        [MaxLength(100)]
        public string Nombre { get; set; }
        [MaxLength(100)]
        public string Correo { get; set; }
        [MaxLength(10)]
        public string Telefono { get; set; }
        [MaxLength(100)]
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        [MaxLength(50)]
        public string TipoPersona { get; set; } //Aqui deberian estar tres tipos de persona: Estudiante, Administrador, Personal de Mantenimiento
    }
}
