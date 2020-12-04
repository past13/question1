using FluentValidation;

namespace transactioApp.Validators
{
    using Models.Xml;
    using Models.Enums;

    public class TransactionValidator : AbstractValidator<TransactionItem>
    {
        public TransactionValidator()
        {
            RuleFor(x => x.TransactionId)
                .NotNull()
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.Status)
                .NotNull()
                .NotEmpty()
                .IsEnumName(typeof(TransactionStatus));

            RuleFor(x => x.PaymentDetails.Amount)
                .NotNull()
                .NotEmpty()
                .Must(ValuesValidator.ValidateDecimal);

            RuleFor(x => x.PaymentDetails.CurrencyCode)
                .NotEmpty()
                .NotNull()
                .Must(ValuesValidator.ValidateCurrency);
        }
    }
}
