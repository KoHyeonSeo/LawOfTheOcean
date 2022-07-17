using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextEnding : MonoBehaviour
{
    [SerializeField] private float endingTime = 30f;
    private float curTime = 0;

    private void Update()
    {
        curTime += Time.deltaTime;
        if(curTime >= endingTime)
        {
            SceneManager.LoadScene(0);
        }
    }
}
