using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class HitCandy : MonoBehaviour
{
    PolygonCollider2D polygonCollider2D;
    public TextMeshProUGUI tmp;
    AudioSource audioSource;
    AudioClip audioClip;
    ParticleSystem ps;
    Material material;
    bool isDissolving = false;
    float fade = 1f;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioClip = Resources.Load("Audio/Candy") as AudioClip;
        tmp = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        polygonCollider2D = GetComponent<PolygonCollider2D>();
        material = GetComponent<SpriteRenderer>().material;
        ps = GetComponent<ParticleSystem>();
    }
    private void Update()
    {
        if (isDissolving)
        {
            fade -= (Time.deltaTime*2);
            if (fade <= 0f)
            {
                fade = 0f;
                isDissolving = false;
            }
            material.SetFloat("_Fade", fade);
        }
    }
    public void AddScore(float _score)
    {
        tmp.text = (Convert.ToInt32(tmp.text) + 20.ToString());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Collided with candy");
            audioSource.PlayOneShot(audioClip);
            polygonCollider2D.enabled = false;
            tmp.text = (Convert.ToInt32(tmp.text) + 10).ToString();
            isDissolving = true;
            ps.Play();
        }
    }



}
