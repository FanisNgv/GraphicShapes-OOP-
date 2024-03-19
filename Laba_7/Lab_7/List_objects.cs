using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary_1;

namespace MyLab1
{
    class List_objects
    {
        public List_objects(Abstract_properties data)
        {
            Data = data;
        }
        public Abstract_properties Data { get; set; }
        public List_objects Next { get; set; }
    }
    
}
