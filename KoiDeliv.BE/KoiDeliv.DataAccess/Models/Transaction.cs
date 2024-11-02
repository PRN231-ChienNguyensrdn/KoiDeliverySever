using System;
using System.Collections.Generic;

namespace KoiDeliv.DataAccess.Models
{
    public partial class Transaction
    {
        public int PaymentId { get; set; }
        public string? PaymentMethod { get; set; }
        public string? BankCode { get; set; }
        public string? BankTranNo { get; set; }
        public string? CardType { get; set; }
        public string? PaymentInfor { get; set; }
        public DateTime? PayDate { get; set; }
        public string? TransactionNo { get; set; }
        public int? TransasctionStatus { get; set; }
        public int? PaymentAccount { get; set; }
        public int? OrderId { get; set; }

        public virtual Order? Order { get; set; }
    }
}
