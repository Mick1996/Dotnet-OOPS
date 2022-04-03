using System;
using System.Collections.Generic;
using System.Linq;

namespace ComplaintOOPS
{

    public class Employee
    {
        public int Id { get; set;} 
        public string Name { get; set;}    
        public string Contact { get; set;}

    }
    public class Complaint
    {
        public string Status { get; set; } = "open";//by default
        public string SpecialRemarks { get; set; }
        public  void ComplaintBy(int id)
        {
            Status = "open";
            Console.WriteLine($"Complaint filed by Employee Whose Id is {id}");
        }
        public  void CloseComplaint(string specialmarks)
        {
            Status = "close";
            SpecialRemarks = specialmarks;
        }
    }
    public class ComplaintManagementSystem
    {

        Complaint cmp=new Complaint();
        public string SpecialMarks { get; set;}
        public void FileComplaint(int id)
        {
            cmp.ComplaintBy(id);        //facade design pattern
        }
        public void CloseComplaint(string specialmarks)
        {
            cmp.CloseComplaint(specialmarks);  
        }
    }
    public class Internal: ComplaintManagementSystem
    {

    }
    public class External : ComplaintManagementSystem
    {

    }
    public class Company
    {
        public ComplaintManagementSystem Complaintmgtsys { get; set; }
        public List<Employee> empList = new List<Employee>()
        {
           new Employee()
           {
               Id=1,Name="Sam",Contact="6541203242"
           },
           new Employee()
           {
              Id=2,Name="Sanju",Contact="9841203242"
           },
           new Employee()
           {
               Id=2,Name="Anju",Contact="91241203242"
           }
        };
        public void AddEmployee(int id,string name,string contact)
        {
            empList.Add(new Employee() {Id=id,Name=name,Contact=contact}); 
        }
        public void RemoveEmployee(int id)
        {
            var emp=empList.Where(x=>x.Id==id).FirstOrDefault();
            empList.Remove(emp);
        }
    }
    public class Admin
    {
        ComplaintManagementSystem c = new ComplaintManagementSystem();
        Company company = new Company();
        public void AddEmployee()
        {
            company.AddEmployee(3, "rahul", "6541203251");
        }
        public void RemoveEmployee()
        {
            company.RemoveEmployee(3);
        }
        public void CloseComplaint()
         {
            c.CloseComplaint("There is issue in your laptop!");
         }
    }
    public class Vendor 
    {
        ComplaintManagementSystem c = new ComplaintManagementSystem();
        public void CloseComplaint()
        {
            c.CloseComplaint("something is wrong!");
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Complaint Management System!");
            
        }

    }
}
