using SITE.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SITE.Domain
{
    public class DataManager
    {
        public ITextFieldsRepository TextFields { get; set; }
        public IServiceItemsRepository ServiceItems { get; set; }
        public IOrdersRepository Orders { get; set; }

        public DataManager(ITextFieldsRepository textFieldsReposytory, IServiceItemsRepository serviceItemReposytory, IOrdersRepository orderRepository)
        {
            TextFields = textFieldsReposytory;
            ServiceItems = serviceItemReposytory;
            Orders = orderRepository;
        }
    }
}
