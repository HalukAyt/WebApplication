using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Entities.Concrete
{
    public class Testimonial: BaseModel
    {

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Comment { get; set; }
    }
}
