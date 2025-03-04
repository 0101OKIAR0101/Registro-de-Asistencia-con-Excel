using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnoDev.Model;

namespace TecnoDev.Controller
{
    public class ProveedorController
    {
        //Traemos la conexion de Base de Datos
        public ApplicationDbContext dbContext;
        //Creamos un Método Constructor
        public ProveedorController()
        {
            //Inicializamos el contexto de la Base de Datos
            dbContext = new ApplicationDbContext();
        }
        //Método Agregar
        public void AgregarProveedor(Proveedor nuevoProveedor)
        {
            //Agregar el nuevo proveedor al contexto de la Base de Datos
            dbContext.Proveedor.Add(nuevoProveedor);
            //Guardar los cambios en la Base de Datos
            dbContext.SaveChanges();
        }
        //Método Modificar
        public void ModificarProveedor(Proveedor proveedorModificado)
        {
            //Actualizar el proveedor en el contexto de la Base de Datos
            dbContext.Entry(proveedorModificado).State = System.Data.Entity.EntityState.Modified;
            //Guardar los cambios en la Base de Datos
            dbContext.SaveChanges();
        }
        //Método Eliminar
        public void EliminarProveedor(int id)
        {
            var proveedorAEliminar = dbContext.Proveedor.Find(id);
            if (proveedorAEliminar != null)
            {
                //Eliminar el proveedor del contexto de la Base de Datos
                dbContext.Proveedor.Remove(proveedorAEliminar);
                //Guardar los cambios en la Base de Datos
                dbContext.SaveChanges();
            }
        }
    }
}