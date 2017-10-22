using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeritBadgeWebService.Models
{
    public class ClassesBoyScoutRequirementViewModal
    {
        public int ClassesBoyScoutRequirementId { get; set; }

        public int RequirementId { get; set; }

        public int ClassId { get; set; }

        public int MeritBadgeId { get; set; }

        public int BoyScoutId { get; set; }

        public bool RequirementPassed { get; set; }
    }
}