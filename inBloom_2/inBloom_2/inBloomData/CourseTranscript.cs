using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace inBloom_2.inBloomData
{
    public class CreditsEarned
    {
        public double creditConversion { get; set; }
        public string creditType { get; set; }
        public double credit { get; set; }
    }

    public class CourseTranscript
    {
        public CreditsEarned creditsEarned { get; set; }
        public string educationOrganizationReference { get; set; }
        public string studentAcademicRecordId { get; set; }
        public string finalLetterGradeEarned { get; set; }
        public string courseId { get; set; }
        public string finalNumericGradeEarned { get; set; }
        public string entityType { get; set; }
        public string gradeLevelWhenTaken { get; set; }
        public string courseAttemptResult { get; set; }
        public string studentId { get; set; }
        public string gradeType { get; set; }
    }
}