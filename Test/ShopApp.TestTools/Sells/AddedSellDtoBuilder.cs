using ShopApp.Entities;
using ShopApp.Services.Sells.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.TestTools.Sells
{
    public class AddedSellDtoBuilder
    {
        private AddedSellDto _sell;
        public AddedSellDtoBuilder()
        {
            _sell = new AddedSellDto()
            {
                AccountingId = 0,
                Count = 0,
                CustomerName = "رضوی",
                ProductId = 0,
                DateTime = DateTime.UtcNow,
                NumberOfinvoiceSell = "123",
                Price = 0,
                ProductName="لنت ترمز",
                //AccountinginSell=
            };
        }

        public AddedSellDtoBuilder WithAccountingId(int accountinId)
        {
            _sell.AccountingId = accountinId;
            return this;
        }
        public AddedSellDtoBuilder WithProductId(int productId)
        {
            _sell.ProductId = productId;
            return this;
        }
        public AddedSellDtoBuilder WithCount(int count)
        {
            _sell.Count = count;
            return this;
        }

        public AddedSellDtoBuilder WithCustomerName(string customerName)
        {
            _sell.CustomerName = customerName;
            return this;
        }
      
        public AddedSellDtoBuilder WithDateTime(DateTime dateTime)
        {
            _sell.DateTime = dateTime;
            return this;
        } 
        public AddedSellDtoBuilder WithNumberOfinvoiceSell(string numberOfInvoiceSell)
        {
            _sell.NumberOfinvoiceSell = numberOfInvoiceSell;
            return this;
        }
        public AddedSellDtoBuilder WithProductName(string title)
        {
            _sell.ProductName = title;
            return this;
        }
        public AddedSellDtoBuilder WithPrice(double price)
        {
            _sell.Price = price;
            return this;
        }
        public AddedSellDto Build()
        {
            return _sell;
        }
    }

}
