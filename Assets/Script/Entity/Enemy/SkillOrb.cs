using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillOrb : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    private Transform player;
    private Vector3 dir;
    private bool isTouch = false;
    public bool IsTouch { get { return isTouch; } set { isTouch = value; }  }
    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        dir = player.position + player.forward - transform.position ;
        transform.position += speed * dir * Time.deltaTime;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            IsTouch = true;
        }
    }
}
