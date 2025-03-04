using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnoDev.Model
{
    public class Usuario
    {
        //Definimos los atributos de la Clase Usuario
        //Definimos el Id del Usuario
        [Key] public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string nombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public string tipoUsuario { get; set; }
        
     
    }
}