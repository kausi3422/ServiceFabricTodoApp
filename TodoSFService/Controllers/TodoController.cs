using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoSFService.Interface;
using TodoSFService.Model;
using TodoSFService.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoSFService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TodoController : ControllerBase
	{

		private readonly TodoService _todoService;

		private readonly IRepository<Item> _item;

		public TodoController(IRepository<Item> Item, TodoService TodoService)
		{
			_todoService = TodoService;
			_item = Item;

		}


		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		//GET All Items
		[HttpGet("GetAllItems")]
		public Object GetAllPersons()
		{
			var data = _todoService.GetAllItems();
			var json = JsonConvert.SerializeObject(data, Formatting.Indented,
				new JsonSerializerSettings()
				{
					ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
				}
			);
			return json;
		}

		//GET All Items by Name
		[HttpGet("GetAllItemByName")]
		public Object GetAllItemsByName(string ItemName)
		{
			var data = _todoService.GetItemByItemName(ItemName);
			var json = JsonConvert.SerializeObject(data, Formatting.Indented,
				new JsonSerializerSettings()
				{
					ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
				}
			);
			return json;
		}



		// GET api/<TodoController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<TodoController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<TodoController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<TodoController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
