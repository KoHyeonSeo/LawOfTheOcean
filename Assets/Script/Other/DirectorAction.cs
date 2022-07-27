using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Cinemachine;
using UnityEngine.SceneManagement;

public class DirectorAction : MonoBehaviour
{
    private PlayableDirector pd;
    [SerializeField] private int sceneNum = 7;

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
            SceneManager.LoadScene(sceneNum);
        }
        if (Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene(sceneNum);
        }
    }
}
