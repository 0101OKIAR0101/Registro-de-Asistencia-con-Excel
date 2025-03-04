using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnoDev.Model;

namespace TecnoDev.Controller
{
    public class ProductoController
    {
        //Traemos la conexion de Base de Datos
        public ApplicationDbContext dbContext;
        //Creamos un Método Constructor
        public ProductoController()
        {
            //Inicializamos el contexto de la Base de Datos
            dbContext = new ApplicationDbContext();
        }
        //Método Agregar
        public void AgregarProducto(Producto nuevoProducto)
        {
            //Agregar el nuevo producto al contexto de la Base de Datos
            dbContext.Producto.Add(nuevoProducto);
            //Guardar los cambios en la Base de Datos
            dbContext.SaveChanges();
        }
        //Método Modificar
        public void ModificarProducto(Producto productoModificado)
        {
            //Actualizar el producto en el contexto de la Base de Datos
            dbContext.Entry(productoModificado).State = System.Data.Entity.EntityState.Modified;
            //Guardar los cambios en la Base de Datos
            dbContext.SaveChanges();
        }
        //Método Eliminar
        public void EliminarProducto(int id)
        {
            var productoAEliminar = dbContext.Producto.Find(id);
            if (productoAEliminar != null)
            {
                //Eliminar el producto del contexto de la Base de Datos
                dbContext.Producto.Remove(productoAEliminar);
                //Guardar los cambios en la Base de Datos
                dbContext.SaveChanges();
            }
        }
    }
}