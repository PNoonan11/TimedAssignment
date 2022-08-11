using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimedAssignment.Services.Comment;

namespace TimedAssignment.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ICommentService _service;
        public UserController(ICommentService service)
        {
            _service = service;
        }
    }
}
