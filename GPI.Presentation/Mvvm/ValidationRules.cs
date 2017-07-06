using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GPI.Presentation.Mvvm
{
	public class IntValidationRule : ValidationRule
	{
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			int val;
			if (int.TryParse((string)value, out val))
			{
				if (val <= 0)
				{
					return new ValidationResult(false, "numéro > 0");
				}
				return new ValidationResult(true, null);
			}
			else
				return new ValidationResult(false, "entrer un numéro ");
		}
	}
	public class DecimalValidationRule : ValidationRule
	{
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			decimal val;
			if (decimal.TryParse((string)value, out val))
			{
				if (val <= 0)
				{
					return new ValidationResult(false, "numéro > 0");
				}
				return new ValidationResult(true, null);
			}
			else
				return new ValidationResult(false, "entrer un numéro ");
		}
	}
	public class NotEmptyStringRule : ValidationRule
	{
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			if ((value == null) || ((value as string).Length < 1))
				return new ValidationResult(false, "le champ ne peut pas être vide.");

			return new ValidationResult(true, null);

		}
	}

	public class NotEmptyComboBoxRule : ValidationRule
	{
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			if (value == null || object.Equals(value, string.Empty))
				return new ValidationResult(false, "Ce champ est obligatoire");
			else
				return ValidationResult.ValidResult;
		}
	}
}
