using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeritBadgeWebService.Models
{
    public class MeritBadgeRequirementViewModal
    {
        public int MeritBadgeRequirementId { get; set; }

        public int MeritBadgeId { get; set; }

        public string Requirement { get; set; }
    }
}