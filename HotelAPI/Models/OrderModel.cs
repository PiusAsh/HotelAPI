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
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Phone { get; set; }
        public int User_Id { get; set; }
        public int Room_Id { get; set; }
        public DateTime Book_Date { get; set; }
        public string Payment_Id { get; set; }
        public int Total_Price { get; set; }
        public string Status { get; set; }
        public DateTime EndDate { get; set; }
        

    }
}
