//using ShopApp.Services.Accountings.Contracts.Dto;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ShopApp.TestTools.Accountings
//{
//    public class AddedAccountingDtoBuilder
//    {

//        private AddedAccountingDto _accounting;

//        public AddedAccountingDtoBuilder()
//        {
//            _accounting = new AddedAccountingDto()
//            {
//               TotalPrice= 0,
//               NumberOfinvoiceSell="123",
//               DocumentRegistrationDate= DateTime.UtcNow,
//               NumberOfDocument=0,
//            };
//        }


//        public AddedAccountingDtoBuilder WithNumberOfinvoiceSell
//            (string numberOfinvoiceSell)
//        {
//            _accounting.NumberOfinvoiceSell = numberOfinvoiceSell;
//            return this;
//        }
//        public AddedAccountingDtoBuilder WithTotalPrice(double totalPrice)
//        {
//            _accounting.TotalPrice = totalPrice;
//            return this;
//        }
//        public AddedAccountingDtoBuilder WithNumberOfDocument(int numberOfDocument)
//        {
//            _accounting.NumberOfDocument = numberOfDocument;
//            return this;
//        }
//        public AddedAccountingDtoBuilder WithDocumentRegistrationDate
//            (DateTime documentRegistrationDate)
//        {
//            _accounting.DocumentRegistrationDate = documentRegistrationDate;
//            return this;
//        }
//        public AddedAccountingDto Build()
//        {
//            return _accounting;
//        }
    
//    }
//}
