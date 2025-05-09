﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservarCanchas_ProyectoProgramacionIV.Models
{
    public class Facultad
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Nombre { get; set; }
        public int CampusId { get; set; }
        [ForeignKey("CampusId")]
        public Campus? Campus { get; set; }
    }
}
