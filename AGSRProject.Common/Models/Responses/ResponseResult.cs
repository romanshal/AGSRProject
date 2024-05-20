using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGSRProject.Common.Models.Responses
{
    public class ResponseResult<T> : Response
    {
        public T? Result { get; set; }

        public ResponseResult(T result, string desctiption, bool isError) : base(desctiption, isError)
        {
            Result = result;
        }
    }
}
