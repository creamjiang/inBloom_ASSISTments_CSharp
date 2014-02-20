using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace inBloom_2.Mapping
{
    public class StudentInfo
    {
        //inBloom
        public string Id { get; set; }
        public string StudentUniqueStateId { get; set; }
        public string Email { get; set; }
        public string GenerationCodeSuffix { get; set; }
        public string LastSurname { get; set; }
        public string FirstName { get; set; }
        public string StudentSectionAssociation { get; set; }
        public string StudentAcademicRecordId { get; set; }
        public string CourseTranscriptId { get; set; }

        //ASSITments
        public string UserType { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public string TimeZone { get; set; }
        public string RegistrationCode { get; set; }
        public string StudentRef { get; set; }
        public string Score { get; set; }
    }
}