using Domain.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Payment.Create
{
    internal class CreatePaymentUseCase
    {
        private readonly IPaymentRepository _paymentRepository;

        public CreatePaymentUseCase(
            Guid SenderId,
            IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<PaymentResponseDTO> ExecuteAsync(PaymentCreateRequestDTO requestDTO)
        {
            var payment = new Domain.Entities.Payment(
                requestDTO.RecipientId,
                requestDTO.Value
                );

            var result = await _paymentRepository.CreatePayment(payment);

            var dto = new PaymentResponseDTO(result.QrCodePayload);

            return dto;
        }
    }
}
