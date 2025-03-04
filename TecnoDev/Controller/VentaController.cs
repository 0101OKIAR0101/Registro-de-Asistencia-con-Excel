using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnoDev.Model;

namespace TecnoDev.Controller
{
    public class VentaController
    {
        //Traemos la conexion de Base de Datos
        public ApplicationDbContext dbContext;
        //Creamos un Método Constructor
        public VentaController()
        {
            //Inicializamos el contexto de la Base de Datos
            dbContext = new ApplicationDbContext();
        }
        //Método Agregar
        public void AgregarVenta(Venta nuevaVenta)
        {
            //Agregar la nueva venta al contexto de la Base de Datos
            dbContext.Venta.Add(nuevaVenta);
            //Guardar los cambios en la Base de Datos
            dbContext.SaveChanges();
        }
        //Método Modificar
        public void ModificarVenta(Venta ventaModificada)
        {
            //Actualizar la venta en el contexto de la Base de Datos
            dbContext.Entry(ventaModificada).State = System.Data.Entity.EntityState.Modified;
            //Guardar los cambios en la Base de Datos
            dbContext.SaveChanges();
        }
        //Método Eliminar
        public void EliminarVenta(int id)
        {
            //Buscar la venta por su ID en la Base de Datos
            var ventaAEliminar = dbContext.Venta.Find(id);
            if (ventaAEliminar != null)
            {
                //Eliminar la venta del contexto de la Base de Datos
                dbContext.Venta.Remove(ventaAEliminar);
                //Guardar los cambios en la Base de Datos
                dbContext.SaveChanges();
            }
        }
    }
}