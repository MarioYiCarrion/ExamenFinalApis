using System;
using System.Collections.Generic;

namespace ExamenFinal.Models;

public partial class HistorialMedico
{
    public int HistorialId { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Descripcion { get; set; }

    public string? Diagnostico { get; set; }

    public string? Tratamiento { get; set; }

    public int? MascotaId { get; set; }

    public virtual Mascota? Mascota { get; set; }
}
