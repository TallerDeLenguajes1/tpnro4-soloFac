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

        public Delicado(float NumeroCliente, string Observacion, bool Estado) : base(NumeroCliente, Observacion, Estado)
        {
        }

        public override float Costo()
        {
            return (float) (base.Costo() * 1.30);
        }
    }
}
