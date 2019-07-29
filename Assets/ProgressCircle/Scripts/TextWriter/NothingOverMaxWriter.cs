namespace ProgressCircle.TextWriter
{
    public class NothingOverMaxWriter : AbstractTextWriter
    {
        public override void Write()
        {
            if(progressCircleInstance != null)
            {
                textField.text =  "/" + progressCircleInstance.MaxValue;
            }
        }
    }
}