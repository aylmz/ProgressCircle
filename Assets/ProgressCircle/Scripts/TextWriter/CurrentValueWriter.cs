namespace ProgressCircle.TextWriter
{
    public class CurrentValueWriter : AbstractTextWriter
    {
        public override void Write()
        {
            if (progressCircleInstance != null)
            {
                textField.text = progressCircleInstance.CurrentValue.ToString("0");
            }
        }
    }
}