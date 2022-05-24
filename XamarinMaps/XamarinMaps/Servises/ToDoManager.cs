using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinMaps.Model;
using XamarinMaps.Servises;

namespace XamarinMaps.Servises
{
    public class ToDoManager
    {
        IRestService service;

        public ToDoManager(IRestService restService)
        {
            service = restService;
        }
        public Task<Rootobject> GetTodoItemModels(string item)
        {
            return service.GetTodoItemAsync(item);
        }
    }
}
