using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CollegeApi.Model.Models
{
    public class TblInscription
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }     
        public Int16 age { get; set; }
        public int idCandidateHouse { get; set; }
    }
}
