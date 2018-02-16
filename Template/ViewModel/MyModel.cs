using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Template.Models;


namespace Template.ViewModel
{
    public class MyModel
    {
        public List<Blog> _blog { get; set; }
        public List<Category> _category { get; set; }
        public List<Contact> _contatc { get; set; }
        public IEnumerable<Feature_Boxes> _feature { get; set; }
        public List<Industry> _industry { get; set; }
        public IEnumerable<Message> _message { get; set; }
        public List<Service_Area_Contents> _service_area_content { get; set; }
        public List<Slider> _slider { get; set; }
        public IEnumerable<Testimonials_Slider> _testimonial { get; set; }
        public List<Service_Area> _service_area { get; set; }
        public List<Menu> _menu { get; set; }
    }
}