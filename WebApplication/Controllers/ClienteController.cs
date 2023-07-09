using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace WebApplication.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente

        public ActionResult Alta()
        {
            string conectar = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            using (SqlConnection sqlConectar = new SqlConnection(conectar))
            {
                try
                {
                    #region Obtener tabla de SQL Server - 14764
                    string sentencia = "SELECT id01,reso_Problemas,ges_Config FROM parteunoProcesos_14764";
                    string sentenciaDos = "SELECT id02,Correccion,Mejora FROM partedosProcesos_14764";
                    string sentenciaTres = "SELECT id03,Estrategia FROM partetresProcesos_14764";
                    SqlDataAdapter da = new SqlDataAdapter(sentencia, conectar);
                    SqlDataAdapter daDos = new SqlDataAdapter(sentenciaDos, conectar);
                    SqlDataAdapter daTres = new SqlDataAdapter(sentenciaTres, conectar);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    daDos.Fill(dt);
                    daTres.Fill(dt);
                    #endregion
                    return View("Alta", dt);
                }
                catch (Exception ex)
                {   
                    TempData["Error: "] = ex.Message;
                    return View("Alta");
                }
            }
        }

        public ActionResult Listado()
        {
            string conectar = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            using (SqlConnection sqlConectar = new SqlConnection(conectar))
            {
                try
                {
                    #region Obtener tabla de SQL Server - procesos_12207
                    string sentencia = "SELECT id,Procesos,Caracteristicas FROM procesos_12207";
                    SqlDataAdapter da = new SqlDataAdapter(sentencia, conectar);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    #endregion
                    return View("Listado", dt);
                }
                catch (Exception ex)
                {
                    TempData["Error: "] = ex.Message;
                    return View("Listado");
                }
            }
        }
    }
}