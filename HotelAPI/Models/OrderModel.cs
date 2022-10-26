using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelAPI.Models.ViewModels
{
    public class OrderModel
    {
        [Key]
        public int Id { get; set; }
        public UserModel User { get; set; }
        public RoomModel Room { get; set; }
        public DateTime Book_Date { get; set; }
        public string Payment_Id { get; set; }
        public string Status { get; set; }
        public DateTime EndDate { get; set; }
        public int RoomPrice { get; set; } //per rom
        public int Days { get; set; }


    }
}
