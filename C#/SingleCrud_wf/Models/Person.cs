using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleCrud
{
    public class Person
    {
        public int Id { get; set; }                  // Id 
        public int Num_Socio { get; set; }           // Numero de Socio 
        public int Seniority_Partner { get; set; }   // Antiguedad del socio
        public string Type_Partner { get; set; }     // Tipo de socio
        public int Share { get; set; }               // Cuota del socio
        public string Post { get; set; }             // Cargo del socio
        public string First_Name { get; set; }       // Nombre
        public string Last_Name { get; set; }        // Apellido
        public int Dni { get; set; }                 // Dni del socio           
        public int Age { get; set; }                 // Edad 
        public int Family_Unity { get; set; }        // Numero de integrantes en la uidad familiar
        public string Hereda_Sitio { get; set; }     // Persona que hereda la plaza de socio
        public int Telef_Primary { get; set; }       // Telefono de contacto -> principal
        public int Telef_Secondary { get; set; }     // Telefono de contacto -> secundario
        public string Email { get; set; }            // Correo Electronico
        public string Location { get; set; }         // Ubicacion -> Localidad
        public string Adress{ get; set; }            // Ubicacion -> Direccion postal
    }
}
