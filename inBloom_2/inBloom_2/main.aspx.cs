using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using System.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using inBloom_2.Utilities;
using inBloom_2.inBloomApiHelper;
using inBloom_2.inBloomData;
using inBloom_2.Mapping;
using inBloom_2.AssitmentsData;
using RestSharp;

namespace inBloom_2
{
    public partial class main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblinBloomCreateCoureError.Visible = false;
            this.lblinBloomCreateCourseOK.Visible = false;

            this.lblinBloomCreateCourseOfferingeOK.Visible = false;
            this.lblinBloomCreateCourseOfferingError.Visible = false;

            this.lblinBloomCreateCourseSectionOK.Visible = false;
            this.lblinBloomCreateCourseSectionError.Visible = false;

            this.lblinBloomCreateTeacherSectionError.Visible = false;
            this.lblinBloomCreateTeacherSectionOK.Visible = false;

            this.lblinBloomGetStudentError.Visible = false;
            this.lblinBloomGetStudentOK.Visible = false;

            this.lblASSITmentsCreateTeacherError.Visible = false;
            this.lblASSITmentsCreateTeacherOK.Visible = false;
            this.view_InBloomStudents.Visible = false;

            this.lblASSIT_CreateClassError.Visible = false;
            this.lblASSIT_CreateClassOK.Visible = false;

            this.lblASSIT_SchoolError.Visible = false;
            this.lblASSIT_SchoolOK.Visible = false;

            this.lblASSIT_AssignmentError.Visible = false;
            this.lblASSIT_AssignmentOK.Visible = false;

            this.lblinBloomEnrollOK.Visible = false;

            this.lblASSIT_UpdateOK.Visible = false;
            this.lblASSIT_UpdateError.Visible = false;

            this.lblASSIT_TransferStudentOK.Visible = false;
            this.lblASSIT_TransferStudentError.Visible = false;

            this.lblASSITments_EnrollOK.Visible = false;
            this.lblASSITments_EnrollError.Visible = false;
        }

        protected void inBloom_CreateCourse(object sender, EventArgs e)
        {
            inBloomData.Course aCourse = new Course();
            aCourse.numberOfParts = Global.course_numberOfParts;
            aCourse.courseTitle = this.txtCourseTitle.Text;
            aCourse.uniqueCourseId = this.txtCourseTitle.Text;

            inBloomData.CourseCode aCourseCode = new inBloomData.CourseCode();
            aCourseCode.identificationSystem = Global.course_identificationSystem;
            aCourseCode.ID = this.txtCourseTitle.Text + " " + Global.course_extendCouseID; //"8th Grade General Math Hien 1";
            
            //add courseCode to Course
            aCourse.courseCode = new List<inBloomData.CourseCode>();
            aCourse.courseCode.Add(aCourseCode);

            aCourse.schoolId = Global.schoolId;

            string jPostCourse = JsonConvert.SerializeObject(aCourse);
           
            string newCourseId = "";
            
            string apiEndPoint = string.Format("{0}/courses",Global.inBloomBaseAPI);
            try
            {
                WebResponse myWebResponse = ApiClient.doPOST(apiEndPoint, Session["access_token"].ToString(), jPostCourse);
                for (int i = 0; i < myWebResponse.Headers.Count; ++i)
                {
                    if (myWebResponse.Headers.Keys[i].ToString() == "Location")
                    {
                        newCourseId = myWebResponse.Headers[i].ToString();
                    }
                }
                newCourseId = newCourseId.Substring(newCourseId.Length - 43);
            }
            catch (Exception ex)
            {
                this.lblinBloomCreateCoureError.Visible = true;
                this.lblinBloomCreateCoureError.Text += " " + ex.Message;
                //throw ex;
            }
            Global.inBloomCourseId = newCourseId;
            this.lblinBloomCreateCourseOK.Visible = true;
        }


        protected void inBloom_CreateCourseOffering(object sender, EventArgs e)
        {
            inBloomData.CourseOffering aCourseOffering = new inBloomData.CourseOffering();
            
            // INIT DATA
            aCourseOffering.localCourseCode = this.txtCourseTitle.Text + " " + Global.course_extendCouseID; //"8th Grade General Math Hien 1";
            aCourseOffering.sessionId = Global.sessionId;
            if (Global.inBloomCourseId != "")
                aCourseOffering.courseId = Global.inBloomCourseId;
            else
            {
                this.lblinBloomCreateCourseOfferingError.Visible = true;
                return;
            }
            aCourseOffering.schoolId = Global.schoolId;

            string jPostCourse = JsonConvert.SerializeObject(aCourseOffering);
            string newCourseOfferingId = "";
            string apiEndPoint = string.Format("{0}/courseOfferings",Global.inBloomBaseAPI);
            try
            {
                WebResponse myWebResponse = ApiClient.doPOST(apiEndPoint, Session["access_token"].ToString(), jPostCourse);
                for (int i = 0; i < myWebResponse.Headers.Count; ++i)
                {
                    if (myWebResponse.Headers.Keys[i].ToString() == "Location")
                    {
                        newCourseOfferingId = myWebResponse.Headers[i].ToString();
                    }
                }
                newCourseOfferingId = newCourseOfferingId.Substring(newCourseOfferingId.Length - 43);
            }
            catch (Exception ex)
            {
                this.lblinBloomCreateCourseOfferingError.Visible = true;
                this.lblinBloomCreateCourseOfferingError.Text += " " + ex.Message;
                //throw ex;
            }
            Global.inBloomCourseOfferingId = newCourseOfferingId;
            this.lblinBloomCreateCourseOfferingeOK.Visible = true;
        }

        protected void inBloom_CreateCourseSection(object sender, EventArgs e)
        {
            inBloomData.Section aSection = new Section();

            // INIT DATA
            aSection.educationalEnvironment = Global.section_educationalEnvironment;
            aSection.sessionId = Global.sessionId;
            if (Global.inBloomCourseOfferingId != "")
                aSection.courseOfferingId = Global.inBloomCourseOfferingId;
            else
            {
                this.lblinBloomCreateCourseSectionError.Visible = true;
                return;
            }
            aSection.populationServed = Global.section_populationServed;
            aSection.sequenceOfCourse = Global.section_sequenceOfCourse;
            aSection.uniqueSectionCode = this.txtCourseTitle.Text + " " + Global.sectionExtend_uniqueSectionCode; //"8th Grade General Math Hien - Sec 1";
            aSection.mediumOfInstruction = Global.section_mediumOfInstruction;
            aSection.schoolId = Global.schoolId;

            string jPostCourse = JsonConvert.SerializeObject(aSection);
            string newSectionId = "";
            string apiEndPoint = string.Format("{0}/sections", Global.inBloomBaseAPI);
            try
            {
                WebResponse myWebResponse = ApiClient.doPOST(apiEndPoint, Session["access_token"].ToString(), jPostCourse);
                for (int i = 0; i < myWebResponse.Headers.Count; ++i)
                {
                    if (myWebResponse.Headers.Keys[i].ToString() == "Location")
                    {
                        newSectionId = myWebResponse.Headers[i].ToString();
                    }
                }
                newSectionId = newSectionId.Substring(newSectionId.Length - 43);
            }
            catch (Exception ex)
            {
                this.lblinBloomCreateCourseSectionError.Visible = true;
                this.lblinBloomCreateCourseSectionError.Text += " " + ex.Message;
                //throw ex;
            }
            Global.inBloomCourseSectionId = newSectionId;
            this.lblinBloomCreateCourseSectionOK.Visible = true;
        }

        protected void inBloom_CreateTeacherSection(object sender, EventArgs e)
        {
            inBloomData.TeacherAssociation aTA = new TeacherAssociation();

            //INIT DATA
            aTA.sectionId = Global.inBloomCourseSectionId;
            aTA.teacherId = Global.teacherId;
            aTA.classroomPosition = Global.teacherSection_classroomPosition;

            string jPostCourse = JsonConvert.SerializeObject(aTA);
            string newTSA = "";
            string apiEndPoint = string.Format("{0}/teacherSectionAssociations",Global.inBloomBaseAPI);
            try
            {
                WebResponse myWebResponse = ApiClient.doPOST(apiEndPoint, Session["access_token"].ToString(), jPostCourse);
                for (int i = 0; i < myWebResponse.Headers.Count; ++i)
                {
                    if (myWebResponse.Headers.Keys[i].ToString() == "Location")
                    {
                        newTSA = myWebResponse.Headers[i].ToString();
                    }
                }
                newTSA = newTSA.Substring(newTSA.Length - 86);
            }
            catch (Exception ex)
            {
                this.lblinBloomCreateTeacherSectionError.Visible = true;
                this.lblinBloomCreateTeacherSectionError.Text += " " + ex.Message;
                //throw ex;
            }
            Global.teacherSectionAssociationId = newTSA;
            this.lblinBloomCreateTeacherSectionOK.Visible = true;
            
        }

        protected void inBloom_SwithToTeacher(object sender, EventArgs e)
        {
            WebClient restClient = new WebClient();
            restClient.Headers.Add("Accept", Global.inBloomAcceptHeader);
            restClient.Headers.Add("Content-Type", Global.inBloomContentTypeHeader);
            string logoutURL = String.Format("{0}",Global.inBloomLogoutAPI);
            string result = restClient.DownloadString(logoutURL);

            //delete previous login
            Session.Remove("access_token");

            Response.Redirect("default.aspx"); 
        }

        protected void inBloom_GetStudents(object sender, EventArgs e)
        {
            string apiStudents = string.Format("{0}/students/",Global.inBloomBaseAPI);
            ApiResponse requestStudents = ApiClient.Request(apiStudents, Session["access_token"].ToString());
            if (requestStudents.ResponseObject != null)
            {
                JArray arrStudentsInfo = requestStudents.ResponseObject;
                for (int i = 0; i < arrStudentsInfo.Count; i++)
                {
                    // remove 2 incorrectly created students
                    if ((arrStudentsInfo[i]["id"].ToString() != "37f885c7ace31c6b304dc18b8f59f4730f84f8f0_id") && 
                        (arrStudentsInfo[i]["id"].ToString() != "bffe1b5f6cd6ee6217f426bbd0473c1434617184_id"))
                    {
                        StudentInfo aStudentInfo = new StudentInfo();
                        aStudentInfo.Id = arrStudentsInfo[i]["id"].ToString();
                        aStudentInfo.StudentUniqueStateId = arrStudentsInfo[i]["studentUniqueStateId"].ToString();
                        if (arrStudentsInfo[i]["electronicMail"].Count() > 0)
                        {
                            aStudentInfo.Email = arrStudentsInfo[i]["electronicMail"][0]["emailAddress"].ToString();
                        }
                        else
                        {
                            aStudentInfo.Email = "junk" + i.ToString() + "@junk.com";
                        }
                        if (arrStudentsInfo[i]["name"]["generationCodeSuffix"] != null)
                            aStudentInfo.GenerationCodeSuffix = arrStudentsInfo[i]["name"]["generationCodeSuffix"].ToString();
                        else
                            aStudentInfo.GenerationCodeSuffix = "";

                        aStudentInfo.FirstName = arrStudentsInfo[i]["name"]["firstName"].ToString();
                        aStudentInfo.LastSurname = arrStudentsInfo[i]["name"]["lastSurname"].ToString();

                        aStudentInfo.UserType = "principal";
                        aStudentInfo.Username = aStudentInfo.FirstName + "." + aStudentInfo.LastSurname; //+ "." + i.ToString();
                        aStudentInfo.Password = "APIpw1";
                        aStudentInfo.DisplayName = aStudentInfo.GenerationCodeSuffix + " " + aStudentInfo.FirstName + " " + aStudentInfo.LastSurname;
                        aStudentInfo.TimeZone = "GMT-4";
                        aStudentInfo.RegistrationCode = "HIEN-API-STUDENT";
                        aStudentInfo.Score = "0"; // for patching, updating score
                        Global.inBloomStudents.Add(aStudentInfo);
                    }
                }
                this.lblinBloomGetStudentOK.Text += " " + Global.inBloomStudents.Count + " " + "inBloom Students!";
                this.lblinBloomGetStudentOK.Visible = true;
                this.view_InBloomStudents.Visible = true;
            }
        }


        protected void inBloom_ViewGetStudents(object sender, EventArgs e)
        {
        }

        protected void inBloom_SwithToAdmin(object sender, EventArgs e)
        {
            WebClient restClient = new WebClient();
            restClient.Headers.Add("Accept", Global.inBloomAcceptHeader);
            restClient.Headers.Add("Content-Type", Global.inBloomContentTypeHeader);
            string logoutURL = String.Format("{0}", Global.inBloomLogoutAPI);
            string result = restClient.DownloadString(logoutURL);

            //delete previous login
            Session.Remove("access_token");

            Response.Redirect("default.aspx"); 
        }

        protected void inBloom_CreateStudentAssociation()
        {
            for (int i = 0; i < Global.inBloomStudents.Count; i++)
            {
                StudentInfo aStudentInfo = (StudentInfo)Global.inBloomStudents[i];

                StudentAssociation aSA = new StudentAssociation();
                aSA.sectionId = Global.inBloomCourseSectionId.ToString();
                aSA.studentId = aStudentInfo.Id;
                aSA.beginDate = "2011-09-01";


                string jPostCourse = JsonConvert.SerializeObject(aSA);
                string apiEndPoint = string.Format("{0}/studentSectionAssociations",Global.inBloomBaseAPI);
                try
                {
                    WebResponse myWebResponse = ApiClient.doPOST(apiEndPoint, Session["access_token"].ToString(), jPostCourse);
                }
                catch (Exception ex)
                {
                   
                    throw ex;
                    
                }
            }
        }


        protected void inBloom_CreateStudentAcademicRecord()
        {
            for (int i = 0; i < Global.inBloomStudents.Count; i++)
            {
                StudentInfo aStudentInfo = (StudentInfo)Global.inBloomStudents[i];
                inBloomData.StudentAcademicRecord aSAR = new StudentAcademicRecord();
                RandomGPA random = new RandomGPA();
                aSAR.schoolYear = "2007-2008";
                aSAR.sessionId = Global.sessionId.ToString();
                aSAR.studentId = aStudentInfo.Id;
                aSAR.cumulativeGradePointAverage = random.doRandomGPA();

                string jPostCourse = JsonConvert.SerializeObject(aSAR);
                string newTA = "";
                string apiEndPoint = string.Format("{0}/studentAcademicRecords",Global.inBloomBaseAPI);
                try
                {
                    WebResponse myWebResponse = ApiClient.doPOST(apiEndPoint, Session["access_token"].ToString(), jPostCourse);
                    for (int j = 0; j < myWebResponse.Headers.Count; ++j)
                    {
                        if (myWebResponse.Headers.Keys[j].ToString() == "Location")
                        {
                            newTA = myWebResponse.Headers[j].ToString();
                        }
                    }
                    newTA = newTA.Substring(newTA.Length - 86);
                }
                catch (Exception ex)
                {
                    int j = i;
                    throw ex;
                    //throw new (j.ToString(),ex);
                }
                aStudentInfo.StudentAcademicRecordId = newTA;
                Global.inBloomStudents[i] = aStudentInfo;
            }
        }

        protected void inBloom_CreateTranscript() //Create 0 transcript
        {
            for (int i = 0; i < Global.inBloomStudents.Count; i++)
            {

                StudentInfo aStudentInfo = (StudentInfo)Global.inBloomStudents[i];
                inBloomData.CourseTranscript aSAR = new CourseTranscript();
                aSAR.creditsEarned = new inBloomData.CreditsEarned();
                aSAR.creditsEarned.creditConversion = 0.0;
                aSAR.creditsEarned.creditType = Global.courseTranscript_creditType;
                aSAR.creditsEarned.credit = Global.courseTranscript_credit;

                aSAR.educationOrganizationReference = Global.courseTranscript_educationOrganizationReference;
                aSAR.finalLetterGradeEarned = "A";
                aSAR.courseId = Global.inBloomCourseId;
                aSAR.entityType = Global.courseTranscript_entityType;
                aSAR.gradeLevelWhenTaken = Global.courseTranscript_gradeLevelWhenTaken;
                aSAR.courseAttemptResult = Global.courseTranscript_courseAttemptResult;
                aSAR.studentId = aStudentInfo.Id;
                aSAR.gradeType = Global.courseTranscript_gradeType;
                aSAR.studentAcademicRecordId = aStudentInfo.StudentAcademicRecordId;
                aSAR.finalNumericGradeEarned = "0";

                string jPostCourse = JsonConvert.SerializeObject(aSAR);
                string apiEndPoint = string.Format("{0}/courseTranscripts",Global.inBloomBaseAPI);
                string newCourseTranscript = "";
                try
                {

                    WebResponse myWebResponse = ApiClient.doPOST(apiEndPoint, Session["access_token"].ToString(), jPostCourse);
                    for (int j = 0; j < myWebResponse.Headers.Count; ++j)
                    {
                        if (myWebResponse.Headers.Keys[j].ToString() == "Location")
                        {
                            newCourseTranscript = myWebResponse.Headers[j].ToString();
                        }
                    }
                    newCourseTranscript = newCourseTranscript.Substring(newCourseTranscript.Length - 43);
                }
                catch (Exception ex)
                {
                    int j = i;
                    throw ex;
                }
                aStudentInfo.CourseTranscriptId = newCourseTranscript;
                Global.inBloomStudents[i] = aStudentInfo;
            }

        }

        protected void inBloom_EnrollStudentSection(object sender, EventArgs e)
        {
            inBloom_CreateStudentAssociation();
            inBloom_CreateStudentAcademicRecord();
            inBloom_CreateTranscript();
            this.lblinBloomEnrollOK.Visible = true;
        }



        protected Teacher ASSITments_GetInBloomCurrentTeacher()
        {
            AssitmentsData.Teacher retTeacher = new Teacher();

            string apiTeachers = string.Format("{0}/teachers/{1}", Global.inBloomBaseAPI,Global.teacherId);
            ApiResponse requestTeacher = ApiClient.Request(apiTeachers, Session["access_token"].ToString());
            if (requestTeacher.ResponseObject != null)
            {
                JArray userInfo = requestTeacher.ResponseObject;
                retTeacher.userType = "principal";
                retTeacher.username = userInfo[0]["staffUniqueStateId"].ToString() + "A";
                retTeacher.password = "APIpw1";
                retTeacher.email = userInfo[0]["electronicMail"][0]["emailAddress"].ToString();
                retTeacher.firstName = userInfo[0]["name"]["firstName"].ToString();
                retTeacher.lastName = userInfo[0]["name"]["lastSurname"].ToString();
                retTeacher.displayName = userInfo[0]["name"]["personalTitlePrefix"].ToString() + " " + retTeacher.firstName + " " + retTeacher.lastName;
                retTeacher.timeZone = "GMT-4";
                retTeacher.registrationCode = " ";
            }
            return retTeacher;
        }

        protected void ASSITments_LinkUser() 
        {
            string retStr = "";
            WebClient restClient = new WebClient();
            string linkUserURL = string.Format("{1}/link_user?partner=Hien-Ref&user={0}&on_success=http://localhost:8380/ASSITmentsController/linkUser.aspx&on_failure=http://localhost:8380/onError.aspx", Global.teacherRef,Global.ASSITmentsAPI_Helper);
            retStr = restClient.DownloadString(linkUserURL);
        }
        
        protected void ASSITments_CreateTeacher(object sender, EventArgs e)
        {
            AssitmentsData.Teacher teacher = ASSITments_GetInBloomCurrentTeacher();

            string retStr = "";
            WebClient restClient = new WebClient();
            restClient.Headers.Add("Content-Type", Global.ASSITments_ContentType);
            restClient.Headers.Add("assistments-auth", Global.ASSITments_Auth_WOBehalf);
            string createUserURL = String.Format("{0}/user",Global.ASSITmentsBaseAPI);
            string postData = "{" + "\"" + "userType" + "\"" + ":" + "\"" + teacher.userType + "\"" + "," +
                                    "\"" + "username" + "\"" + ":" + "\"" + teacher.username + "\"" + "," +
                                    "\"" + "password" + "\"" + ":" + "\"" + teacher.password + "\"" + "," +
                                    "\"" + "email" + "\"" + ":" + "\"" + teacher.email + "\"" + "," +
                                    "\"" + "firstName" + "\"" + ":" + "\"" + teacher.firstName + "\"" + "," +
                                    "\"" + "lastName" + "\"" + ":" + "\"" + teacher.lastName + "\"" + "," +
                                    "\"" + "displayName" + "\"" + ":" + "\"" + teacher.displayName + "\"" + "," +
                                    "\"" + "timeZone" + "\"" + ":" + "\"" + teacher.timeZone + "\"" + "," +
                                    "\"" + "registrationCode" + "\"" + ":" + "\"" + teacher.registrationCode + "\"" + "}";
            byte[] byteArray = Encoding.ASCII.GetBytes(postData);
            byte[] byteResult = restClient.UploadData(createUserURL, "POST", byteArray);
            retStr = Encoding.ASCII.GetString(byteResult);

            JObject response = JObject.Parse(retStr);
            string teacher_ref = response["user"].ToString();
            Global.teacherRef = teacher_ref;
            this.lblASSITmentsCreateTeacherOK.Visible = true;

            ASSITments_LinkUser(); // link Principal User to get access token
        }

        protected void createSchoolRef()
        {
            string retStr;
            WebClient restClient = new WebClient();
            restClient.Headers.Add("Content-Type", Global.ASSITments_ContentType);
            restClient.Headers.Add("assistments-auth", Global.ASSITments_Auth_WOBehalf);
            string schoolRefURL = String.Format("{0}/school",Global.ASSITmentsBaseAPI);
            string postData = "{" + "\"" + "nces" + "\"" + ":" + "\"" + Global.ASSITments_School_NCES + "\"" + "}";
            byte[] byteArray = Encoding.ASCII.GetBytes(postData);
            byte[] byteResult = restClient.UploadData(schoolRefURL, "POST", byteArray);
            retStr = Encoding.ASCII.GetString(byteResult);

            JObject response = JObject.Parse(retStr);
            string school_ref = response["school"].ToString();
            Global.schoolRef = school_ref;
        }

        protected void ASSITments_CreateSchoolMembership(object sender, EventArgs e)
        {
            //createSchoolRef();

            Global.ASSITments_Auth_Behalf = "partner=" + "\"" + "Hien-Ref" + "\",onBehalfOf=" + "\"" + Global.OnBehalfOf + "\"";

            WebClient restClient = new WebClient();
            restClient.Headers.Add("Content-Type", Global.ASSITments_ContentType);
            restClient.Headers.Add("assistments-auth", Global.ASSITments_Auth_Behalf); //Session["OnBehalfOf"]: linkUser.aspx

            string createUserURL = String.Format("{0}/school_membership",Global.ASSITmentsBaseAPI);

            string postData = "{" + "\"" + "user" + "\"" + ":" + "\"" + Global.teacherRef + "\"" + "," +
                                    "\"" + "school" + "\"" + ":" + "\"" + Global.schoolRef + "\"" + "}";

            byte[] byteArray = Encoding.ASCII.GetBytes(postData);
            byte[] byteResult = restClient.UploadData(createUserURL, "POST", byteArray);
            string retStr = Encoding.ASCII.GetString(byteResult);
            
            this.lblASSIT_SchoolOK.Visible = true;
        }


        protected void ASSITments_CreateClass(object sender, EventArgs e)
        {
            WebClient restClient = new WebClient();
            restClient.Headers.Add("Content-Type", Global.ASSITments_ContentType);
           
            restClient.Headers.Add("assistments-auth", Global.ASSITments_Auth_Behalf);
            string createUserURL = string.Format("{0}/student_class",Global.ASSITmentsBaseAPI);
            if (Global.OnBehalfOf == "")
            {
                this.lblASSIT_CreateClassError.Visible = true;
                return;
            }
            string postData = "{" + "\"" + "courseName" + "\"" + ":" + "\"" + this.txtCourseTitle.Text + " " + Global.course_extendCouseID + "\"" + "," +
                                  "\"" + "courseNumber" + "\"" + ":" + "\"" + "1" + "\"" + "," +
                                  "\"" + "sectionNumber" + "\"" + ":" + "\"" + "1" + "\"" + "}";
            byte[] byteArray = Encoding.ASCII.GetBytes(postData);
            byte[] byteResult = restClient.UploadData(createUserURL, "POST", byteArray);
            string retStr = Encoding.ASCII.GetString(byteResult);

            JObject response = JObject.Parse(retStr);
            string class_ref = response["class"].ToString();
            Global.classRef = class_ref;
            this.lblASSIT_CreateClassOK.Visible = true;
        }

        protected void ASSITments_CreateAssignment(object sender, EventArgs e)
        {
            WebClient restClient = new WebClient();
            restClient.Headers.Add("Content-Type", Global.ASSITments_ContentType);
            // restClient.Headers.Add("assistments-auth", "partner=" + "\"" + "Hien-Ref" + "\",onBehalfOf=" + Session["OnBehalfOf"]); //Session["OnBehalfOf"]: linkUser.aspx
            restClient.Headers.Add("assistments-auth", Global.ASSITments_Auth_Behalf);
            if (Global.OnBehalfOf == "")
            {
                this.lblASSIT_AssignmentError.Visible = true;
                return;
            }

            string createAssignmentURL = String.Format("{0}/assignment",Global.ASSITmentsBaseAPI);

            string postData = "{" + "\"" + "problemSet" + "\"" + ":" + "\"" + Global.problemSetId + "\"" + "," +
                      "\"" + "class" + "\"" + ":" + "\"" + Global.classRef + "\"" + "," +
                      "\"" + "scope" + "\"" + ":" + "\"" + Global.classRef + "\"" + "}";
            byte[] byteArray = Encoding.ASCII.GetBytes(postData);
            byte[] byteResult = restClient.UploadData(createAssignmentURL, "POST", byteArray);
            string retStr = Encoding.ASCII.GetString(byteResult);

            JObject response = JObject.Parse(retStr);
            string assignment_ref = response["assignment"].ToString();
            Global.assignmentRef = assignment_ref;
            this.lblASSIT_AssignmentOK.Visible = true;
        }

        protected void createSchoolStudentMembership(string student_ref)
        {
          
            WebClient restClient = new WebClient();
            restClient.Headers.Add("Content-Type", Global.ASSITments_ContentType);
            restClient.Headers.Add("assistments-auth", Global.ASSITments_Auth_Behalf); //Session["OnBehalfOf"]: linkUser.aspx
            //restClient.Headers.Add("assistments-auth", "partner=" + "\"" + "Hien-Ref" + "\",onBehalfOf=" + "QPLVA00CD151QSARRI876U7U");
            string createUserURL = String.Format("{0}/school_membership",Global.ASSITmentsBaseAPI);

            string postData = "{" + "\"" + "user" + "\"" + ":" + "\"" + student_ref + "\"" + "," +
                                    "\"" + "school" + "\"" + ":" + "\"" + Global.schoolRef + "\"" + "}";

            /*
            string postData = "{" + "\"" + "user" + "\"" + ":" + "\"" + "604161c15ae58acd36178e575a4f3e64" + "\"" + "," +
                                   "\"" + "school" + "\"" + ":" + "\"" + "acabb5c9c11b9102107d0bfb34062eb4" + "\"" + "}";
             */
            byte[] byteArray = Encoding.ASCII.GetBytes(postData);
            byte[] byteResult = restClient.UploadData(createUserURL, "POST", byteArray);
            string retStr = Encoding.ASCII.GetString(byteResult);
            //Response.Redirect("createClass.aspx");
        }



        protected void ASSITments_TransferStudentAccounts(object sender, EventArgs e)
        {
            for (int i = 0; i < Global.inBloomStudents.Count; i++)
            {
                Mapping.StudentInfo aStudentInfo = (StudentInfo)Global.inBloomStudents[i];

                WebClient restClient = new WebClient();
                restClient.Headers.Add("Content-Type", Global.ASSITments_ContentType);
                restClient.Headers.Add("assistments-auth", Global.ASSITments_Auth_WOBehalf);
                string createUserURL = String.Format("{0}/user", Global.ASSITmentsBaseAPI) ;

                string postData = "{" + "\"" + "userType" + "\"" + ":" + "\"" + aStudentInfo.UserType + "\"" + "," +
                                           "\"" + "username" + "\"" + ":" + "\"" + aStudentInfo.Username + "\"" + "," +
                                           "\"" + "password" + "\"" + ":" + "\"" + aStudentInfo.Password + "\"" + "," +
                                           "\"" + "email" + "\"" + ":" + "\"" + aStudentInfo.Email + "\"" + "," +
                                           "\"" + "firstName" + "\"" + ":" + "\"" + aStudentInfo.FirstName + "\"" + "," +
                                           "\"" + "lastName" + "\"" + ":" + "\"" + aStudentInfo.LastSurname + "\"" + "," +
                                           "\"" + "displayName" + "\"" + ":" + "\"" + aStudentInfo.DisplayName + "\"" + "," +
                                           "\"" + "timeZone" + "\"" + ":" + "\"" + aStudentInfo.TimeZone + "\"" + "," +
                                           "\"" + "registrationCode" + "\"" + ":" + "\"" + aStudentInfo.RegistrationCode + "\"" + "}";

                byte[] byteArray = Encoding.ASCII.GetBytes(postData);
                byte[] byteResult = restClient.UploadData(createUserURL, "POST", byteArray);
                string retStr = Encoding.ASCII.GetString(byteResult);

                JObject response = JObject.Parse(retStr);
                string student_ref = response["user"].ToString();
                aStudentInfo.StudentRef = student_ref;
                Global.inBloomStudents[i] = aStudentInfo;

                //create Student School Membership so students can login
                createSchoolStudentMembership(student_ref);

            }

            this.lblASSIT_TransferStudentOK.Text += " " + Global.inBloomStudents.Count + " students to ASSITments!";
        }

        protected void ASSITments_EnrollStudents(object sender, EventArgs e)
        {
            for (int i = 0; i < Global.inBloomStudents.Count; i++)
            {
                StudentInfo aStudentInfo = (StudentInfo)Global.inBloomStudents[i];

                WebClient restClient = new WebClient();
                restClient.Headers.Add("Content-Type", Global.ASSITments_ContentType);
                // restClient.Headers.Add("assistments-auth", "partner=" + "\"" + "Hien-Ref" + "\",onBehalfOf=" + Session["OnBehalfOf"]); //Session["OnBehalfOf"]: linkUser.aspx
                restClient.Headers.Add("assistments-auth", Global.ASSITments_Auth_Behalf);
                string enrollClassMember = String.Format("{0}/class_membership",Global.ASSITmentsBaseAPI);

                string postData = "{" + "\"" + "user" + "\"" + ":" + "\"" + aStudentInfo.StudentRef + "\"" + "," +
                          "\"" + "class" + "\"" + ":" + "\"" + Global.classRef + "\"" + "}";
                byte[] byteArray = Encoding.ASCII.GetBytes(postData);
                byte[] byteResult = restClient.UploadData(enrollClassMember, "POST", byteArray);
                string retStr = Encoding.ASCII.GetString(byteResult);
            }

            this.lblASSITments_EnrollOK.Text += " " + Global.inBloomStudents.Count + " students!";
        }

        protected string ASSITments_GetHTMLReport()
        {
            WebClient restClientURL = new WebClient();
            restClientURL.Headers.Add("Content-Type", Global.ASSITments_ContentType);
            restClientURL.Headers.Add("assistments-auth", Global.ASSITments_Auth_Behalf);
            string schoolRefURL = string.Format("{1}/report/{0}/1", Global.assignmentRef,Global.ASSITmentsBaseAPI);

            string result = restClientURL.DownloadString(schoolRefURL);

            JObject responseURL = JObject.Parse(result);
            string handler_ref = responseURL["unencodedHandler"].ToString();
            handler_ref = "https://test1.assistments.org" + handler_ref;
            string assingmentReport = string.Format("{2}/user_login?partner=Hien-Ref&access={0}&on_success={1}&on_failure=yahoo.com", Global.OnBehalfOf, handler_ref, Global.ASSITmentsAPI_Helper);
            var restClient = new RestClient(assingmentReport);

            var request = new RestRequest(Method.GET);
            RestResponse response = (RestResponse)restClient.Execute(request);
            string data = response.Content;
            return data;
        }

        protected void ASSITments_GetStudentResult()
        {
            string data = ASSITments_GetHTMLReport();
            for (int i = 0; i < Global.inBloomStudents.Count; i++)
            {
                StudentInfo aStudent = (StudentInfo)Global.inBloomStudents[i];
                string nameFound = aStudent.LastSurname + ", " + aStudent.FirstName;


                int indexName = data.IndexOf(nameFound, 0);
                if (indexName >= 0) //if name available, find the next score 
                {
                    string regex = "<span title=" + "\\\"" + "Final grade." + "\\\"" + " style=" + "\\\"" + "font-weight:bold;font-size:1.2em;color:#2554C7" + "\\\"" + ">";
                    string regex2 = "<td valign=middle align=" + "\\\"" + "middle" + "\\\"" + " style=" + "\\\"" + "background-color:white" + "\\\"" + ">";
                    int index = data.IndexOf(regex, indexName);
                    int index2 = data.IndexOf(regex2, indexName); 
                    if ( (index2 + 60 < index)   && (index2 + 80 > index) )
                    {
                        int indexGreater = data.IndexOf(">", index);
                        int percentIndex = data.IndexOf("%", indexGreater);
                        aStudent.Score = data.Substring(indexGreater + 1, percentIndex - (indexGreater + 1));
                    }
                    else
                    {
                        aStudent.Score = "0";
                    }
                }
                Global.inBloomStudents[i] = aStudent;

            }
        }

        protected void ASSITments_UpdateResult_ToInBloom(object sender, EventArgs e)
        {

            ASSITments_GetStudentResult(); //update score after every click

            for (int i = 0; i < Global.inBloomStudents.Count; i++)
            {
                StudentInfo aStudentInfo = (StudentInfo)Global.inBloomStudents[i];

                
                WebClient restClient = new WebClient();
                restClient.Headers.Add("Accept", Global.inBloomAcceptHeader);
                restClient.Headers.Add("Content-Type", Global.inBloomContentTypeHeader);
                restClient.Headers.Add("Authorization", "bearer " + Session["access_token"].ToString());
                string enrollClassMember = String.Format("{0}/courseTranscripts/{1}", Global.inBloomBaseAPI, aStudentInfo.CourseTranscriptId);

                string postData = "{" + "\"" + "finalNumericGradeEarned" + "\"" + ":" + "\"" + aStudentInfo.Score + "\"" + "}";
                byte[] byteArray = Encoding.ASCII.GetBytes(postData);
                byte[] byteResult = restClient.UploadData(enrollClassMember, "PATCH", byteArray);
                string retStr = Encoding.ASCII.GetString(byteResult);

                /*
                var client  = new RestClient(enrollClassMember);
                var request = new RestRequest(Method.PATCH);
                request.AddHeader("Accept", Global.inBloomAcceptHeader);
                request.AddHeader("Content-Type", Global.inBloomContentTypeHeader);
                request.AddHeader("Authorization", "bearer " + Session["access_token"].ToString());
                inBloomData.UpdateGrade udgrade = new UpdateGrade();
                UpdateGrade.finalNumericGradeEarned = aStudentInfo.Score;
                request.AddBody(udgrade);
                RestResponse response = (RestResponse)client.Execute(request);
                string data = response.Content;
                */

            }

            this.lblASSIT_UpdateOK.Visible = true;


        }

    }
}