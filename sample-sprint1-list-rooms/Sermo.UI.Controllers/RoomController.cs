using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics.Contracts;

using Sermo.UI.Contracts;
using Sermo.UI.ViewModels;

namespace Sermo.UI.Controllers
{
    public class RoomController : Controller
    {
        public RoomController(IRoomViewModelReader reader, IRoomViewModelWriter writer)
        {
            Contract.Requires<ArgumentNullException>(reader != null);
            Contract.Requires<ArgumentNullException>(writer != null);

            this.reader = reader;
            this.writer = writer;
        }
        
        [HttpGet]
        public ActionResult List()
        {
            var roomListViewModel = new RoomListViewModel(reader.GetAllRooms());
            
            return View(roomListViewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new RoomViewModel());
        }

        [HttpPost]
        public ActionResult Create(RoomViewModel model)
        {
            ActionResult result;
 
            if(ModelState.IsValid)
            {
                writer.CreateRoom(model.Name);

                result = RedirectToAction("List");
            }
            else
            {
                result = View("Create", model);
            }

            return result;
        }

        private readonly IRoomViewModelReader reader;
        private readonly IRoomViewModelWriter writer;
    }
}