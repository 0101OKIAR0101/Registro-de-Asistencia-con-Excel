using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnoDev.Model
{
    public class Proveedor
    {
        //Definimos los atributos de la Clase Proveedor
        //Definimos el Id del Proveedor
        [Key] public int ProveedorId { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public int Telefono { get; set; }
    }
}