﻿using System.ComponentModel.DataAnnotations;

namespace ReservarCanchas_ProyectoProgramacionIV.Models
{
    public class Campus
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Nombre { get; set; }
        [MaxLength(100)]
        public string Direccion { get; set; }
    }
}
