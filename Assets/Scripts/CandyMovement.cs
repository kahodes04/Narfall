using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyMovement : MonoBehaviour
{
    float speed;
    float candyID;
    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
    }
    public void SetSpeed(float _speed)
    {
        speed = _speed;
    }

    public void SetID(float _id)
    {
        candyID = _id;
    }
}
