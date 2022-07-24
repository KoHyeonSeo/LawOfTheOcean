using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class StartScript : MonoBehaviour
{
    [Serializable]
    public struct Script
    {
        public string Spanish;
        public string Korean;
    }

    [Header("ด๋ป็")]
    public List<Script> scripts;

    private float time = 0.05f;
    private float curTime = 0f;
    private float waitTime = 1.5f;
    private float curWaitTime = 0f;
    private Text text1;
    private Text text2;
    private bool isWait = false;

    int i = 0;
    int s = 0;
    int k = 0;
    private void Start()
    {
        text1 = transform.GetChild(0).GetComponent<Text>();
        text2 = transform.GetChild(1).GetComponent<Text>();
    }

    private void Update()
    {
        if (isWait)
        {
            curWaitTime += Time.deltaTime;
            if(curWaitTime >= waitTime)
            {
                isWait = false;
                curWaitTime = 0f;
                text1.text = "";
                text2.text = "";
            }
        }
        else
        {
            if (s >= scripts[i].Spanish.Length && k >= scripts[i].Korean.Length)
            {
                i++;
                s = 0;
                k = 0;
                isWait = true;
            }
            else
            {
                curTime += Time.deltaTime;
                if (curTime >= time)
                {
                    if (s < scripts[i].Spanish.Length)
                    {
                        text1.text += scripts[i].Spanish[s];
                        s++;
                    }
                    if (k < scripts[i].Korean.Length)
                    {
                        text2.text += scripts[i].Korean[k];
                        k++;
                    }
                    curTime = 0;
                }
            }
        }
    }
}
