using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HitCloud : MonoBehaviour
{
    Material material;
    bool isDissolving = false;
    float fade = 1f;
    PlayerMovement healthAccess;
    PolygonCollider2D polygonCollider2D;
    List<RawImage> heartRawImages;
    AudioSource audioSource;
    AudioClip audioClip;


    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioClip = Resources.Load("Audio/Cloud") as AudioClip;
        polygonCollider2D = GetComponent<PolygonCollider2D>();
        material = GetComponent<SpriteRenderer>().material;
        heartRawImages = new List<RawImage>();
        heartRawImages.Add(GameObject.Find("Heart1").GetComponent<RawImage>());
        heartRawImages.Add(GameObject.Find("Heart2").GetComponent<RawImage>());
        heartRawImages.Add(GameObject.Find("Heart3").GetComponent<RawImage>());
        healthAccess = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (isDissolving)
        {
            fade -= Time.deltaTime;
            if (fade <= 0f)
            {
                fade = 0f;
                isDissolving = false;
            }
            material.SetFloat("_Fade", fade);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isDissolving = true;
            audioSource.PlayOneShot(audioClip);
            healthAccess.TakeDamage(1);
            heartRawImages[healthAccess.GetPlayerHealth()].enabled = false;
            collision.GetComponent<Animator>().SetTrigger("isHit");
            polygonCollider2D.enabled = false;

            
        }
    }
}
