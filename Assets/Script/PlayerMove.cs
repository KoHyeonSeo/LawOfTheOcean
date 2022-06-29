using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private PlayerInput playerInput;
    public float speed = 5;

    public Transform characterbody;
    public Transform cameraArm; 
    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();

    }

    // Update is called once per frame
    void Update()
    {
        float x = playerInput.XAxisDir;
        float z = playerInput.ZAxisDir;

        Vector3 dir = Vector3.right * x + Vector3.forward * z;
        dir.Normalize();
        dir = Camera.main.transform.TransformDirection(dir);
        transform.position += dir * speed * Time.deltaTime;

        

    }
   
}
