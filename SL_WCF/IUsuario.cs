using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUsuario" in both code and config file together.
    [ServiceContract]
    public interface IUsuario
    {

        [OperationContract]
        SL_WCF.Result AddUsuario(ML.Usuario usuario);

        [OperationContract]

        SL_WCF.Result DeleteUsuario(int IdUsuario);

        [OperationContract]
        SL_WCF.Result UpdateUsuario(ML.Usuario usuario);


        [OperationContract]
        [ServiceKnownType(typeof(ML.Usuario))]
        SL_WCF.Result GetByIdUsuario(int IdUsuario);

        [OperationContract]
        [ServiceKnownType(typeof(ML.Usuario))]
        SL_WCF.Result GetAllUsuario();

    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Result
    {
        [DataMember]
        public bool correct { set; get; }

        [DataMember]
        public string ErrorMessage { set; get; }

        [DataMember]
        public object Object { set; get; }

        [DataMember]
        public List<object> Objects { set; get; }

        [DataMember]
        public Exception ex { set; get; }

    }
}

