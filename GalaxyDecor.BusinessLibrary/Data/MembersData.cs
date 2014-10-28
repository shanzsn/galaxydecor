using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxyDecor.BusinessLibrary.BusinessObjects;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace GalaxyDecor.BusinessLibrary.Data
{
    public static class MembersData
    {
        #region Categories
        public static int CreateMember(MembersInformation member)
        {
            int MemberShipNo = 0;

            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.Create(DataSettings.ConnectionString);
            DbCommand command = db.GetStoredProcCommand("MemberAdd");
            
            SetParameters(out db, factory, command, member, true);
            
            // Code to execute goes here.
            db.ExecuteNonQuery(command);

            MemberShipNo = (int)db.GetParameterValue(command, "MemberShipNo");

            command = null;
            db = null;

            return MemberShipNo;
        }

        public static int UpdateMember(MembersInformation member)
        {
            if (member != null)
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.Create(DataSettings.ConnectionString);
                DbCommand command = db.GetStoredProcCommand("MembersUpdate");

                SetParameters(out db, factory, command, member, true);

                // Code to execute goes here.
                db.ExecuteNonQuery(command);

                command = null;
                db = null;
            }

            return -1;
        }

        public static Collection<MembersInformation> GetAllMembers()
        {
            Collection<MembersInformation> members = new Collection<MembersInformation>();
            MembersInformation member = null;

            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.Create(DataSettings.ConnectionString);
            DbCommand command = db.GetStoredProcCommand("GetAllMembersInformation");

            DataSet dataSet = null;

            // Code to execute goes here.
            dataSet = db.ExecuteDataSet(command);

            foreach (DataRow rw in dataSet.Tables[0].Rows)
            {
                member = SetMembersProperty(rw);

                members.Add(member);
            }

            return members;
        }

        internal static MembersInformation GetSelectedMember(int MemberID)
        {
            MembersInformation member = null;

            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.Create(DataSettings.ConnectionString);
            DbCommand command = db.GetStoredProcCommand("GetSelectedMember");

            db.AddInParameter(command, "MembershipNo", DbType.Int32, MemberID);

            DataSet dataSet = null;

            // Code to execute goes here.
            dataSet = db.ExecuteDataSet(command);

            foreach (DataRow rw in dataSet.Tables[0].Rows)
            {
                member = SetMembersProperty(rw);
            }

            return member;
        }
        
        public static int DeleteMember(int memberID)
        {
            if (memberID != 0)
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.Create(DataSettings.ConnectionString);
                DbCommand command = db.GetStoredProcCommand("MemberDelete");

                db.AddInParameter(command, "MemberID", DbType.Int32, memberID);

                // Code to execute goes here.
                db.ExecuteNonQuery(command);

                command = null;
                db = null;
            }

            return -1;
        }

        private static MembersInformation SetMembersProperty(DataRow rw)
        {
            MembersInformation member = new MembersInformation();

            member.ApplicantSigned = rw.IsNull("ApplicantSigned") ? false : Convert.ToBoolean(rw["ApplicantSigned"]);
            if (!rw.IsNull("AuthorisedSignatoryCompletionDate")) { member.AuthorisedSignatoryCompletionDate = Convert.ToDateTime(rw["AuthorisedSignatoryCompletionDate"]).Date; }
            member.DOB = rw.IsNull("DOB") ? DateTime.Now : Convert.ToDateTime(rw["DOB"]).Date;
            member.DocumentCheckedBy = rw.IsNull("DocumentCheckedBy") ? string.Empty : Convert.ToString(rw["DocumentCheckedBy"]);
            member.IsAuthorisedSignatoryComplete = rw.IsNull("IsAuthorisedSignatoryComplete") ? false : Convert.ToBoolean(rw["IsAuthorisedSignatoryComplete"]);
            member.JoiningDate = rw.IsNull("JoiningDate") ? DateTime.Now.Date : Convert.ToDateTime(rw["JoiningDate"]).Date;
            member.MembershipFee = rw.IsNull("MembershipFee") ? false : Convert.ToBoolean(rw["MembershipFee"]);
            member.MembershipNo = rw.IsNull("MembershipNo") ? 0 : Convert.ToInt32(rw["MembershipNo"]);
            member.MotherTounge = rw.IsNull("MotherTounge") ? string.Empty : Convert.ToString(rw["MotherTounge"]);
            member.PassportSizePhoto = rw.IsNull("PassportSizePhoto") ? false : Convert.ToBoolean(rw["PassportSizePhoto"]);
            member.PermenantDistrict = rw.IsNull("PermenantDistrict") ? string.Empty : Convert.ToString(rw["PermenantDistrict"]);
            member.PermenantPinCode = rw.IsNull("PermenantPinCode") ? string.Empty : Convert.ToString(rw["PermenantPinCode"]);
            member.PermenantState = rw.IsNull("PermenantState") ? string.Empty : Convert.ToString(rw["PermenantState"]);
            member.PersonalHobby = rw.IsNull("PersonalHobby") ? string.Empty : Convert.ToString(rw["PersonalHobby"]);
            member.PersonalMobile = rw.IsNull("PersonalMobile") ? string.Empty : Convert.ToString(rw["PersonalMobile"]);
            member.PersonalPhone = rw.IsNull("PersonalPhone") ? string.Empty : Convert.ToString(rw["PersonalPhone"]);
            member.PersonName = rw.IsNull("PersonName") ? string.Empty : Convert.ToString(rw["PersonName"]);
            member.PhotoIDProof = rw.IsNull("PhotoIDProof") ? false : Convert.ToBoolean(rw["PhotoIDProof"]);
            member.ResidentialAddress = rw.IsNull("ResidentialAddress") ? string.Empty : Convert.ToString(rw["ResidentialAddress"]);
            member.ResidentialCity = rw.IsNull("ResidentialCity") ? string.Empty : Convert.ToString(rw["ResidentialCity"]);
            member.ResidentialPinCode = rw.IsNull("ResidentialPinCode") ? string.Empty : Convert.ToString(rw["ResidentialPinCode"]);
            member.ResidentialProof = rw.IsNull("ResidentialProof") ? false : Convert.ToBoolean(rw["ResidentialProof"]);
            member.ResidentialState = rw.IsNull("ResidentialState") ? string.Empty : Convert.ToString(rw["ResidentialState"]);
            member.ResidentialTaluka = rw.IsNull("ResidentialTaluka") ? string.Empty : Convert.ToString(rw["ResidentialTaluka"]);
            member.SponsorshipNo = rw.IsNull("SponsorshipNo") ? 0 : Convert.ToInt32(rw["SponsorshipNo"]);

            return member;
        }

        private static void SetParameters(out Database db, DatabaseProviderFactory factory, DbCommand command, MembersInformation member, bool isUpdate)
        {
            db = factory.Create(DataSettings.ConnectionString);

            if (isUpdate)
            { db.AddInParameter(command, "MemberShipNo", DbType.Int32, member.MembershipNo); }
            else
            { db.AddOutParameter(command, "MemberShipNo", DbType.Int32, 0); }

            db.AddInParameter(command, "ApplicantSigned", DbType.Boolean, member.ApplicantSigned);
            db.AddInParameter(command, "AuthorisedSignatoryCompletionDate", DbType.Date, member.AuthorisedSignatoryCompletionDate);
            db.AddInParameter(command, "DOB", DbType.Date, member.DOB);
            db.AddInParameter(command, "DocumentCheckedBy", DbType.String, member.DocumentCheckedBy);
            db.AddInParameter(command, "JoiningDate", DbType.Date, member.JoiningDate);
            db.AddInParameter(command, "MembershipFee", DbType.Boolean, member.MembershipFee);
            db.AddInParameter(command, "MotherTounge", DbType.String, member.MotherTounge);
            db.AddInParameter(command, "PassportSizePhoto", DbType.Boolean, member.PassportSizePhoto);
            db.AddInParameter(command, "PermenantPinCode", DbType.String, member.PermenantPinCode);
            db.AddInParameter(command, "PermenantState", DbType.String, member.PermenantState);
            db.AddInParameter(command, "PersonalMobile", DbType.String, member.PersonalMobile);
            db.AddInParameter(command, "PersonName", DbType.String, member.PersonName);
            db.AddInParameter(command, "PersonalPhone", DbType.String, member.PersonalPhone);
            db.AddInParameter(command, "PersonalHobby", DbType.String, member.PersonalHobby);
            db.AddInParameter(command, "PhotoIDProof", DbType.Boolean, member.PhotoIDProof);
            db.AddInParameter(command, "ResidentialAddress", DbType.String, member.ResidentialAddress);
            db.AddInParameter(command, "ResidentialCity", DbType.String, member.ResidentialCity);
            db.AddInParameter(command, "ResidentialPinCode", DbType.String, member.ResidentialPinCode);
            db.AddInParameter(command, "ResidentialProof", DbType.Boolean, member.ResidentialProof);
            db.AddInParameter(command, "ResidentialState", DbType.String, member.ResidentialState);
            db.AddInParameter(command, "ResidentialTaluka", DbType.String, member.ResidentialTaluka);
            db.AddInParameter(command, "SponsorshipNo", DbType.Int32, member.SponsorshipNo);
        }

        public static Collection<MembersInformation> GetAllPossibleSponsors(int MemberID)
        {
            Collection<MembersInformation> members = new Collection<MembersInformation>();
            MembersInformation member = null;

            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.Create(DataSettings.ConnectionString);
            DbCommand command = db.GetStoredProcCommand("GetAllPossibleSponsors");

            DataSet dataSet = null;

            db.AddInParameter(command, "MemberShipNo", DbType.Int32, MemberID); 

            // Code to execute goes here.
            dataSet = db.ExecuteDataSet(command);

            foreach (DataRow rw in dataSet.Tables[0].Rows)
            {
                member = SetSponsorsProperty(rw);

                members.Add(member);
            }

            return members;
        }

        private static MembersInformation SetSponsorsProperty(DataRow rw)
        {
            MembersInformation member = new MembersInformation();

            member.MembershipNo = rw.IsNull("MembershipNo") ? 0 : Convert.ToInt32(rw["MembershipNo"]);
            member.PersonName = rw.IsNull("PersonName") ? string.Empty : Convert.ToString(rw["PersonName"]);
            member.PersonalMobile = rw.IsNull("PersonalMobile") ? string.Empty : Convert.ToString(rw["PersonalMobile"]);
            member.PermenantDistrict = rw.IsNull("PermenantDistrict") ? string.Empty : Convert.ToString(rw["PermenantDistrict"]);
            member.ResidentialAddress = rw.IsNull("ResidentialAddress") ? string.Empty : Convert.ToString(rw["ResidentialAddress"]);

            return member;
        }
        #endregion
    }
}
