using RegistroAsistencia.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAsistencia.Controller
{
    public class AsistenciaController
    {
        //Traemos la conexion de Base de Datos
        public ApplicationDbContext dbContext;
        //Creamos un Método Constructor
        public AsistenciaController()
        {
            //Inicializamos el contexto de la Base de Datos
            dbContext = new ApplicationDbContext();
        }
        //Método Agregar
        public void AgregarAsistencia(Asistencia nuevaAsistencia)
        {
            //Agregar la nueva venta al contexto de la Base de Datos
            dbContext.Asistencia.Add(nuevaAsistencia);
            //Guardar los cambios en la Base de Datos
            dbContext.SaveChanges();
        }
        //Método Modificar
        public void AsistenciaModificada(Asistencia asistenciaModificada)
        {
            //Actualizar la venta en el contexto de la Base de Datos
            dbContext.Entry(asistenciaModificada).State = System.Data.Entity.EntityState.Modified;
            //Guardar los cambios en la Base de Datos
            dbContext.SaveChanges();
        }
        //Método Eliminar
        public void EliminarVenta(int id)
        {
            //Buscar la venta por su ID en la Base de Datos
            var asistenciaAEliminar = dbContext.Asistencia.Find(id);
            if (asistenciaAEliminar != null)
            {
                //Eliminar la venta del contexto de la Base de Datos
                dbContext.Asistencia.Remove(asistenciaAEliminar);
                //Guardar los cambios en la Base de Datos
                dbContext.SaveChanges();
            }
        }
    }
}
