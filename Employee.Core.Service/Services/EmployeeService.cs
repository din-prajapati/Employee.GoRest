using Employee.Core.Interfaces;
using Employee.Core.Service.Interfaces;
using Employee.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;
using System.Net;
using Employee.Core.Common;
using Employee.Core.Service.Models;
using System.Security.Principal;

namespace Employee.Core.Service
{
    public class EmployeeService : BaseService, IEmployeeService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IApiRepositoryFactory _repoFactory;
        private readonly ICoreBase<EmployeeService> _coreBase;
        private readonly IApiRepository<EmployeeEntity> _employeeRepo;

        private readonly HttpClient _httpClient;

        private IAppLogger<EmployeeService> Logger => _coreBase.Logger;

        public EmployeeService(IHttpClientFactory clientFactory, IApiRepositoryFactory repoFactory, ICoreBase<EmployeeService> coreBase)
        {
            this._clientFactory = clientFactory;
            this._repoFactory = repoFactory;
            this._coreBase = coreBase;

            _httpClient = _clientFactory.CreateClient("GoRest");
            _employeeRepo = _repoFactory.GetRepository<EmployeeEntity>(_httpClient, "users");
        }

        /// <summary>
        /// Used to Get all Employees.
        /// </summary>
        /// <returns></returns>
        public async Task<EmployeeListItem> GetEmployees()
        {
            EmployeeListItem mListItem = new EmployeeListItem();
            ApiEntityListResponse<EmployeeEntity> mResponse = await _employeeRepo.GetAllAsync();
            if (mResponse != null)
            {
                mListItem.Entities = mResponse.Entities;
                mListItem.CurrentPage = mResponse.CurrentPage;
                mListItem.TotalPageCount = mResponse.TotalPages;
                mListItem.TotalCount = mResponse.TotalCount;
            }
            return mListItem;
        }

        /// <summary>
        /// Used to get Employee by Employee ID
        /// </summary>
        /// <param name="EmployeeId"></param>
        /// <returns></returns>
        public async Task<EmployeeDetailsItem> GetEmployeeById(long id)
        {
            EmployeeDetailsItem mItem = new EmployeeDetailsItem();
            ApiEntityResponse<EmployeeEntity> mResponse = await _employeeRepo.GetAsync(id);
            if (mResponse != null)
            {
                mItem.Entity = mResponse.Entity;
            }
            return mItem;
        }

        /// <summary>
        /// Used to Get all Employees as per pagination.
        /// </summary>
        /// <returns></returns>
        public async Task<EmployeeListItem> GetEmployees(int page)
        {
            EmployeeListItem mListItem = new EmployeeListItem();
            ApiEntityListResponse<EmployeeEntity> mResponse = await _employeeRepo.GetAllAsync(page);
            if (mResponse != null)
            {
                mListItem.Entities = mResponse.Entities;
                mListItem.CurrentPage = mResponse.CurrentPage;
                mListItem.TotalPageCount = mResponse.TotalPages;
                mListItem.TotalCount = mResponse.TotalCount;
            }
            return mListItem;
        }

        /// <summary>
        /// Used to Get all Employees by name.
        /// </summary>
        /// <returns></returns>
        public async Task<EmployeeListItem> GetEmployees(string name)
        {
            EmployeeListItem mListItem = new EmployeeListItem();
            ApiEntityListResponse<EmployeeEntity> mResponse = await _employeeRepo.GetAllAsync(name);
            if (mResponse != null)
            {
                mListItem.Entities = mResponse.Entities;
                mListItem.CurrentPage = mResponse.CurrentPage;
                mListItem.TotalPageCount = mResponse.TotalPages;
                mListItem.TotalCount = mResponse.TotalCount;
            }
            return mListItem;
        }

        ///// <summary>
        /// Used to Add Employee 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<EmployeeDetailsItem> AddEmployee(EmployeeEntity entity)
        {
            EmployeeDetailsItem mItem = new EmployeeDetailsItem();
            ApiEntityResponse<EmployeeEntity> mResponse = await _employeeRepo.Add(entity);
            if (mResponse != null)
            {
                mItem.Entity = mResponse.Entity;
            }
            return mItem;
        }


        ///// <summary>
        /// Used to Update Employee 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<EmployeeDetailsItem> UpdateEmployee(long id, EmployeeEntity entity)
        {
            EmployeeDetailsItem mItem = new EmployeeDetailsItem();
            ApiEntityResponse<EmployeeEntity> mResponse = await _employeeRepo.Update(id, entity);
            if (mResponse != null)
            {
                mItem.Entity = mResponse.Entity;
            }
            return mItem;
        }

        /// <summary>
        /// Used to delete employee
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteEmployee(long id)
        {
            HttpStatusCode ResponseStatus = await _employeeRepo.Delete(id);
            if (ResponseStatus == HttpStatusCode.OK || ResponseStatus == HttpStatusCode.NoContent)
            {
                return true;
            }
            return false;
        }      

    }
}

