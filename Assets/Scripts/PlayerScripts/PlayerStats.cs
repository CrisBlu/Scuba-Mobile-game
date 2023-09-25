using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    /* 
    Written by Christian Laverde

    This Script contains player values that need to be manipulated by other scripts
    and also player constants that other scripts need to reference 

    */
    //I can't understand C# events right now, this is hopefully a temporary way to remove gaspips when one is used
    [SerializeField] private GasDrawer gasDrawerScript;
    [HideInInspector] public bool gassedUp = false;
    [SerializeField] private float _gasPips;
    public float GasPips
    {
        get
        {
            return _gasPips;
        }
        set
        {
            _gasPips = value;
            gasDrawerScript.RemoveGasPip(value);

        }
    }

    public Vector2 DashDirection {get; set;}

    
    

}
