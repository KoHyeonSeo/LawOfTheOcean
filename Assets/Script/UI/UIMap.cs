using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMap : MonoBehaviour
{
    [SerializeField] private GameObject mapImage;
    private PlayerInput playerInput;
    private void Awake()
    {
        mapImage.SetActive(false);
        transform.GetChild(0).gameObject.SetActive(true);
        playerInput =UIManager.instance.PlayerObject.GetComponent<PlayerInput>();
    }
    private void Update()
    {
        if (playerInput.MapButton)
        {
            mapImage.SetActive(true);
        }
        else
        {
            mapImage.SetActive(false);
        }
    }
}
