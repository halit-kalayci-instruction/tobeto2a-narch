using Application.Services.PaymentService;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Adapters.Payment;
public class IyziCoPaymentAdapter : PaymentServiceBase
{
    public override Task<bool> Pay(string cardHolderName, string creditCartNo, string cvc, double price, DateTime expiryDate)
    {
        // ÖNEMLİ : REFACTOR ETMEDEN KULLANMA !!
        // appsettings.json!
        Options options = new Options();
        options.ApiKey = "keyiniz";
        options.SecretKey = "secretkeyiniz";
        options.BaseUrl = "https://sandbox-api.iyzipay.com";

        CreatePaymentRequest request = new CreatePaymentRequest();
        request.Locale = Locale.TR.ToString();
        request.ConversationId = "123456789";
        request.Price = price.ToString();
        request.PaidPrice = (price + (price*0.2)).ToString();
        request.Currency = Currency.TRY.ToString();
        request.Installment = 1;
        request.BasketId = "B67832";
        request.PaymentChannel = PaymentChannel.WEB.ToString();
        request.PaymentGroup = PaymentGroup.PRODUCT.ToString();

        Buyer buyer = new Buyer();
        buyer.Id = "BY789";
        buyer.Name = "John";
        buyer.Surname = "Doe";
        buyer.GsmNumber = "+905350000000";
        buyer.Email = "email@email.com";
        buyer.IdentityNumber = "74300864791";
        buyer.LastLoginDate = "2015-10-05 12:43:35";
        buyer.RegistrationDate = "2013-04-21 15:12:09";
        buyer.RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
        buyer.Ip = "85.34.78.112";
        buyer.City = "Istanbul";
        buyer.Country = "Turkey";
        buyer.ZipCode = "34732";
        request.Buyer = buyer;

        Address shippingAddress = new Address();
        shippingAddress.ContactName = "Jane Doe";
        shippingAddress.City = "Istanbul";
        shippingAddress.Country = "Turkey";
        shippingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
        shippingAddress.ZipCode = "34742";
        request.ShippingAddress = shippingAddress;

        Address billingAddress = new Address();
        billingAddress.ContactName = "Jane Doe";
        billingAddress.City = "Istanbul";
        billingAddress.Country = "Turkey";
        billingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
        billingAddress.ZipCode = "34742";
        request.BillingAddress = billingAddress;

        PaymentCard paymentCard = new PaymentCard();
        paymentCard.CardHolderName = cardHolderName;
        paymentCard.CardNumber = creditCartNo;
        paymentCard.ExpireMonth = expiryDate.Month.ToString();
        paymentCard.ExpireYear = expiryDate.Year.ToString();
        paymentCard.Cvc = cvc;
        paymentCard.RegisterCard = 0;

        List<BasketItem> basketItems = new List<BasketItem>();
        BasketItem firstBasketItem = new BasketItem();
        firstBasketItem.Id = "BI101";
        firstBasketItem.Name = "Binocular";
        firstBasketItem.Category1 = "Collectibles";
        firstBasketItem.Category2 = "Accessories";
        firstBasketItem.ItemType = BasketItemType.VIRTUAL.ToString();
        firstBasketItem.Price = price.ToString();
        basketItems.Add(firstBasketItem);

        request.BasketItems = basketItems;

        request.PaymentCard = paymentCard;

        Iyzipay.Model.Payment payment = Iyzipay.Model.Payment.Create(request, options);

        return Task.FromResult(payment.Status == Status.SUCCESS.ToString());
    }
}
