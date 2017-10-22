using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeritBadgeWebService.Models
{
    [TableName("BSAMembers")]
    [PrimaryKey("BSAMemberId", AutoIncrement = true)]
    [ExplicitColumns]
    public class BSAMember
    {
        [Column("BSAMemberId")]
//        [PrimaryKeyColumn(AutoIncrement = true)]
        public int BSAMemberId { get; set; }

        [Column("BSAMemberType")]
//        [IndexAttribute(IndexTypes.NonClustered, Name = "IX_BSAMemberType")]
        public string BSAMemberType { get; set; }

        [Column("UserName")]
//        [NullSetting(NullSetting = NullSettings.Null)]
//        [IndexAttribute(IndexTypes.NonClustered, Name = "IX_BSAMemberUserName")]
        public string UserName { get; set; }

        [Column("Password")]
//        [NullSetting(NullSetting = NullSettings.Null)]
        public string Password { get; set; }

        [Column("FirstName")]
        public string FirstName { get; set; }

        [Column("LastName")]
        public string LastName { get; set; }

        [Column("StreetAddress")]
//        [NullSetting(NullSetting = NullSettings.Null)]
        public string StreetAddress { get; set; }

        [Column("City")]
//        [NullSetting(NullSetting = NullSettings.Null)]
        public string City { get; set; }

        [Column("State")]
//        [NullSetting(NullSetting = NullSettings.Null)]
        public string State { get; set; }

        [Column("ZipCode")]
//        [NullSetting(NullSetting = NullSettings.Null)]
        public string ZipCode { get; set; }

        [Column("District")]
//        [NullSetting(NullSetting = NullSettings.Null)]
        public string District { get; set; }

        [Column("Council")]
//        [NullSetting(NullSetting = NullSettings.Null)]
        public string Council { get; set; }

        [Column("Troop")]
//        [NullSetting(NullSetting = NullSettings.Null)]
        public string Troop { get; set; }

        [Column("Crew")]
//        [NullSetting(NullSetting = NullSettings.Null)]
        public string Crew { get; set; }

        [Column("ScoutMasterId")]
//        [NullSetting(NullSetting = NullSettings.Null)]
        public int ScoutMasterId { get; set; }

        [Column("Telephone")]
//        [NullSetting(NullSetting = NullSettings.Null)]
        public string Telephone { get; set; }

        [Column("BirthDate")]
//        [NullSetting(NullSetting = NullSettings.Null)]
        public string BirthDate { get; set; }

        [Column("EmailAddress")]
//        [NullSetting(NullSetting = NullSettings.Null)]
        public string EmailAddress { get; set; }

        [Column("BackGroundCheck")]
//        [NullSetting(NullSetting = NullSettings.Null)]
        public bool BackGroundCheck { get; set; }

        [Column("DeleteRecordFlag")]
//        [NullSetting(NullSetting = NullSettings.Null)]
        public bool DeleteRecordFlag { get; set; }
    }
}