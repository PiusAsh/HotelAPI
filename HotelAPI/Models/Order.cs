using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelAPI.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int User_ID { get; set; }
        public int Room_Id { get; set; }
    }
}
