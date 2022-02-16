using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
public class PlayerMovement : MonoBehaviour
{
    
    float movementX;
    float movementSpeed = 30f;
    Rigidbody2D rb;
    int playerHealth = 3;
    Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    public Camera MainCamera;
    SpriteRenderer sr;
    public PlayableDirector playableDirector;
    SpawnCloud cloudSpawner;
    PolygonCollider2D playerCollider;
    public WordWobble wb;
    public TextMeshProUGUI tmp;
    bool notTryAgain = true;
    AudioSource audioSource;
    AudioClip audioClip;
    BGMManager backgroundMusic;
    
    void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioClip = Resources.Load("Audio/Lose") as AudioClip;
        rb = GetComponent<Rigidbody2D>();
        Input.gyro.enabled = true;
        sr = transform.GetComponent<SpriteRenderer>();
        cloudSpawner = GameObject.Find("Cloud Spawner").GetComponent<SpawnCloud>();
        playerCollider = GameObject.Find("Player").GetComponent<PolygonCollider2D>();
        if (GameObject.Find("Background Music") != null)
        {
            backgroundMusic = GameObject.Find("Background Music").GetComponent<BGMManager>();
            StartCoroutine(backgroundMusic.FadeDown(2f, 0.3f));
        }

    }
    void Update()
    {
        movementX = Input.acceleration.x * movementSpeed;

        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        objectWidth = sr.bounds.extents.x;
        objectHeight = sr.bounds.extents.y;

        if (rb.velocity.x < -1)
        {
            //sr.flipX = false;
            transform.localScale = new Vector3(0.45f, 0.45f, 0);
        }
            
        else if (rb.velocity.x > 1)
        {
            //sr.flipX = true;
            transform.localScale = new Vector3(-0.45f, 0.45f, 0);
        }
            
        
        if(playerHealth == 0 && notTryAgain)
        {
            StartCoroutine(backgroundMusic.FadeDown(2f, 0.15f));
            audioSource.PlayOneShot(audioClip);
            notTryAgain = false;
            cloudSpawner.SetIsAlive(false);
            playerCollider.enabled = false;
            playableDirector.Play();
            wb.isDead = true;
        }
    }
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
        transform.position = viewPos;
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movementX, 0f);
    }
    public void TakeDamage(int _damage)
    {
        playerHealth -= _damage;
    }
    public void GiveHealth(int _health)
    {
        playerHealth += _health;
    }
    public int GetPlayerHealth()
    {
        return playerHealth;
    }
}
