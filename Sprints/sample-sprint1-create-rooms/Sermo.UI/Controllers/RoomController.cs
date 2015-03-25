using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics.Contracts;

using Sermo.Contracts;
using Sermo.UI.ViewModels;

namespace Sermo.UI.Controllers
{
    public class RoomController : Controller
    {
        public RoomController(IRoomRepository roomService)
        {
            Contract.Requires<ArgumentNullException>(roomService != null);

            this.roomRepository = roomService;
        }
        
        [HttpGet]
        public ActionResult List()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new CreateRoomViewModel());
        }

        [HttpPost]
        public ActionResult Create(CreateRoomViewModel model)
        {
            ActionResult result;
 
            if(ModelState.IsValid)
            {
                roomRepository.CreateRoom(model.NewRoomName);

                result = RedirectToAction("List");
            }
            else
            {
                result = View("Create", model);
            }

            return result;
        }

        private readonly IRoomRepository roomRepository;
    }
}