using ProgramaCadeteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCadeteria.Entidades.Tipos_Pedidos
{
    class Delicado : Pedido
    {
       public Delicado() : base()
        {
        }

        public Delicado(float NumeroCliente, string Observacion, bool Estado, TPedido TipoPedido) : base(NumeroCliente, Observacion, Estado, TipoPedido)
        {
        }
         
        public override float Costo()
        {
            if (Cupon)
            {
                return (float)((base.Costo() * 1.30) * 0.9);      //Aplica descuento del 10%
            }
            return (float) (base.Costo() * 1.30);
        }
    }
}
