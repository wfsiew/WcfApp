using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfApp.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ICarService
    {
        [OperationContract]
        void insertCar(CarRecord r);

        [OperationContract]
        List<CarRecord> GetCars(int page, int pageSize);
    }

    [DataContract]
    public class CarRecord
    {
        [DataMember]
        public int ID;
        [DataMember]
        public string Make;
        [DataMember]
        public string Model;
        [DataMember]
        public int Year;
        [DataMember]
        public int Doors;
        [DataMember]
        public string Colours;
        [DataMember]
        public double Price;
    }
}