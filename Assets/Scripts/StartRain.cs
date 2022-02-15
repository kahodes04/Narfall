using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRain : MonoBehaviour
{
    ParticleSystem rain;

    private void Awake()
    {
        rain = GetComponent<ParticleSystem>();
    }
    public void PlayRain()
    {
        rain.Play();
    }
}
