using System;
using System.Collections.Generic;
using System.Text;
using ProjetoFinal.Entities.Enums;
using System.Globalization;

namespace ProjetoFinal.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public Client Client { get; set; } 
        public Product Product { get; set; } 

        public Order()
        {
        }

        public Order(OrderStatus status, Client client, DateTime moment)
        {
            Status = status;
            Moment = moment;
            Client = client;

        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }

        public double Total()
        {
            double sum = 0;
            foreach(OrderItem item in Items)
            {
                sum += item.SubTotal();
            }
            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ORDER SUMMARY:");
            sb.Append("Order moment: ");
            sb.AppendLine(Moment.ToString("dd/MM/yyyy HH:mm:ss "));
            sb.Append("Order status: ");
            sb.AppendLine(Status.ToString());
            sb.AppendLine("Client: " + Client);
            sb.AppendLine("Order items:");
            
            foreach(OrderItem item in Items)
            {
                sb.AppendLine(item.ToString());
            }
            sb.Append("Total Price: ");
            sb.Append(Total().ToString("F2", CultureInfo.InvariantCulture));

            return sb.ToString();
        }
    }
}
