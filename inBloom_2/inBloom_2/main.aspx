<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="inBloom_2.main" MasterPageFile="~/BodySite.Master" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h2>Main Menu</h2>
        <div>
            <table title="inBloom">
                <!-- input field --> <!-- Link Button --> <!--Info -->
                <tr> <!-- inBloom Course -->
                    <td>
                        <asp:Label runat="server" Font-Size="Large" Font-Bold="true">1.Create inBloom Course</asp:Label>
                    </td>
                    <td>
                        <asp:Label runat="server">Course Title:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCourseTitle" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:LinkButton runat="server" OnClick="inBloom_CreateCourse" Text="Create Course" ToolTip="Create inBloom Course"></asp:LinkButton>
                    </td>
                    <td>
                         <asp:Label ID="lblinBloomCreateCourseOK" runat="server" Font-Size="Large" Font-Bold="true" ForeColor="#00ccff">Successfully Created</asp:Label>
                         <asp:Label ID="lblinBloomCreateCoureError" runat="server" Font-Size="Large" Font-Bold="true" ForeColor="#ff0000">There were some errors!</asp:Label>
                    </td>
                </tr>

                <tr> <!-- Course Offering -->
                    <td>
                        <asp:Label runat="server" Font-Size="Large" Font-Bold="true">2.Create inBloom Course Offerings</asp:Label>
                    </td>
                    <td>
                       
                    </td>
                    <td>
                        
                    </td>
                    <td>
                        <asp:LinkButton runat="server" OnClick="inBloom_CreateCourseOffering" Text="Create Course Offering" ToolTip="Create inBloom Course Offering"></asp:LinkButton>
                    </td>
                    <td>
                         <asp:Label ID="lblinBloomCreateCourseOfferingeOK" runat="server" Font-Size="Large" Font-Bold="true" ForeColor="#00ccff">Successfully Created</asp:Label>
                         <asp:Label ID="lblinBloomCreateCourseOfferingError" runat="server" Font-Size="Large" Font-Bold="true" ForeColor="#ff0000">There were some errors!</asp:Label>
                    </td>
                </tr>

                 <tr><!-- Section --> 
                    <td>
                        <asp:Label ID="Label1" runat="server" Font-Size="Large" Font-Bold="true">3.Create inBloom Course Section</asp:Label>
                    </td>
                    <td>
                       
                    </td>
                    <td>
                        
                    </td>
                    <td>
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="inBloom_CreateCourseSection" Text="Create Course Section" ToolTip="Create inBloom Course Section"></asp:LinkButton>
                    </td>
                    <td>
                         <asp:Label ID="lblinBloomCreateCourseSectionOK" runat="server" Font-Size="Large" Font-Bold="true" ForeColor="#00ccff">Successfully Created</asp:Label>
                         <asp:Label ID="lblinBloomCreateCourseSectionError" runat="server" Font-Size="Large" Font-Bold="true" ForeColor="#ff0000">There were some errors!</asp:Label>
                    </td>
                </tr>


                <tr>  <!-- TeacherSectionAssociations -->
                    <td>
                        <asp:Label runat="server" Font-Size="Large" Font-Bold="true">4.Create inBloom Teacher Section Associations</asp:Label>
                    </td>
                    <td>
                       
                    </td>
                    <td>
                        
                    </td>
                    <td>
                        <asp:LinkButton runat="server" OnClick="inBloom_CreateTeacherSection" Text="Create Teacher Section Associations" ToolTip="Create inBloom Teacher Section Associations"></asp:LinkButton>
                    </td>
                    <td>
                         <asp:Label ID="lblinBloomCreateTeacherSectionOK" runat="server" Font-Size="Large" Font-Bold="true" ForeColor="#00ccff">Successfully Created</asp:Label>
                         <asp:Label ID="lblinBloomCreateTeacherSectionError" runat="server" Font-Size="Large" Font-Bold="true" ForeColor="#ff0000">There were some errors!</asp:Label>
                    </td>
                </tr>

                <tr>  <!-- Login as Linda Kim -->
                    <td>
                        <asp:Label runat="server" Font-Size="Large" Font-Bold="true">5.Login as a Teacher role (Linda Kim)</asp:Label>
                    </td>
                    <td>
                       
                    </td>
                    <td>
                        
                    </td>
                    <td>
                        <asp:LinkButton runat="server" OnClick="inBloom_SwithToTeacher" Text="Switch to Teacher Role" ToolTip="Switch to Teacher Role"></asp:LinkButton>
                    </td>
                    <td>
                    </td>
                </tr>
                
                 <tr>  <!-- Get students-->
                    <td>
                        <asp:Label runat="server" Font-Size="Large" Font-Bold="true">6.Get Linda Kim's students</asp:Label>
                    </td>
                    <td>
                       
                    </td>
                    <td>
                        
                    </td>
                    <td>
                        <asp:LinkButton runat="server" OnClick="inBloom_GetStudents" Text="Get inBloom Students" ToolTip="Get inBloom Students"></asp:LinkButton>
                    </td>
                    <td>
                         <asp:Label ID="lblinBloomGetStudentOK" runat="server" Font-Size="Large" Font-Bold="true" ForeColor="#00ccff">Successfully Get</asp:Label>
                         <asp:Label ID="lblinBloomGetStudentError" runat="server" Font-Size="Large" Font-Bold="true" ForeColor="#ff0000">There were some errors!</asp:Label>
                         <asp:LinkButton ID="view_InBloomStudents" runat="server" OnClick="inBloom_ViewGetStudents" Text="View inBloom Students" ToolTip="View inBloom Students"></asp:LinkButton>
                    </td>
                </tr>

                  <tr>  <!-- Login as Admin -->
                    <td>
                        <asp:Label ID="Label2"  runat="server" Font-Size="Large" Font-Bold="true">6c.Login as a Admin role (James Stevenson)</asp:Label>
                    </td>
                    <td>
                       
                    </td>
                    <td>
                        
                    </td>
                    <td>
                        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="inBloom_SwithToAdmin" Text="Switch to Admin Role" ToolTip="Switch to Admin Role"></asp:LinkButton>
                    </td>
                    <td>
                    </td>
                </tr>

                <tr>  <!-- Erroll student in Section -->
                    <td>
                        <asp:Label runat="server" Font-Size="Large" Font-Bold="true">6b.Enroll students to inBloom Section</asp:Label>
                    </td>
                    <td>
                       
                    </td>
                    <td>
                        
                    </td>
                    <td>
                        <asp:LinkButton  runat="server" OnClick="inBloom_EnrollStudentSection" Text="Enroll inBloom Students into section" ToolTip="Enroll Student Section"></asp:LinkButton>
                    </td>
                    <asp:Label ID="lblinBloomEnrollOK" runat="server" Font-Size="Large" Font-Bold="true" ForeColor="#00ccff">Successfully Enrolled</asp:Label>
                    <td>
                    </td>
                </tr>

               

               <tr>  <!-- Created Linda Kim in ASSITments -->
                    <td>
                        <asp:Label runat="server" Font-Size="Large" Font-Bold="true">7.Transfer current inBloom Login Teacher to ASSITments</asp:Label>
                    </td>
                    <td>
                    </td>
                    <td>
                        
                    </td>
                    <td>
                        <asp:LinkButton runat="server" OnClick="ASSITments_CreateTeacher" Text="Create" ToolTip="Create an ASSITments Teachers"></asp:LinkButton>
                    </td>
                    <td>
                        <asp:Label  runat="server" ID ="lblASSITmentsCreateTeacherOK" Font-Size="Large" Font-Bold="true" ForeColor="#00ccff">Transfered Successfully</asp:Label>
                        <asp:Label runat="server" ID ="lblASSITmentsCreateTeacherError" Font-Size="Large" Font-Bold="true" ForeColor="#ff0000">There were some errors!</asp:Label>
                    </td>
                </tr>

                 <tr>  <!-- Create School Referece -->
                    <td>
                        <asp:Label runat="server" Font-Size="Large" Font-Bold="true">8.Create ASSITments School Referene and Assign new Teacher to School</asp:Label>
                    </td>
                    <td>
                    </td>
                    <td>
                        
                    </td>
                    <td>
                        <asp:LinkButton runat="server" OnClick="ASSITments_CreateSchoolMembership" Text="Create" ToolTip="Create an ASSITments School Reference"></asp:LinkButton>
                    </td>
                    <td>
                        <asp:Label  runat="server" ID ="lblASSIT_SchoolOK" Font-Size="Large" Font-Bold="true" ForeColor="#00ccff">Create and Assign Successfully</asp:Label>
                        <asp:Label runat="server" ID ="lblASSIT_SchoolError" Font-Size="Large" Font-Bold="true" ForeColor="#ff0000">There were some errors!</asp:Label>
                    </td>
                </tr>

                <tr>  <!-- Create Class -->
                    <td>
                        <asp:Label  runat="server" Font-Size="Large" Font-Bold="true">9.Create ASSITments Class</asp:Label>
                    </td>
                    <td>
                    </td>
                    <td>
                        
                    </td>
                    <td>
                        <asp:LinkButton  runat="server" OnClick="ASSITments_CreateClass" Text="Create" ToolTip="Create an ASSITments Class"></asp:LinkButton>
                    </td>
                    <td>
                        <asp:Label  runat="server" ID ="lblASSIT_CreateClassOK" Font-Size="Large" Font-Bold="true" ForeColor="#00ccff">Created Successfully</asp:Label>
                        <asp:Label runat="server" ID ="lblASSIT_CreateClassError" Font-Size="Large" Font-Bold="true" ForeColor="#ff0000">There were some errors!</asp:Label>
                    </td>
                </tr>

                <tr>  <!-- Create Assignment -->
                    <td>
                        <asp:Label  runat="server" Font-Size="Large" Font-Bold="true">10.Create an ASSITments Assignment</asp:Label>
                    </td>
                    <td>
                    </td>
                    <td>
                        
                    </td>
                    <td>
                        <asp:LinkButton runat="server" OnClick="ASSITments_CreateAssignment" Text="Create" ToolTip="Create an ASSITments Assignment"></asp:LinkButton>
                    </td>
                    <td>
                        <asp:Label ID="lblASSIT_AssignmentOK" runat="server" Font-Size="Large" Font-Bold="true" ForeColor="#00ccff">Created Successfully</asp:Label>
                        <asp:Label ID="lblASSIT_AssignmentError" runat="server"  Font-Size="Large" Font-Bold="true" ForeColor="#ff0000">There were some errors!</asp:Label>
                    </td>
                </tr>


                <tr>  <!-- Transfer student account -->
                    <td>
                        <asp:Label  runat="server" Font-Size="Large" Font-Bold="true">10.Transfer students from inBloom to ASSITments</asp:Label>
                    </td>
                    <td>
                    </td>
                    <td>
                        
                    </td>
                    <td>
                        <asp:LinkButton runat="server" OnClick="ASSITments_TransferStudentAccounts" Text="Transfer" ToolTip="Create ASSITments Student Accounts"></asp:LinkButton>
                    </td>
                    <td>
                        <asp:Label ID="lblASSIT_TransferStudentOK" runat="server" Font-Size="Large" Font-Bold="true" ForeColor="#00ccff">Transfer Successfully</asp:Label>
                        <asp:Label ID="lblASSIT_TransferStudentError" runat="server"  Font-Size="Large" Font-Bold="true" ForeColor="#ff0000">There were some errors!</asp:Label>
                    </td>
                </tr>


                <tr>  <!-- Enroll student class -->
                    <td>
                        <asp:Label  runat="server" Font-Size="Large" Font-Bold="true">11.Enroll Students in Class</asp:Label>
                    </td>
                    <td>
                    </td>
                    <td>
                        
                    </td>
                    <td>
                        <asp:LinkButton runat="server" OnClick="ASSITments_EnrollStudents" Text="Enroll" ToolTip="Enroll Students in Class"></asp:LinkButton>
                    </td>
                    <td>
                        <asp:Label ID="lblASSITments_EnrollOK" runat="server" Font-Size="Large" Font-Bold="true" ForeColor="#00ccff">Enroll Successfully</asp:Label>
                        <asp:Label ID="lblASSITments_EnrollError" runat="server"  Font-Size="Large" Font-Bold="true" ForeColor="#ff0000">There were some errors!</asp:Label>
                    </td>
                </tr>

                <tr>  <!-- Enroll student class -->
                    <td>
                        <asp:Label  runat="server" Font-Size="Large" Font-Bold="true">12.Update Assignment Result to inBloom</asp:Label>
                    </td>
                    <td>
                    </td>
                    <td>
                        
                    </td>
                    <td>
                        <asp:LinkButton runat="server" OnClick="ASSITments_UpdateResult_ToInBloom" Text="Update" ToolTip="Update Assignment Result"></asp:LinkButton>
                    </td>
                    <td>
                        <asp:Label ID="lblASSIT_UpdateOK" runat="server" Font-Size="Large" Font-Bold="true" ForeColor="#00ccff">Updated Successfully</asp:Label>
                        <asp:Label ID="lblASSIT_UpdateError" runat="server"  Font-Size="Large" Font-Bold="true" ForeColor="#ff0000">There were some errors!</asp:Label>
                    </td>
                </tr>

            </table>
        </div>

        <br />
        <br />
       
    </asp:Content>