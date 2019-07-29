using UnityEngine.UI;

namespace ProgressCircle.TextWriter
{
    public class PercentageWriter : AbstractTextWriter
    {
        public override void Write()
        {
            if(progressCircleInstance != null)
            {
                textField.text = (progressCircleInstance.FillPercentage * 100).ToString("0") + "%";
            }
        }
    }
}
