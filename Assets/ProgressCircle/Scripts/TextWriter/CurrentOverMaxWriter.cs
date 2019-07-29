using UnityEngine.UI;

namespace ProgressCircle.TextWriter
{
    public class CurrentOverMaxWriter : AbstractTextWriter
    {
        public override void Write()
        {
            if(progressCircleInstance != null)
            {
                textField.text = progressCircleInstance.CurrentValue.ToString("0") + "/" + progressCircleInstance.MaxValue;
            }
        }
    }
}