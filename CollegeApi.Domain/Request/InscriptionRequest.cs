using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeApi.Domain.Request
{
    public class InscriptionRequest
    {
        public string name { get; set; }
        public string lastName { get; set; }
        public int id { get; set; }
        public Int16 age { get; set; }
        public int idCandidateHouse { get; set; }
    }
}
