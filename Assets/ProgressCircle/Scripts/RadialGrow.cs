using UnityEngine;

namespace ProgressCircle
{
    public class RadialGrow : AbstractRadial
    {
        // Create a property to handle the slider's value
        public override float CurrentValue
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

                fillImage.transform.localScale = new Vector3(FillPercentage, FillPercentage, 1);
            }
        }
    }
}

