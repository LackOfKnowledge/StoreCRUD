using FluentValidation.Results;

public interface IItem
{
    List<ValidationFailure> Validate();
}