using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private PlayerInput playerInput;
    // Start is called before the first frame update
    void Start()
    {

        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {

        if (playerInput.IsShootingButton)
        {
            Debug.Log("น฿ป็");
        }
    }
}
