using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jose;

namespace AnkietyUW.Utilities
{
    public class JwtUtility : IJwtUtility
    {

        public JwtUtility()
        {
            _secretKey = new byte[] {

                197, 66 , 218, 166 ,131,
                152, 74 , 205, 236 ,20,
                21  ,202 ,251, 96 , 177,
                79 , 152, 203, 233, 87,
                191, 125, 189, 231, 219,
                176, 48 , 97 , 240, 231,
                135, 92};

        }

        private readonly byte[] _secretKey;

        public Dictionary<string, string> Decode(string token)
        {
            var dictionary = Jose.JWT.Decode<Dictionary<string, string>>(token, _secretKey, JwsAlgorithm.HS256);

            return dictionary;
        }

        public string Encode(Dictionary<string, string> payload)
        {
            var token = Jose.JWT.Encode(payload, _secretKey, JwsAlgorithm.HS256);
            return token;
            
        }
    }
}
