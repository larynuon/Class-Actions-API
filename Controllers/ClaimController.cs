using Class_Actions_API.Data;
using Class_Actions_API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Class_Actions_API.Controllers
{
    public class ClaimController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ClaimController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Claim> claimObjList = _db.Claims;
            //show claims list
            return View(claimObjList);
            
        }
        // GET-Create
        public IActionResult Create(int clientId)
        {
            if (clientId == 0)
            {
                return NotFound();
            }
            // pass the clientId to the claims form
            Claim claimObj = new Claim();
            claimObj.ClientId = clientId;            
            //show create form for claim
            return View(claimObj);
        }
        // POST-Create
        [HttpPost]
        //good practice for users who have a security token and are logged into the system
        [ValidateAntiForgeryToken]
        public IActionResult Create(Claim claimObj)
        {
            //server side validation
            if (ModelState.IsValid)
            {
                // find the client in db
                var clientObj = _db.Clients.Find(claimObj.ClientId);
                if (clientObj == null)
                {
                    return NotFound();
                }
                //add the client to the claim
                claimObj.Client = clientObj;
                claimObj.TotalClaimCost = claimObj.FencingCost + claimObj.GroundsCost + claimObj.LabourCost;
                //make a claim entry to the db
                _db.Claims.Add(claimObj);
                _db.SaveChanges();
                //show updated claim list for client
                return Redirect("../Client/Update/"+ claimObj.ClientId);
            }
            return View(claimObj);           
        }
        // GET-Delete
        public IActionResult Delete(int? Id)
        {           
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            //find the claim in db
            var claimObj = _db.Claims.Find(Id);
            if(claimObj == null)
            {
                return NotFound();
            }
            //show delete form for claim
            return View(claimObj);
        }
        // POST-Delete
        [HttpPost]
        //good practice for users who have a security token and are logged into the system
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? Id)
        {
            //find the claim in db
            var claimObj = _db.Claims.Find(Id);
            if(claimObj == null)
            {
                return NotFound();
            }
            //remove the claim entry from db
            _db.Claims.Remove(claimObj);
            _db.SaveChanges();
            //show updated claim list
            return Redirect("../Client/Update/" + claimObj.ClientId);

        }
        // GET-Update
        public IActionResult Update(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            //find the claim in db
            var claimObj = _db.Claims.Find(Id);
            if (claimObj == null)
            {
                return NotFound();
            }
            //show update form for claim
            return View(claimObj);
        }
        // POST-UPDATE
        [HttpPost]
        //good practice for users who have a security token and are logged into the system
        [ValidateAntiForgeryToken]
        public IActionResult Update(Claim claimObj)
        {
            //server side validation
            if (ModelState.IsValid)
            {
                claimObj.TotalClaimCost = claimObj.FencingCost + claimObj.GroundsCost + claimObj.LabourCost;
                //update claim in db
                _db.Claims.Update(claimObj);
                _db.SaveChanges();
                //show updated claim list for client
                return Redirect("../../Client/Update/" + claimObj.ClientId);
            }
            return View(claimObj);

        }
    }
}
