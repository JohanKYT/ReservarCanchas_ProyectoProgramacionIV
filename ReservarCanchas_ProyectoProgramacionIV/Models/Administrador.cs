﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ReservarCanchas_ProyectoProgramacionIV.Models
{
    public class Administrador : PersonaUdla
    {
        public Administrador()
        {
            TipoPersona = "Administrador";
        }
        public int FacultadId { get; set; }
        [ForeignKey("FacultadId")]
        public Facultad? Facultad { get; set; }
    }
}