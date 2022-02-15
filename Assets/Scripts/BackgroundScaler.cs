using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScaler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer meshrenderer = gameObject.GetComponent<MeshRenderer>();
        float aspectratio;
        float valuemultiplyx = Screen.width / 1000f;
        float valuemultiplyy = Screen.height / 1000f;
        //Debug.Log(aspectratio);
        //gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * aspectratio, 1, gameObject.transform.localScale.z * aspectratio);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
