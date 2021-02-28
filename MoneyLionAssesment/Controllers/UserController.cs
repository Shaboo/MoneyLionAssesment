using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoneyLionAssesment.DTO.User;
using MoneyLionAssesment.Models;
using MoneyLionAssesment.Repository;

namespace MoneyLionAssesment.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepo;

        private readonly IMapper mapper;
        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepo = userRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        public ActionResult<UserReadDTO> CreateUser(UserCreateDTO userCreateDto)
        {
            try
            {
                var user = mapper.Map<User>(userCreateDto);

                userRepo.CreateUser(user);

                if (userRepo.SaveChanges())
                {
                    return Ok(mapper.Map<UserReadDTO>(user));
                }

                return BadRequest();
            }
            catch (BadHttpRequestException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
