using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace OzerNet.Commands.Infrastructure
{
    public static class CommandValidation
    {
        public static object Validation(this Command command)
        {
            var errorList = new List<object>();

            #region CommandValidation
            var commandProperties = command?.GetType().GetProperties().ToList();

            if (commandProperties.Count > 0)
            {
                foreach (var property in commandProperties)
                {
                    #region Required
                    var requiredProperty = property.GetAttribute<RequiredValidation>();
                    if (requiredProperty != null)
                    {
                        var propertyValue = command.GetPropertyValue<string>(property.Name);
                        var propertyIsNullValue = propertyValue.NullOrEmptyControl();
                        if (propertyIsNullValue)
                        {
                            errorList.Add(new
                            {
                                FieldName = property.Name,
                                ErrorMessage = requiredProperty.ErrorMessage
                            });
                        }
                    }
                    #endregion

                    #region MinLength
                    var minLengthProperty = property.GetAttribute<MinLengthValidation>();
                    if (minLengthProperty != null)
                    {
                        var propertyValueLength = command.GetPropertyValue<string>(property.Name)?.Length;

                        if (propertyValueLength < minLengthProperty.MinLength)
                        {
                            errorList.Add(new
                            {
                                FieldName = property.Name,
                                ErrorMessage = string.Format(minLengthProperty.ErrorMessage, minLengthProperty.MinLength, propertyValueLength)
                            });
                        }
                    }
                    #endregion

                    #region MaxLength
                    var maxLengthProperty = property.GetAttribute<MaxLengthValidation>();
                    if (maxLengthProperty != null)
                    {
                        var propertyValueLength = command.GetPropertyValue<string>(property.Name).Length;
                        if (propertyValueLength > maxLengthProperty.MaxLength)
                        {
                            errorList.Add(new
                            {
                                FieldName = property.Name,
                                ErrorMessage = string.Format(maxLengthProperty.ErrorMessage, maxLengthProperty.MaxLength, propertyValueLength)
                            });
                        }
                    }
                    #endregion

                    #region MinNumber
                    var minNumberProperty = property.GetAttribute<MinNumberValidation>();
                    if (minNumberProperty != null)
                    {
                        var propertyValueNumber = property.GetPropertyValue<int>(property.Name);
                        if (propertyValueNumber < minNumberProperty.MinNumber)
                        {
                            errorList.Add(new
                            {
                                FieldName = property.Name,
                                ErrorMessage = string.Format(minNumberProperty.ErrorMessage, minNumberProperty.MinNumber, propertyValueNumber)
                            });
                        }
                    }
                    #endregion

                    #region MaxNumber
                    var maxNumberProperty = property.GetAttribute<MaxNumberValidation>();
                    if (maxNumberProperty != null)
                    {
                        var propertyValueNumber = property.GetPropertyValue<int>(property.Name);
                        if (propertyValueNumber > minNumberProperty.MinNumber)
                        {
                            errorList.Add(new
                            {
                                FieldName = property.Name,
                                ErrorMessage = string.Format(maxNumberProperty.ErrorMessage, maxNumberProperty.MaxNumber, propertyValueNumber)
                            });
                        }
                    }
                    #endregion

                    #region MinItem
                    var minItemProperty = property.GetAttribute<MinItemValidation>();
                    if (minItemProperty != null)
                    {
                        var propertyItemCount = property.GetPropertyValue<dynamic>(property.Name).Count;
                        if (propertyItemCount < minItemProperty.MinItemCount)
                        {
                            errorList.Add(new
                            {
                                FieldName = property.Name,
                                ErrorMessage = string.Format(minItemProperty.ErrorMessage, minItemProperty.MinItemCount, propertyItemCount)
                            });
                        }
                    }
                    #endregion

                    #region MaxItem
                    var maxItemProperty = property.GetAttribute<MaxItemValidation>();
                    if (maxItemProperty != null)
                    {
                        var propertyItemCount = property.GetPropertyValue<dynamic>(property.Name).Count;
                        if (propertyItemCount > minItemProperty.MinItemCount)
                        {
                            errorList.Add(new
                            {
                                FieldName = property.Name,
                                ErrorMessage = string.Format(maxItemProperty.ErrorMessage, maxItemProperty.MaxItemCount, propertyItemCount)
                            });
                        }
                    }
                    #endregion
                }
            }
            #endregion

            #region ReturnModel
            if (errorList.Count == 0) return true;

            var result = new
            {
                Message = "İstek cevaplanırken bazı hatalar oluştu.",
                ErrorList = errorList
            };
            return result;
            #endregion
        }
    }
}
