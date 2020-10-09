using SistemaCadeteria.Entidades;
using SistemaCadeteria.Entidades.Tipos_Pedidos;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace ProgramaCadeteria
{
    static class Helper
    {
        public static Dictionary<Vehiculo, TPedido> DicVehiculoPedido = new Dictionary<Vehiculo, TPedido>() { {Vehiculo.Bici, TPedido.Ecologico}
        , {Vehiculo.Moto, TPedido.Express}, {Vehiculo.Auto, TPedido.Delicado} };

        static TPedido TipoPedido;

        static Random aleat = new Random();
        //PARA VALORES ALEATORIOS PERSONA
        static string[] Nombres = { "Fernando", "Lucia", "Juan", "Armando", "Selena", "Jose", "Lucia", "Nahuel", "Mariana", "Nicolas" };
        static string[] Direcciones = { "Av Roca 990", "Gral Paz 589", "25 de Mayo 89", "Buenos Aires 1282", "Laprida 150", "Cordoba 785", "Santiago 850", "Bernabe Araoz 584", "Av. Mitre 587", "Pje Padilla 897", "Cecilia", "Lautaro", "Gabriel", "Javier", "Sofia", "Gerardo", "Gonzalo", "Camilo", "Martin", "Nadia", "Av Alem 90", "Lamadrid 51", "San Martin 58", "Av. Soldati 85", "Mendoza 45", "San Juan 75", "Av Avellaneda 50", "Av America 58", "Ayacucho 26", "Av Salta 97" };
        static string[] Telefonos = { "3817020356", "3817434439", "3813022745", "3814893804", "3812423882", "3813397144", "3815367815", "3811212862", "3819710230", "3818225830", "3817020356", "3817434439", "3813022745", "3814893804", "3812423882", "3813397144", "3815367815", "3811212862", "3819710230", "3818225830" };

        //PARA VALORES ALEATORIOS CADETE
        static string[] NombresCadetes = { "Cecilia", "Lautaro", "Gabriel", "Javier", "Sofia", "Gerardo", "Gonzalo", "Camilo", "Martin", "Nadia" };
        static string[] DireccionesCadetes = { "Av Alem 90", "Lamadrid 51", "San Martin 58", "Av. Soldati 85", "Mendoza 45", "San Juan 75", "Av Avellaneda 50", "Av America 58", "Ayacucho 26", "Av Salta 97" };
        static string[] TelefonosCadetes = { "3817020356", "3817434439", "3813022745", "3814893804", "3812423882", "3813397144", "3815367815", "3811212862", "3819710230", "3818225830" };

        //PARA VALORES ALEATORIOS CLIENTE
        static string[] NombresClientes = { "Fernando", "Lucia", "Juan", "Armando", "Selena", "Jose", "Lucia", "Nahuel", "Mariana", "Nicolas" };
        static string[] DireccionesClientes = { "Av Roca 990", "Gral Paz 589", "25 de Mayo 89", "Buenos Aires 1282", "Laprida 150", "Cordoba 785", "Santiago 850", "Bernabe Araoz 584", "Av. Mitre 587", "Pje Padilla 897" };
        static string[] TelefonosClientes = { "3817020356", "3817434439", "3813022745", "3814893804", "3812423882", "3813397144", "3815367815", "3811212862", "3819710230", "3818225830" };

        //PARA VALORES ALEATORIOS PEDIDO
        static string[] Observaciones = { "Forma de pago: Tarjeta", "Comida caliente", "Sabores: Frutilla y Vainilla", "Sin aceitunas" };

        //Informe de Entregas realizadas por Cadete
        public static void GenerarInforme(Cadeteria nCadeteria)
        {
            InformeCadetes(nCadeteria.ListadoCadetes);

            Console.WriteLine("El cadete con mas entregas realizadas es: ");
            Cadete cadeteMasEntregasRealizadas = nCadeteria.CadeteMasEntregas();
            MostrarDatosCadete(cadeteMasEntregasRealizadas);

            Console.WriteLine("El promedio de sus entregas es: " + cadeteMasEntregasRealizadas.PromedioEntregasRealizadas());

        }

        public static void InformeCadetes(List<Cadete> listadoCadetes)
        {
            Console.WriteLine("Cadetes:");
            foreach (Cadete cadete in listadoCadetes)
            {
                InformeCadete(cadete);
            }
        }


        public static void GenerarCadeteria(Cadeteria nCadeteria)
        {
            nCadeteria.Nombre = "Cadeteria Rapida";
            GenerarListadoCadetes(nCadeteria.ListadoCadetes);
            foreach (Cadete cadete in nCadeteria.ListadoCadetes)
            {
                GenerarListadoPedidos(cadete.ListadoPedidos);
                DeterminarEntregaPedidos(cadete.ListadoPedidos);
            }
        }

        public static void GenerarPersona(Persona nPersona)
        {
            nPersona.ID = aleat.Next(550);
            nPersona.Nombre = Nombres[aleat.Next(Nombres.Length)];
            nPersona.Direccion = Direcciones[aleat.Next(Direcciones.Length)];
            nPersona.Telefono = Telefonos[aleat.Next(Telefonos.Length)];
        }

        /// <summary>
        /// Genera Cadete de valores aleatorios ID, Nombre, Direccion, Telefono, Listado de Pedidos Vacio
        /// </summary>
        public static void GenerarCadete(Cadete nCadete)
        {
            nCadete.ID = aleat.Next(550);
            nCadete.Nombre = NombresCadetes[aleat.Next(NombresCadetes.Length)];
            nCadete.Direccion = DireccionesCadetes[aleat.Next(DireccionesCadetes.Length)];
            nCadete.Telefono = TelefonosCadetes[aleat.Next(TelefonosCadetes.Length)];
            //Ademas determino su vehiculo cuando se genera
            DeterminarVehiculo(nCadete);
        }

        public static void GenerarCliente(Cliente nCliente)
        {
            nCliente.ID = aleat.Next(550);
            nCliente.Nombre = NombresClientes[aleat.Next(NombresClientes.Length)];
            nCliente.Direccion = DireccionesClientes[aleat.Next(DireccionesClientes.Length)];
            nCliente.Telefono = TelefonosClientes[aleat.Next(TelefonosClientes.Length)];
        }

        public static void GenerarPedido(Pedido nPedido)
        {
            nPedido.NumeroCliente = aleat.Next(550);
            nPedido.Observacion = Observaciones[aleat.Next(Observaciones.Length)];
            nPedido.Estado = false;
            GenerarCliente(nPedido.PCliente);
        }


        /// <summary>
        /// Genera Listado de Pedidos con sus respectivos valores aleatorios 
        /// </summary>
        /// <param name="cantPedidos"></param>
        /// <returns></returns>
        public static void GenerarListadoPedidos(List<Pedido> listadoPedidos)
        {
            Pedido nPedido = null;
            Console.WriteLine("Cantidad de Pedidos a Registrar");
            int cantPed = Convert.ToInt32(Console.ReadLine());

            TipoPedido = (TPedido)aleat.Next(3);

            for (int i = 0; i < cantPed; i++)
            {
                switch (TipoPedido)
                {
                    case TPedido.Ecologico:
                        nPedido = new Ecologico();
                        break;
                    case TPedido.Express:
                        nPedido = new Express();
                        break;
                    case TPedido.Delicado:
                        nPedido = new Delicado();
                        break;
                }
                nPedido.TipoPedido = TipoPedido;
                GenerarPedido(nPedido);
                listadoPedidos.Add(nPedido);
            }
        }
        /// <summary>
        /// Genera Listado de Cadetedes con sus respectivos valores aleatorios ID, Nombre, Direccion, Telefono, Listado de Pedidos Vacio
        /// </summary>
        /// <returns>void</returns>
        public static void GenerarListadoCadetes(List<Cadete> listadoCadetes)
        {
            Cadete nCadete;
            Console.WriteLine("Cantidad de Cadetes a Registrar");
            int cantCad = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < cantCad; i++)
            {
                nCadete = new Cadete();
                GenerarCadete(nCadete);

                listadoCadetes.Add(nCadete);
            }
        }

        /// <summary>
        /// Determina si el Pedido fue entregado o no
        /// </summary>
        /// <returns>Lista completa con los valores que ya tenia y su Estado de entrega que se detemrino en esta funcion</returns>
        public static void DeterminarEntregaPedidos(List<Pedido> listadoPedidos)
        {
            foreach (Pedido _pedido in listadoPedidos)
            {
                if (aleat.Next(2) == 1)
                {
                    _pedido.Estado = true;
                }
                else
                {
                    _pedido.Estado = false;
                }
            }
        }


        public static void MostrarDatosPedido(Pedido nPedido)
        {
            Console.WriteLine("\nDatos del Pedido: ");
            Console.WriteLine("\nNumero de Cliente: " + nPedido.NumeroCliente);
            Console.WriteLine("Observacion del Pedido: " + nPedido.Observacion);
            Console.WriteLine("Estado: " + nPedido.Estado);
            Console.WriteLine("Cliente que realizo el pedido: ");
            MostrarDatosCliente(nPedido.PCliente);
            Console.WriteLine("Tipo Pedido: " + nPedido.TipoPedido);
        }
        public static void MostrarDatosCliente(Cliente nCliente)
        {
            Console.WriteLine("\nDatos del Cliente: ");
            Console.WriteLine("\nID: " + nCliente.ID);
            Console.WriteLine("Nombre: " + nCliente.Nombre);
            Console.WriteLine("Direccion" + nCliente.Direccion);
            Console.WriteLine("Telefono " + nCliente.Telefono);
        }
        public static void MostrarDatosCadete(Cadete nCadete)
        {
            Console.WriteLine("\nDatos del Cadete: ");
            Console.WriteLine("\nID: " + nCadete.ID);
            Console.WriteLine("Nombre: " + nCadete.Nombre);
            Console.WriteLine("Direccion: " + nCadete.Direccion);
            Console.WriteLine("Telefono: " + nCadete.Telefono);
            Console.WriteLine("Vehiculo: " + nCadete.TipoVehiculo);
        }


        public static void InformeCadete(Cadete cadete)
        {
            Console.WriteLine("\nInforme del Cadete: ");
            Console.WriteLine("\nNombre: " + cadete.Nombre);
            Console.WriteLine("Cantidad de Pedidos Entregados: " + cadete.DeterminarCantidadPedidosEntregados());
            Console.WriteLine("Paga jornal: " + cadete.DeterminarPago());
        }

        public static void DeterminarVehiculo(Cadete nCadete)
        {
            int variable = aleat.Next(3);

            if (variable == 0)
            {
                nCadete.TipoVehiculo = Vehiculo.Bici;
            }
            else if (variable == 1)
            {
                nCadete.TipoVehiculo = Vehiculo.Moto;
            }
            else
            {
                nCadete.TipoVehiculo = Vehiculo.Auto;
            }
        }


        public static bool Comparar_TPedido_Vehiculo(TPedido TipoPedido, Vehiculo TipoVehiculo)
        {
            if (TipoPedido == TPedido.Ecologico && TipoVehiculo == Vehiculo.Bici)
            {
                return true;
            }
            else if (TipoPedido == TPedido.Express && TipoVehiculo == Vehiculo.Moto)
            {
                return true;
            }
            else if (TipoPedido == TPedido.Delicado && TipoVehiculo == Vehiculo.Auto)
            {
                return true;
            }

            return false;
        }
    }
}
