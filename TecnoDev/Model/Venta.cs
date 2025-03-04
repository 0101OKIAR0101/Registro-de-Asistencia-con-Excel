using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnoDev.Model
{
    public class Venta
    {
        //Definimos los atributos de la Clase Venta
        //Definimos el Id de la Venta
        [Key] public int AsistenciaId { get; set; }
        public int Hora { get; set; }
        public int Minutos { get; set; }
        public int Dia { get; set; }
        public string Mes { get; set; }
        public string Asistencia { get; set; }
        public int UsuarioId { get; set; }

    }
}