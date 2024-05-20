using Microsoft.AspNetCore.Mvc;

namespace SimpleWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly MyDbContext context;

        public UsersController(MyDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return context.Users;
        }

        [HttpPost]
        public int Post(string username)
        {
            var user = new User()
            {
                UserName = username,
            };
            context.Users.Add(user);
            context.SaveChanges();
            return user.Id;
        }
    }
}
