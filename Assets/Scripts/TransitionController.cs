using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionController : MonoBehaviour
{
    public SpriteRenderer sr;
    public float transitionSpeed = 1f;
    private float transitionProgress = 0f;
    private bool transitionStarted = false;
    private void Start()
    {
        StartCoroutine(LongComputation());
    }
    IEnumerator LongComputation()
    {
        yield return null;
    }
}
