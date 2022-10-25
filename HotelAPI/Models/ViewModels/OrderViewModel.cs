using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelAPI.Models.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int TotalPrice { get; set; }
        public string PaymentId { get; set; }
        public DateTime BookDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public List<CartItemViewModel> Items { get; set; }

    }
}


