using FluentValidation;

public class SmartphoneValidator : AbstractValidator<Smartphone>
{
	public SmartphoneValidator()
	{
        RuleFor(smartphone => smartphone.Model)
                .NotEmpty()
                .NotNull();
        RuleFor(smartphone => smartphone.Manufacturer)
                .NotEmpty()
                .NotNull();
                
    }

}