using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopigStore.Data;
using ShopigStore.Dto;
using ShopigStore.Model;

namespace ShopigStore.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IProjectRepo _repository;

        public IMapper _mapper { get; }

        public UserController(IProjectRepo repository,IMapper mapper)
        {
            _repository=repository;
            _mapper=mapper;
        }

        [HttpGet]
        public ActionResult getAllUsers(){
            return Ok(_repository.getAllUser());
        }
        [HttpGet("{id}")]
        public ActionResult GetUserById(int id){
            var resp = _repository.GetUserById(id);
            if(resp == null) return NotFound();
            return Ok(resp);
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public ActionResult Authenticate(UserCred user){
           var resp = _repository.AuthenticationManager(user.Email, user.Password);
           if(resp == null) return BadRequest();
           return Ok(resp);
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult CreateUser(User user){
            var resp =_repository.CreateUser(user);
            if(!resp) return BadRequest("Email is Alreadyin use");
            _repository.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id,UpdateUser user){
            var resp = _repository.GetUserById(id);
            user.UpdatedAt = DateTime.Now;
            _mapper.Map(user,resp);
            _repository.UpdateUser(resp);
            _repository.SaveChanges();

            return NoContent();
        }
        // Create User Intrust
        [HttpGet("/api/userIntrust/{uid}/{intrusti}")]
        public ActionResult CreateUserIntrust(int uid,string intrusti){
            var intrust = new Intrust{
                UserId=uid,
                FeildOfIntrust=intrusti
            };
            _repository.CreateIntrust(intrust);
            _repository.SaveChanges();

            return Ok();
        }

        [HttpPut("/api/updateUserIntrust/{uid}/")]
        public ActionResult UpdateUserIntrust(int uid,UpdateUserIntrust user){
            var resp = _repository.GetUserById(uid);
            _mapper.Map(user,resp);
            _repository.UpdateUser(resp);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpPost("login")]
        public ActionResult LoginRoute(UserCred user) {
            var resp = _repository.SignInRoute(user.Email,user.Password);
            // if(resp == null) return BadRequest("Can't login");
            return Ok(resp);
        }
    }
}