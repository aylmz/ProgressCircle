﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ProgressCircle
{
    public class RadialHP : RadialBase
    {
        [SerializeField]
        private Color lowValueTextColor = Color.red;
        [SerializeField]
        private float lowValueTriggerPercentage = 30f;
        private Color defaultTextColor;

        [Header("Extended Components")]
        [SerializeField]
        private Image traceImage = null;
        [SerializeField]
        private float traceLatency = 0.5f;
        [SerializeField]
        private float traceStepValue = 10f;
        [SerializeField]
        private float traceStepTime = 0.05f;
        private float _currentTraceValue;

        private Coroutine activeTraceCoroutine = null;

        public void Awake()
        {
            defaultTextColor = mainText.color;
            _currentTraceValue = CurrentValue;
        }

        private IEnumerator WaitAndTrace()
        {
            if (CurrentValue > CurrentTraceValue || CurrentValue == 0f)
            {
                CurrentTraceValue = CurrentValue;
                yield break;
            }
            yield return new WaitForSeconds(traceLatency);
            while (CurrentTraceValue > CurrentValue)
            {
                CurrentTraceValue -= traceStepValue;
                yield return new WaitForSeconds(traceStepTime);
            }
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
                StopTraceCoroutine();
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

                if (FillPercentage * 100 <= lowValueTriggerPercentage)
                {
                    mainText.color = lowValueTextColor;
                }
                else
                {
                    mainText.color = defaultTextColor;
                }

                mainText.text = base.CurrentValue.ToString("0");
                subText.text = "/" + MaxValue.ToString();

                StartTraceCoroutine();
            }
        }

        private void StartTraceCoroutine()
        {
            if (traceImage != null && activeTraceCoroutine == null)
            {
                activeTraceCoroutine = StartCoroutine(WaitAndTrace());
            }
        }

        private void StopTraceCoroutine()
        {
            if (activeTraceCoroutine != null)
            {
                StopCoroutine(activeTraceCoroutine);
                activeTraceCoroutine = null;
            }
        }

        private float CurrentTraceValue
        {
            get
            {
                return _currentTraceValue;
            }
            set
            {
                // Ensure the passed value falls within min/max range
                _currentTraceValue = Mathf.Clamp(value, CurrentValue, MaxValue);
                if (traceImage != null)
                {
                    traceImage.fillAmount = _currentTraceValue / MaxValue;
                }
            }
        }
    }
}
