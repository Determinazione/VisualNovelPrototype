using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;

[CustomPropertyDrawer(typeof(SetValueByHandAttribute))]
public class CustomCircularScrollInspector : PropertyDrawer
{
    private const int TOGGLE_HEIGHT = 16;
    private const int SLIDE_HEIGHT = 16;
    private SerializedProperty mHide;
    private SerializedProperty mAmount;
    private SetValueByHandAttribute mSetValueByHandAttribute { get { return (SetValueByHandAttribute)attribute; } }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        if (!IsHidden(property.FindPropertyRelative("CalculateAmountOfUnitByHand")))
        {
            return base.GetPropertyHeight(property, label);
        }
        else
        {
            return base.GetPropertyHeight(property, label) + SLIDE_HEIGHT;
        }
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        // Get relative properties.
        mHide = property.FindPropertyRelative("CalculateAmountOfUnitByHand");
        mAmount = property.FindPropertyRelative("AmountOfUnit");

        // Setup the location & height before it is drawn on the inspector.
        Rect toggleHeight = position;
        Rect slideHeight = EditorGUI.IndentedRect(toggleHeight);
        toggleHeight.height = TOGGLE_HEIGHT;
        slideHeight.y += TOGGLE_HEIGHT;
        slideHeight.height = SLIDE_HEIGHT;

        // Draw properties.
        EditorGUI.PropertyField(toggleHeight, mHide);
        if (mHide.boolValue)
        {
            EditorGUI.indentLevel++;
            EditorGUI.IntSlider(slideHeight, mAmount, 0, 30);
            EditorGUI.indentLevel--;
        }
        EditorGUI.EndProperty();
    }

    bool IsHidden(SerializedProperty property)
    {
        return property.boolValue;
    }
}
