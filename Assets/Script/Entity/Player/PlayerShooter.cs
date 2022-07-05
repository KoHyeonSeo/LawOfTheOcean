using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//필요 속성: 입력값, 총알
public class PlayerShooter : MonoBehaviour
{
    [Header("총알 관련 설정")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletMaxDistance = 1100;

    private PlayerInput playerInput;
    public Vector3 EnemyPosition { get; private set; }
    public Vector3 BulletMaxDirection { get; private set; }
    //스킬을 사용했는가
    public bool IsStealUse { get; set; }
    private void Start()
    {
        IsStealUse = false;
        //playerInput이 필요하다.
        playerInput = GetComponent<PlayerInput>();
    }
    private void Update()
    {
        Vector3 dir = new Vector3(transform.position.x + playerInput.MousePosition.x, playerInput.MousePosition.y, this.transform.position.z + bulletMaxDistance);
        Debug.DrawRay(transform.position, dir.normalized * bulletMaxDistance, Color.red);
        //어딘가에 닿았다면(deadzone 제외)
        if (GameManager.instance.StealSkillButton)
        {
            //SteaSkillButton 초기화
            GameManager.instance.StealSkillButton = false;
            IsStealUse = true;
        }
        //마우스 왼클릭이 입력된다면
        if (playerInput.IsShootingButton)
        {
            //총알을 생성한다.
            bullet.transform.position = transform.position;
            Instantiate(bullet);
        }
        BulletMaxDirection = dir;
    }
}
