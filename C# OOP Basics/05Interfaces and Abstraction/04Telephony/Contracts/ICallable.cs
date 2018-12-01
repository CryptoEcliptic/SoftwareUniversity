using System;
using System.Collections.Generic;
using System.Text;

namespace _04Telephony.Contracts
{
    public interface ICallable
    {
        void Call(string number);
    }
}
