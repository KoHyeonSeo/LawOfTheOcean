using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Cinemachine;
using UnityEngine.SceneManagement;

public class DirectorAction : MonoBehaviour
{
    private PlayableDirector pd;

    // Start is called before the first frame update
    void Start()
    {
        pd = GetComponent<PlayableDirector>();
        pd.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (pd.duration - pd.time <= 0.05f)
        {
            SceneManager.LoadScene(7);
        }
    }
}
