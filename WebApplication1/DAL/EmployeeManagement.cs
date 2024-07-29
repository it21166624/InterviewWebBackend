using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.DBconnection;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class EmployeeManagement
    {
        public List<EmployeeModel> getAllEmployees()
        {
            List<EmployeeModel> EmployeeList = new List<EmployeeModel>();
            string Query = "SELECT Emp_ID, Age, Name,Edu_ID,(SELECT E_Category FROM Education WHERE E_ID = Edu_ID) AS EducationType FROM Employee_Details";
            using (var DBconnect = new DBconnection1())
            {
                using (SqlDataReader rdr = DBconnect.ReadTable(Query))
                {
                    while (rdr.Read())
                    {
                        EmployeeModel employee = new EmployeeModel
                        {
                            employeeID = rdr["Emp_ID"].ToString(),
                            name = rdr["Name"].ToString(),
                            age = rdr["Age"].ToString(),
                            educationType = rdr["EducationType"].ToString(),
                            eID = rdr["Edu_ID"].ToString(),
                        };

                        EmployeeList.Add(employee);
                    }
                   
                }
            }

            return EmployeeList;
        }

        public EmployeeModel getEmployeeByID(int EmpID)
        {
            EmployeeModel Employee = new EmployeeModel();
            string Query = "SELECT Emp_ID, Age, Name,Edu_ID,(SELECT E_Category FROM Education WHERE E_ID = Edu_ID) AS EducationType FROM Employee_Details WHERE Emp_ID = "+EmpID+"";
            using (var DBconnect = new DBconnection1())
            {
                using (SqlDataReader rdr = DBconnect.ReadTable(Query))
                {
                    while (rdr.Read())
                    {
                        Employee.employeeID = rdr["Emp_ID"].ToString();
                        Employee.name = rdr["Name"].ToString();
                        Employee.age = rdr["Age"].ToString();
                        Employee.educationType = rdr["EducationType"].ToString();
                        Employee.eID = rdr["Edu_ID"].ToString();                      
                        
                    }

                }
            }

            return Employee;
        }

        public bool insertEmployee(EmployeeModel EmpModel)
        {
            string Query = @"INSERT INTO Employee_Details ( Age, Name, Edu_ID)
                         VALUES ('" + EmpModel.age + "', '" + EmpModel.name + "', '" + EmpModel.eID + "')"; ;

            using (var DBconnect = new DBconnection1())
            {
                if (DBconnect.AddEditDel(Query))
                {
                    return true;
                }

            }
            
            return false;
        }

        public bool updateEmployee(EmployeeModel EmpModel)
        {
            string Query = @"UPDATE Employee_Details SET Age = '" + EmpModel.age + @"', Name = '" + EmpModel.name + @"', Edu_ID = '" + EmpModel.eID + @"' WHERE Emp_ID = '" + EmpModel.employeeID + @"'";
                         

            using (var DBconnect = new DBconnection1())
            {
                if (DBconnect.AddEditDel(Query))
                {
                    return true;
                }

            }

            return false;
        }

        public bool deleteEmployee(int EmpID)
        {
            string Query = @"DELETE FROM Employee_Details
                               WHERE Emp_ID = '" + EmpID + "' ";


            using (var DBconnect = new DBconnection1())
            {
                if (DBconnect.AddEditDel(Query))
                {
                    return true;
                }

            }

            return false;
        }
    }
}