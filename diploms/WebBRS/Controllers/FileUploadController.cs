using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.Controllers
{
	[Route("api/fileupload")]
	[ApiController]
	public class FileUploadController : ControllerBase
	{
		[HttpPost("UploadSecond")]
		[DisableRequestSizeLimit]
		public IActionResult UploadSecond(IFormFile file,  string filename)
		{
			return Ok();
		}
	}
}
