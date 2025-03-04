using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnoDev.Model
{
    public class ApplicationDbContext : DbContext
    {
        //Utilizamos DbSet para representar 4 tablas con las Clases
       //Venta y Usuario
      
        public DbSet<Venta> Venta { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        //Creamos la cadena de conexion con la Base de Datos
        //Data Source: Nombre del servidor
        //Initial Catalog: Nombre de la Base de Datos
        //Integrated Security: Tipo de autenticación(por defecto Windows Autentication)
        public ApplicationDbContext() : base("Data Source=C3YC0N3R; Initial Catalog=ControlAsistencia; Integrated Security=True;")
        {
        }
    }
}