using Microsoft.EntityFrameworkCore;
using PaymentAPI.Data;
using PaymentAPI.Interface;
using PaymentAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentAPI.DAL.Repositories
{
    public class PaymentDetailRepository : IPaymentDetailRepository
    {
        private readonly PaymentDetailContext _context;
        public PaymentDetailRepository(PaymentDetailContext context)
        {
            _context = context;
        }
        public async Task<List<PaymentDetail>> AddPaymentDetailsAsync(PaymentDetail detail)
        {
             _context.PaymentDetails.Add(detail);
            await _context.SaveChangesAsync();

_context.PaymentDetails.FromSqlRaw
            return await _context.PaymentDetails.ToListAsync();
            throw new NotImplementedException();
        }

        public async Task<List<PaymentDetail>> DeleteAllPaymentDetailsByIdAsync(int id)
        {
            var dbpaymentdetail = await _context.PaymentDetails.FindAsync(id);
            _context.PaymentDetails.Remove(dbpaymentdetail);
            await _context.SaveChangesAsync();

            return await _context.PaymentDetails.ToListAsync();
            throw new NotImplementedException();
        }

        public async Task<List<PaymentDetail>> GetAllPaymentDetailsAsync()
        {
            return await _context.PaymentDetails.ToListAsync();
            throw new NotImplementedException();
        }

        public async Task<List<PaymentDetail>> GetAllPaymentDetailsByIdAsync(int id)
        {
            var paymentDetail = await _context.PaymentDetails.FindAsync(id);

            return await _context.PaymentDetails.ToListAsync();

            throw new NotImplementedException();
        }

        public async Task<List<PaymentDetail>> UpdatePaymentDetailsAsync(PaymentDetail detail)
        {
            var dbpaymentdetails = await _context.PaymentDetails.FindAsync(detail.PaymentDetailId);

            dbpaymentdetails.CardOwnerName = detail.CardOwnerName;
            dbpaymentdetails.CardNumber = detail.CardNumber;
            dbpaymentdetails.ExpirationDate = detail.ExpirationDate;
            dbpaymentdetails.SecurityCode = detail.SecurityCode;

            await _context.SaveChangesAsync();
            return await _context.PaymentDetails.ToListAsync();
            throw new NotImplementedException();
        }
    }
}
