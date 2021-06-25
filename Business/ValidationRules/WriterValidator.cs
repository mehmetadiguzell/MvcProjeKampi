using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı boş geçilemez");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Soyad  boş geçilemez");
            RuleFor(x => x.WriterSurName).MinimumLength(2).WithMessage("Soyad  2 karakterden büyük olmalı");
            RuleFor(x => x.WriterSurName).MaximumLength(50).WithMessage("Soyad  50 karakterden büyük olamaz");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkımda  boş geçilemez");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Yazar unvan boş geçilemez");
        }
    }
}
