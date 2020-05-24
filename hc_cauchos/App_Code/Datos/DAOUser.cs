using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DAOUser
/// </summary>
public class DAOUser
{
    //METODO PARA INSERTAR USUARIO AL MOMENTO DEL LOGIN
    public void InsertarUsuario(EncapUsuario user)
    {
        using (var db = new Mapeo())
        {
            db.usuario.Add(user);
            db.SaveChanges();
        }
    }
    //METODO PARA VERIFICAR SI EXISTE REGISTRADO EL CORREO
    public EncapUsuario verificarCorreo(EncapUsuario verificar)
    {
        using (var db = new Mapeo())
        {
            return db.usuario.Where(x => x.Correo.Equals(verificar.Correo)).FirstOrDefault();
        }
    }
    //METODO PARA VERIFICAR SI EXISTE REGISTRADA LA IDENTIFICACION
    public EncapUsuario verificarIdentificacion(EncapUsuario verificar)
    {
        using (var db = new Mapeo())
        {
            return db.usuario.Where(x => x.Correo.Equals(verificar.Correo) || x.Identificacion.Equals(verificar.Identificacion)).FirstOrDefault();
        }
    }

    //OBTENGO CANTIDAD ACTUAL DEL INVENTARIO Y LE RESTO LA CANTIDAD QUE SE ENCUENTRA EN EL CARRITO
    public int ObtenerCantidadxProductoCarrito(int producto_id)
    {
        using (var db = new Mapeo())
        {
            //return db.inventario.Where(x => x.Id == producto_id).Select(x=> x.Ca_actual).First() - db.carrito.Where(x => x.Prod ucto_id == producto_id).Sum(x => x.Cantidad);
            Nullable<int> carrito = db.carrito.Where(x => x.Producto_id == producto_id).Sum(x => x.Cantidad);
            int cantidad = db.inventario.Where(x => x.Id == producto_id).Select(x => x.Ca_actual).First();
            return cantidad - (carrito != null ? carrito.Value : 0);
        }
    }

    //METODO PARA INSERTAR USUARIO AL MOMENTO DEL LOGIN
    public void InsertarCarrito(EncapCarrito carrito)
    {
        using (var db = new Mapeo())
        {
            db.carrito.Add(carrito);
            db.SaveChanges();
        }
    }


    //OBTENGO CANTIDAD DE PRODUCTOS DE USUARIO CARRITO
    public int ObtenerCantidadxProductoCarritoxUser(int user_id)
    {
        using (var db = new Mapeo())
        {
            return db.carrito.Where(x => x.User_id == user_id).Count();
        }
    }

    //METODO PARA VERIFICAR SI EL ITEM SELECCIONADO YA ESTA EN LA LISTA 
    public EncapCarrito verificarArticuloEnCarrito(EncapCarrito verificar)
    {
        using (var db = new Mapeo())
        {
            return db.carrito.Where(x => x.Producto_id.Equals(verificar.Producto_id) && x.User_id.Equals(verificar.User_id)).FirstOrDefault();
        }
    }

    //METODO PARA VERIFICAR SI EL USUARIO TIENE PEDIDO
    public EncapCarrito verificarUsuarioTienePedido(EncapCarrito verificar)
    {
        using (var db = new Mapeo())
        {
            return db.carrito.Where(x => x.User_id.Equals(verificar.User_id) && x.Estadocar.Equals(2)).FirstOrDefault();
        }
    }

    //METODO ACTUALIZAR + ITEMS EN CARRITO 
    public void ActualizarCarritoItems(EncapCarrito carrito)
    {
        using (var db = new Mapeo())
        {
            var resultado = db.carrito.FirstOrDefault(x => x.Producto_id == carrito.Producto_id && x.User_id == carrito.User_id);
            if (resultado != null)
            {
                resultado.Id_Carrito = resultado.Id_Carrito;
                resultado.User_id = resultado.User_id;
                resultado.Producto_id = resultado.Producto_id;
                resultado.Cantidad = resultado.Cantidad + carrito.Cantidad;
                resultado.Fecha = resultado.Fecha;
                resultado.Precio = resultado.Precio;
                resultado.Total = resultado.Total + (carrito.Cantidad * resultado.Precio).Value;

                db.SaveChanges();
            }
        }

    }
    //METODO CONSULTAR INVENTARIO MENOS LA CANTIDAD DEL CARRITO 
    public List<EncapInventario> ConsultarInventario()
    {
        using (var db = new Mapeo())
        {
            return (from uu in db.inventario.Where(x=> x.Ca_actual > 0)
                    join marca_carro in db.marca_carro on uu.Id_marca equals marca_carro.Id
                    join categoria in db.categoria on uu.Id_categoria equals categoria.Id
                    join estadoitem in db.estado_item on uu.Id_estado equals estadoitem.Id
                    let _cantCarrito = (from ss in db.carrito where ss.Producto_id == uu.Id select ss.Cantidad).Sum()

                    select new
                    {
                        uu,
                        marca_carro,
                        categoria,
                        estadoitem,
                        _cantCarrito


                    }).ToList().Select(m => new EncapInventario
                    {
                        Id = m.uu.Id,
                        Imagen = m.uu.Imagen,
                        Titulo = m.uu.Titulo,
                        Precio = m.uu.Precio,
                        Referencia = m.uu.Referencia,
                        Ca_actual = m.uu.Ca_actual - (m._cantCarrito.HasValue ? m._cantCarrito.Value : 0),
                        Ca_minima = m.uu.Ca_minima,
                        Id_marca = m.uu.Id_marca,
                        Id_categoria = m.uu.Id_categoria,
                        Id_estado = m.uu.Id_estado,
                        Nombre_categoria = m.categoria.Categoria,
                        Nombre_marca = m.marca_carro.Marca,
                        Estado = m.estadoitem.Estado_item

                    }).ToList();
        }
    }
    //METODO CONSULTAR INVENTARIO CATEGORIA MENOS LA CANTIDAD DEL CARRITO 
    public List<EncapInventario> ConsultarInventarioCategoria(int categ)
    {
        using (var db = new Mapeo())
        {
            return (from uu in db.inventario.Where(x => x.Ca_actual > 0 && x.Id_categoria == categ)
                    join marca_carro in db.marca_carro on uu.Id_marca equals marca_carro.Id
                    join categoria in db.categoria on uu.Id_categoria equals categoria.Id
                    join estadoitem in db.estado_item on uu.Id_estado equals estadoitem.Id
                    let _cantCarrito = (from ss in db.carrito where ss.Producto_id == uu.Id select ss.Cantidad).Sum()

                    select new
                    {
                        uu,
                        marca_carro,
                        categoria,
                        estadoitem,
                        _cantCarrito


                    }).ToList().Select(m => new EncapInventario
                    {
                        Id = m.uu.Id,
                        Imagen = m.uu.Imagen,
                        Titulo = m.uu.Titulo,
                        Precio = m.uu.Precio,
                        Referencia = m.uu.Referencia,
                        Ca_actual = m.uu.Ca_actual - (m._cantCarrito.HasValue ? m._cantCarrito.Value : 0),
                        Ca_minima = m.uu.Ca_minima,
                        Id_marca = m.uu.Id_marca,
                        Id_categoria = m.uu.Id_categoria,
                        Id_estado = m.uu.Id_estado,
                        Nombre_categoria = m.categoria.Categoria,
                        Nombre_marca = m.marca_carro.Marca,
                        Estado = m.estadoitem.Estado_item

                    }).ToList();
        }
    }
    //METODO CONSULTAR INVENTARIO MARCA MENOS LA CANTIDAD DEL CARRITO 
    public List<EncapInventario> ConsultarInventariMarca(int marca)
    {
        using (var db = new Mapeo())
        {
            return (from uu in db.inventario.Where(x => x.Ca_actual > 0 && x.Id_marca == marca)
                    join marca_carro in db.marca_carro on uu.Id_marca equals marca_carro.Id
                    join categoria in db.categoria on uu.Id_categoria equals categoria.Id
                    join estadoitem in db.estado_item on uu.Id_estado equals estadoitem.Id
                    let _cantCarrito = (from ss in db.carrito where ss.Producto_id == uu.Id select ss.Cantidad).Sum()

                    select new
                    {
                        uu,
                        marca_carro,
                        categoria,
                        estadoitem,
                        _cantCarrito


                    }).ToList().Select(m => new EncapInventario
                    {
                        Id = m.uu.Id,
                        Imagen = m.uu.Imagen,
                        Titulo = m.uu.Titulo,
                        Precio = m.uu.Precio,
                        Referencia = m.uu.Referencia,
                        Ca_actual = m.uu.Ca_actual - (m._cantCarrito.HasValue ? m._cantCarrito.Value : 0),
                        Ca_minima = m.uu.Ca_minima,
                        Id_marca = m.uu.Id_marca,
                        Id_categoria = m.uu.Id_categoria,
                        Id_estado = m.uu.Id_estado,
                        Nombre_categoria = m.categoria.Categoria,
                        Nombre_marca = m.marca_carro.Marca,
                        Estado = m.estadoitem.Estado_item

                    }).ToList();
        }
    }
    //METODO CONSULTAR INVENTARIO CATEGORIA Y MARCA MENOS LA CANTIDAD DEL CARRITO 
    public List<EncapInventario> ConsultarInventariCombinado(int marca, int categ)
    {
        using (var db = new Mapeo())
        {
            return (from uu in db.inventario.Where(x => x.Ca_actual > 0 && x.Id_marca == marca && x.Id_categoria == categ)
                    join marca_carro in db.marca_carro on uu.Id_marca equals marca_carro.Id
                    join categoria in db.categoria on uu.Id_categoria equals categoria.Id
                    join estadoitem in db.estado_item on uu.Id_estado equals estadoitem.Id
                    let _cantCarrito = (from ss in db.carrito where ss.Producto_id == uu.Id select ss.Cantidad).Sum()

                    select new
                    {
                        uu,
                        marca_carro,
                        categoria,
                        estadoitem,
                        _cantCarrito


                    }).ToList().Select(m => new EncapInventario
                    {
                        Id = m.uu.Id,
                        Imagen = m.uu.Imagen,
                        Titulo = m.uu.Titulo,
                        Precio = m.uu.Precio,
                        Referencia = m.uu.Referencia,
                        Ca_actual = m.uu.Ca_actual - (m._cantCarrito.HasValue ? m._cantCarrito.Value : 0),
                        Ca_minima = m.uu.Ca_minima,
                        Id_marca = m.uu.Id_marca,
                        Id_categoria = m.uu.Id_categoria,
                        Id_estado = m.uu.Id_estado,
                        Nombre_categoria = m.categoria.Categoria,
                        Nombre_marca = m.marca_carro.Marca,
                        Estado = m.estadoitem.Estado_item

                    }).ToList();
        }
    }
    //METODO PARA OBTENER TODOS LOS ELEMENTOS DEL CARRITO 
    public List<EncapCarrito> ObtenerCarritoxUsuario(int usu)
    {
        using (var db = new Mapeo())
        {
            return (from carrito in db.carrito.Where(x => x.User_id == usu)
                    join iven in db.inventario on carrito.Producto_id equals iven.Id
                    select new
                    {
                        carrito,
                        iven
                    }).ToList().Select(m => new EncapCarrito
                    {
                        Id_Carrito = m.carrito.Id_Carrito,
                        User_id = m.carrito.User_id,
                        Producto_id = m.carrito.Producto_id,
                        Cantidad = m.carrito.Cantidad,
                        Fecha = m.carrito.Fecha,
                        Precio = m.carrito.Precio,
                        Total = m.carrito.Total,
                        Nom_producto=m.iven.Titulo,
                        Cant_Actual = (m.iven.Ca_actual - m.carrito.Cantidad).Value,
                        Id_pedido = m.carrito.Id_pedido
                    }).ToList();
        }
    }
    //ELIMINAR PRODUCTO DEL CARRITO 
    public void EliminarItemCarrito(EncapCarrito carrito)
    {
        using (var db = new Mapeo())
        {
            db.carrito.Attach(carrito);
            var entry = db.Entry(carrito);
            entry.State = EntityState.Deleted;
            db.SaveChanges();
        }
    }
    //ACTUALIZAR DATO DEL PRODUCTO EN EL CARRITO 
    public void ActualizarCarritoFactura(EncapCarrito carrito)
    {
        using (var db = new Mapeo())
        {
            EncapCarrito carritoedit = db.carrito.Where(x => x.Id_Carrito == carrito.Id_Carrito).SingleOrDefault();
            carritoedit.Cantidad = carrito.Cantidad;
            carritoedit.Precio = carrito.Precio;
            carritoedit.Cant_Actual = (carritoedit.Cant_Actual - carritoedit.Cantidad).Value;
            carritoedit.Total = (carritoedit.Cantidad * carritoedit.Precio).Value ;

            db.SaveChanges();
        }
    }

    //CAMBIO TODOS LOS ESTADOS DEL PRODUCTO CUANDO DAN FACTURAR EN EL CARRITO
    public void ActualizarCarritoEstado(EncapCarrito carrito)
    {
        using (var db = new Mapeo())
        {
            
            var carritoedit = db.carrito.Where(x => x.User_id == carrito.User_id).ToList();
            foreach (var car in carritoedit)
            {
                car.Estadocar = carrito.Estadocar;
            }
            db.SaveChanges();
        }
    }


    //METODO PARA INSERTAR PEDIDO
    public int InsertarPedido(EncapPedido pedido)
    {
        using (var db = new Mapeo())
        {
            db.pedidos.Add(pedido);
            db.SaveChanges();
        }
        return pedido.Id;
    }

    //MODIFICAR ID DEL PEDIDO EN CARRITO
    public void ActualizarIdpedidoCarrito(EncapCarrito carrito)
    {
        using (var db = new Mapeo())
        {

            var carritoedit = db.carrito.Where(x => x.User_id == carrito.User_id).ToList();
            foreach (var car in carritoedit)
            {
                car.Id_pedido = carrito.Id_pedido;
            }
            db.SaveChanges();
        }
    }

    //METODO PARA BORRAR EN CARRITO LUEGO DE HACER FACTURACION
    public void limpiarCarrito(int userid) {
        using (var db = new Mapeo())
        {
            List<EncapCarrito> productos = db.carrito.Where(x => x.User_id == userid).ToList();

            foreach (var pro in productos)
            {
                db.Entry(pro).State=EntityState.Deleted;
            }

            db.SaveChanges();
        }
    }

    //MODIFICAR VALOR EN PEDIDO SI MODIFICAN CARRITO
    public void ActualizarValorpedido(EncapPedido pedido)
    {
        using (var db = new Mapeo())
        {

            EncapPedido pedidoedit = db.pedidos.Where(x => x.Id == pedido.Id).SingleOrDefault();
            pedidoedit.Total = pedido.Total;

            db.SaveChanges();
        }
    }
    //METODO CONSULTAR PRECIO ASCEDENE
    public List<EncapInventario> ConsultarInventarioPrecio( string valores)
    {
        //Metodo de Slip
        string[] split = valores.Split( ',');
        int can1 = Convert.ToInt32(split[0]);
        int can2 = Convert.ToInt32(split[1]);


        using (var db = new Mapeo())
        {
            return (from uu in db.inventario.Where(x=> x.Precio >= can1 && x.Precio <= can2 ) 
                    join marca_carro in db.marca_carro on uu.Id_marca equals marca_carro.Id
                    join categoria in db.categoria on uu.Id_categoria equals categoria.Id
                    join estadoitem in db.estado_item on uu.Id_estado equals estadoitem.Id

                    let _cantCarrito = (from ss in db.carrito where ss.Producto_id == uu.Id select ss.Cantidad).Sum()

                    select new
                    {
                        uu,
                        marca_carro,
                        categoria,
                        estadoitem,

                        _cantCarrito

                    }).ToList().Select(m => new EncapInventario
                    
                    {
                        Id = m.uu.Id,
                        Imagen = m.uu.Imagen,
                        Titulo = m.uu.Titulo,
                        Precio = m.uu.Precio,
                        Referencia = m.uu.Referencia,
                        Ca_actual = m.uu.Ca_actual - (m._cantCarrito.HasValue ? m._cantCarrito.Value : 0),
                        Ca_minima = m.uu.Ca_minima,
                        Id_marca = m.uu.Id_marca,
                        Id_categoria = m.uu.Id_categoria,

                        Id_estado = m.uu.Id_estado,

                        Nombre_categoria = m.categoria.Categoria,
                        Nombre_marca = m.marca_carro.Marca,

                        Estado = m.estadoitem.Estado_item





                    }
                        

                    ).ToList() ;

        }
    }
    //METODO CONSULTAR PRECIO ASCEDENE
    public List<EncapInventario> ConsultarInventarioPrecioCategoria(string valores, int categ)
    {
        //Metodo de Slip
        string[] split = valores.Split(',');
        int can1 = Convert.ToInt32(split[0]);
        int can2 = Convert.ToInt32(split[1]);


        using (var db = new Mapeo())
        {
            return (from uu in db.inventario.Where(x => x.Precio >= can1 && x.Precio <= can2 && x.Id_categoria == categ)
                    join marca_carro in db.marca_carro on uu.Id_marca equals marca_carro.Id
                    join categoria in db.categoria on uu.Id_categoria equals categoria.Id
                    join estadoitem in db.estado_item on uu.Id_estado equals estadoitem.Id

                    let _cantCarrito = (from ss in db.carrito where ss.Producto_id == uu.Id select ss.Cantidad).Sum()

                    select new
                    {
                        uu,
                        marca_carro,
                        categoria,
                        estadoitem,

                        _cantCarrito

                    }).ToList().Select(m => new EncapInventario

                    {
                        Id = m.uu.Id,
                        Imagen = m.uu.Imagen,
                        Titulo = m.uu.Titulo,
                        Precio = m.uu.Precio,
                        Referencia = m.uu.Referencia,
                        Ca_actual = m.uu.Ca_actual - (m._cantCarrito.HasValue ? m._cantCarrito.Value : 0),
                        Ca_minima = m.uu.Ca_minima,
                        Id_marca = m.uu.Id_marca,
                        Id_categoria = m.uu.Id_categoria,

                        Id_estado = m.uu.Id_estado,

                        Nombre_categoria = m.categoria.Categoria,
                        Nombre_marca = m.marca_carro.Marca,

                        Estado = m.estadoitem.Estado_item





                    }


                    ).ToList();

        }
    }
    public List<EncapInventario> ConsultarInventarioPrecioMarca(string valores, int marca)
    {
        //Metodo de Slip
        string[] split = valores.Split(',');
        int can1 = Convert.ToInt32(split[0]);
        int can2 = Convert.ToInt32(split[1]);


        using (var db = new Mapeo())
        {
            return (from uu in db.inventario.Where(x => x.Precio >= can1 && x.Precio <= can2 && x.Id_marca == marca)
                    join marca_carro in db.marca_carro on uu.Id_marca equals marca_carro.Id
                    join categoria in db.categoria on uu.Id_categoria equals categoria.Id
                    join estadoitem in db.estado_item on uu.Id_estado equals estadoitem.Id

                    let _cantCarrito = (from ss in db.carrito where ss.Producto_id == uu.Id select ss.Cantidad).Sum()

                    select new
                    {
                        uu,
                        marca_carro,
                        categoria,
                        estadoitem,

                        _cantCarrito

                    }).ToList().Select(m => new EncapInventario

                    {
                        Id = m.uu.Id,
                        Imagen = m.uu.Imagen,
                        Titulo = m.uu.Titulo,
                        Precio = m.uu.Precio,
                        Referencia = m.uu.Referencia,
                        Ca_actual = m.uu.Ca_actual - (m._cantCarrito.HasValue ? m._cantCarrito.Value : 0),
                        Ca_minima = m.uu.Ca_minima,
                        Id_marca = m.uu.Id_marca,
                        Id_categoria = m.uu.Id_categoria,

                        Id_estado = m.uu.Id_estado,

                        Nombre_categoria = m.categoria.Categoria,
                        Nombre_marca = m.marca_carro.Marca,

                        Estado = m.estadoitem.Estado_item





                    }


                    ).ToList();

        }
    }
    public List<EncapInventario> ConsultarInventarioPrecioCombinado(string valores, int marca , int categor)
    {
        //Metodo de Slip
        string[] split = valores.Split(',');
        int can1 = Convert.ToInt32(split[0]);
        int can2 = Convert.ToInt32(split[1]);


        using (var db = new Mapeo())
        {
            return (from uu in db.inventario.Where(x => x.Precio >= can1 && x.Precio <= can2 &&
                    x.Id_marca == marca && x.Id_categoria == categor)
                    join marca_carro in db.marca_carro on uu.Id_marca equals marca_carro.Id
                    join categoria in db.categoria on uu.Id_categoria equals categoria.Id
                    join estadoitem in db.estado_item on uu.Id_estado equals estadoitem.Id

                    let _cantCarrito = (from ss in db.carrito where ss.Producto_id == uu.Id select ss.Cantidad).Sum()

                    select new
                    {
                        uu,
                        marca_carro,
                        categoria,
                        estadoitem,

                        _cantCarrito

                    }).ToList().Select(m => new EncapInventario

                    {
                        Id = m.uu.Id,
                        Imagen = m.uu.Imagen,
                        Titulo = m.uu.Titulo,
                        Precio = m.uu.Precio,
                        Referencia = m.uu.Referencia,
                        Ca_actual = m.uu.Ca_actual - (m._cantCarrito.HasValue ? m._cantCarrito.Value : 0),
                        Ca_minima = m.uu.Ca_minima,
                        Id_marca = m.uu.Id_marca,
                        Id_categoria = m.uu.Id_categoria,

                        Id_estado = m.uu.Id_estado,

                        Nombre_categoria = m.categoria.Categoria,
                        Nombre_marca = m.marca_carro.Marca,

                        Estado = m.estadoitem.Estado_item





                    }


                    ).ToList();

        }
    }
    //METODO PARA OBTENER TODOS LOS ELEMENTOS DEL CARRITO 
    public EncapParametros ObtenerTiempo(EncapParametros nombre)
    {
        using (var db = new Mapeo())
        {
            return db.parametros.Where(x => x.Nombre.Equals(nombre.Nombre)).FirstOrDefault();
        }
    }
    //METODO pARA OBTENER pRODUCTOS DEL pEDIDO
    public List<EncapProducto_pedido> ObtenerProductos (int id)
    {
        using (var db = new Mapeo())
        {
            return (from uu in db.productos.Where(x => x.Pedido_id == id)


                    select new
                    {
                        uu
                    }).ToList().Select(x => new EncapProducto_pedido
                    {
                        Pedido_id = x.uu.Pedido_id,
                        Producto_id = x.uu.Producto_id,
                        Cantidad = x.uu.Cantidad,
                        Precio = x.uu.Precio,
                        Total = x.uu.Total
                    }
                    
                    ).ToList();
        }
    }
    public List<EncapEstadoPedido> ConsultarEstadoPedidos()
    {
        using (var db=new Mapeo())
        {
            return db.estado_pedido.ToList();
        }
    }
    public List<EncapPedido> ConsultarPedidosEstado(int est)
    {
        using (var db = new Mapeo())
        {



            return (from uu in db.pedidos.Where(x=> x.Estado_pedido == est)
                    join usuario in db.usuario on uu.User_id equals usuario.User_id
                    join empleado in db.usuario on uu.Atendido_id equals empleado.User_id
                    join estado in db.estado_pedido on uu.Estado_pedido equals estado.Id

                    select new
                    {
                        uu,
                        usuario,
                        estado,
                        empleado,


                    }).ToList().Select(m => new EncapPedido
                    {

                        Id = m.uu.Id,
                        User_id = m.usuario.User_id,
                        Atendido_id = m.uu.Atendido_id,
                        Domiciliario_id = m.uu.Domiciliario_id,
                        Fecha_pedido = m.uu.Fecha_pedido,
                        Estado_pedido = m.uu.Estado_pedido,
                        Total = m.uu.Total,

                        Usuario = m.usuario.Nombre,
                        Estado = m.estado.Estado,
                        Empleado = m.empleado.Nombre,

                    }
                      ).ToList();
        }

    }

    //METODO DE BUSCAR EL HISTORIA DE VENTAS DEACUEDO A AÑO Y MES
    public List<EncapPedido> ConsultarVentasAnoMes(int ano, int mes)
    {
        using (var db = new Mapeo())
        {

            return (from uu in db.pedidos.Where(x => x.Estado_pedido == 4 && x.Fecha_pedido.Year == ano && x.Fecha_pedido.Month == mes)
                    join usuario in db.usuario on uu.User_id equals usuario.User_id
                    join estado in db.estado_pedido on uu.Estado_pedido equals estado.Id
                    join empleado in db.usuario on uu.Atendido_id equals empleado.User_id
                    select new
                    {
                        uu,
                        usuario,
                        estado,
                        empleado
                    }).ToList().Select(m => new EncapPedido
                    {

                        Id = m.uu.Id,
                        User_id = m.usuario.User_id,
                        Atendido_id = m.uu.Atendido_id,
                        Domiciliario_id = m.uu.Domiciliario_id,
                        Fecha_pedido = m.uu.Fecha_pedido,
                        Estado_pedido = m.uu.Estado_pedido,
                        Total = m.uu.Total,
                        Empleado = m.empleado.Nombre,
                        Usuario = m.usuario.Nombre,
                        Estado = m.estado.Estado

                    }
                      ).ToList();
        }
    }

    //METODO ELIMINAR CUENTA DE USUARIO
    public void EliminarCuenta(EncapUsuario usuario)
    {

        using (var db = new Mapeo())
        {
            db.usuario.Attach(usuario);

            var usuario_eliminar = db.usuario.Where(x => x.User_id == usuario.User_id);

            var entry = db.Entry(usuario);
            entry.State = EntityState.Deleted;

            db.usuario.RemoveRange(usuario_eliminar);

            db.SaveChanges();
        }
    }
    //METODO PARA OBTENER LOS PEDIDOS POR ESTADOS DEL USUARIO 

    public List<EncapPedido> ObtenerPedidosActivo(int usu)
    {
        using (var db = new Mapeo())
        {
            return (from pedido in db.pedidos.Where(x => x.User_id == usu && x.Estado_pedido != 6 )
                    //join atendido in db.usuario on pedido.Atendido_id equals atendido.User_id
                    //join domiciliario in db.usuario on pedido.Domiciliario_id equals domiciliario.User_id
                    join estado in db.estado_pedido on pedido.Estado_pedido equals estado.Id
                    join ciudad_dep in db.ciudades_departamentso on pedido.Ciu_dep_id equals ciudad_dep.Id
                    join municipio in db.municipios on pedido.Municipio_id equals municipio.Id
                    select new
                    {
                        pedido,
                        //atendido,
                        //domiciliario,
                        estado,
                        ciudad_dep,
                        municipio

                    }).ToList().Select(m => new EncapPedido
                    {
                       Id= m.pedido.Id,
                       Fecha_pedido=m.pedido.Fecha_pedido,
                       User_id =m.pedido.User_id,
                       Atendido_id=m.pedido.Atendido_id,
                       //Empleado=m.atendido.Nombre,
                       Domiciliario_id=m.pedido.Domiciliario_id,
                       //Domiciliaro=m.domiciliario.Nombre,
                       Estado_pedido =m.pedido.Estado_pedido,
                       Estado=m.estado.Estado,
                       Total=m.pedido.Total,
                       Novedad=m.pedido.Novedad,
                       Direccion=m.pedido.Direccion,
                       Ciu_dep_id=m.pedido.Ciu_dep_id,
                       Ciudad_dep=m.ciudad_dep.Nombre,
                       Municipio_id=m.pedido.Municipio_id,
                       Municipio=m.municipio.Nombre,
                       Fecha_pedido_fin=m.pedido.Fecha_pedido_fin

                    }).ToList();
        }
    }
    //METODO PARA OBTENER LOS PEDIDOS FINALZIADOS POR USUARIO
    public List<EncapPedido> ObtenerPedidosFin(int usu)
    {
        using (var db = new Mapeo())
        {
            return (from pedido in db.pedidos.Where(x => x.User_id == usu && x.Estado_pedido ==6)
                    join atendido in db.usuario on pedido.Atendido_id equals atendido.User_id
                    join domiciliario in db.usuario on pedido.Domiciliario_id equals domiciliario.User_id
                    join estado in db.estado_pedido on pedido.Estado_pedido equals estado.Id
                    join ciudad_dep in db.ciudades_departamentso on pedido.Ciu_dep_id equals ciudad_dep.Id
                    join municipio in db.municipios on pedido.Municipio_id equals municipio.Id
                    select new
                    {
                        pedido,
                        atendido,
                        domiciliario,
                        estado,
                        ciudad_dep,
                        municipio

                    }).ToList().Select(m => new EncapPedido
                    {
                        Id = m.pedido.Id,
                        Fecha_pedido = m.pedido.Fecha_pedido,
                        User_id = m.pedido.User_id,
                        Atendido_id = m.pedido.Atendido_id,
                        Empleado = m.atendido.Nombre,
                        Domiciliario_id = m.pedido.Domiciliario_id,
                        Domiciliaro = m.domiciliario.Nombre,
                        Estado_pedido = m.pedido.Estado_pedido,
                        Estado = m.estado.Estado,
                        Total = m.pedido.Total,
                        Novedad = m.pedido.Novedad,
                        Direccion = m.pedido.Direccion,
                        Ciu_dep_id = m.pedido.Ciu_dep_id,
                        Ciudad_dep = m.ciudad_dep.Nombre,
                        Municipio_id = m.pedido.Municipio_id,
                        Municipio = m.municipio.Nombre,
                        Fecha_pedido_fin = m.pedido.Fecha_pedido_fin

                    }).ToList();
        }
    }

    //METODO PARA HACER UPDATE DE IP Y MAC 
    public void ActualizarSessiones(EncapUsuario User)
    {
        using (var db = new Mapeo())
        {
            var resultado = db.usuario.FirstOrDefault(x => x.Correo == User.Correo);
            if (resultado != null)
            {
                /*resultado.User_id = User.User_id;
                resultado.Nombre = User.Nombre;
                resultado.Apellido = User.Apellido;
                resultado.Correo = User.Correo;
                resultado.Estado_id = User.Estado_id;
                resultado.Fecha_nacimiento = User.Fecha_nacimiento;
                resultado.Identificacion = User.Identificacion;
                resultado.Tiempo_token = User.Tiempo_token;*/

                resultado.Ip_ = null;
                resultado.Mac_ = null;
                resultado.Sesion = null;


                db.SaveChanges();
            }
        }

    }
    //METODO PARA OBTENER LOS PRODUCTOS DEL PEDIDO
    public List<EncapProducto_pedido> ConsultarProductosPedido(int id_ped)
    {
        using (var db = new Mapeo())
        {
            return (from uu in db.productos where uu.Pedido_id == id_ped
                    join iven in db.inventario on uu.Producto_id equals iven.Id

                    select new
                    {
                        uu,
                        iven
                        

                    }).ToList().Select(m => new EncapProducto_pedido
                    {
                        Id = m.uu.Id,
                        Pedido_id = m.uu.Pedido_id,
                        Producto_id = m.uu.Producto_id,
                        Cantidad = m.uu.Cantidad,
                        Precio = m.uu.Precio,
                        Total = m.uu.Total,
                        Nombre_producto = m.iven.Titulo,
                        Referencia = m.iven.Referencia
                       

                    }).ToList();
        }
    }


}


