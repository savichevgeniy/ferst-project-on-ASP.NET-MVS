using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvroValExport.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public string Content { get; set; }
        public DateTime DateNotification { get; set; }
        public bool Notific { get; set; }

        public void Notification(bool Notific)
        {
            if (DateNotification == DateTime.Now)
            {
                Notific = true;
            }
            else Notific = false;
            
        }
        
    }

    
}