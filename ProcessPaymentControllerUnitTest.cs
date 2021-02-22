using System;
using filed.Controllers;
using filed.Domain.Services;
using Xunit;
using Moq;
using AutoMapper;
using filed.Domain.Models;
using filed.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace filed
{
    public class ProcessPaymentController_Test
    {
        [Fact]
        public async System.Threading.Tasks.Task Test1Async()
        {
            // Arrange

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<Payment>(It.IsAny<PaymentResource>()));

            PaymentResource tester = new PaymentResource();
            tester.Amount = 0.0F;
            tester.CreditCardNumber = "CCCC CCCC CCCC CCCC CCC";
            tester.CardHolder = "FOO BAR";
            tester.ExpirationDate = new DateTime(2021, 11, 1);
            tester.SecurityCode = "xxx";

            var testPayment = new Payment();

            mockMapper.Setup(mock => mock.Map<Payment>(It.IsAny<PaymentResource>())).Returns(testPayment);

            var testPaymentState = new PaymentState();
            testPaymentState.PaymentStatus = StatusUnit.Processed;

            var mocService = new Mock<IProcessPaymentService>();
            var state = mocService.Setup(s => s.ProcessPayment(testPayment)).ReturnsAsync(testPaymentState);


            ProcessPaymentController _processPaymentController = new ProcessPaymentController(mocService.Object, mockMapper.Object);

            // Act

            var result = await _processPaymentController.ProcessPayment(tester);

            //Assert
            var okResult = result as ObjectResult;
            Assert.NotNull(okResult);

            var model = okResult.StatusCode;
            Assert.False(model.Equals(200));

        }
    }
}
