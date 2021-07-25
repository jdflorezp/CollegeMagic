using CollegeApi.Business.Interface;
using CollegeApi.Common.Resources;
using CollegeApi.Domain.Request;
using CollegeApi.Domain.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CollegeApi.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class InscriptionController : ControllerBase
    {
        private readonly IinscriptionBusiness inscriptionBusiness;
        private readonly IConfiguration config;
        private BaseResponse baseResponse = new BaseResponse();
        public InscriptionController(IinscriptionBusiness inscriptionBusiness,
          IConfiguration _config)
        {
            this.inscriptionBusiness = inscriptionBusiness;
            this.config = _config;
        }
        [HttpPost]
        public async Task<IActionResult> CreateStudent(InscriptionRequest inscriptionRequest)
        {
            try
            {
                baseResponse = this.inscriptionBusiness.ObligatoryValidations(inscriptionRequest);
                if (!string.IsNullOrEmpty(baseResponse.header.error))
                {
                    return StatusCode(((int)HttpStatusCode.BadRequest), baseResponse);
                }
                else
                {
                    baseResponse = this.inscriptionBusiness.SizeValidations(inscriptionRequest);
                    baseResponse = this.inscriptionBusiness.CharacterValidations(inscriptionRequest);
                    if (!string.IsNullOrEmpty(baseResponse.header.error))
                    {
                        return StatusCode(((int)HttpStatusCode.BadRequest), baseResponse);
                    }
                }
                return StatusCode(((int)HttpStatusCode.Created), await this.inscriptionBusiness.InsertAsyncStudent(inscriptionRequest));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                baseResponse.header.error = MessageInfo.messageErrorGeneric;
                return StatusCode(((int)HttpStatusCode.InternalServerError), baseResponse);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStudent()
        {
            try
            {
                return Ok(await this.inscriptionBusiness.GetInscription());
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                baseResponse.header.error = MessageInfo.messageErrorGeneric;
                return StatusCode(((int)HttpStatusCode.InternalServerError), baseResponse);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateStudent(InscriptionRequest inscriptionRequest)
        {
            try
            {
                baseResponse = this.inscriptionBusiness.ObligatoryValidations(inscriptionRequest);
                if (!string.IsNullOrEmpty(baseResponse.header.error))
                {
                    return StatusCode(((int)HttpStatusCode.BadRequest), baseResponse);
                }
                else
                {
                    baseResponse = this.inscriptionBusiness.SizeValidations(inscriptionRequest);
                    baseResponse = this.inscriptionBusiness.CharacterValidations(inscriptionRequest);
                    if (!string.IsNullOrEmpty(baseResponse.header.error))
                    {
                        return StatusCode(((int)HttpStatusCode.BadRequest), baseResponse);
                    }
                }
                return StatusCode(((int)HttpStatusCode.OK), await this.inscriptionBusiness.UpdateAsyncStudent(inscriptionRequest));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                baseResponse.header.error = MessageInfo.messageErrorGeneric;
                return StatusCode(((int)HttpStatusCode.InternalServerError), baseResponse);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteStudent(InscriptionDeleteRequest inscriptionRequest)
        {
            try
            {
                return StatusCode(((int)HttpStatusCode.OK), await this.inscriptionBusiness.DeleteAsyncStudent(inscriptionRequest.id));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                baseResponse.header.error = MessageInfo.messageErrorGeneric;
                return StatusCode(((int)HttpStatusCode.InternalServerError), baseResponse);
            }
        }
    }
}
