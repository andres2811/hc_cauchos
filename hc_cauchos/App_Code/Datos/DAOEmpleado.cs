using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DAOEmpleado
/// </summary>
public class DAOEmpleado
{
    public DAOEmpleado()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }


    //METODO PARA OBTENER LOS CLIENTES EN VENTAS 
    public List<EncapUsuario> ObtenerClientes()
    {
        using (var db = new Mapeo())
        {
            return (
                    //apunto a tabla empleado donde usuario sea empleado/domiciliario 
                    from usu in db.usuario
                    where usu.Rol_id == 4
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
    //METODO PARA OBTEENR CLIENTES POR NIMBRE
    public List<EncapUsuario> ObtenerClientesCedula(string cedula)
    {
        using (var db = new Mapeo())
        {
            return (
                    //apunto a tabla empleado donde usuario sea empleado/domiciliario 
                    from usu in db.usuario
                    where (usu.Rol_id == 4) && (usu.Identificacion == cedula)
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

    //METODO PARA INSERTAR UN CLIENTE
    public void InsertarCliente(EncapUsuario clien)
    {
        using (var db = new Mapeo())
        {
            db.usuario.Add(clien);
            db.SaveChanges();
        }
    }

    //OBTENGO CANTIDAD DE PRODUCTOS DE VENDEDOR CARRITO
    public int ObtenerCantidadxProductoCarritoxEmple(int user_id)
    {
        using (var db = new Mapeo())
        {
            return db.carrito.Where(x => x.User_id == user_id).Count();
        }
    }



}