using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Session2Service
{
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        void save(Course course);

        [OperationContract]

         List<Course> getCourses();


    }

    [DataContract]
    public class Course
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}
