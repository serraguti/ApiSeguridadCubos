﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiSeguridadCubos.Models
{
    [Table("COMPRACUBOS")]
    public class Compra
    {
        [Key]
        [Column("ID_PEDIDO")]
        public int IdPedido { get; set; }
        [Column("ID_CUBO")]
        public int IdCubo { get; set; }
        [Column("ID_USUARIO")]
        public int IdUsuario { get; set; }
        [Column("FECHAPEDIDO")]
        public int FechaPedido { get; set; }
    }
}
