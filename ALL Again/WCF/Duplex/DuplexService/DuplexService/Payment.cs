using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;


[DataContract]
public class Payment
{
   public Payment()
    {
        
    }
    [DataMember]
    public string CCCNO { get; set; }
    [DataMember]
    public string CCEXPMonth { get; set; }
    [DataMember]
    public string CCEXpYear { get; set; }
    [DataMember]
    public string TransactionID { get; set; }
    [DataMember]
    public string Status { get; set; }
    [DataMember]
    public string StatusMessage { get; set; }

}
