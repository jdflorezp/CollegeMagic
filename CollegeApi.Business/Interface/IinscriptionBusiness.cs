using CollegeApi.Domain.Request;
using CollegeApi.Domain.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApi.Business.Interface
{
    public interface IinscriptionBusiness
    {
        Task<object> InsertAsyncStudent(InscriptionRequest inscriptionRequest);
        Task<List<InscriptionResponse>> GetInscription();
        Task<object> UpdateAsyncStudent(InscriptionRequest inscriptionRequest);
        Task<object> DeleteAsyncStudent(int id);
        BaseResponse CharacterValidations(InscriptionRequest inscriptionRequest);
        BaseResponse ObligatoryValidations(InscriptionRequest inscriptionRequest);
        BaseResponse SizeValidations(InscriptionRequest inscriptionRequest);
    }
}
