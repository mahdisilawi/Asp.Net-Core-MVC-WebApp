﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMarket.Models
{
	public class OrderDetails
	{
		[Key]
        public int Id { get; set; }

        public int OrderId { get; set; }

		[ForeignKey("OrderId")]
		public OrderHeader OrderHeader { get; set; }

		[Required]
		public int ProductId { get; set; }

		[ForeignKey("ProductId")]
		public Product Product { get; set; }

        public int Count { get; set; }

		public double Price { get; set; }


	}
}
