using hotelapp.Data.Repositories;
using hotelapp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hotelapp.Web.Controllers
{
    [Route("RoomSearch")]
    public class RoomSearchController : Controller
    {
        private readonly IBookingRepository _repo;
        public RoomSearchController(IBookingRepository repo)
        {
            _repo = repo;
        }


        public IActionResult Index()
        {
            var viewModel = new SearchViewModel();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AvailableRoomList(SearchViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var roomList = new AvailableRoomListViewModel()
                {
                    StartDate = vm.StartDate,
                    EndDate = vm.EndDate,
                    AvailableRoomTypes = _repo.GetAvailableRoomTypes(vm.StartDate, vm.EndDate).ToList()
                };

                return View(roomList);
            }

            return View("Index", vm);
        }

        [HttpPost("BookRoom/{roomTypeId}")]
        public IActionResult BookRoom(int roomTypeId, SearchViewModel vm)
        {

            var bookRoom = new BookRoomViewModel()
            {
                StartDate = vm.StartDate,
                EndDate = vm.EndDate,
                RoomTypeId = roomTypeId,
            };

            return View(bookRoom);
        }


        [HttpPost("Confirmed")]
        public IActionResult Confirmed(BookRoomViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("BookRoom", vm);
            }

            _repo.BookGuest(vm.FirstName, vm.LastName, vm.StartDate, vm.EndDate, vm.RoomTypeId);
            return View(vm);
        }

        [HttpGet("CheckIn")]
        public IActionResult CheckIn()
        {
            var vm = new CheckInViewModel();
            vm.Bookings = _repo.SearchBookings(vm.LastName);

            return View(vm);
        }

        [HttpPost("CheckIn")]
        public IActionResult CheckIn(CheckInViewModel vm)
        {
            vm.Bookings = _repo.SearchBookings(vm.LastName);

            return View(vm);
        }

        [HttpPost("CheckIn/{bookingId}")]
        public IActionResult FinallCheckIn(int bookingId)
        {
            _repo.CheckInGuest(bookingId);
            TempData["message"] = $"Reservation number {bookingId} was added";
            return RedirectToAction(nameof(CheckIn));
        }

        [HttpGet("AddRoom")]
        public IActionResult AddRoom()
        {

            var roomList = new RoomListViewModel()
            {
                RoomLists = _repo.GetAllRooms()
            };

            return View(roomList);
        }

        [HttpGet("Update/{id}")]
        public IActionResult Update(int id)
        {
            var room = _repo.Get(id);
            if (room == null)
            {
                return NotFound();
            }
            var viewModel = new RoomViewModel(room);

            return View(viewModel);
        }

        //[HttpGet("Update/{id}")]
        //public IActionResult Update(RoomViewModel viewModel)
        //{

        //    if (!ModelState.IsValid)
        //    {
        //        return View(viewModel);
        //    }

        //    return null;
        //}

    }
}
