using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DAOAdmin
/// </summary>
public class DAOAdmin
{
   public EncapUsuario loginEntity(EncapUsuario user)
    {
        using (var db = new Mapeo())
        {
            return db.usuario.Where(x => x.Correo.Equals(user.Correo) && x.Clave.Equals(user.Clave)).FirstOrDefault();
        }

    }
    public EncapUsuario BuscarCorreo(string correo)
    {
        using (var db = new Mapeo())
        {
            return db.usuario.Where(x => x.Correo.Equals(correo) ).FirstOrDefault();
        }

    }

    public EncapUsuario BuscarToken(string token)
    {
        using (var db = new Mapeo())
        {
            return db.usuario.Where(x => x.Token.Equals(token) && x.Estado_id == 2).FirstOrDefault();
        }

    }

    public void ActualizarUsuario(EncapUsuario user)
    {
        using (var db = new Mapeo())
        {

            var resultado = db.usuario.SingleOrDefault(b => b.User_id == user.User_id);
            if (resultado != null)
            {
                resultado.Nombre = user.Nombre;
                resultado.Apellido = user.Apellido;
                resultado.Correo = user.Correo;
                resultado.Clave = user.Clave;
                resultado.Fecha_nacimiento = user.Fecha_nacimiento;
                resultado.Identificacion = user.Identificacion;
                resultado.Token = user.Token;
                resultado.Estado_id = user.Estado_id;
                resultado.Tiempo_token = user.Tiempo_token;
                resultado.Sesion = user.Sesion;
                resultado.Last_modify = DateTime.Now;
                db.SaveChanges();
            }

        }

    }

    //METODO PARA VERIFICAR SI EL CORREO ESTA AL MOMENTO DE REGISTRAR EMPLEADO
    public EncapUsuario verificarCorreo(EncapUsuario emple)
    {
        using (var db = new Mapeo())
        {
            return db.usuario.Where(x => x.Correo.Equals(emple.Correo)).FirstOrDefault();
        }
    }
    
    //METODO PARA INSERTAR UN EMPLEADO
    public void InsertarEmpleado(EncapUsuario emple)
    {
        using (var db = new Mapeo())
        {
            db.usuario.Add(emple);
            db.SaveChanges();
        }
    }

    //METODO PARA TRAER USUARIO CON NOMBRE DE ROL Y ESTADO }

    public List<EncapUsuario> ObtenerEmpleados()
    {
        using (var db = new Mapeo())
        {
            return (                
                    //apunto a tabla empleado donde usuario sea empleado/domiciliario 
                    from usu in db.usuario where usu.Rol_id==2 || usu.Rol_id==3
                    //join usuario - rol
                    join rol in db.rol on usu.Rol_id equals rol.Id
                    //join usuario - estado 
                    join estado in db.estado on usu.Estado_id equals estado.Id

                    select new
                    {
                        usu,
                        rol,
                        estado

                    }).ToList().Select(m => new EncapUsuario
                    {
                        User_id = m.usu.User_id,
                        Nombre = m.usu.Nombre,
                        Apellido = m.usu.Apellido,
                        Correo = m.usu.Correo,
                        Clave = m.usu.Clave,
                        Fecha_nacimiento = m.usu.Fecha_nacimiento,
                        Identificacion = m.usu.Identificacion,
                        //
                        Rol_id = m.usu.Rol_id,
                        RolNombre = m.rol.Nombre,
                        //
                        Estado_id = m.usu.Estado_id,
                        EstadoNombre = m.estado.Nombre

                    }).ToList();
        }
    }

    //METODO PARA ELIMINAR UN EMPLEADO
    public void EliminarEmpleado(EncapUsuario emple)
    {
        using (var db = new Mapeo())
        {
            db.usuario.Attach(emple);
            var entry = db.Entry(emple);
            entry.State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
        }
    }

    //METODO PARA OBTENER LOS ROLES 
    public List<EncapRol> ObtenerRoles()
    {
        using (var db = new Mapeo())
        {
            return db.rol.ToList();
        }
    }

    //METODO PARA OBTENER LOS ESTADOS
    public List<EncapEstado> ObtenerEstados()
    {
        using (var db = new Mapeo())
        {
            return db.estado.ToList();
        }
    }

    //METODO PARA ACTUALIZAR EMPLEADO
    public void actualizarEmpleado(EncapUsuario empleado)
    {
        using (var db = new Mapeo())
        {
            EncapUsuario encapUsuario = db.usuario.Where(x => x.User_id == empleado.User_id).First();

            encapUsuario.Nombre = empleado.Nombre;
            encapUsuario.Apellido = empleado.Apellido;
            encapUsuario.Correo = empleado.Correo;
            encapUsuario.Identificacion = empleado.Identificacion;
            encapUsuario.Rol_id = empleado.Rol_id;
            encapUsuario.Estado_id = empleado.Estado_id;

            db.usuario.Attach(encapUsuario);
            var entry = db.Entry(encapUsuario);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}