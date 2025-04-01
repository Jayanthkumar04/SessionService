using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Session2Service
{
    [ServiceContract(SessionMode=SessionMode.Required)]
    public interface IService1
    {

        [OperationContract(IsInitiating =true)]
        
        void save(Course course);

        [OperationContract(IsTerminating =true)]

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
