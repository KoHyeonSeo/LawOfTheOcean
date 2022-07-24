using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Portal : MonoBehaviour
{
    [SerializeField] private int portalIndex;
    [SerializeField] private bool endingSceneLoad = false;
    private Image fade;
    private bool startSceneLoad = false;
    private float endingTime = 34;
    private float curTime = 0;
    private AudioSource audio;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        fade = gameObject.transform.GetChild(0).GetChild(0).GetComponent<Image>();
    }
    private void Update()
    {
        if (endingSceneLoad && !startSceneLoad)
        {
            curTime += Time.deltaTime;
            if (curTime >= endingTime)
            {
                startSceneLoad = true;
                StartCoroutine("fadeIn");
            }
        }
    }
    private IEnumerator fadeIn()
    {
        float count = 0;
        while(count < 1.0f)
        {
            count += 0.005f;
            fade.color = new Color(0, 0, 0, count);
            yield return new WaitForSeconds(0.01f);
        }
        SceneManager.LoadScene(portalIndex);
        yield return new WaitForSeconds(0.01f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !startSceneLoad)
        {
            other.gameObject.tag = "Enemy";
            audio.Play();
            startSceneLoad = true;
            StartCoroutine("fadeIn");
        }
    }
}
