using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelAPI.Models
{
    public class RoomModel
    {
        [Key]
        public int Id { get; set; }
        public string RoomName { get; set; }
        public string RoomType { get; set; }
        public string RoomDes { get; set; }
        public int RoomPrice { get; set; }
        public string RoomImg { get; set; }
        public Boolean Status { get; set; }

    }
}
