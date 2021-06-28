using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CalculateService" in code, svc and config file together.
public class CalculateService : ICalculateService
{
    public int Add(int x, int y)
    {
        return x + y;
    }

    public decimal Divide(int x, int y)
    {
        return Convert.ToDecimal(x / y);
    }

    public int Multiply(int x, int y)
    {
        return x * y;
    }

    public int Subtract(int x, int y)
    {
        return x - y;
    }
}
