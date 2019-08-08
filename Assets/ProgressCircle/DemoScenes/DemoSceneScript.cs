using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using ProgressCircle;

public class DemoSceneScript : MonoBehaviour
{
    public RadialProgress[] radialProgresses;
    public RadialHP[] radialHPs;
    public RadialGrow[] radialGrows;

    // Start is called before the first frame update
    void Start()
    {
        if(radialProgresses != null && radialProgresses.Length > 0)
        {
            foreach(RadialProgress radialProgress in radialProgresses)
            {
                if (radialProgress == null)
                    continue;
                radialProgress.CurrentValue = radialProgress.MinValue;
                radialProgress.onProgressComplete = new UnityEvent();
                radialProgress.onProgressComplete.AddListener(OnRadialProgressComplete);
            }
        }
        if (radialHPs != null && radialHPs.Length > 0)
        {
            foreach (RadialHP radialHP in radialHPs)
            {
                if (radialHP == null)
                    continue;
                radialHP.CurrentValue = radialHP.MaxValue;
                StartCoroutine(ReduceHP(radialHP));
            }
        }

        if (radialGrows != null && radialGrows.Length > 0)
        {
            foreach (RadialGrow radialGrow in radialGrows)
            {
                if (radialGrow == null)
                    continue;
                radialGrow.CurrentValue = radialGrow.MinValue;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (radialProgresses != null && radialProgresses.Length > 0)
        {
            foreach (RadialProgress radialProgress in radialProgresses)
            {
                if (radialProgress == null)
                    continue;
                if (radialProgress.CurrentValue < radialProgress.MaxValue)
                    radialProgress.CurrentValue += Random.Range(0.001f, 0.2f);
            }
        }
        if (radialGrows != null && radialGrows.Length > 0)
        {
            foreach (RadialGrow radialGrow in radialGrows)
            {
                if (radialGrow == null)
                    continue;
                if (radialGrow.CurrentValue < radialGrow.MaxValue)
                    radialGrow.CurrentValue += Random.Range(0.01f, 0.5f);
            }
        }
    }

    private IEnumerator ReduceHP(RadialHP radialHp)
    {
        while (radialHp.CurrentValue > radialHp.MinValue)
        {
            yield return new WaitForSeconds(Random.Range(0.2f, 2f));
            radialHp.CurrentValue -= Random.Range(-50f, 250f);
        }
    }

    public void OnRadialProgressComplete()
    {
        Debug.Log("Radial Progress Complete");
    }
}
