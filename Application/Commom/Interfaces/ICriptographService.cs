using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commom.Interfaces
{
    public interface ICriptographService
    {
        string Criptograph(string value);
        string Decriptograph(string value);
        string GetHash(string value);
        bool VerifyHash(string input, string hash);
    }
}
