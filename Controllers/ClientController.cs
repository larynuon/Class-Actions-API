using Class_Actions_API.Data;
using Class_Actions_API.Models;
using Class_Actions_API.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Class_Actions_API.Controllers
{
    public class ClientController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ClientController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(string firstName, string surname, State? state)
        {
            var stateList = new List<State>();
            //get list of states from the db
            var stateQuery= from c in _db.Clients
                           orderby c.State
                            select c.State;
            stateList.AddRange(stateQuery.Distinct());
            //used so that the view configure the column heading with the appopriate query string
            ViewBag.state = new SelectList(stateList);            
            IEnumerable<Client> clientObjList = _db.Clients;
            //filter view model
            if (!String.IsNullOrEmpty(firstName))
            {
                clientObjList = clientObjList.Where(x => x.FirstName == firstName);
            }
            if (!String.IsNullOrEmpty(surname))
            {
                clientObjList = clientObjList.Where(x => x.Surname == surname);
            }
            if (state!= null)
            {
                clientObjList = clientObjList.Where(x => x.State == state);
            }
            //show client list
            return View(clientObjList);
        }
        //GET-Create
        public IActionResult Create()
        {
            ClientVM clientVM = new ClientVM()
            {
                Client = new Client(),
            };
            //show create form for client
            return View(clientVM);
        }
        //POST-Create
        [HttpPost]
        //good practice for users who have a security token and are logged into the system
        [ValidateAntiForgeryToken]
        public IActionResult Create(ClientVM clientVmObj)
        {
            //server side validation
            if(ModelState.IsValid)
            {
                //make a client entry to the db
                _db.Clients.Add(clientVmObj.Client);
                _db.SaveChanges();
                //show updated client list
                return RedirectToAction("Index");
            }
            return View(clientVmObj.Client);           
        }
        //GET-Delete
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            //find client in db 
            var clientObj = _db.Clients.Find(Id);
            if (clientObj == null)
            {
                return NotFound();
            }
            //show delete form for client
            return View(clientObj);
        }
        //POST-Delete
        [HttpPost]
        //good practice for users who have a security token and are logged into the system
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? Id)
        {
            var clientObj = _db.Clients.Find(Id);
            if (clientObj == null)
            {
                return NotFound();
            }
            //remove client entry from db
            _db.Clients.Remove(clientObj);
            _db.SaveChanges();
            //show updated client list
            return RedirectToAction("Index");
        }
        // GET Update
        public IActionResult Update(int? Id)
        {  
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            ClientVM clientVM = new ClientVM()
            {
                Client = new Client()
            };
            //find the client in db
            clientVM.Client = _db.Clients.Find(Id);
            if (clientVM.Client == null)
            {
                return NotFound();
            }
            var claimsList = _db.Claims.Where(c => c.ClientId == Id);
            clientVM.ClaimList = claimsList;
            //show update form for client
            return View(clientVM);
        }
        // POST UPDATE
        [HttpPost]
        //good practice for users who have a security token and are logged into the system
        [ValidateAntiForgeryToken]
        public IActionResult Update(ClientVM clientVmObj)
        {
            //server side validation
            if (ModelState.IsValid)
            {
                //update client in db
                _db.Clients.Update(clientVmObj.Client);
                _db.SaveChanges();
                //show updated client list
                return RedirectToAction("Index");
            }
            return View(clientVmObj);
        }
    }
}
