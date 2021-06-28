using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICalculateService" in both code and config file together.
[ServiceContract]
public interface ICalculateService
{
    [OperationContract]
    int Add(int x, int y);
    [OperationContract]
    int Subtract(int x, int y);
    int Multiply(int x, int y);
    [OperationContract]
    decimal Divide(int x, int y);
}
