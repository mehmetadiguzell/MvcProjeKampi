using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail adresi boş geçilemez");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu boş geçilemez");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Konu 3 karakterden büyük olmalı");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Kullanıcı adı 3 karakterden büyük olmalı");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Konu başlığı 50 karakterden büyük olamaz");
        }
    }
}
