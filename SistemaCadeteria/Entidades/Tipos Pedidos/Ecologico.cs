﻿using ProgramaCadeteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCadeteria.Entidades.Tipos_Pedidos
{
    class Ecologico : Pedido
    {
        public Ecologico() : base()
        {
        }

        public Ecologico(float NumeroCliente, string Observacion, bool Estado, TPedido TipoPedido) : base(NumeroCliente, Observacion, Estado, TipoPedido)
        {
        }

        public override float Costo()
        {
            if (Cupon)
            {
                return (float)(base.Costo() * 0.9);
            }

            return base.Costo();
        }
    }
}
