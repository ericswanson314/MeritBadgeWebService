using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeritBadgeWebService.Models
{
    public class MeritBadgeEditViewModal
    {
        int m_MeritBadgeid = 0;
        //		List<HttpPostedFileBase> m_Files = new List<HttpPostedFileBase>();
        List<MeritBadgeRequirementViewModal> m_Reqs = new List<MeritBadgeRequirementViewModal>();
        int m_PictureId = 0;
        int m_MeritBadgeRequirementId = 0;
        string m_Name;
        string m_Description;
        string m_NewRequirement;
        string m_meritbadgeimageurl;
        string m_MeritBadgeImageTitle;
        string m_MeritBadgeUrl;

        public MeritBadgeEditViewModal()
        {
            Files = new List<HttpPostedFileBase>();
        }

        public int MeritBadgeid
        {
            get { return m_MeritBadgeid; }
            set { m_MeritBadgeid = value; }
        }

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        public string Description
        {
            get { return m_Description; }
            set { m_Description = value; }
        }

        public int PictureID
        {
            get { return m_PictureId; }
            set { m_PictureId = value; }
        }

        public string MeritBadgeImageUrl
        {
            get { return m_meritbadgeimageurl; }
            set { m_meritbadgeimageurl = value; }
        }

        public string MeritBadgeImageTitle
        {
            get { return m_MeritBadgeImageTitle; }
            set { m_MeritBadgeImageTitle = value; }
        }

        public List<MeritBadgeRequirementViewModal> Requirements
        {
            get { return m_Reqs; }
            set { m_Reqs = value; }
        }

        public string newRequirement
        {
            get { return m_NewRequirement; }
            set { m_NewRequirement = value; }
        }

        public int MeritBadgeRequirementId
        {
            get { return m_MeritBadgeRequirementId; }
            set { m_MeritBadgeRequirementId = value; }
        }

        public List<HttpPostedFileBase> Files { get; set; }

        public string MeritBadgeUrl
        {
            get { return m_MeritBadgeUrl; }
            set { m_MeritBadgeUrl = value; }
        }
    }
}