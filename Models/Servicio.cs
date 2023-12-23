using System;
using System.Collections.Generic;

namespace ExamenFinal.Models;

public partial class Servicio
{
    public int ServicioId { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Costo { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();
}
