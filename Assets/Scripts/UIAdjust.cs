using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAdjust : MonoBehaviour
{
    UnityEngine.UI.CanvasScaler scaler;
    void Start()
    {
        scaler = gameObject.GetComponent<UnityEngine.UI.CanvasScaler>();
        if(Screen.height > Screen.width)
            scaler.referenceResolution = new Vector2(Screen.width,Screen.height);
        else
            scaler.referenceResolution = new Vector2(Screen.height, Screen.width);
    }
}
