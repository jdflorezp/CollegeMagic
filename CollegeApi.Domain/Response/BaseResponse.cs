using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeApi.Domain.Response
{
    public class BaseResponse
    {
        public HeaderResponse header { get; set; }
        public object body { get; set; }
        public BaseResponse()
        {
            this.header = new HeaderResponse();
        }
    }
}
