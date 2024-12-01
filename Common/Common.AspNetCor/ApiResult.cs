using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.AspNetCor
{
    public class ApiResult
    {
        public bool IsSuccess { get; set; }
        public MetaData MetaData { get; set; }
    }  
    
    public class ApiResult<TData>
    {
        public bool IsSuccess { get; set; }
        public TData Data { get; set; }
        public MetaData MetaData { get; set; }
    }  
    
    public class MetaData
    {
        public string Message { get; set; }
        public AppStatusCode AppStatusCode  { get; set; }
    }

    public enum AppStatusCode
    {
        Success = 1,
        NotFound=2,
        BadRequest=3,
        LogicError=4,
        UnAuthorize=5,
        ServerError=6

    }
}
