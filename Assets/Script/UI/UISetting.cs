using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UISetting : MonoBehaviour
{
    [SerializeField] private GameObject quitButton;
    private GameObject canvas;
    private bool isCheck = false;
    private void Start()
    {
        canvas = transform.GetChild(0).gameObject;
        canvas.SetActive(false);
    }
    private void Update()
    {
        if (UIManager.instance.PlayerObject.GetComponent<PlayerInput>().EscButton)
        {
            if (canvas.activeSelf)
            {
                canvas.SetActive(false);
            }
            else
            {
                canvas.SetActive(true);
            }
        }
        if (canvas.activeSelf)
        {
            Time.timeScale = 0f;
            GameManager.instance.IsStopPlayerInput = true;
        }
        else
        {
            Time.timeScale = 1f;
            GameManager.instance.IsStopPlayerInput = false;
        }
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }
    public void GameExit()
    {
        Application.Quit();
    }
}
