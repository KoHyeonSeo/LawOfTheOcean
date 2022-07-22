using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIExplain : MonoBehaviour
{
    [SerializeField] private GameObject explainImage;
    private PlayerInput playerInput;
    private void Awake()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        playerInput = UIManager.instance.PlayerObject.GetComponent<PlayerInput>();
    }
    private void Update()
    {
        if (playerInput.ExplainButton)
        {
           explainImage.SetActive(true);
        }
        else
        {
            explainImage.SetActive(false);
        }
    }
}
