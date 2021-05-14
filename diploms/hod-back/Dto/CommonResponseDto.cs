using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.Dto
{
    public class CommonResponseDto
    {
        public CommonResponseDto(string message) { this.Message = message; }
        public CommonResponseDto(bool done, string path, string message = "")
        {
            this.Done = done;
            this.Path = path;
            this.Message = message;
        }

        public bool Done { get; set; }
        public string Path { get; set; }
        public string Message { get; set; }
    }
}
