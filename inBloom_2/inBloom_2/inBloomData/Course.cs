using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace inBloom_2.inBloomData
{
    public class Course
    {
           
        public int numberOfParts { get; set; }
        public string uniqueCourseId { get; set; }
        public string courseTitle { get; set; }
        public List<CourseCode> courseCode { get; set; }
        public string schoolId { get; set; }
    }

    public class CourseCode
    {
        public string identificationSystem { get; set; }
        public string ID { get; set; }
    }

}