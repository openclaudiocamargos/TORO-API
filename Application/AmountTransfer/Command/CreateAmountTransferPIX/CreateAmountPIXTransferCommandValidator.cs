using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AmountTransfer.Command.CreateAmountTransferPIX
{
    public class CreateAmountPIXTransferCommandValidator : AbstractValidator<CreateAmountPIXTransferCommand>
    {
        public CreateAmountPIXTransferCommandValidator()
        {			
			RuleFor(c => c.Event)
				.Equal("TRANSFER").WithMessage("Invalid event type.");

			RuleFor(c => c.Origin.CPF)
				.Must(ValidCPF).WithMessage("Invalid CPF.");

			RuleFor(x => x.Amount)
				.GreaterThan(0).WithMessage("Invalid amount value.");
			
			RuleFor(x => x.Target.Bank)
                .Equal("352").WithMessage("Invalid bank code.");
			
			RuleFor(x => x.Target.Branch)
                .Equal("0001").WithMessage("Invalid target branch.");

			RuleFor(x => x.Target.Account)
				.NotNull().WithMessage("Invalid target account.")
				.MinimumLength(1).WithMessage("Invalid target account.");

			RuleFor(x => x.Origin.Bank)
                .NotNull().WithMessage("Invalid origin bank code.")
				.MinimumLength(1).WithMessage("Invalid origin bank code.");

			RuleFor(x => x.Origin.Branch)
                .NotNull().WithMessage("Invalid origin branch code.")
				.MinimumLength(1).WithMessage("Invalid origin branch code.");

			RuleFor(x => x.Origin.Account)
                .NotNull().WithMessage("Invalid origin account.")
				.MinimumLength(1).WithMessage("Invalid origin account.");
		}

		private bool ValidCPF(string? cpf)
		{
			if (cpf == null)
				return false;

			int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			string tempCpf;
			string digito;
			int soma;
			int resto;
			cpf = cpf.Trim();
			cpf = cpf.Replace(".", "").Replace("-", "");
			if (cpf.Length != 11)
				return false;
			tempCpf = cpf.Substring(0, 9);
			soma = 0;

			for (int i = 0; i < 9; i++)
				soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
			resto = soma % 11;
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = resto.ToString();
			tempCpf = tempCpf + digito;
			soma = 0;
			for (int i = 0; i < 10; i++)
				soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
			resto = soma % 11;
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = digito + resto.ToString();
			return cpf.EndsWith(digito);
		}
	}
}
