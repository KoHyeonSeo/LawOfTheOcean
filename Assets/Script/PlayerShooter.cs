using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//필요 속성: 입력값, 총알
public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletMaxDistance = 300;

    private RaycastHit hit;
    private PlayerInput playerInput;
    public Vector3 EnemyPosition { get; private set; }
    public Vector3 BulletMaxDirection { get; private set; }
    public bool IsEnemyHit { get; private set; }
    private void Start()
    {
        IsEnemyHit = false;
        //playerInput이 필요하다.
        playerInput = GetComponent<PlayerInput>();
    }
    private void Update()
    {
        //마우스 왼클릭이 입력된다면
        if (playerInput.IsShootingButton)
        {
            Vector3 dir = new Vector3(this.transform.position.x + playerInput.MousePosition.x, playerInput.MousePosition.y, this.transform.position.z + bulletMaxDistance);
            dir.Normalize();
            Debug.DrawRay(transform.position, dir * 300, Color.red);
            //Enemy에 맞았다면,
            if (Physics.Raycast(transform.position, dir, out hit, bulletMaxDistance, 6))
            {
                Debug.Log("Enemy 맞음");
                IsEnemyHit = true;
                EnemyPosition = hit.transform.position;
            }
            else
            {
                IsEnemyHit = false;
                BulletMaxDirection = dir;
            }
            //총알을 생성한다.
            bullet.transform.position = this.transform.position;
            Instantiate(bullet);
        }  
    }
}
