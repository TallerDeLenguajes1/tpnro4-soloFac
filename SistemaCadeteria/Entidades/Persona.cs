using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCadeteria.Entidades
{
    class Persona
    {
        private int iD;
        private string nombre;
        private string direccion;
        private string telefono;

        public int ID { get => iD; set => iD = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }

        static string[] Nombres = { "Fernando", "Lucia", "Juan", "Armando", "Selena", "Jose", "Lucia", "Nahuel", "Mariana", "Nicolas", "Cecilia", "Lautaro", "Gabriel", "Javier", "Sofia", "Gerardo", "Gonzalo", "Camilo", "Martin", "Nadia"};
        static string[] Direcciones = { "Av Roca 990", "Gral Paz 589", "25 de Mayo 89", "Buenos Aires 1282", "Laprida 150", "Cordoba 785", "Santiago 850", "Bernabe Araoz 584", "Av. Mitre 587", "Pje Padilla 897",  "Av Alem 90", "Lamadrid 51", "San Martin 58", "Av. Soldati 85", "Mendoza 45", "San Juan 75", "Av Avellaneda 50", "Av America 58", "Ayacucho 26", "Av Salta 97" };
        static string[] Telefonos = { "3817020356", "3817434439", "3813022745", "3814893804", "3812423882", "3813397144", "3815367815", "3811212862", "3819710230", "3818225830", "3817020356", "3817434439", "3813022745", "3814893804", "3812423882", "3813397144", "3815367815", "3811212862", "3819710230", "3818225830" };

        public Persona()
        {

        }

        public Persona(int ID, string Nombre, string Direccion, string Telefono)
        {
            this.ID = ID;
            this.Nombre = Nombre;
            this.Direccion = Direccion;
            this.Telefono = Telefono;
        }

        virtual public void GenerarPersona()
        {
            Random aleat = new Random();

            this.ID = aleat.Next(550);
            this.Nombre = Nombres[aleat.Next(Nombres.Length)];
            this.Direccion = Direcciones[aleat.Next(Direcciones.Length)];
            this.Telefono = Telefonos[aleat.Next(Telefonos.Length)];
        }
    }
}
