using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnoDev.Model
{
    public class Producto
    {
        //Definimos los atributos de la Clase Producto
        //Definimos el Id del Producto
        [Key] public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public int Cantidad { get; set; }
        public string Marca { get; set; }
        public string Categoria { get; set; }
    }
}