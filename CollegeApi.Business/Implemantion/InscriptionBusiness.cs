using CollegeApi.Business.Interface;
using CollegeApi.Domain.Request;
using CollegeApi.Domain.Response;
using CollegeApi.Model.Models;
using CollegeApi.Repository.EF.Interfaces;
using Microsoft.Extensions.Configuration;
using CollegeApi.Common.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CollegeApi.Business
{
    public class InscriptionBusiness : IinscriptionBusiness
    {
        readonly IConfiguration _configuration;
        private readonly IinscriptionRepository repository;
        private BaseResponse baseResponse = new BaseResponse();
        public InscriptionBusiness(IConfiguration configuration,
                           IinscriptionRepository _repository)
        {
            _configuration = configuration;
            this.repository = _repository;
        }
        public async Task<object> InsertAsyncStudent(InscriptionRequest inscriptionRequest)
        {
            try
            {
                if (this.repository.ContainsAsyncStudent(inscriptionRequest.id).Any())
                {
                    baseResponse.header.error = MessageInfo.messageUserExists;
                    return baseResponse;
                }
                if (!this.repository.ContainsAsyncHouse(inscriptionRequest.idCandidateHouse).Any())
                {
                    baseResponse.header.error = MessageInfo.messageHouseExists;
                    return baseResponse;
                }
                TblInscription entity = new TblInscription();
                entity.id = inscriptionRequest.id;
                entity.idCandidateHouse = inscriptionRequest.idCandidateHouse;
                entity.age = inscriptionRequest.age;
                entity.lastName = inscriptionRequest.lastName;
                entity.name = inscriptionRequest.name;
                var model = await this.repository.AddAsync(entity);
                baseResponse.body = MessageInfo.messageOK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, nameof(InsertAsyncStudent), ex);
            }
        }
        public async Task<object> UpdateAsyncStudent(InscriptionRequest inscriptionRequest)
        {
            try
            {
                if (!this.repository.ContainsAsyncStudent(inscriptionRequest.id).Any())
                {
                    baseResponse.header.error = MessageInfo.messageNotExist;
                    return baseResponse;
                }
                if (!this.repository.ContainsAsyncHouse(inscriptionRequest.idCandidateHouse).Any())
                {
                    baseResponse.header.error = MessageInfo.messageHouseExists;
                    return baseResponse;
                }
                TblInscription entity = new TblInscription();
                entity.id = inscriptionRequest.id;
                entity.idCandidateHouse = inscriptionRequest.idCandidateHouse;
                entity.age = inscriptionRequest.age;
                entity.lastName = inscriptionRequest.lastName;
                entity.name = inscriptionRequest.name;
                await this.repository.UpdateAsync(entity, inscriptionRequest.id);
                baseResponse.body = MessageInfo.messageOK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, nameof(UpdateAsyncStudent), ex);
            }
        }
        public async Task<object> DeleteAsyncStudent(int id)
        {
            try
            {
                if (!this.repository.ContainsAsyncStudent(id).Any())
                {
                    baseResponse.header.error = MessageInfo.messageNotExist;
                    return baseResponse;
                }
                await this.repository.RemoveAsync(id);
                baseResponse.body = MessageInfo.messageOK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, nameof(DeleteAsyncStudent), ex);
            }
        }
        public async Task<List<InscriptionResponse>> GetInscription()
        {
            try
            {
                List<InscriptionResponse> result = new List<InscriptionResponse>();
                result = await this.repository.ListStudent();
                return result;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, nameof(GetInscription), ex);
            }
        }

        public BaseResponse CharacterValidations(InscriptionRequest inscriptionRequest)
        {
            Regex text = new Regex(@"^[a-zA-Z ]+$");
            Regex number = new Regex(@"^[0-9]+$");
            if (!text.IsMatch(inscriptionRequest.name))
            {
                baseResponse.header.error = string.Format(MessageInfo.messageErrorText, "name");
                return baseResponse;
            }
            if (!text.IsMatch(inscriptionRequest.lastName))
            {
                baseResponse.header.error = string.Format(MessageInfo.messageErrorText, "lastName");
                return baseResponse;
            }
            if (!number.IsMatch(inscriptionRequest.id.ToString()))
            {
                baseResponse.header.error = string.Format(MessageInfo.messageErrorNumber, "id");
                return baseResponse;
            }
            if (!number.IsMatch(inscriptionRequest.age.ToString()))
            {
                baseResponse.header.error = string.Format(MessageInfo.messageErrorNumber, "age");
                return baseResponse;
            }
            if (!number.IsMatch(inscriptionRequest.idCandidateHouse.ToString()))
            {
                baseResponse.header.error = string.Format(MessageInfo.messageErrorNumber, "idCandidateHouse");
                return baseResponse;
            }
            return baseResponse;
        }
        public BaseResponse ObligatoryValidations(InscriptionRequest inscriptionRequest)
        {
            if (string.IsNullOrEmpty(inscriptionRequest.name))
            {
                baseResponse.header.error = string.Format(MessageInfo.messageObligatoryField, "name");
                return baseResponse;
            }
            if (string.IsNullOrEmpty(inscriptionRequest.lastName))
            {
                baseResponse.header.error = string.Format(MessageInfo.messageObligatoryField, "lastName");
                return baseResponse;
            }
            if (inscriptionRequest.id == 0)
            {
                baseResponse.header.error = string.Format(MessageInfo.messageObligatoryField, "id");
                return baseResponse;
            }
            if (inscriptionRequest.age == 0)
            {
                baseResponse.header.error = string.Format(MessageInfo.messageObligatoryField, "age");
                return baseResponse;
            }
            if (inscriptionRequest.idCandidateHouse == 0)
            {
                baseResponse.header.error = string.Format(MessageInfo.messageObligatoryField, "idCandidateHouse");
                return baseResponse;
            }
            return baseResponse;
        }
        public BaseResponse SizeValidations(InscriptionRequest inscriptionRequest)
        {
            if (inscriptionRequest.name.Length > 20)
            {
                baseResponse.header.error = string.Format(MessageInfo.messageErrorSize, "name");
                return baseResponse;
            }
            if (inscriptionRequest.lastName.Length > 20)
            {
                baseResponse.header.error = string.Format(MessageInfo.messageErrorSize, "lastName");
                return baseResponse;
            }
            if (inscriptionRequest.id.ToString().Length > 10)
            {
                baseResponse.header.error = string.Format(MessageInfo.messageErrorSize, "id");
                return baseResponse;
            }
            if (inscriptionRequest.age.ToString().Length > 2)
            {
                baseResponse.header.error = string.Format(MessageInfo.messageErrorSize, "age");
                return baseResponse;
            }
            return baseResponse;
        }
    }
}
