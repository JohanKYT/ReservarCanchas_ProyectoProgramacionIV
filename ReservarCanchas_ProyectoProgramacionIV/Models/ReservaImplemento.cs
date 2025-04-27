using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservarCanchas_ProyectoProgramacionIV.Models
{
    public class ReservaImplemento
    {
        [Key]
        public int Id { get; set; }
        public int ReservaId { get; set; }
        [ForeignKey("ReservaId")]
        public Reserva Reserva { get; set; }
        public int ImplementoId { get; set; }
        [ForeignKey("ImplementoId")]
        public Implemento Implemento { get; set; }
        public int CantidadSolicitada { get; set; }
    }
}
