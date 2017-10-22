using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeritBadgeWebService.Models
{
    public class ClassAndBSAMemberViewModal
    {
        public int ClassId { get; set; }

        public int MeritBadgeIdCL { get; set; }

        public string DateTimeOfClass { get; set; }

        public int InstructorId { get; set; }

        public BSAMemberViewModel InstructorInfo { get; set; }

        public string Location { get; set; }

        public int TotalNumberOfStudents { get; set; }

        public int EnrolledNumberOfStudents { get; set; }
    }
}