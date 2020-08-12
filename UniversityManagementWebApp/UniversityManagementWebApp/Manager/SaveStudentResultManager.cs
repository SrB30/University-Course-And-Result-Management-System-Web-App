using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementWebApp.Gateway;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Manager
{
    public class SaveStudentResultManager
    {
        private SaveStudentResultGateway saveStudentResultGateway;

        public SaveStudentResultManager()
        {
            saveStudentResultGateway = new SaveStudentResultGateway();
        }

        public string Save(EnrollCourseToStudent aCourseToStudent)
        {
            int rowAffect = saveStudentResultGateway.Save(aCourseToStudent);

            if (rowAffect>0)
            {
                return "Grade updated successfuly";
            }
            return "Grade update failed. Please try again";
        }
    }
}