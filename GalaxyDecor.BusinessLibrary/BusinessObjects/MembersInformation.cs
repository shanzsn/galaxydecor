
namespace GalaxyDecor.BusinessLibrary.BusinessObjects
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class MembersInformation
    {
        private int _MembershipNo;
        private int _SponsorshipNo;
        private string _PersonName;
        private DateTime _JoiningDate;
        private DateTime _DOB;
        private string _PersonalPhone;
        private string _PersonalMobile;
        private string _MotherTounge;
        private string _PersonalHobby;
        private string _PermenantDistrict;
        private string _PermenantPinCode;
        private string _PermenantState;
        private string _ResidentialAddress;
        private string _ResidentialTaluka;
        private string _ResidentialCity;
        private string _ResidentialState;
        private string _ResidentialPinCode;
        private bool _PassportSizePhoto;
        private bool _PhotoIDProof;
        private bool _ResidentialProof;
        private bool _MembershipFee;
        private bool _ApplicantSigned;
        private string _DocumentCheckedBy;
        private bool _IsAuthorisedSignatoryComplete;

        public int MembershipNo 
        {
            get { return _MembershipNo; }
            set { _MembershipNo = value; } 
        }

        public int SponsorshipNo 
        {
            get { return _SponsorshipNo;  }
            set { _SponsorshipNo = value; } 
        }

        [Required]
        public string PersonName
        {
            get { return _PersonName; }
            set { _PersonName = value; }
        }

        [Required]
        public DateTime JoiningDate
        {
            get { return _JoiningDate; }
            set { _JoiningDate = value; }
        }

        [Required]
        public DateTime DOB
        {
            get { return _DOB; }
            set { _DOB = value; }
        }

        public string PersonalPhone
        {
            get { return _PersonalPhone; }
            set { _PersonalPhone = value; }
        }

        [Required]
        public string PersonalMobile
        {
            get { return _PersonalMobile; }
            set { _PersonalMobile = value; }
        }

        public string MotherTounge
        {
            get { return _MotherTounge; }
            set { _MotherTounge = value; }
        }

        public string PersonalHobby
        {
            get { return _PersonalHobby; }
            set { _PersonalHobby = value; }
        }

        public string PermenantDistrict
        {
            get { return _PermenantDistrict; }
            set { _PermenantDistrict = value; }
        }

        public string PermenantPinCode
        {
            get { return _PermenantPinCode; }
            set { _PermenantPinCode = value; }
        }
        
        public string PermenantState
        {
            get { return _PermenantState; }
            set { _PermenantState = value; }
        }

        public string ResidentialAddress
        {
            get { return _ResidentialAddress; }
            set { _ResidentialAddress = value; }
        }

        public string ResidentialTaluka
        {
            get { return _ResidentialTaluka; }
            set { _ResidentialTaluka = value; }
        }

        public string ResidentialCity
        {
            get { return _ResidentialCity; }
            set { _ResidentialCity = value; }
        }

        public string ResidentialState
        {
            get { return _ResidentialState; }
            set { _ResidentialState = value; }
        }

        public string ResidentialPinCode
        {
            get { return _ResidentialPinCode; }
            set { _ResidentialPinCode = value; }
        }

        public bool PassportSizePhoto
        {
            get { return _PassportSizePhoto; }
            set { _PassportSizePhoto = value; }
        }

        public bool PhotoIDProof
        {
            get { return _PhotoIDProof; }
            set { _PhotoIDProof = value; }
        }

        public bool ResidentialProof
        {
            get { return _ResidentialProof; }
            set { _ResidentialProof = value; }
        }

        public bool MembershipFee
        {
            get { return _MembershipFee; }
            set { _MembershipFee = value; }
        }

        public bool ApplicantSigned
        {
            get { return _ApplicantSigned; }
            set { _ApplicantSigned = value; }
        }

        public string DocumentCheckedBy
        {
            get { return _DocumentCheckedBy; }
            set { _DocumentCheckedBy = value; }
        }
        
        public bool IsAuthorisedSignatoryComplete
        {
            get { return _IsAuthorisedSignatoryComplete; }
            set { _IsAuthorisedSignatoryComplete = value; }
        }

        public Nullable<DateTime> AuthorisedSignatoryCompletionDate
        {
            get;
            set;
        }
    }
}
