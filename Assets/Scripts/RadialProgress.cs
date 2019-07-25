using UnityEngine.Events;

namespace ProgressCircle
{
    public class RadialProgress : RadialBase
    {
        // Event to invoke when the progress bar fills up
        public UnityEvent onProgressComplete;

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
                    if (onProgressComplete != null)
                        onProgressComplete.Invoke();
                }

                base.CurrentValue = value;

                mainText.text = (FillPercentage * 100).ToString("0") + "%";
                subText.text = CurrentValue.ToString("0") + "/" + MaxValue;
            }
        }
    }
}

