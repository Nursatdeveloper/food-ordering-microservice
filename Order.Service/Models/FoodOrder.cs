﻿namespace Order.Service.Models
{
    public class FoodOrder
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Telephone { get; set; }
        public string DeliveryAddress { get; set; }
        public DateTime Date { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantAddress { get; set; }
        public string FoodCategory { get; set; }
        public string FoodName { get; set; }
        public string Status { get; set; }
        public string DeliveryCode { get; set; }

    }
}
