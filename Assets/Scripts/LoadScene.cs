using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    AsyncOperation asyncOperation;
    public string sceneName;

    public RawImage transitionSpriteRenderer;
    public float transitionSpeed = 1f;
    private float transitionProgress = 0f;
    private bool transitionStarted = false;
    BGMManager backgroundMusic;

    void Start()
    {
        StartCoroutine(SceneLoader(sceneName));
    }

    IEnumerator SceneLoader(string _sceneName)
    {
        yield return null;
        asyncOperation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(_sceneName);
        asyncOperation.allowSceneActivation = false;
    }
    public void LoadNewScene()
    {
        asyncOperation.allowSceneActivation = true;
        

    }
    IEnumerator LongComputation()
    {
        while (transitionProgress < 1f)
        {
            transitionProgress += Time.deltaTime * transitionSpeed;
            //transitionSpriteRenderer.material.SetFloat("_Cutoff", transitionProgress);
            yield return null;
        }
        transitionStarted = false;
        asyncOperation.allowSceneActivation = true;

    }
}
