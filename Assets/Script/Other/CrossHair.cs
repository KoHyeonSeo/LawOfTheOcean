using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossHair : MonoBehaviour
{
    [SerializeField] private GameObject image;
    [SerializeField] private RectTransform canvas;
    private PlayerInput player;
    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerInput>();
        image.transform.position = Vector3.zero;
    }
    private void Update()
    {
        image.transform.position = new Vector3(player.MousePosition.x + canvas.rect.width / 2, player.MousePosition.y + canvas.rect.height / 2, 0);
    }
}
