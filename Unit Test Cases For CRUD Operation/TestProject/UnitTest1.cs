using CRUD_Operation_Api.Controllers;
using CRUD_Operation_Api.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestProject
{
    public class UnitTest1
    {
        public List<Student> stud = new List<Student>()
        {
           new Student(){Id=1,Name="Micky",Address="Okhla",Course="Mca" },
           new Student(){Id=2,Name="Rahul",Address="noida",Course="Mba" },
           new Student{Id=3,Name="Sam",Address="dwarka",Course="BBA"}
        };
        StudentController stcon = new StudentController();

        [Fact]
        public void TestGetAll()
        {
           List<Student> st=stcon.GetAll();

           Assert.Equal(stud.Count,st.Count);
        }
        [Fact]
        public void TestGetById()
        {
            Student st = new Student()
            {
               Id = 1,
              Name = "Micky",
              Address = "Okhla",
              Course = "Mca"
            };
            string result = stcon.GetById(1);
            Assert.Equal(st.Name,result);
        }
        [Fact]
        public void TestCreate()
        {
            Student st=new Student() { Id = 4, Name = "abhi", Address = "dwarka", Course = "btech" };
            Student s=stcon.Create(st); 
            Assert.Equal(st, s);
        }
        [Fact]
        public void TestDelete()
        {
            Student st= new Student { Id = 3, Name = "Sam", Address = "dwarka", Course = "BBA" };
            string result=stcon.DeleteStudent(3);
            Assert.Equal(st.Name,result);
        }
    }
}
