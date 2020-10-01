using SistemaCadeteria.Entidades;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ProgramaCadeteria
{
    enum Vehiculo
    {
        Bici,
        Moto,
        Auto
    }

    class Cadete : Persona
    {
        private Vehiculo tipoVehiculo;
        private List<Pedido> listadoPedidos;

        internal List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }
        internal Vehiculo TipoVehiculo { get => tipoVehiculo; set => tipoVehiculo = value; }


        //PARA VALORES ALEATORIOS
        static string[] Nombres = { "Cecilia", "Lautaro", "Gabriel", "Javier", "Sofia", "Gerardo", "Gonzalo", "Camilo", "Martin", "Nadia" };
        static string[] Direcciones = { "Av Alem 90", "Lamadrid 51", "San Martin 58", "Av. Soldati 85", "Mendoza 45", "San Juan 75", "Av Avellaneda 50", "Av America 58", "Ayacucho 26", "Av Salta 97" };
        static string[] Telefonos = { "3817020356", "3817434439", "3813022745", "3814893804", "3812423882", "3813397144", "3815367815", "3811212862", "3819710230", "3818225830" };


        //CONSTRUCTOR POR DEFECTO
        public Cadete()
        {
            this.ListadoPedidos = new List<Pedido>();
        }

        //CONSTRUCTOR DE CADETE
        public Cadete(int ID, string Nombre, string Direccion, string Telefono, Vehiculo TipoVehiculo)
        {
            this.ID = ID;
            this.Nombre = Nombre;
            this.Direccion = Direccion;
            this.Telefono = Telefono;
            //Agregacion
            this.ListadoPedidos = new List<Pedido>();
            this.TipoVehiculo = TipoVehiculo;
        }

        //public static Cadete GenerarCadete()
        //{
        //    Random aleat = new Random();
        //    Cadete nCadete = new Cadete();

        //    nCadete.ID = aleat.Next(550);
        //    nCadete.Nombre = Nombres[aleat.Next(Nombres.Length + 1)];
        //    nCadete.Direccion = Direcciones[aleat.Next(Direcciones.Length + 1)];
        //    nCadete.Telefono = Telefonos[aleat.Next(Telefonos.Length + 1)];

        //    return nCadete;
        //}

        /// <summary>
        /// Genera Cadete de valores aleatorios ID, Nombre, Direccion, Telefono, Listado de Pedidos Vacio
        /// </summary>
        /*public override void GenerarPersona() //Consulta: No se puede solo renombrar el metodo?
        {
            Random aleat = new Random();

            this.ID = aleat.Next(550);
            this.Nombre = Nombres[aleat.Next(Nombres.Length)];
            this.Direccion = Direcciones[aleat.Next(Direcciones.Length)];
            this.Telefono = Telefonos[aleat.Next(Telefonos.Length)];
        }*/

        public void DeterminarVehiculo()
        {
            Random aleat = new Random();
            int variable = aleat.Next(3); 

            if (variable == 0)
            {
                this.TipoVehiculo = Vehiculo.Bici;
            }
            else if (variable == 1)
            {
                this.TipoVehiculo = Vehiculo.Moto;
            }
            else
            {
                this.TipoVehiculo = Vehiculo.Auto;
            }
        }

        public void AgregarVehiculo(Vehiculo TipoVehiculo)
        {
            this.TipoVehiculo = TipoVehiculo;
        }

        //Agregacion
        public void AgregarPedido(Pedido nPedido)
        {
            this.ListadoPedidos.Add(nPedido);
        }

        public string DatosCadete()
        {
            return (this.ID + " " + this.Nombre + " " + this.Direccion + " " + this.Telefono);
        }

        public void MostrarDatosCadete()
        {
            //string[] Datos = this.DatosCadete().Split(" ");
            Console.WriteLine("Datos del Cadete: ");
            Console.WriteLine("ID: " + this.ID);
            Console.WriteLine("Nombre: " + this.Nombre);
            Console.WriteLine("Direccion: " + this.Direccion);
            Console.WriteLine("Telefono: " + this.Telefono);
        }

    }
}
