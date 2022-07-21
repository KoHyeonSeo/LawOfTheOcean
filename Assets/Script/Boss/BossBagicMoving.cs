using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBagicMoving : MonoBehaviour
{
    [Header("sin 움직임 멤버변수")]
    [SerializeField] private float speed = 1;

    void Update()
    {

        float y = speed * Mathf.Sin(Time.time);

        transform.parent.position = new Vector3(transform.parent.position.x, y, transform.parent.position.z);
        if (y <= 0.001f && y >= -0.001f)
        {
            speed = Random.Range(0.5f, 3.1f);
        }
    }
}
