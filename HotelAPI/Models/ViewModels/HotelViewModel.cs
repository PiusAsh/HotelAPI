using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelAPI.Models.ViewModels
{
    public class HotelViewModel
    {
        public int Id { get; set; }
        public string RoomName { get; set; }
        public string RoomType { get; set; }
        public string RoomDes { get; set; }
        public string RoomPrice { get; set; }
        public string RoomImg { get; set; }
    }
}
