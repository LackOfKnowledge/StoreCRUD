using FluentValidation.Results;

namespace crudDemo2.Interfaces
{
    public interface IViewer
    {
        bool ShowItem(IItem item);
        void ExistingItemError();
        void NotFoundError();
        bool OutputMsg(List<ValidationFailure> validationFailures);
        void ValueError();
    }
}