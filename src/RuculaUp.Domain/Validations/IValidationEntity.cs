

using FluentValidation.Results;

namespace RuculaUp.Core;

public interface IValidationEntity<T> where T: class
{
    ValidationResult Validate(T target);
}
