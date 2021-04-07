using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToCatchAGremlin.Models;

namespace ToCatchAGremlin.Controllers
{
    public class OfficerController : ApiController
    {
        //we need to reference the GremlinDbContext -> this is how we make database interactions...
        private readonly GremlinDBContext _context = new GremlinDBContext();

        //Create
        [HttpPost]
        public IHttpActionResult EnlistAnOfficer([FromBody] Officer model)
        {
            //check if the user didn't input anything...
            if (model is null)
            {
                return BadRequest("No data found");
            }
            if (ModelState.IsValid==false)
            {
                //anything missing in the model *body* will be displayed to the user
                return BadRequest(ModelState);
            }
            //adding to DbSet<Officer>...
            _context.Officers.Add(model);

            //save the changes.
            _context.SaveChanges();

            return Ok();

        }

        //Read All
        [HttpGet]
        public IHttpActionResult GetOfficers()
        {
            var officers = _context.Officers.ToList();
            if (officers is null)
            {
                return NotFound();
            }
            return Ok(officers);

        }

        //Read by Id
        [HttpGet]
        public IHttpActionResult GetOfficerById(int id)
        {
            var officer = _context.Officers.Find(id);
            if (officer is null)
            {
                return NotFound();
            }
            return Ok(officer);
        }

        //update
        [HttpPut]
        public IHttpActionResult UpdateOfficer(int id, Officer newOfficerData)
        {
            if (id<1)
            {
                return BadRequest("Invalid data entry...");
            }
            if (newOfficerData==null)
            {
                return NotFound();
            }
            if (id!=newOfficerData.Id)
            {
                return BadRequest("Ids dont match");
            }

            //search for  an existing officer....
            var oldOfficerData = _context.Officers.Find(id);

            if (oldOfficerData is null)
            {
                return NotFound();
            }

            //if it is found..
            oldOfficerData.Id = newOfficerData.Id;
            oldOfficerData.Name = newOfficerData.Name;
            oldOfficerData.ApprehenedGremlins = newOfficerData.ApprehenedGremlins;

            //save changes...
            _context.SaveChanges();

            return Ok("Success");
        }

        [HttpDelete]
        public IHttpActionResult DeleteOfficer(int id)
        {
            //check for id
            if (id<1)
            {
                return BadRequest("Invalid data entry");
            }

            var officer = _context.Officers.Find(id);
            if (officer is null)
            {
                return NotFound();
            }

            //if officer exist ... remove officer...
            _context.Officers.Remove(officer);

            //save changes
            _context.SaveChanges();

            return Ok("Success");

        }
    }
}
