﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Application.DtosAnd.Statistic.Commands.Create
{
    public class CreateStatisticCommandValidator : AbstractValidator<CreateStatisticCommand>
    {
        public CreateStatisticCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty().MinimumLength(2).MaximumLength(20);
        }
    }
}