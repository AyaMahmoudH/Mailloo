﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Mailo.Data.Enums;

namespace Mailo.Models
{
	public class Payment
	{
		[Key]
		public int ID { get; set; }
		public double TotalPrice { get; set; }
		//[EnumDataType(typeof(PaymentMethod))]
		//public PaymentMethod PaymentMethod { get; set; }
		[EnumDataType(typeof(PaymentStatus))]
		public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Pending;
		[ForeignKey("user")]
		public int UserID { get; set; }
		public User user { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    } 
}
