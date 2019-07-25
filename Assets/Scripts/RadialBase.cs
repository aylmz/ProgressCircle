using UnityEngine;
using UnityEngine.UI;

namespace ProgressCircle
{
    [ExecuteInEditMode]
    public class RadialBase : MonoBehaviour
    {
        protected Image fillImage = null;
        protected Text mainText = null;
        protected Text subText = null;

        [SerializeField]
        private Color lowValueFillColor = Color.red;
        [SerializeField]
        private Color highValueFillColor = Color.green;
        [SerializeField]
        private float _maxValue = 100f, _minValue = 0f;

        private float _currentValue = 0f;

        public virtual void Awake()
        {
            if (!Application.isPlaying)
            {
                _currentValue = (_maxValue - _minValue) * 0.27f;
            }
            fillImage = transform.Find("CircleForeground").GetComponent<Image>();
            mainText = transform.Find("MainText").GetComponent<Text>();
            subText = transform.Find("SubText").GetComponent<Text>();
            
        }

#if UNITY_EDITOR
        public void Update()
        {
            if (!Application.isPlaying)
            {
                CurrentValue = _currentValue;
            }
        }
#endif

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

        public virtual float CurrentValue
        {
            get
            {
                return _currentValue;
            }
            set
            {
                // Ensure the passed value falls within min/max range
                _currentValue = Mathf.Clamp(value, _minValue, _maxValue);

                if(fillImage != null)
                {
                    // Calculate the current fill percentage and display it
                    if (fillImage.type == Image.Type.Filled)
                    {
                        fillImage.fillAmount = FillPercentage;
                    }

                    fillImage.color = Color.Lerp(lowValueFillColor, highValueFillColor, FillPercentage);
                }
            }
        }
    }
}

