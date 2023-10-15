using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ResponseResult
{
    public interface IResponseResult<T>
    {
        public T Data { get; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }
}
