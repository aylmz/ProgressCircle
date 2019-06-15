using UnityEngine;
using UnityEngine.UI;

public class RadialBase : MonoBehaviour
{
   
   
    [Header("Core Components")]
    [SerializeField]
    private Image fillImage = null;
    [SerializeField]
    protected Text mainText = null;
    [SerializeField]
    protected Text subText = null;

    [Header("Options")]
    public bool displayText = true;
    [SerializeField]
    private Color lowValueFillColor = Color.red;
    [SerializeField]
    private Color highValueFillColor = Color.green;
    [SerializeField]
    private float _maxValue = 100f, _minValue = 0f;

    private float _currentValue = 0f;

    public float FillPercentage
    {
        get
        {
            return _currentValue / _maxValue;
        }
    }

    public float MaxValue
    {
        get
        {
            return _maxValue;
        }
        set
        {
            _maxValue = value;
            //reevaluate CurrentValue to redraw
            CurrentValue = _currentValue;
        }
    }

    public float MinValue
    {
        get
        {
            return _minValue;
        }
        set
        {
            _minValue = value;
            //reevaluate CurrentValue to redraw
            CurrentValue = _currentValue;
        }
    }

    // Create a property to handle the slider's value
    
    public float CurrentValue
    {
        get
        {
            return _currentValue;
        }
        set
        {
            // Ensure the passed value falls within min/max range
            _currentValue = Mathf.Clamp(value, _minValue, _maxValue);

            // Calculate the current fill percentage and display it
            fillImage.fillAmount = FillPercentage;
            fillImage.color = Color.Lerp(lowValueFillColor, highValueFillColor, FillPercentage);
        }
    }
}
