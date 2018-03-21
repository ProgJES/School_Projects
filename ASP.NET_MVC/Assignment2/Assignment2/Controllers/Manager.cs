using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using AutoMapper;
using Assignment2.Models;

namespace Assignment2.Controllers
{
    public class Manager
    {
        // Reference to the data context
        private DataContext ds = new DataContext();

        public Manager()
        {
            // If necessary, add constructor code here
        }
        public IEnumerable<EmployeeBase> EmployeeGetAll()
        {
            return Mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeBase>>(ds.Employees);
        }
        public EmployeeBase EmployeeGetById(int id)
        {
            var identNum = ds.Employees.Find(id);

            return (identNum == null) ? null : Mapper.Map<Employee, EmployeeBase>(identNum);
        }
        public EmployeeBase EmployeeAdd(EmployeeAdd newItem)
        {
            //Attempt to add the new item
            var addedItem = ds.Employees.Add(Mapper.Map<EmployeeAdd, Employee>(newItem));
            ds.SaveChanges();
            
            //If successful, return the added item, mapped to a view model object
            return (addedItem == null) ? null : Mapper.Map<Employee, EmployeeBase>(addedItem);
        }

        // Add methods below
        // Controllers will call these methods
        // Ensure that the methods accept and deliver ONLY view model objects and collections
        // The collection return type is almost always IEnumerable<T>

        // Suggested naming convention: Entity + task/action
        // For example:
        // ProductGetAll()
        // ProductGetById()
        // ProductAdd()
        // ProductEdit()
        // ProductDelete()
    }
}