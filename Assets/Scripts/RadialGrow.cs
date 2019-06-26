using UnityEngine;

namespace ProgressCircle
{
    public class RadialGrow : RadialBase
    {
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
                if (value >= MaxValue)
                {
                    value = MaxValue;
                }

                base.CurrentValue = value;

                mainText.text = (FillPercentage * 100).ToString("0") + "%";
                subText.text = CurrentValue.ToString("0") + "/" + MaxValue;
                fillImage.transform.localScale = new Vector3(FillPercentage, FillPercentage, 1);
            }
        }
    }
}

