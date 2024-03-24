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
        public JsonResult GetDataQmqInHeaderByMessageTypeAndPeriod(string MessageType, string dtIni, string dtFin)
        {
           
           try
            {
                if(!string.IsNullOrEmpty(MessageType) || (!string.IsNullOrEmpty(dtIni) && !string.IsNullOrEmpty(dtFin) ))
                {    
                    
                    var result = _context.QMQ_IN_HEADERs.Select(p => new { p.SOURCE, p.MESSAGE_ID,p.TARGET,p.MESSAGE_TYPE,
                                                    p.EXPIRATION_TIME,p.REMARKS,p.MSG_STATUS,p.DATE_TIME_IN,p.DATE_TIME_PROC,p.RETRY_COUNT }).Distinct()
                                                    .Where(p => p.MESSAGE_TYPE == MessageType) /*&& Convert.ToDateTime(p.DATE_TIME_IN) >= Convert.ToDateTime(dtIni) && 
                                                    Convert.ToDateTime(p.DATE_TIME_IN) <= Convert.ToDateTime(dtFin)) */
                                                    .ToListAsync().Result;

                                                                
                    return Json(
                        result
                    );  

                }
                else
                {
                    var result = _context.QMQ_IN_HEADERs.Select(p => new { p.SOURCE, p.MESSAGE_ID,p.TARGET,p.MESSAGE_TYPE,p.EXPIRATION_TIME,p.REMARKS,p.MSG_STATUS,p.DATE_TIME_IN,p.DATE_TIME_PROC,p.RETRY_COUNT }).Distinct()
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
                    /*if (!string.IsNullOrEmpty(dtIni))
                        startDate = Convert.ToDateTime(dtIni);
                    if (!string.IsNullOrEmpty(dtFin))
                        endDate = Convert.ToDateTime(dtFin); */

                    var result = _context.QMQ_OUT_HEADERs
                        .Where(p => p.MESSAGE_TYPE == MessageType )//&&
                                   // Convert.ToDateTime(p.DATE_TIME_IN) >= startDate &&
                                   // Convert.ToDateTime(p.DATE_TIME_IN) <= endDate)
                        .Select(p => new
                        {
                            p.SOURCE,
                            p.MESSAGE_ID,
                            p.TARGET,
                            p.MESSAGE_TYPE,
                            p.EXPIRATION_TIME,
                            p.REMARKS,
                            p.MSG_STATUS,
                            p.DATE_TIME_IN,
                            p.DATE_TIME_PROC,
                            p.RETRY_COUNT
                        })
                        .ToList();

                    return Json(result);
                }
                else
                {
                    var result = _context.QMQ_OUT_HEADERs
                        .Select(p => new
                        {
                            p.SOURCE,
                            p.MESSAGE_ID,
                            p.TARGET,
                            p.MESSAGE_TYPE,
                            p.EXPIRATION_TIME,
                            p.REMARKS,
                            p.MSG_STATUS,
                            p.DATE_TIME_IN,
                            p.DATE_TIME_PROC,
                            p.RETRY_COUNT
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
