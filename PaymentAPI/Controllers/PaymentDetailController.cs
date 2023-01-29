using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentAPI.Data;
using PaymentAPI.Interface;
using PaymentAPI.Models;

namespace PaymentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailController : ControllerBase
    {
        private readonly IPaymentDetailRepository _details;
        public PaymentDetailController(IPaymentDetailRepository details)
        {
            _details = details;
        }

        // GET: api/PaymentDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDetail>>> GetPaymentDetails()
        {
            return Ok(await _details.GetAllPaymentDetailsAsync());
        }

        // GET: api/PaymentDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDetail>> GetPaymentDetail(int id)
        {
            return Ok(await _details.GetAllPaymentDetailsByIdAsync(id));
        }

        // PUT: api/PaymentDetail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutPaymentDetail(PaymentDetail paymentDetail)
        {
            return Ok(await _details.UpdatePaymentDetailsAsync(paymentDetail));
        }

        // POST: api/PaymentDetail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaymentDetail>> PostPaymentDetail(PaymentDetail paymentDetail)
        {
            return Ok(await _details.AddPaymentDetailsAsync(paymentDetail));
        }

        // DELETE: api/PaymentDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentDetail(int id)
        {
            return Ok(await _details.DeleteAllPaymentDetailsByIdAsync(id));
        }

        //private bool paymentdetailexists(int id)
        //{
        //    return _details.paymentdetails.any(e => e.paymentdetailid == id);
        //}
    }
}
