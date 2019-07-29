using UnityEngine;
using Text = UnityEngine.UI.Text;

namespace ProgressCircle.TextWriter
{
    /// <summary>
    /// Strategy class that is used to determine what text will be written in the text fields of ProgressCircle instances
    /// </summary>
    public abstract class AbstractTextWriter : MonoBehaviour
    {
        protected AbstractRadial progressCircleInstance;
        public Text textField;

        private void Awake()
        {
            progressCircleInstance = gameObject.GetComponent<AbstractRadial>();
        }

        /// <summary>
        /// Override this method to create your own text writer strategy. See <see cref="ProgressCircle.TextWriter.PercentageWriter"/> for example implementation
        /// </summary>
        public abstract void Write();
    }
}
