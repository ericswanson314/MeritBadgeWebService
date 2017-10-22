using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeritBadgeWebService.Models
{
    public class BSAMemberViewModel
    {
        public BSAMemberViewModel()
        {
        }

        public BSAMemberViewModel(string bsaType)
        {
            BSAMemberType = bsaType;
        }

        public BSAMemberTypeState BSAMemberTypeA
        {
            get { return new BSAMemberTypeState(BSAMemberType); }
            set { BSAMemberType = value.Value; }
        }

        public int BSAMemberId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string BSAMemberType { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string District { get; set; }

        public string Council { get; set; }

        public string Troop { get; set; }

        public string Crew { get; set; }

        public int ScoutMasterId { get; set; }

        public string SMFirstName { get; set; }

        public string SMLastName { get; set; }

        public string SMTelephone { get; set; }

        public string SMEmailAddress { get; set; }

        public string Telephone { get; set; }

        public string BirthDate { get; set; }

        public string EmailAddress { get; set; }

        public bool BackGroundCheck { get; set; }
    }
}