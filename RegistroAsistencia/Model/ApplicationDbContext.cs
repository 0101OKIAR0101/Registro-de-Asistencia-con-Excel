using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAsistencia.Model
{
    public class ApplicationDbContext
    {
        //Utilizamos DbSet para representar 4 tablas con las Clases
        //Producto, Proveedor, Venta y Usuario
       
        public DbSet<Asistencia> Asistencia { get; set; }
        public DbSet<Usuario> Usuario {  get; set; }
        //Creamos la cadena de conexion con la Base de Datos
        //Data Source: Nombre del servidor
        //Initial Catalog: Nombre de la Base de Datos
        //Integrated Security: Tipo de autenticación(por defecto Windows Autentication)
        public ApplicationDbContext() : base("Data Source=DESKTOP-E66H2N1\\SQLEXPRESS02; Initial Catalog=RegistroAsistencia; Integrated Security=True;")
        {
        }

        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }

        internal object Entry(Usuario usuarioModificado)
        {
            throw new NotImplementedException();
        }

        internal object Entry(Asistencia asistenciaModificada)
        {
            throw new NotImplementedException();
        }
    }
}
