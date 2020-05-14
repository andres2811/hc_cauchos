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
}

    //METODO PARA OBTENER TODOS LOS ELEMENTOS DEL CARRITO 
    public EncapParametros ObtenerTiempo(EncapParametros nombre)
    {
        using (var db = new Mapeo())
        {
            return  db.parametros.Where(x => x.Nombre.Equals(nombre.Nombre)).FirstOrDefault();        
        }
    }



