using System;
using FluentValidation;

public class PersonValidator : AbstractValidator<UserDetail>
{
    public PersonValidator()
    {

        // RuleFor(x => x.TransactionId)
        //     .NotEmpty()
        //     .Length(1, 255);

        // RuleFor(x => x.Amount)
        //     .NotEmpty();
        //     // .Length(1, 2);

        // RuleFor(x => x.CurrencyCode)
        //     .NotEmpty()
        //     .Length(1, 255);

        // RuleFor(x => x.TransactionDate)
        //     .NotEmpty()
        //     .Length(1, 255);

            // .Length(1, 255);
            // .GreaterThan(new DateTime(1870, 1, 1, 0, 0, 0, DateTimeKind.Utc));

        // RuleFor(x => x.Status)
        //     .NotEmpty()
        //     .Length(1, 255);
    }
}