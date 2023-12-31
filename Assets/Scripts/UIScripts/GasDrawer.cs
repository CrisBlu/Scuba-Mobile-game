using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasDrawer : MonoBehaviour
{
    [SerializeField] GameObject gasPip;
    [SerializeField] RectTransform gasMeter;
    [SerializeField] PlayerStats playerStatsScript;
    

    // Start is called before the first frame update
    void Start()
    {
        //Should be a variable in playerStats
        DrawGasPip(playerStatsScript.GasPips);
    }

    public void DrawGasPip(float gasPips)
    {
        //Get the total size of the ui element
        Vector2 meterSize = gasMeter.sizeDelta;
        for(int i = 0; i < gasPips; i++)
        {
            GameObject currentGasPip = Instantiate(gasPip, transform);

            currentGasPip.transform.localScale =  new Vector2(1f, (1/gasPips));

            //The -70 is arbitrary and doesn't work for all number of gas pips, find an algorithm or solution that does
            float gasPipPosition = (meterSize.y * i/gasPips) - 70f;
            currentGasPip.transform.localPosition = new Vector2(0f, gasPipPosition);
        }
    }

    public void RemoveGasPip(float usedGasPip)
    {
        Destroy(transform.GetChild((int)usedGasPip).gameObject);
    }

}
