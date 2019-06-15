using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DemoSceneScript : MonoBehaviour
{
    public RadialProgress[] radialProgresses;
    public RadialHP[] radialHPs;

    // Start is called before the first frame update
    void Start()
    {
        if(radialProgresses != null && radialProgresses.Length > 0)
        {
            foreach(RadialProgress radialProgress in radialProgresses)
            {
                radialProgress.CurrentValue = radialProgress.MinValue;
                radialProgress.onProgressComplete = new UnityEvent();
                radialProgress.onProgressComplete.AddListener(OnRadialProgressComplete);
            }
        }
        if (radialHPs != null && radialHPs.Length > 0)
        {
            foreach (RadialHP radialHP in radialHPs)
            {
                radialHP.CurrentValue = radialHP.MaxValue;
                StartCoroutine(ReduceHP(radialHP));
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
                if (radialProgress.CurrentValue < radialProgress.MaxValue)
                    radialProgress.CurrentValue += Random.Range(0.001f, 0.2f);
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
