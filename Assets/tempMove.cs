using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempMove : MonoBehaviour
{
    [SerializeField] private float speed = 0.3f;
    void Update()
    {
        float y = speed * Mathf.Sin(Time.time);

        transform.position += new Vector3(0, y * 0.008f, 0);
    }
}
