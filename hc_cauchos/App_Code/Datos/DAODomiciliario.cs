using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DAODomiciliario
/// </summary>
public class DAODomiciliario
{
    public DAODomiciliario()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    //METODO PARA OBTENER LOS PEDIDOS DEL DOMICILIARIO
    public List<EncapPedido> ObtenerPedidos(int user)
    {
        using (var db = new Mapeo())

            return (from pedi in db.pedidos.Where(x => x.Domiciliario_id == user && x.Estado_pedido == 4)
                    join usu in db.usuario on pedi.User_id equals usu.User_id
                    join emple in db.usuario on pedi.Atendido_id equals emple.User_id
                    join domi in db.usuario on pedi.Domiciliario_id equals domi.User_id
                    join ciudad_dep in db.ciudades_departamentso on pedi.Ciu_dep_id equals ciudad_dep.Id
                    join municipio in db.municipios on pedi.Municipio_id equals municipio.Id

                    select new
                    {
                        pedi,
                        usu,
                        emple,
                        domi,
                        municipio,
                        ciudad_dep

                    }).ToList().Select(m => new EncapPedido
                    {

                        Id = m.pedi.Id,
                        Fecha_pedido = m.pedi.Fecha_pedido,
                        User_id = m.pedi.User_id,
                        Usuario = m.usu.Nombre,
                        Atendido_id = m.pedi.Atendido_id,
                        Empleado = m.emple.Nombre,
                        Domiciliario_id = m.pedi.Domiciliario_id,
                        Domiciliaro = m.domi.Nombre,
                        Estado_pedido = m.pedi.Estado_pedido,
                        Total = m.pedi.Total,
                        Direccion=m.pedi.Direccion,
                        Ciu_dep_id=m.pedi.Ciu_dep_id,
                        Municipio_id=m.pedi.Municipio_id,
                        Fecha_pedido_fin=m.pedi.Fecha_pedido_fin,
                        Ciudad_dep=m.ciudad_dep.Nombre,
                        Municipio=m.municipio.Nombre


                    }).ToList();
    }

    //ACTUALIZAR ESTADO EN EL PEDIDO POR DOMICILIARIO
    public void ActualizarNovedadPedido(EncapPedido estado5)
    {
        using (var db = new Mapeo())
        {
            EncapPedido newnovedad = db.pedidos.Where(x => x.Id == estado5.Id).SingleOrDefault();
            newnovedad.Estado_pedido = 5;
            newnovedad.Fecha_pedido_fin = estado5.Fecha_pedido_fin;

            db.SaveChanges();
        }
    }


}