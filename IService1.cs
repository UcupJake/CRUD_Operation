using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CRUD_Operation
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string Insert(InsertUser value);

        [OperationContract]
        gettestdata GetInfo();

        [OperationContract]
        string Update(UpdateUser update);

        [OperationContract]
        string Delete(DeleteUser delete);

//        [OperationContract]
//        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class InsertUser
    {
        //        bool boolValue = true;
        //        string stringValue = "Hello ";

        string name = string.Empty;
        string email = string.Empty;

//        [DataMember]
//        public bool BoolValue
//        {
//            get { return boolValue; }
//            set { boolValue = value; }
//        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

    }

    [DataContract]
    public class gettestdata
    {
        [DataMember]
        public DataTable usertab
        {
            get;
            set;
        }
    }

    [DataContract]
    public class UpdateUser
    {
        int uid;
        string name;
        string email;

        [DataMember]
        public int UID
        {
            get { return uid; }
            set { uid = value; }
        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

    }

    [DataContract]
    public class DeleteUser
    {
        int uid;

        [DataMember]
        public int UID
        {
            get { return uid; }
            set { uid = value; }
        }
    }
}
