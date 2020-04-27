using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Mision_Vision_Objetivo
/// </summary>
public class Mision_Vision_Objetivo
{
    public Mision_Vision_Objetivo()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public EncapMision ObtenerMision(EncapMision id)
    {
        using (var db = new Mapeo())
        {
            return db.mision.Where(x => x.Id.Equals(id.Id)).FirstOrDefault();
        }
    }

    public EncapVision ObtenerVision(EncapVision id)
    {
        using (var db = new Mapeo())
        {
            return db.vision.Where(x => x.Id.Equals(id.Id)).FirstOrDefault();
        }
    }

    public EncapObjetivo ObtenerObjetivon(EncapObjetivo id)
    {
        using (var db = new Mapeo())
        {
            return db.objetivo.Where(x => x.Id.Equals(id.Id)).FirstOrDefault();
        }
    }

    public void ActualizarMision(EncapMision mision)
    {
        using (var db = new Mapeo())
        {

            var resultado = db.mision.SingleOrDefault(x => x.Id == 1);
            if (resultado != null)
            {
                resultado.Mision = mision.Mision;
                db.SaveChanges();
            }

        }

    }
    public void ActualizarVision(EncapVision vision)
    {
        using (var db = new Mapeo())
        {

            var resultado = db.vision.SingleOrDefault(x => x.Id == 1);
            if (resultado != null)
            {
                resultado.Vision = vision.Vision;
                db.SaveChanges();
            }

        }

    }
    public void ActualizarObjetivo(EncapObjetivo objetivo)
    {
        using (var db = new Mapeo())
        {

            var resultado = db.objetivo.SingleOrDefault(x => x.Id == 1);
            if (resultado != null)
            {
                resultado.Objetivo = objetivo.Objetivo;
                db.SaveChanges();
            }

        }

    }
}