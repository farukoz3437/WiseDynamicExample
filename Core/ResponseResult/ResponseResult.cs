using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ResponseResult
{
    public class ResponseResult<T>: IResponseResult<T>
    {
        public ResponseResult()
        {  
        }
        public ResponseResult(T data)
        {
                Data = data;
        }
        public ResponseResult(T data,bool isSuccess)
        {
            Data = data;
            IsSuccess = isSuccess;
        }
        public ResponseResult(T data, bool isSuccess,string message)
        {
            Data = data;
            IsSuccess = isSuccess;
            Message = message;
        }
        public ResponseResult(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }
        public ResponseResult(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }
        public T Data { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }
}
