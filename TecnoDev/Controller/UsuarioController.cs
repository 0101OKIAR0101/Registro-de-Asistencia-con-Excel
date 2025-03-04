using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnoDev.Model;

namespace TecnoDev.Controller
{
    public class UsuarioController
    {
        //Traemos la conexion de Base de Datos
        public ApplicationDbContext dbContext;
        //Creamos un Método Constructor
        public UsuarioController()
        {
            //Inicializamos el contexto de la Base de Datos
            dbContext = new ApplicationDbContext();
        }
        //Método Agregar
        public void AgregarUsuario(Usuario nuevoUsuario)
        {
            //Agregar el nuevo usuario al contexto de la Base de Datos
            dbContext.Usuario.Add(nuevoUsuario);
            //Guardar los cambios en la Base de Datos
            dbContext.SaveChanges();
        }
        //Método Modificar
        public void ModificarUsuario(Usuario usuarioModificado)
        {
            //Actualizar el usuario en el contexto de la Base de Datos
            dbContext.Entry(usuarioModificado).State = System.Data.Entity.EntityState.Modified;
            //Guardar los cambios en la Base de Datos
            dbContext.SaveChanges();
        }
        //Método Eliminar
        public void EliminarUsuario(int id)
        {
            var UsuarioAEliminar = dbContext.Usuario.Find(id);
            if (UsuarioAEliminar != null)
            {
                //Eliminar el usuario en el contexto de la Base de Datos
                dbContext.Usuario.Remove(UsuarioAEliminar);
                //Guardar los cambios en la Base de Datos
                dbContext.SaveChanges();
            }
        }
    }
}