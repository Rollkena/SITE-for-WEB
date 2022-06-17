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
        public IOrderRepository Order { get; set; }

        public DataManager(ITextFieldsRepository textFieldsReposytory, IServiceItemsRepository serviceItemReposytory)
        {
            TextFields = textFieldsReposytory;
            ServiceItems = serviceItemReposytory;
        }
    }
}
