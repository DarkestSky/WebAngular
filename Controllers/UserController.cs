using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebAngular.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            this._logger = logger;
        }
        
        public class LogForm
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }
        
        [HttpPost("/controller/user/login")]
        public IEnumerable<bool> Login([FromBody]LogForm logForm)
        {
            var res = Enumerable.Empty<bool>();
            return res.Append(logForm.UserName.Equals(logForm.Password)).ToArray();
        }

        public class RegisterForm
        {
            public string Username { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string Confirm { get; set; }
        }
        
        [HttpPost("/controller/user/register")]
        public IEnumerable<bool> Register([FromBody] RegisterForm registerForm)
        {
            var res = Enumerable.Empty<bool>();
            return res.Append(!registerForm.Username.Equals("test_fail")).ToArray();
        }

        [HttpGet("/controller/user/load-user-info")]
        public IEnumerable<UserInfo> LoadUserInfo()
        {
            var res = new UserInfo {Nickname = "nick_test", Birthday = "1999", AvatarUrl = "/avatar.png", RegisterData = "2020"};
            return Enumerable.Empty<UserInfo>().Append(res).ToArray();
        }

        [HttpPost("/controller/user/get-user-info")]
        public IEnumerable<UserItem> GetUserInfo([FromBody] UsernameModel usernameModel)
        {
            var res = new UserItem() {Nickname = "nick_" + usernameModel.Username, AvatarUrl = "/avatar.png"};
            return Enumerable.Empty<UserItem>().Append(res).ToArray();
        }

        public class UserInfo
        {
            public string Nickname { get; set; }
            public string AvatarUrl { get; set; }
            public string Birthday { get; set; }
            public string RegisterData { get; set; }
        }

        public class UserItem
        {
            public string Nickname { get; set; }
            public string AvatarUrl { get; set; }
        }

        public class UsernameModel
        {
            public string Username { get; set; }
        }
    }
}