using FluentValidation.Results;

public class Notebook : IItem
{
    public string Manufacturer { get; set; }
    public string Model { get; set; }
    public Notebook(string manufacturer, string model)
    {
        Manufacturer = manufacturer;
        Model = model;
    }
    public Notebook()
    {

    }
    public List<ValidationFailure> Validate()
    {
        NotebookValidator validator = new();
        ValidationResult result = validator.Validate(this);
        if (!result.IsValid)
        {
            return result.Errors;
        }
            return null;
    }
}