using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Session2Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    //[ServiceBehavior(InstanceContextMode=InstanceContextMode.PerCall)]
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single)]
    public class Service1 : IService1
    {
        public List<Course> courses;
        Service1()
        {
            courses = new List<Course>();

        }
        public  List<Course> getCourses()
        {
            return courses;
        }

        public void save(Course course)
        {
            courses.Add(course);
        }
    }
}
