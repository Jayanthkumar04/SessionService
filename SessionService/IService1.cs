using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SessionService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
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
