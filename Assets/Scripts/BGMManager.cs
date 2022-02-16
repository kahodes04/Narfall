using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour {

    private static BGMManager bgmmanagerInstance;
    AudioSource audioSource1;

    void Awake()
    {
        audioSource1 = gameObject.GetComponent<AudioSource>();
        DontDestroyOnLoad(this);
        if (bgmmanagerInstance == null)
            bgmmanagerInstance = this;
        else
            Destroy(gameObject);
        
    }

    public IEnumerator FadeDown(float _fadetime, float _fadeto)
    {
        float startvolume = audioSource1.volume;

        if(startvolume > _fadeto)
        {
            while (audioSource1.volume > _fadeto)
            {
                audioSource1.volume -= startvolume * Time.deltaTime / _fadetime;

                yield return null;
            }
        }
        else
        {
            while (audioSource1.volume < _fadeto)
            {
                audioSource1.volume += startvolume * Time.deltaTime / _fadetime;

                yield return null;
            }
        }
    }
}
