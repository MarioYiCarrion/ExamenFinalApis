﻿using System;
using System.Collections.Generic;

namespace ExamenFinal.Models;

public partial class Cliente
{
    public int ClienteId { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public virtual ICollection<Mascota> Mascota { get; set; } = new List<Mascota>();
}
