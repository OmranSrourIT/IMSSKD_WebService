using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSSKD_WebService.Controllers
{
    public class ApiResponseResult
    {
      
        public string DataMessage  { get; set; }
        public string ErrorCode { get; set; }
        public Boolean IsError { get; set; }
    }
}