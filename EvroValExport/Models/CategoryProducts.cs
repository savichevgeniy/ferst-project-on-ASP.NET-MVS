using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvroValExport.Models
{
    public class CategoryProducts
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Material { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        decimal? TSum { get; set; }
        public virtual Decimal CalculateTotalSum()
        {
            return Price * Quantity;
        }

        public decimal? TotalSum

        {
            get
            {
                if (TSum == null)
                    TSum = CalculateTotalSum();
                else
                    TSum = null; 
                return TSum;
            }

            set
            {
                if (value == null)
                    TSum = value;
               
                else
                    TSum = CalculateTotalSum();
            }

        }
    }
} 