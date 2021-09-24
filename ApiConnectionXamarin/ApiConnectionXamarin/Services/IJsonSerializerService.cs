using System;
using System.Collections.Generic;
using System.Text;

namespace ApiConnectionXamarin.Services
{
    interface IJsonSerializerService
    {
        string Serialize(object payload);
        T Deserialize<T>(string payload);

    }
}
