using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EvroValExport.Models;

namespace EvroValExport.Models
{
    public class Workers
    {
        public int Id { get; set; }
        //Информация о работнике
        public string FIO { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        //Работа
        public string Position { get; set; }
        public decimal SumWork { get; set; }
        //Время работы
        public decimal StartTime { get; set; }
        public decimal EndTime { get; set; }
        public decimal CurrentTime { get; set; }


        decimal? TTime { get; set; }
       
        private decimal CalculateTotalTime()
        {
          
            return  Convert.ToDecimal(CurrentTime + (EndTime - StartTime));
            
        }
       
        public decimal? TotalTime
        {
            get
            {
               
                TTime = null;
                if (TTime == null)
                {
                    
                    TTime = CalculateTotalTime();
                }
                else
                    TTime = null;
                return TTime;
            }

            set
            {
                if (value != null)
                    TTime = value;
                
            }
        }

        decimal? TSalary { get; set; }
        private decimal CalculateTotalSalary()
        {
            return Convert.ToDecimal(TotalTime * SumWork);
        }

        public decimal? TotalSalary
        {
            get
            {
                TSalary = null;
                if (TSalary == null)
                    TSalary = CalculateTotalSalary();
                else
                    TSalary = null; 
                return TSalary;
            }

            set
            {
                if (value != null)
                    TSalary = value;

                else
                    TSalary = CalculateTotalSalary();
            }
        }

    }
}