using Entities.Concrete;
using FluentValidation;
using System;

namespace Business.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        [Obsolete]
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı adı boş geçilemez");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu boş geçilemez");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Konu boş geçilemez");
            RuleFor(x => x.ReceiverMail).EmailAddress(FluentValidation.Validators.EmailValidationMode.Net4xRegex);

            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Konu 3 karakterden büyük olmalı");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Konu başlığı 100 karakterden büyük olamaz");
        }

    }
}
