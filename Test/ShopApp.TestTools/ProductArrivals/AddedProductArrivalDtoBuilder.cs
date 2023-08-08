using ShopApp.Entities;
using ShopApp.Services.ProductArrivals.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.TestTools.ProductArrivals
{
    public class AddedProductArrivalDtoBuilder
    {
        private AddedProductArrivalDto _productArrival;

        public AddedProductArrivalDtoBuilder()
        {
            _productArrival = new AddedProductArrivalDto()
            {
                NameCompany = "فپکو",
                ProductId = 0,
                Count = 0,             
                NumberOfInvoice = "123a",
                DateTime = DateTime.UtcNow,

            };
        }


        public AddedProductArrivalDtoBuilder WithNameCompany(string nameCompany)
        {
            _productArrival.NameCompany = nameCompany;
            return this;
        }
        public AddedProductArrivalDtoBuilder WithProductId(int productId)
        {
            _productArrival.ProductId = productId;
            return this;
        }
        public AddedProductArrivalDtoBuilder WithCount(int count)
        {
            _productArrival.Count = count;
            return this;
        }

        public AddedProductArrivalDtoBuilder WithNumberOfInvoice(string numberOfInvoice)
        {
            _productArrival.NumberOfInvoice = numberOfInvoice;
            return this;
        } 
      public AddedProductArrivalDtoBuilder WithDateTime(DateTime dateTime)
        {
            _productArrival.DateTime = dateTime;
            return this;
        }
        public AddedProductArrivalDto Build()
        {
            return _productArrival;
        }
    }

}
