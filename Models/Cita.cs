using System;
using System.Collections.Generic;

namespace ExamenFinal.Models;

public partial class Cita
{
    public int CitaId { get; set; }

    public DateTime? FechaHora { get; set; }

    public int? MascotaId { get; set; }

    public int? ServicioId { get; set; }

    public virtual Mascota? Mascota { get; set; }

    public virtual Servicio? Servicio { get; set; }
}
