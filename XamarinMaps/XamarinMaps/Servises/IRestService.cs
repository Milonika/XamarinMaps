using System;
using System.Collections.Generic;
using System.Text;
using XamarinMaps.Model;
using System.Threading.Tasks;

namespace XamarinMaps.Servises
{
    public interface IRestService
    {
        Task<Rootobject> GetTodoItemAsync(string item);
    }
}
