﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extensions
{
    public static class EnumExtensions
    {
        public static string ToDisplay(this Enum value, DisplayProperty property = DisplayProperty.Name)
        {
            ArgumentNullException.ThrowIfNull(value, nameof(value));

            var attribute = value.GetType().GetField(value.ToString())!
                .GetCustomAttributes<DisplayAttribute>(false).FirstOrDefault();

            if (attribute == null)
                return value.ToString();

            var propertyValue = attribute.GetType().GetProperty(property.ToString()).GetValue(attribute, null);
            return propertyValue.ToString();
        }
    }
}



public enum DisplayProperty
{
    Description,
    GroupName,
    Name,
    Prompt,
    ShortName,
    Order
}
