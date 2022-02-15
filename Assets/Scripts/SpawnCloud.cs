using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnCloud : MonoBehaviour
{
    private float maxTime = 1.5f;
    private float candySpawn = 5f;
    private float timer = 0;
    private float candyTimer = 0;
    private float horizontalPosition = 4;
    private float cloudSpeed = 4f;
    private float idSet = 0;
    private bool spawnCandy = false;
    public bool isAlive = true;
    public GameObject cloud;
    private GameObject randomCloud;
    public GameObject candy;
    private GameObject randomCandy;
    public TextMeshProUGUI tmp;
    Vector2 screenBounds;
    public Camera MainCamera;
    private void Start()
    {
        randomCloud = cloud.transform.GetChild(0).gameObject;
        randomCandy = candy.transform.GetChild(0).gameObject;
        tmp = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
    }

    private void Update()
    {
        if (isAlive)
        {
            if (timer > maxTime)
            {
                candyTimer++;
                if (candyTimer == 15)
                {
                    spawnCandy = true;
                }
                if (spawnCandy)
                {
                    spawnCandy = false;
                    candyTimer = 0;

                    tmp.text = (System.Convert.ToInt32(tmp.text) + 1).ToString();
                    StartCoroutine(AddScore(1));

                    GameObject candyToSpawn = Instantiate(candy.transform.GetChild(Random.Range(0, 3)).gameObject);
                    SpriteRenderer sr = candyToSpawn.GetComponent<SpriteRenderer>();
                    candyToSpawn.transform.position = transform.position + new Vector3(Random.Range(screenBounds.x * -1 + sr.bounds.extents.x, screenBounds.x - sr.bounds.extents.x), 0, 0);

                    candyToSpawn.GetComponent<CandyMovement>().SetSpeed(cloudSpeed);
                    candyToSpawn.GetComponent<CandyMovement>().SetID(idSet);

                    Destroy(candyToSpawn, 7);
                }
                else
                {
                    GameObject cloudToSpawn = Instantiate(cloud.transform.GetChild(Random.Range(0, 4)).gameObject);
                    SpriteRenderer sr = cloudToSpawn.GetComponent<SpriteRenderer>();
                    float random = Random.Range(screenBounds.x * -1 + sr.bounds.extents.x, screenBounds.x - sr.bounds.extents.x);
                    cloudToSpawn.transform.position = new Vector3(random, transform.position.y, 0);
                    StartCoroutine(AddScore(1));

                    cloudToSpawn.GetComponent<CloudMovement>().SetSpeed(cloudSpeed);
                    cloudToSpawn.GetComponent<CloudMovement>().SetID(idSet);

                    Destroy(cloudToSpawn, 7);
                }
                idSet++;
                timer = 0;

                if (cloudSpeed < 10)
                    cloudSpeed += 0.1f;

                if (maxTime > 0.5f)
                    maxTime -= 0.01f;
            }
            timer += Time.deltaTime;
        }
    }

    IEnumerator AddScore(int _score)
    {
        for (float i = 1f; i <= 1.4f; i += 0.05f)
        {
            tmp.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();
        }
        tmp.rectTransform.localScale = new Vector3(1.4f, 1.4f, 1.4f);
        tmp.text = (System.Convert.ToInt32(tmp.text) + _score).ToString();

        for (float i = 1.4f; i <= 1f; i -= 0.05f)
        {
            tmp.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();
        }
        tmp.rectTransform.localScale = new Vector3(1f, 1f, 1f);
    }

    public void SetIsAlive(bool _isAlive)
    {
        isAlive = _isAlive;
    }

}


