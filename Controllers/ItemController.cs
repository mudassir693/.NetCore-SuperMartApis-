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
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IProjectRepo _repository;
        private readonly IMapper _mapper;

        public ItemController(IProjectRepo repository,IMapper mapper)
            {
                _repository=repository;
                _mapper=mapper;
            }

            [HttpGet]
            public ActionResult GetAllItems(){
                var resp = _repository.getAllItems();
                return Ok(resp);
            }
            [HttpGet("{id}")]
            public ActionResult GetItemById(int id){
                var resp = _repository.GetItemById(id);
                if(resp == null) return NotFound();
                return Ok(resp);
            }

            [HttpPost]
            public ActionResult CreateItem(Item item){
                var resp = _repository.CreateItem(item);
                if(!resp) return BadRequest();
                _repository.SaveChanges();

                return Ok();
            }

            [HttpPut("{id}")]
            public ActionResult UpdateItem(int id ,UpdateItem item){
                var resp = _repository.GetItemById(id);
                item.UpdateEntry = DateTime.Now;
                _mapper.Map(item,resp);
                _repository.UpdateItem(resp);

                _repository.SaveChanges();
                return NoContent();
            }

            [HttpGet("/api/getAllItem/{uid}")]
            public ActionResult TestingRoute(int uid){
                var resp = _repository.GetAllItemsForSpecificUser(uid);

                return Ok(resp);
            }
    }
}