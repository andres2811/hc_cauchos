using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_administrador_HistorialVentas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Btn_Buscar_Click(object sender, EventArgs e)
    {
        if(TB_Dia.Text != "")
        {
            GV_Historial.DataSourceID = "ODS_HistorialDia";
        }
        if(TB_Mes.Text != "")
        {
            GV_Historial.DataSourceID = "ODS_HistorialMes";
        }
        if (TB_Ano.Text != "")
        {
            GV_Historial.DataSourceID = "ODS_HistorialAno";
        }
        if (TB_Ano.Text != "" && TB_Mes.Text != "")
        {
            GV_Historial.DataSourceID = "ODS_HistorialAnoMes";
        }
        if (TB_Ano.Text != "" && TB_Dia.Text != "")
        {
            GV_Historial.DataSourceID = "ODS_HistorialAnoDia";
        }
        if (TB_Ano.Text != "" && TB_Mes.Text != "" && TB_Dia.Text != "")
        {
            GV_Historial.DataSourceID = "ODS_HistorialAnoMesDia";
        }

    }

    protected void GV_Historial_DataBound(object sender, EventArgs e)
    {

    }
}