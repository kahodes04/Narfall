using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    private float speed = 0.5f;
    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
    }
}
