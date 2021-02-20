﻿using System;
using System.Collections.Generic;
using System.Text;
using Business.Constant;
using Entities.Concrete;
using FluentValidation;
using FluentValidation.Results;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator:AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.RentDate).NotNull().WithMessage("Kiralama Tarihi Boş Olamaz !");
            RuleFor(r => r.CarId).NotEmpty();
            RuleFor(r => r.CustomerId).NotEmpty();
            RuleFor(r => r.ReturnDate).NotNull().WithMessage(Messages.RentalReturnDate);
        }
    }
}
