using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlayerSilence : MonoBehaviour
{
    [SerializeField] GameObject textSilence;

    void Update()
    {
        if (GameManager.instance.IsStopAttack)
        {
            textSilence.SetActive(true);
        }
        else
        {
            textSilence.SetActive(false);
        }
    }
}
