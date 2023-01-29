using PaymentAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentAPI.Interface
{
    public interface IPaymentDetailRepository 
    {
        Task<List<PaymentDetail>> GetAllPaymentDetailsAsync();
        Task<List<PaymentDetail>> GetAllPaymentDetailsByIdAsync(int id);
        Task<List<PaymentDetail>> AddPaymentDetailsAsync(PaymentDetail detail);
        Task<List<PaymentDetail>> DeleteAllPaymentDetailsByIdAsync(int id);
        Task<List<PaymentDetail>> UpdatePaymentDetailsAsync(PaymentDetail detail);
    }
}
