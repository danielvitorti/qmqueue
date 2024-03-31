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
        
        public IActionResult Index()
        {
            return RedirectToAction("Monitor","Qmq");
        }

        public IActionResult Monitor()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetQmqInHeaderMessageType()
        {
            try
            {
                var qmqInHeader = _context.mensagemEntradaCabecalho
                                    .Select(p => new { p.CODIGO_MENSAGEM, p.ID_MENSAGEM }).Distinct()
                                    .ToListAsync().Result;
                                                        
                
                return Json(qmqInHeader);
                
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }


        [HttpGet]
        public JsonResult GetDataQmqInHeaderByMessageTypeAndPeriod(string MessageType, string dtIni, string dtFin)
        {
           
           try
            {
                if(!string.IsNullOrEmpty(MessageType) || (!string.IsNullOrEmpty(dtIni) && !string.IsNullOrEmpty(dtFin) ))
                {    
                    
                    var result = _context.mensagemEntradaCabecalho.Select(p => new { p.SISTEMA_ORIGEM, p.ID_MENSAGEM,p.SISTEMA_DESTINO,p.CODIGO_MENSAGEM
                                        ,p.OBSERVACAO,p.STATUS,p.DATA_PROCESSAMENTO}).Distinct()
                                        .Where(p => p.CODIGO_MENSAGEM == MessageType && Convert.ToDateTime(p.DATA_PROCESSAMENTO) >= Convert.ToDateTime(dtIni) && 
                                        Convert.ToDateTime(p.DATA_PROCESSAMENTO) <= Convert.ToDateTime(dtFin)) 
                                        .ToListAsync().Result;
                                                                
                    return Json(
                        result
                    );  

                }
                else
                {
                    var result = _context.mensagemEntradaCabecalho.Select(p => new { p.SISTEMA_ORIGEM, p.ID_MENSAGEM,p.SISTEMA_DESTINO,p.CODIGO_MENSAGEM,p.OBSERVACAO,p.STATUS,p.DATA_PROCESSAMENTO }).Distinct()
                                                    .ToListAsync().Result;

                                
                        return Json(
                            result
                        );
                }

            }
            catch (Exception ex)
            {
                return Json("erro");
            }
        }

        [HttpGet]
        public JsonResult GetDataQmqOutHeaderByMessageTypeAndPeriod(string MessageType, string dtIni, string dtFin)
        {
            try
            {
                if (!string.IsNullOrEmpty(MessageType) || (!string.IsNullOrEmpty(dtIni) && !string.IsNullOrEmpty(dtFin)))
                {
                    DateTime startDate = DateTime.MinValue;
                    DateTime endDate = DateTime.MaxValue;
                    if (!string.IsNullOrEmpty(dtIni))
                        startDate = Convert.ToDateTime(dtIni);
                    if (!string.IsNullOrEmpty(dtFin))
                        endDate = Convert.ToDateTime(dtFin); 

                    var result = _context.mensagemSaidaCabecalho
                                .Where(p => p.CODIGO_MENSAGEM == MessageType && Convert.ToDateTime(p.DATA_PROCESSAMENTO) >= startDate && Convert.ToDateTime(p.DATA_PROCESSAMENTO) <= endDate)
                                .Select(p => new {
                                    p.SISTEMA_ORIGEM,
                                    p.ID_MENSAGEM,
                                    p.SISTEMA_DESTINO,
                                    p.CODIGO_MENSAGEM,
                                    p.OBSERVACAO,
                                    p.STATUS,
                                    p.DATA_PROCESSAMENTO
                                })
                                .ToList();

                    return Json(result);
                }
                else
                {
                    var result = _context.mensagemSaidaCabecalho
                        .Select(p => new
                        {
                            p.SISTEMA_ORIGEM,
                            p.ID_MENSAGEM,
                            p.SISTEMA_DESTINO,
                            p.CODIGO_MENSAGEM,
                            p.DATA_PROCESSAMENTO
                    
                        })
                        .Distinct()
                        .ToList();

                    return Json(result);
                }
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
                var qmqInBody = _context.mensagemEntradaCorpo.Where( p => p.ID_MENSAGEM == MessageId)
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
                var qmqOutHeader =  _context.mensagemSaidaCabecalho
                                                            .Select(p => new { p.CODIGO_MENSAGEM, p.ID_MENSAGEM })
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
                var qmqOutBody = _context.mensagemSaidaCorpo.Where( p => p.ID_MENSAGEM == MessageId).ToList();
                                        
                return Json(qmqOutBody);
            
            }
            catch(Exception ex)
            {
                return Json(ex.Message);
            }

        }
    }
}
