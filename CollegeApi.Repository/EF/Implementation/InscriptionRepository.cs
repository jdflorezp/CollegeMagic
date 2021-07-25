using CollegeApi.Model.Models;
using CollegeApi.Repository.EF.Context;
using CollegeApi.Repository.EF.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeApi.Repository.EF.Implementation
{
    public class InscriptionRepository : CollegeRepository<TblInscription>, IinscriptionRepository
    {
        public InscriptionRepository(EFContext context) : base(context)
        {

        }
    }
}
