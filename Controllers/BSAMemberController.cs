using MeritBadgeWebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PetaPoco;
using MeritBadgeWebService.Filter;

namespace MeritBadgeWebService.Controllers
{
    public class BSAMemberController : ApiController
    {
        private static string sConnectString = "";
        public BSAMemberController()
        {

        }

        [Route("api/ScoutMasters")]
        [HttpGet]
        [ValidSessionFilter]
        public IEnumerable<BSAMemberViewModel> GetBoyScoutMasters(string District, string Council, string Troop)
        {
            //Connect to the Umbraco DB
            var db = new PetaPoco.Database(sConnectString);

            List<BSAMemberViewModel> members = new List<BSAMemberViewModel>();
            //Get an IENumberable of MeritBadges objects to iterate over
            var lstMember = db.Query<BSAMember>("SELECT * FROM BSAMembers where DeleteRecordFlag = @0 and District = @1 and Council = @2 and Troop = @3", false, District, Council, Troop);
            foreach (BSAMember item in lstMember)
            {
                BSAMemberViewModel oModel = FillViewModelBSAMember(item, false);
                members.Add(oModel);
            }

            //Return the view with our model and comments
            return members;
        }

        [Route("api/AllUsers")]
        [HttpGet]
        [ValidSessionFilter]
        public IEnumerable<BSAMemberViewModel> GetAllBSAMembers()
        {
            //Connect to the Umbraco DB
            var db = new PetaPoco.Database(sConnectString);

            List<BSAMemberViewModel> members = new List<BSAMemberViewModel>();
            //Get an IENumberable of MeritBadges objects to iterate over
            var lstMember = db.Query<BSAMember>("SELECT * FROM BSAMembers where DeleteRecordFlag = @0", false);
            foreach (BSAMember item in lstMember)
            {
                BSAMemberViewModel oModel = FillViewModelBSAMember(item, false);
                members.Add(oModel);
            }

            //Return the view with our model and comments
            return  members;
        }

        [Route("api/Member")]
        [HttpGet]
        [ValidSessionFilter]
        public BSAMemberViewModel GetABSAMember(int iID)
        {
            BSAMemberViewModel oModel = GetABSAMemberInternal(iID);
            if (oModel.ScoutMasterId > 0)
            {
                BSAMemberViewModel item = GetABSAMemberInternal(oModel.ScoutMasterId);
                if (item.BSAMemberId > 0)
                {
                    oModel.SMFirstName = item.FirstName;
                    oModel.SMLastName = item.LastName;
                    oModel.SMTelephone = item.Telephone;
                    oModel.SMEmailAddress = item.EmailAddress;
                }
            }

            //Return the view with our model and comments
            return oModel;
        }

        [Route("api/Login")]
        [HttpGet]
        [ValidSessionFilter]
        public BSAMemberViewModel ValidateUserNameAndPassword(string username, string password)
        {
            BSAMemberViewModel item1 = null;
            try
            {
                //Connect to the Umbraco DB
                var db = new PetaPoco.Database(sConnectString);

                //Get an IENumberable of MeritBadges objects to iterate over
                var item = db.Single<BSAMember>("Select * from BSAMembers where UserName = @0 and Password = @1 and DeleteRecordFlag = @2", username, password, false);
                item1 = FillViewModelBSAMember(item, false);
            }
            catch (Exception ex)
            {
            }

            return item1;
        }

        private BSAMemberViewModel GetABSAMemberInternal(int iID)
        {
            //Connect to the Umbraco DB
            var db = new PetaPoco.Database(sConnectString);

            //Get an IENumberable of MeritBadges objects to iterate over
            var item = db.Single<BSAMember>(iID);

            return FillViewModelBSAMember(item, true);
        }

        private BSAMemberViewModel FillViewModelBSAMember(BSAMember item, bool includePassword)
        {
            BSAMemberViewModel oModel = new BSAMemberViewModel();
            oModel.BSAMemberId = item.BSAMemberId;
            oModel.BSAMemberType = item.BSAMemberType;
            oModel.UserName = item.UserName;
            if (includePassword == true)
            {
                oModel.Password = item.Password;
            }

            oModel.FirstName = item.FirstName;
            oModel.LastName = item.LastName;
            oModel.StreetAddress = item.StreetAddress;
            oModel.City = item.City;
            oModel.State = item.State;
            oModel.ZipCode = item.ZipCode;
            oModel.District = item.District;
            oModel.Council = item.Council;
            oModel.Troop = item.Troop;
            oModel.Crew = item.Crew;
            oModel.Telephone = item.Telephone;
            oModel.BirthDate = item.BirthDate;
            oModel.EmailAddress = item.EmailAddress;
            oModel.ScoutMasterId = item.ScoutMasterId;
            oModel.BackGroundCheck = item.BackGroundCheck;

            return oModel;
        }

        [Route("api/Member")]
        [HttpPost]
        [ValidSessionFilter]
        public bool InsertABSAMember(BSAMemberViewModel item)
        {
            if (item.BSAMemberType == "BoyScout")
            {
                if (item.ScoutMasterId == 0)
                {
                    BSAMemberViewModel oModel = new BSAMemberViewModel();
                    oModel.UserName = item.SMEmailAddress;
                    oModel.BSAMemberType = "ScoutMaster";
                    oModel.FirstName = item.SMFirstName;
                    oModel.LastName = item.SMLastName;
                    oModel.Telephone = item.SMTelephone;
                    oModel.EmailAddress = item.SMEmailAddress;
                    oModel.District = item.District;
                    oModel.Council = item.Council;
                    oModel.Troop = item.Troop;
                    int iId1 = SaveABSAMemberRecord(oModel);
                    item.ScoutMasterId = iId1;
                }
            }

            int iId = SaveABSAMemberRecord(item);

            return true;
        }

        private int SaveABSAMemberRecord(BSAMemberViewModel item)
        {
            //Connect to the Umbraco DB
            var db = new PetaPoco.Database(sConnectString);

            BSAMember oModel = new BSAMember();
            oModel.BSAMemberId = item.BSAMemberId;
            oModel.UserName = item.UserName;
            oModel.Password = item.Password;
            oModel.BSAMemberType = item.BSAMemberType;
            oModel.FirstName = item.FirstName;
            oModel.LastName = item.LastName;
            oModel.StreetAddress = item.StreetAddress;
            oModel.City = item.City;
            oModel.State = item.State;
            oModel.ZipCode = item.ZipCode;
            oModel.District = item.District;
            oModel.Council = item.Council;
            oModel.Troop = item.Troop;
            oModel.Crew = item.Crew;
            oModel.ScoutMasterId = item.ScoutMasterId;
            oModel.Telephone = item.Telephone;
            oModel.BirthDate = item.BirthDate;
            oModel.EmailAddress = item.EmailAddress;
            oModel.BackGroundCheck = item.BackGroundCheck;
            oModel.DeleteRecordFlag = false;

            if (item.BSAMemberId > 0)
            {
                db.Update(oModel);
            }
            else
            {
                db.Insert(oModel);
            }

            //Return the view with our model and comments
            return oModel.BSAMemberId;
        }

        public static List<System.Web.Mvc.SelectListItem> GetInstructorDropDown()
        {
            List<System.Web.Mvc.SelectListItem> ls = new List<System.Web.Mvc.SelectListItem>();
            BSAMemberController oController = new BSAMemberController();
            var db = new PetaPoco.Database(sConnectString);
            var lstMember = db.Query<BSAMember>("SELECT * FROM BSAMembers where BSAMemberType = @0 AND DeleteRecordFlag = @1", "Instructor", false);
            foreach (var temp in lstMember)
            {
                ls.Add(new System.Web.Mvc.SelectListItem() { Text = temp.FirstName + " " + temp.LastName, Value = temp.BSAMemberId.ToString() });
            }

            return ls;
        }

        [Route("api/Member")]
        [HttpDelete]
        [ValidSessionFilter]
        public bool DeleteABSAMember(BSAMemberViewModel item)
        {
            //Connect to the Umbraco DB
            var db = new PetaPoco.Database(sConnectString);

            BSAMember oModel = new BSAMember();
            oModel.BSAMemberId = item.BSAMemberId;
            oModel.BSAMemberType = item.BSAMemberType;
            oModel.FirstName = item.FirstName;
            oModel.LastName = item.LastName;
            oModel.StreetAddress = item.StreetAddress;
            oModel.City = item.City;
            oModel.State = item.State;
            oModel.ZipCode = item.ZipCode;
            oModel.District = item.District;
            oModel.Council = item.Council;
            oModel.Troop = item.Troop;
            oModel.Crew = item.Crew;
            oModel.Telephone = item.Telephone;
            oModel.BirthDate = item.BirthDate;
            oModel.EmailAddress = item.EmailAddress;
            oModel.ScoutMasterId = item.ScoutMasterId;
            oModel.BackGroundCheck = item.BackGroundCheck;
            oModel.DeleteRecordFlag = true;

            db.Update(oModel);

            //Return the view with our model and comments
            return true;
        }
    }
}
