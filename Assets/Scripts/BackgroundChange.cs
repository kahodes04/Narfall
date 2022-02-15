using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class BackgroundChange : MonoBehaviour
{
    Renderer rend;
    //float clamp1;
    //float clamp2;
    //float clamp3;
    //float clamp4;
    //float clamp5;
    //float clamp6;
    //float clamp7;
    //float clamp8;
    //float clamp1and2;
    //float clamp3and4;
    //float clamp12and34;
    //List<float> listOfClamps;
    float clampValue = 0;
    int currentClamp = 0;
    float count = 0;

    bool forward = true;
    StringBuilder sb = new StringBuilder();
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        //listOfClamps = new List<float>();
        //listOfClamps.Add(clamp1); listOfClamps.Add(clamp1and2); listOfClamps.Add(clamp2); listOfClamps.Add(clamp12and34); listOfClamps.Add(clamp3);
        //listOfClamps.Add(clamp3and4); listOfClamps.Add(clamp4);
    }

    // Update is called once per frame
    void Update()
    {
        if (forward)
        {
            if (count >= 15)
            {
                if (clampValue < 1)
                    clampValue += (Time.deltaTime / 10);
                else
                {
                    if (currentClamp < 6)
                    {
                        currentClamp++;
                        clampValue = 0;
                        count = 0;
                    }
                    else
                        forward = false;
                }
                
            }
            count += Time.deltaTime;
        }

        //}
        //else
        //{
        //    if (clampValue > 0)
        //        clampValue -= 0.0001f;
        //    else
        //    {

        //        if (currentClamp > 0)
        //        {
        //            currentClamp--;
        //            clampValue = 1;
        //        }
        //        else
        //            forward = true;
        //    }
        //}
        sb.Append("_");
        sb.Append(currentClamp);
        rend.material.SetFloat(sb.ToString(), clampValue);
        sb.Clear();
    }
}
