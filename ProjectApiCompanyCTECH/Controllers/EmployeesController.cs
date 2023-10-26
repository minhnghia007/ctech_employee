using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectApiCompanyCTECH.Services;
using System.Threading.Tasks;
using System;
using ProjectApiCompanyCTECH.Model.Request;
using ProjectApiCompanyCTECH.Model;

namespace ProjectApiCompanyCTECH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService= employeeService;
        }

        [Route("createEmployee")]
        [Consumes("multipart/form-data")]
        [HttpPost]
        public async Task<object> Create([FromForm] EmployeeCreateRequest request)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                #region
                if (string.IsNullOrEmpty(request.Fullname))
                {
                    response.respCode = EmployeeResponse.FullnameEmpty;
                    response.respMsg = EmployeeResponse.FullnameEmptyMsg;

                    return response;
                }
                if (string.IsNullOrEmpty(request.Email))
                {
                    response.respCode = EmployeeResponse.EmailEmpty;
                    response.respMsg = EmployeeResponse.EmailEmptyMsg;

                    return response;
                }
                if (string.IsNullOrEmpty(request.PhoneNumber))
                {
                    response.respCode = EmployeeResponse.PhoneNumberEmpty;
                    response.respMsg = EmployeeResponse.PhoneNumberEmptyMsg;

                    return response;
                }
                if (string.IsNullOrEmpty(request.Image))
                {
                    response.respCode = EmployeeResponse.ImageEmpty;
                    response.respMsg = EmployeeResponse.ImageEmptyMsg;

                    return response;
                }
                if (string.IsNullOrEmpty(request.Biography))
                {
                    response.respCode = EmployeeResponse.BiographyEmpty;
                    response.respMsg = EmployeeResponse.BiographyEmptyMsg;

                    return response;
                }

                #endregion

                var _res = await _employeeService.CreateEmployee(request);

                response.respCode = SystemResponse.Success;
                response.respMsg = SystemResponse.SuccessMsg;
                response.respObj= _res;

                return response;
            }
            catch (Exception ex)
            {
                response.respCode = SystemResponse.SystemError;
                response.respMsg = SystemResponse.SystemErrorMsg;

                return response;
            }

        }
        [Route("getByIdEmployee/{id}")]
        [HttpGet]
        public async Task<object> GetById(int id)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                var _res = await _employeeService.GetById(id);
                if (_res == null)
                {
                    response.respCode = EmployeeResponse.EmployeeNotExist;
                    response.respMsg = EmployeeResponse.EmployeeNotExistMsg;
                    return response;
                }
                response.respCode = SystemResponse.Success;
                response.respMsg = SystemResponse.SuccessMsg;
                response.respObj = _res;

                return response;
            }
            catch (Exception ex)
            {
                response.respCode = SystemResponse.SystemError;
                response.respMsg = SystemResponse.SystemErrorMsg;

                return response;
            }
        }
        [Route("deleteEmployee/{id}")]
        [HttpDelete]
        public async Task<object> Delete(int id)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                await _employeeService.DeleteEmployee(id);
               
                response.respCode = SystemResponse.Success;
                response.respMsg = SystemResponse.SuccessMsg;

                return response;

            }
            catch (Exception ex)
            {
                response.respCode = SystemResponse.SystemError;
                response.respMsg = SystemResponse.SystemErrorMsg;

                return response;
            }
        }
        [Route("getList")]
        [HttpGet]
        public async Task<object> GetAllPaging(string fullname, int pageIndex, int pageSize)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                if (string.IsNullOrEmpty(fullname))
                {
                    response.respCode = EmployeeResponse.FullnameEmpty;
                    response.respMsg = EmployeeResponse.FullnameEmptyMsg;

                    return response;
                }
                var _res = await _employeeService.GetAllEmployee(fullname, pageIndex, pageSize);
               
                response.respCode = SystemResponse.Success;
                response.respMsg = SystemResponse.SuccessMsg;
                response.respObj = _res;

                return response;
            }
            catch (Exception ex)
            {
                response.respCode = SystemResponse.SystemError;
                response.respMsg = SystemResponse.SystemErrorMsg;

                return response;
            }
        }
    }
}
