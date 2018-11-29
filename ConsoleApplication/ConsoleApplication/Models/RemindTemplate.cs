using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.Models
{
  public  class RemindTemplate
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public string Primary_industry { get; set; }
        public string Deputy_industry { get; set; }
        public string Content { get; set; }
        public string Example { get; set; }
    }
}
