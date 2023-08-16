using UnityEngine.PostProcessing;
using MinAttr = UnityEngine.MinAttribute;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace UnityEditor.PostProcessing
{
    [CustomPropertyDrawer(typeof(MinAttribute))]
    sealed class MinDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            MinAttribute postProcessingMinAttribute = (MinAttribute)base.attribute;

            VisualElement container = new VisualElement();

            if (property.propertyType == SerializedPropertyType.Integer)
            {
                IntegerField integerField = new IntegerField(property.displayName);
                integerField.value = property.intValue;
                integerField.RegisterValueChangedCallback((evt) =>
                {
                    property.intValue = UnityEngine.Mathf.Max(evt.newValue, (int)postProcessingMinAttribute.min);
                });
                container.Add(integerField);
            }
            else if (property.propertyType == SerializedPropertyType.Float)
            {
                FloatField floatField = new FloatField(property.displayName);
                floatField.value = property.floatValue;
                floatField.RegisterValueChangedCallback((evt) =>
                {
                    property.floatValue = UnityEngine.Mathf.Max(evt.newValue, postProcessingMinAttribute.min);
                });
                container.Add(floatField);
            }
            else
            {
                Label label = new Label($"Use Min with float or int.");
                container.Add(label);
            }

            return container;
        }
    }
}
