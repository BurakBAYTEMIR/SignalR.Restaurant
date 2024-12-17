using FluentValidation;
using SignalR.Restaurant.Dtos.BookingDtos;

namespace SignalR.Restaurant.Business.ValidationRules.BookingValidations
{
    public class CreateBookingValidation : AbstractValidator<CreateBookingDto>
    {
        public CreateBookingValidation()
        {
            RuleFor(x => x.BookingName).NotEmpty().WithMessage("İsim alanı boş geçilemez!");
            RuleFor(x => x.BookingPhone).NotEmpty().WithMessage("Telefon boş geçilemez!");
            RuleFor(x => x.BookingMail).NotEmpty().WithMessage("Mail alanı boş geçilemez!");
            RuleFor(x => x.BookingPersonCount).NotEmpty().WithMessage("Kişi alanı boş geçilemez!");
            RuleFor(x => x.BookingDate).NotEmpty().WithMessage("Tarih alanı boş geçilemez lütfen tarih seçimi yapınız!");

            RuleFor(x => x.BookingName).MinimumLength(5).WithMessage("Lütfen isim alanına en az 5 karekter veri girişi yapınız").MaximumLength(50).WithMessage("Lütfen isim alanına en fazla 50 kareter veri girişi yapınız.");
            RuleFor(x => x.BookingDescription).MaximumLength(500).WithMessage("Lütfen açıklama alanına en fazla 500 kareter veri girişi yapınız.");

            RuleFor(x => x.BookingMail).EmailAddress().WithMessage("Lütfen geçerli bir email adresi giriniz");
        }
    }
}
