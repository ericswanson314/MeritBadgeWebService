using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeritBadgeWebService.Models
{
    public class BSAMemberTypeState
    {
        private BSAMemberTypeState(string value, string text)
        {
            this.Value = value;
            this.Name = text;
        }

        public BSAMemberTypeState(string value)
        {
            this.Value = value;
            this.Name = value;
        }

        public string Value { get; set; }
        public string Name { get; set; }
    }
}