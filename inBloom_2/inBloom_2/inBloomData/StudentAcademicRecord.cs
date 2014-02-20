using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace inBloom_2.inBloomData
{
    public class StudentAcademicRecord
    {
        public string schoolYear { get; set; }
        public string sessionId { get; set; }
        public string studentId { get; set; }
        public double cumulativeGradePointAverage { get; set; }
    }
}