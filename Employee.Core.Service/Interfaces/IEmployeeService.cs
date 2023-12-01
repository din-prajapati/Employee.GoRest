using System;
using System.Collections.Generic;
using System.Text;
using Employee.Core.Entities;
using Employee.Core.Service.Models;

namespace Employee.Core.Service.Interfaces
{
    public interface IEmployeeService
    {
        /// <summary>
        /// Get all Employees
        /// </summary>
        /// <returns>List of Employees</returns>
        Task<EmployeeListItem> GetEmployees();


        ///// <summary>
        ///// Used to get Employee by Employee ID
        ///// </summary>
        ///// <param name="EmployeeId"></param>
        ///// <returns></returns>
        Task<EmployeeDetailsItem> GetEmployeeById(long id);


        ///// <summary>
        ///// Used to Get all Employees as per Paging
        ///// </summary>
        ///// <returns></returns>
        Task<EmployeeListItem> GetEmployees(int page);


        ///// <summary>
        ///// Used to Get all Employees by name
        ///// </summary>
        ///// <returns></returns>
        Task<EmployeeListItem> GetEmployees(string name);


        ///// <summary>
        ///// Used to add Employee
        ///// </summary>
        ///// <returns></returns>
        Task<EmployeeDetailsItem> AddEmployee(EmployeeEntity entity);


        /// <summary>
        /// Used to update employee
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<EmployeeDetailsItem> UpdateEmployee(long id, EmployeeEntity entity);


        /// <summary>
        /// Used to delete employee
        /// </summary>
        /// <param name="id"></param>        
        /// <returns></returns>
        Task<bool> DeleteEmployee(long id);       
    }
}
