using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//필요 속성: 입력값, 총알
public class PlayerShooter : MonoBehaviour
{
    
    [Header("총알 관련 설정")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletMaxDistance = 950;
    private RaycastHit hit;
    private PlayerInput playerInput;
    public Vector3 BulletMaxDirection { get; private set; }
    private void Start()
    {
        //playerInput이 필요하다.
        playerInput = GetComponent<PlayerInput>();
    }
    private void Update()
    {
        Vector3 mousepos = playerInput.MousePosition;
        mousepos.z = bulletMaxDistance;
        Vector3 v = Camera.main.ScreenToWorldPoint(mousepos);
        Vector3 dir = v - transform.position;

        BulletMaxDirection = dir;

        Debug.DrawRay(transform.position, dir, Color.red);
        if (Physics.Raycast(transform.position, dir.normalized, out hit, bulletMaxDistance) && hit.collider.tag != "DeadZone")
        {
            if (hit.collider.tag == "Enemy")
            {
                UIManager.instance.CurrentEnemy = hit.collider.gameObject;
            }
        }
        //어딘가에 닿았다면(deadzone 제외)
        else
        {
            UIManager.instance.CurrentEnemy = null;
        }

        if (playerInput.StealSkillButton)
        {
            //SteaSkillButton 초기화
            playerInput.StealSkillButton = false;
            GameManager.instance.IsStealUse = true;
        }
        //마우스 왼클릭이 입력된다면
        if (playerInput.IsShootingButton)
        {
            //총알을 생성한다.
            bullet.transform.position = transform.position;
            Instantiate(bullet);
            if(hit.collider != null && hit.collider.tag != "Enemy")
            {
                GameManager.instance.IsStealUse = false;
            }
        }
    }
}
