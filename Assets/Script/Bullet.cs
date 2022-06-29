using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//필요 속성: 마우스 포인터 위치, 총알 속도
public class Bullet : MonoBehaviour
{
    [Header("총알 속성")]
    [SerializeField] private float speed = 10;
    [SerializeField] private float shootRange = 100f;
    private GameObject player;
    private PlayerInput playerInput;
    private Vector3 dir;
    //총알을 마우스 포인터 방향으로 이동시킨다.
    private void Awake()
    {
        //필요속성: 입력값
        player = GameObject.Find("Player");
        playerInput = player.GetComponent<PlayerInput>();
    }
    private void Start()
    {
        //마우스 포인터 방향으로
        dir = new Vector3(this.transform.position.x + playerInput.MousePosition.x,playerInput.MousePosition.y, this.transform.position.z + shootRange);
        dir.Normalize();
    }
    void Update()
    {
        //총알을 이동시킨다.
        this.transform.position += dir * speed* Time.deltaTime;
    }
}
