using ProgramaCadeteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCadeteria.Entidades.Tipos_Pedidos
{
    class Express : Pedido
    {
        public Express() : base()
        {
        }

        public Express(float NumeroCliente, string Observacion, bool Estado) : base(NumeroCliente, Observacion, Estado)
        {
        }

        public override float Costo()
        {
            if (Cupon)
            {
                return (float)((base.Costo() * 1.25) * 0.9);
            }

            return (float) (base.Costo() * 1.25);
        }
    }
}
