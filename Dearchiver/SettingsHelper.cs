using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Globalization;

namespace Piksel.SettingsHelper
{
    /// <summary>
    /// Represents an extension of AssociatedMetadataTypeTypeDescriptionProvider that wraps the
    /// TypeDescriptor returned with a custom TypeDescriptor.
    /// </summary>
    public class SettingsDescriptorProvider : AssociatedMetadataTypeTypeDescriptionProvider
    {

        public SettingsDescriptorProvider(Type type)
            : base(type)
        {
            // No-op
        }

        public SettingsDescriptorProvider(Type type, Type associatedMetadataType)
            : base(type, associatedMetadataType)
        {
            // No-op
        }

        private ICustomTypeDescriptor Descriptor { get; set; }

        public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object instance) 
            => Descriptor ?? (Descriptor = new SettingsTypeDescriptor(base.GetTypeDescriptor(objectType, instance)));
    }

    /// <summary>
    /// Represents a custom TypeDescriptor that wraps the real TypeDescriptor, but overrides
    /// both GetProperties() *and* GetProperties(Attribute[]).
    /// </summary>
    public class SettingsTypeDescriptor : CustomTypeDescriptor
    {

        public SettingsTypeDescriptor(ICustomTypeDescriptor wrappedTypeDescriptor)
        {
            WrappedTypeDescriptor = wrappedTypeDescriptor;
        }

        private ICustomTypeDescriptor WrappedTypeDescriptor { get; set; }

        public override AttributeCollection GetAttributes() 
            => WrappedTypeDescriptor.GetAttributes();

        public override PropertyDescriptorCollection GetProperties()
            => new PropertyDescriptorCollection(WrappedTypeDescriptor
                .GetProperties()
                .Cast<PropertyDescriptor>()
                .Select(d => new SettingsPropertyDescriptor(d))
                .ToArray(), true);

        public override PropertyDescriptorCollection GetProperties(Attribute[] attributes) 
            => GetProperties();
    }

    /// <summary>
    /// Represents a custom PropertyDescriptor that wraps the real PropertyDescriptor, and enforces
    /// any ValidationAttributes defined on the associated property.
    /// </summary>
    public class SettingsPropertyDescriptor : PropertyDescriptor
    {

        public SettingsPropertyDescriptor(PropertyDescriptor wrappedPropertyDescriptor)
            : base(wrappedPropertyDescriptor)
        {
            WrappedPropertyDescriptor = wrappedPropertyDescriptor;
        }

        private PropertyDescriptor WrappedPropertyDescriptor { get; }

        public override void AddValueChanged(object component, EventHandler handler)
            => WrappedPropertyDescriptor.AddValueChanged(component, handler);

        public override bool CanResetValue(object component)
            => WrappedPropertyDescriptor.CanResetValue(component);

        public override Type ComponentType
            => WrappedPropertyDescriptor.ComponentType;

        public override bool IsReadOnly
            => WrappedPropertyDescriptor.IsReadOnly;

        public override object GetValue(object component)
            => WrappedPropertyDescriptor.GetValue(component);

        public override Type PropertyType 
            => WrappedPropertyDescriptor.PropertyType;

        public override void RemoveValueChanged(object component, EventHandler handler)
            => WrappedPropertyDescriptor.RemoveValueChanged(component, handler);

        public override void ResetValue(object component)
            => WrappedPropertyDescriptor.ResetValue(component);

        public override void SetValue(object component, object value)
        {
            var attributes = new List<Attribute>();
            FillAttributes(attributes);

            foreach (Attribute attribute in attributes)
            {
                var validationAttribute = attribute as ValidationAttribute;
                if (validationAttribute == null)
                    continue;

                if (!validationAttribute.IsValid(value))
                    throw new ValidationException(validationAttribute.ErrorMessage, validationAttribute, component);
            }

            WrappedPropertyDescriptor.SetValue(component, value);
        }

        public override bool ShouldSerializeValue(object component) 
            => WrappedPropertyDescriptor.ShouldSerializeValue(component);

        public override bool SupportsChangeEvents 
            => WrappedPropertyDescriptor.SupportsChangeEvents;
    }
}
