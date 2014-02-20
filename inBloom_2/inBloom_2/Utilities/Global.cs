using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Collections;

namespace inBloom_2.Utilities
{
    public static class Global
    {
        // FOR inBloom
        public static string clientID = ConfigurationManager.AppSettings["clientID"];
        public static string clientSecret = ConfigurationManager.AppSettings["clientSecret"];
        public static string redirectUri = ConfigurationManager.AppSettings["redirectUri"];
        public static string inBloomBaseOAuth = ConfigurationManager.AppSettings["inBloomBaseOAuth"];
        public static string inBloomBaseAPI = ConfigurationManager.AppSettings["inBloomBaseAPI"];
        public static string inBloomAcceptHeader = ConfigurationManager.AppSettings["inBloomAcceptHeader"];
        public static string inBloomContentTypeHeader = ConfigurationManager.AppSettings["inBloomContentTypeHeader"];
        public static string inBloomLogoutAPI = ConfigurationManager.AppSettings["inBloomLogoutAPI"];

        public static string schoolId = "5c48047b9be981f7e91721863b1fad4d0bacd7eb_id";
        public static string sessionId = "6517902124d8f203da43818f8bb2a4bb99a976b9_id";

        //Course
        public static int course_numberOfParts = 1;
        public static string course_identificationSystem = "CSSC course code";
        public static string course_extendCouseID = "Hien A"; //ID = couseTitle +  " " + courseextendID

        public static string inBloomCourseId; //Course Created

        public static string inBloomCourseOfferingId; //Course Offering Created

        
        //Section
        public static string section_educationalEnvironment = "Classroom";
        public static string section_populationServed = "Regular Students";
        public static int section_sequenceOfCourse = 3;
        public static string sectionExtend_uniqueSectionCode = "- Sec 2"; // = courseTitle + " " + sectionExtend_uniqueSectionCode
        public static string section_mediumOfInstruction = "Technology-based instruction in classroom";

        public static string inBloomCourseSectionId; //Course Section Id


        //Teacher Association
        public static string teacherSection_classroomPosition = "Teacher of Record";
        public static string teacherId = "09ce3f961162b7f3ef689e5358f7d769c0e7c081_id"; //Linda Kim fixed

        public static string teacherSectionAssociationId; // created TeacherSectionAssociation

        public static ArrayList inBloomStudents = new ArrayList();

        //Course Transcript
        public static string courseTranscript_creditType = "Semester hour credit";
        public static int courseTranscript_credit = 2;
        public static string courseTranscript_educationOrganizationReference = "5c48047b9be981f7e91721863b1fad4d0bacd7eb_id";
        public static string courseTranscript_entityType = "courseTranscript";
        public static string courseTranscript_gradeLevelWhenTaken = "Eighth grade";
        public static string courseTranscript_courseAttemptResult = "Pass";
        public static string courseTranscript_gradeType = "Exam";

        // FOR ASSITments
        //*public static string teacherRef;
        public static string teacherRef = "90e0034ab0a3b9868ad672636ebaf546";
        public static string ASSITmentsBaseAPI = ConfigurationManager.AppSettings["ASSITmentsBaseAPI"];
        public static string ASSITmentsAPI_Helper = ConfigurationManager.AppSettings["ASSITmentsAPI_Helper"];

        //*public static string OnBehalfOf;
        public static string OnBehalfOf = "44PUCPVB2A8C6FM915OQ0KQY";

        public static string ASSITments_ContentType = "application/json";
        public static string ASSITments_Auth_WOBehalf = "partner=" + "\"" + "Hien-Ref" + "\"";
        public static string ASSITments_Auth_Behalf = "partner=" + "\"" + "Hien-Ref" + "\",onBehalfOf=" + "\"" + Global.OnBehalfOf + "\"";

        //school
        public static string ASSITments_School_NCES = "250936001503";
        //*public static string schoolRef;
        public static string schoolRef = "b4181adef4914ac8bb7d86715d7225c0";
        // class
        //* public static string classRef;
        public static string classRef = "fa02ea7fa16e0d5441c42179cfe4cfd4";

        // assingment
        //*public static string assignmentRef;
        public static string assignmentRef = "6c8d82722c75fff7b92ffc539b854ae2";
        public static string problemSetId = "148300";
    }
}