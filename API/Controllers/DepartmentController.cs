using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace API.Controllers
{
    public class DepartmentController : ApiController
    {
        DepartmentService departmentService = null;

        public DepartmentController()
        {
            departmentService = new DepartmentService();
        }

        public IHttpActionResult Get()
        {
            try
            {
                var departments = departmentService.GetAll();
                if (departments == null)
                    return NotFound();

                return Ok(departments);
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Exception - " + ex.Message));
            }
        }
    }
}
