using System.ComponentModel.DataAnnotations;

namespace ReservarCanchas_ProyectoProgramacionIV.Models
{
    public abstract class PersonaUdla
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
        public string TipoPersona { get; set; }
        protected PersonaUdla()
        {
            TipoPersona = ObtenerTipoPersona();
        }
        private string ObtenerTipoPersona()
        {
            return GetType().Name switch
            {
                "Administrador" => "Administrador",
                "Estudiante" => "Estudiante",
                "PersonalMantenimiento" => "Personal de Mantenimiento",
                _ => "Desconocido" //Esta linea es para controlar que si se escribe un tipo de persona que no existe, no rompa el programa
            };
        }
    }
}
