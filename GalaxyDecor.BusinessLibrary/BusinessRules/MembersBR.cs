using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxyDecor.BusinessLibrary.BusinessObjects;
using GalaxyDecor.BusinessLibrary.Data;

namespace GalaxyDecor.BusinessLibrary.BusinessRules
{
    public static class MembersBR
    {
        #region Members
        public static Collection<MembersInformation> GetAllMembers()
        {
            return MembersData.GetAllMembers();
        }

        public static MembersInformation GetSelectedMember(int MemberID)
        {
            return MembersData.GetSelectedMember(MemberID);
        }

        public static int CreateMember(MembersInformation member)
        {
            return MembersData.CreateMember(member);
        }

        public static int UpdateMember(MembersInformation member)
        {
            return MembersData.UpdateMember(member);
        }

        public static int DeleteMember(int MemberID)
        {
            return MembersData.DeleteMember(MemberID);
        }
        #endregion

        public static Collection<MembersInformation> GetAllPossibleSponsors(int memberID)
        {
            return MembersData.GetAllPossibleSponsors(memberID);
        }
    }
}
