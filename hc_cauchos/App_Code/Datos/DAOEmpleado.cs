using System;
using System.Collections.Generic;
using System.Data.Entity;
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


    //METODO PARA INSERTAR PRODUCTOS AL MOMENTO DE VENTA
    public void InsertarProductos(EncapProducto_pedido producto)
    {
        using (var db = new Mapeo())
        {
            db.productos.Add(producto);
            db.SaveChanges();
        }
    }

    //ACTUALIZAR  CANTIDAD DEL PRODUCTO EN EL INVENTARIO 
    public void ActualizarCantidadInventario(EncapInventario producto)
    {
        using (var db = new Mapeo())
        {
            EncapInventario inventarioedit = db.inventario.Where(x => x.Id == producto.Id).SingleOrDefault();
            inventarioedit.Ca_actual = inventarioedit.Ca_actual - producto.Ca_actual;

            db.SaveChanges();
        }
    }

    //METODO PARA BORRAR EN CARRITO LUEGO DE HACER FACTURACION
    public void limpiarCarrito(int userid)
    {
        using (var db = new Mapeo())
        {
            List<EncapCarrito> productos = db.carrito.Where(x => x.User_id == userid).ToList();

            foreach (var pro in productos)
            {
                db.Entry(pro).State = EntityState.Deleted;
            }

            db.SaveChanges();
        }
    }

    //METODO PARA OBTENER LOS PEDIDOS DEL EMPLEADO
    public List<EncapPedido> ObtenerPedidos(int user)
    {
        using (var db = new Mapeo())
        
            return (from pedi in db.pedidos.Where(x=>x.Atendido_id== user && x.Estado_pedido == 2)
                    join usu in db.usuario on pedi.User_id equals usu.User_id 
                    join emple in db.usuario  on pedi.Atendido_id  equals emple.User_id
                    join domi in db.usuario on pedi.Domiciliario_id equals domi.User_id

                    select new
                    {
                        pedi,
                        usu,
                        emple,
                        domi

                    }).ToList().Select(m => new EncapPedido
                    {           

                        Id=m.pedi.Id,
                        Fecha_pedido = m.pedi.Fecha_pedido,
                        User_id = m.pedi.User_id,
                        User_nombre = m.usu.Nombre,
                        Atendido_id = m.pedi.Atendido_id,
                        Empleado_nombre=m.emple.Nombre,
                        Domiciliario_id=m.pedi.Domiciliario_id,
                        Domiciliario_nombre=m.domi.Nombre,
                        Estado_pedido = m.pedi.Estado_pedido,
                        Total= m.pedi.Total


                    }).ToList();
        }
    }



}