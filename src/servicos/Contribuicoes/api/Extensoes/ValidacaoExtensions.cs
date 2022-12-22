

using FluentValidation.Results;

namespace api.Extensoes;
public static class ValidacaoExtensions
{
    public static List<string> ToNotificacoes(this ValidationResult validationResult) 
        => validationResult.Errors.Select(x => $"{x.ErrorMessage}").ToList();
}
