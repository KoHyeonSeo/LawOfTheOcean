using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//필요 속성: 입력값, 총알
public class PlayerShooter : MonoBehaviour
{
    
    [Header("총알 관련 설정")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletMaxDistance = 950;
    [SerializeField] private Transform firePos;
    
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
        Vector3 mousepos = new Vector3(Screen.width / 2, Screen.height / 2);
       
        mousepos.z = bulletMaxDistance;
        Vector3 v = Camera.main.ScreenToWorldPoint(mousepos);
        Vector3 dir = v - firePos.position;

        BulletMaxDirection = dir;

        Debug.DrawRay(firePos.position, dir, Color.red);
        if (Physics.Raycast(firePos.position, dir.normalized, out hit, bulletMaxDistance) && hit.collider.tag != "DeadZone")
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
            if (GameManager.instance.IsStealUse)
            {
                GameManager.instance.IsStealUse = false;
            }
            else
            {
                GameManager.instance.IsStealUse = true;
            }
            //SteaSkillButton 초기화
            playerInput.StealSkillButton = false;
        }
        //마우스 왼클릭이 입력된다면
        if (playerInput.IsShootingButton)
        {
            //총알을 생성한다.
            bullet.transform.position = firePos.position;
            Instantiate(bullet);
        }
    }
}
