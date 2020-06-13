using System;
using System.ComponentModel.DataAnnotations;

namespace Warehouse.Web.Models
{
    public class Order
    {
        [Key]
        public long OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public long EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string DeliveryAddress { get; set; }
        public string DeliveryCity { get; set; }
        public decimal OrderExpences { get; set; }
        public PaymentType PaymentType { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Notes { get; set; }
        public decimal TotalPrice{ get; set; }
        public long ClientId { get; set; }
        public Client Client { get; set; }
    }

    public enum PaymentType
    {
        Cash,
        Check,
        BankTransfer
    }
}
