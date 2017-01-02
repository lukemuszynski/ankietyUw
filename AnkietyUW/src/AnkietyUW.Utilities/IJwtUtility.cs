using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnkietyUW.Utilities
{
    public interface IJwtUtility
    {

        Dictionary<string, string> Decode(string token);
        string Encode(Dictionary<string, string> payload);
    }
}
