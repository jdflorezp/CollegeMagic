using CollegeApi.Domain.Response;
using CollegeApi.Model.Models;
using CollegeApi.Repository.EF.Context;
using CollegeApi.Repository.EF.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApi.Repository.EF.Implementation
{
    public class CollegeRepository<T> : ICollegeRepository<T> where T : class
    {
        private readonly EFContext context;

        public CollegeRepository(EFContext _context)
        {
            this.context = _context;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<T> AddAsync(T entity)
        {
            try
            {
                var result = await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, nameof(AddAsync), ex);
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task RemoveAsync(int id)
        {
            try
            {
                var type = await context.Set<T>().FindAsync(id);
                context.Remove(type);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, nameof(RemoveAsync), ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task UpdateAsync(T entity, int id)
        {
            try
            {
                var type = await context.Set<T>().FindAsync(id);
                context.Entry(type).CurrentValues.SetValues(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, nameof(UpdateAsync), ex);
            }

        }
        /// <summary>
        /// /
        /// </summary>
        /// <returns></returns>
        public async Task<List<InscriptionResponse>> ListStudent()
        {
            List<InscriptionResponse> listInscription = new List<InscriptionResponse>();
            try
            {
                listInscription = await context.TblInscription.Join(context.TblCandidateHouse, x => x.idCandidateHouse, y => y.idCandidateHouse,
                (x, y) => new InscriptionResponse
                {
                    name = x.name,
                    lastName = x.lastName,
                    id = x.id,
                    age = x.age,
                    idCandidateHouse = x.idCandidateHouse,
                    CandidateHouse = y.candidateHouseName
                }).ToListAsync();
                return listInscription;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, nameof(ListStudent), ex);
            }
        }
        public  List<TblInscription> ContainsAsyncStudent(int id)
        {
            List<TblInscription> listInscription = new List<TblInscription>();
            try
            {
                listInscription = context.TblInscription.Where(x => x.id == id).ToList();
                return listInscription;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, nameof(ContainsAsyncStudent), ex);
            }
        }
        public List<TblCandidateHouse> ContainsAsyncHouse(int idCandidateHouse)
        {
            List<TblCandidateHouse> listCandidateHouse = new List<TblCandidateHouse>();
            try
            {
                listCandidateHouse = context.TblCandidateHouse.Where(x => x.idCandidateHouse == idCandidateHouse).ToList();
                return listCandidateHouse;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, nameof(ContainsAsyncHouse), ex);
            }
        }
  
    }
}
