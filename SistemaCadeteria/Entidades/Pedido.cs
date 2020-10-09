using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramaCadeteria
{
    enum TPedido
    {
        Ecologico,
        Express,
        Delicado
    }

    class Pedido
    {
        private float numeroCliente;
        private string observacion;
        private bool estado;
        private Cliente pCliente;
        private bool cupon;
        private TPedido tipoPedido;

        private const float costoBase = 150;

        public float NumeroCliente { get => numeroCliente; set => numeroCliente = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public bool Estado { get => estado; set => estado = value; }
        internal Cliente PCliente { get => pCliente; set => pCliente = value; }
        public bool Cupon { get => cupon; set => cupon = value; }
        internal TPedido TipoPedido { get => tipoPedido; set => tipoPedido = value; }

        //CONSTRUCTOR POR DEFECTO
        public Pedido()
        {
            //Composicion
            PCliente = new Cliente();
        }

        //CONSTRUCTOR PEDIDO
        public Pedido(float NumeroCliente, string Observacion, bool Cupon, TPedido TipoPedido)
        {
            this.NumeroCliente = NumeroCliente;
            this.Observacion = Observacion;
            this.Estado = false;
            this.Cupon = Cupon;
            this.TipoPedido = TipoPedido;
            //Composicion
            this.PCliente = new Cliente();
        }

        public string DatosPedido()
        {
            return (this.NumeroCliente + ";" + this.Observacion + ";" + this.Estado);
        }

        public string DatosClienteRealizaPedido()
        {
            return (this.pCliente.DatosCliente());
        }

        public virtual float Costo()
        {
            return costoBase;
        }
    }
}
