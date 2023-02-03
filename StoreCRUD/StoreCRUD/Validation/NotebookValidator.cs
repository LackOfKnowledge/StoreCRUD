using FluentValidation;

public class NotebookValidator : AbstractValidator<Notebook>
{
	public NotebookValidator()
	{
		RuleFor(notebook => notebook.Model)
			.NotEmpty()
			.NotNull();
		RuleFor(notebook => notebook.Manufacturer)
			.NotEmpty()
			.NotNull();
    }
}