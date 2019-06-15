using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialHP : RadialBase
{
    [SerializeField]
    private Color lowValueTextColor = Color.red;
    [SerializeField]
    private float lowValueTriggerPercentage = 30f;
    private Color defaultTextColor;

    public void Awake()
    {
        defaultTextColor = mainText.color;
    }

    // Create a property to handle the slider's value
    public new float CurrentValue
    {
        get
        {
            return base.CurrentValue;
        }
        set
        {
            // If the value exceeds the max fill, invoke the completion function
            if (value > MaxValue)
            {
                value = MaxValue;
            }
            else if (value < MinValue)
            {
                value = MinValue;
            }

            base.CurrentValue = value;

            if(FillPercentage * 100 <= lowValueTriggerPercentage)
            {
                mainText.color = lowValueTextColor;
            }
            else
            {
                mainText.color = defaultTextColor;
            }

            mainText.text = base.CurrentValue.ToString("0");
            subText.text = "/" + MaxValue.ToString();
        }
    }
}
