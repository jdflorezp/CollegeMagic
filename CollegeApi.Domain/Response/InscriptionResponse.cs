using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CollegeApi.Domain.Response
{
    public class InscriptionResponse
    {
        public string name { get; set; }
        public string lastName { get; set; }
        [Key]
        public int id { get; set; }
        public Int16 age { get; set; }
        public int idCandidateHouse { get; set; }
        public string CandidateHouse { get; set; }
    }
}
