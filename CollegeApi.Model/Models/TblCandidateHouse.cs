using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CollegeApi.Model.Models
{
    public class TblCandidateHouse
    {
        [Key]
        public int idCandidateHouse { get; set; }
        public string candidateHouseName { get; set; }
    }
}
