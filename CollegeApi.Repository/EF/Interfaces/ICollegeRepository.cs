using CollegeApi.Domain.Response;
using CollegeApi.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApi.Repository.EF.Interfaces
{
    public interface ICollegeRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<List<InscriptionResponse>> ListStudent();
        Task RemoveAsync(int id);
        Task UpdateAsync(T entity, int id);
        List<TblInscription> ContainsAsyncStudent(int id);
        List<TblCandidateHouse> ContainsAsyncHouse(int idCandidateHouse);
    }
}
