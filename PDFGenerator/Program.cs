using System;
using System.Collections.Generic;
using PDFGenerator.DeliveryReceipt;
using PDFGenerator.OrderConfirmation;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace PDFGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Orden de confirmacion");
            OrderConfirmationModel data = new OrderConfirmationModel()
            {
                OrderNumber = 1234,
                IssueDate = DateTime.Now,
                OrderInformation = new OrderInformation(),
                Items = new List<OrderItem>(),
                Comments = "Recuerda que puedes hacerle seguimiento al pedido ingresando el numero de la orden en la pagina web: http://www.bufferorigin.com/seguimientopedidos/"
            };
            OrderConfirmationDocument order = new OrderConfirmationDocument(data);
            order.GeneratePdf("order.pdf");

            Console.WriteLine("Recibo de entrega");
            DeliveryReceiptModel dataDelivery = new DeliveryReceiptModel()
            {
                IssueDate = DateTime.Now
            };
            DeliveryReceiptDocument delivery = new DeliveryReceiptDocument(dataDelivery);
            delivery.GeneratePdf("delivery.pdf");
        }
    }
}
