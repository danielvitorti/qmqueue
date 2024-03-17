using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QMessage;
using QMessage.Models;

namespace QMessage.Controllers
{
    public class QmqController : Controller
    {
        private readonly qmessageContext _context;

        public QmqController(qmessageContext context)
        {
            _context = context;
        }


        /*


         ***** FORMATO ABAIXO QUE DEVERA TRAZER OS DADOS PARA A DATATABLE *************

            try
            {                
                //public IEnumerable<OutOfGaugeTCMViewModel> GetData(string Bobina, string Grau, string InfGrauAco, string InicioLaminacao, string FimLaminacao)
                var coilListResult = outOfGaugeTCMAppService.GetData(param.Bobina,param.Grau,param.InfGrauAco,param.InicioLaminacao,param.FimLaminacao).ToList();

                var displayResult = coilListResult.Skip(param.iDisplayStart).Take(param.iDisplayLength).ToList().OrderByDescending(p => p.FimLaminacao);
                var totalRecords = coilListResult.Count();

                logDataAppService.WebInfo(HttpContext.Session.GetString("UserLZC3"), $"Dados de fora de bitola carregados com sucesso. Action => {nameof(ConsultationsController)}/{nameof(GetDataOfOutOfGaugeTCM)}");

                return Json(
                    new
                    {
                        param.sEcho,
                        iTotalRecords = totalRecords,
                        iTotalDisplayRecords = totalRecords,
                        aaData = displayResult
                    });
                
            }
            catch(Exception ex)
            {
                logDataAppService.WebError(HttpContext.Session.GetString("UserLZC3"), $"Erro ao carregar Sequencia de Producao. Action => {nameof(ConsultationsController)}/{nameof(GetDataOfOutOfGaugeTCM)} => {ex.Message}");
                return Json(
                    new
                    {
                    StatusCode = 500
                    });
            }        
        
        */

        
        public IActionResult Index()
        {
            return RedirectToAction("Monitor","Qmq");
        }


        /*public IActionResult Monitor()
        {
            return View();
        } */

        // GET: QmqInHeader
        /*public IActionResult Index()
        {
            return RedirectToAction("Monitor","Qmq");
        }  */


        public IActionResult Monitor()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetQmqInHeaderMessageType()
        {
            try
            {
                return Content("");

            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }


        [HttpGet]
        public ActionResult GetDataQmqInHeaderByMessageType(string MessageType, string dtIni, string dtFin)
        {
            try
            {

                return Content("");

            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        public ActionResult GetDataQmqOutHeaderByMessageType(string MessageType, string dtIni,string dtFin  )
        {
            try
            {
                return Content("");

            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        [HttpGet]
        public ActionResult GetMessageInBodyByMessageId(string MessageId)
        {
            try
            {
                return Content("");

            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        public ActionResult GetQmqOutHeaderMessageType()
        {
            try
            {
            
                return Content("");

            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        public ActionResult GetMessageOutBodyByMessageId(string MessageId)
        {
            try
            {
                return Content("");

            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

    }
}
