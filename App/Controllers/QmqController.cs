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
        public JsonResult GetQmqInHeaderMessageType()
        {
            try
            {
                var qmqInHeader = _context.QMQ_IN_HEADERs
                                                            .Select(p => new { p.MESSAGE_TYPE, p.MESSAGE_ID }).Distinct()
                                                            .ToListAsync().Result;
                                                        
                
                return Json(qmqInHeader);
                
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
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
        public JsonResult GetDataQmqOutHeaderByMessageType(string MessageType, string dtIni,string dtFin  )
        {
            try
            {
                return Json("");

            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        [HttpGet]
        public JsonResult GetMessageInBodyByMessageId(string MessageId)
        {
            try{
                var qmqInBody = _context.QMQ_IN_BODies.Where( p => p.MESSAGE_ID == MessageId)
                                                        .ToList();
            

                return Json(qmqInBody);
            }
            catch(Exception ex)
            {
                return Json(ex.Message);
            }
             
        }

        [HttpGet]
        public JsonResult GetQmqOutHeaderMessageType()
        {
            try{
                var qmqOutHeader =  _context.QMQ_OUT_HEADERs
                                                            .Select(p => new { p.MESSAGE_TYPE, p.MESSAGE_ID })
                                                            .Distinct()
                                                            .ToListAsync().Result;

                return Json(qmqOutHeader);

            }
            catch(Exception ex)
            {
                return Json(ex.Message);
            }                                            
            
        }

        [HttpGet]
        public JsonResult GetMessageOutBodyByMessageId(string MessageId)
        {
            try
            {
                var qmqOutBody = _context.QMQ_OUT_BODies.Where( p => p.MESSAGE_ID == MessageId).ToList();
                                        
                return Json(qmqOutBody);
            
            }
            catch(Exception ex)
            {
                return Json(ex.Message);
            }

        }
    }
}
