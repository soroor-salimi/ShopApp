using ShopApp.Entities;
using ShopApp.Services.Sells.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.TestTools.Sells
{
    public class AddedSellWithAccountigBuilderDto
    {
        private AddedSellWithAccountigDto _sell;
        public AddedSellWithAccountigBuilderDto()
        {
            _sell = new AddedSellWithAccountigDto()
            {
                Count = 0,
                CustomerName = "رضوی",
                ProductId = 0,
                DateTime = DateTime.UtcNow,
                NumberOfinvoiceSell = "123",
                Price = 0,
                ProductName="لنت ترمز",
            };
        }

     
        public AddedSellWithAccountigBuilderDto WithProductId(int productId)
        {
            _sell.ProductId = productId;
            return this;
        }
        public AddedSellWithAccountigBuilderDto WithCount(int count)
        {
            _sell.Count = count;
            return this;
        }

        public AddedSellWithAccountigBuilderDto WithCustomerName(string customerName)
        {
            _sell.CustomerName = customerName;
            return this;
        }
      
        public AddedSellWithAccountigBuilderDto WithDateTime(DateTime dateTime)
        {
            _sell.DateTime = dateTime;
            return this;
        } 
        public AddedSellWithAccountigBuilderDto WithNumberOfinvoiceSell(string numberOfInvoiceSell)
        {
            _sell.NumberOfinvoiceSell = numberOfInvoiceSell;
            return this;
        }
        public AddedSellWithAccountigBuilderDto WithProductName(string title)
        {
            _sell.ProductName = title;
            return this;
        }
        public AddedSellWithAccountigBuilderDto WithPrice(double price)
        {
            _sell.Price = price;
            return this;
        }
        public AddedSellWithAccountigDto Build()
        {
            return _sell;
        }
    }

}
