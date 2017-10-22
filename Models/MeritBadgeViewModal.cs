using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeritBadgeWebService.Models
{
    public class MeritBadgeViewModal
    {
        public int MeritBadgeId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int PictureID { get; set; }

    }
}