using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public const string XAxis = "Horizontal";
    public const string ZAxis = "Vertical";
    public const string ShootButton = "Fire1";
    public const string YAxis = "Jump";
    public const string XMouseName = "Mouse X";
    public const string YMouseName = "Mouse Y";
    public const string SwapName = "Swap";
    public const string StealName = "Steal Skill";
    public const string CancelName = "Cancel";
    public const string CopiedSkillUseName = "Use Skill";
    public const string ExplainName = "Explain";

    //좌: -1,정지:0,  우: 1
    public float XAxisDir { get; private set; }
    //아래: -1,정지:0,  위: 1
    public float ZAxisDir { get; private set; }
    //마우스 왼클릭시 1(true), 0(false)
    public bool IsShootingButton { get; private set; }
    //스페이스바 사용시 1(true), 0(false)
    public bool YAxisDir { get; private set; }
    //마우스 커서의 x입력값 반환
    public float XMouseOut { get; private set; }
    //마우스 커서의 y입력값 반환
    public float YMouseOut { get; private set; }
    //마우스 위치를 반환
    public Vector3 MousePosition { get; private set; }
    //스킬 swap 하기위한 입력
    //tab을 누르면 true 반환 
    public bool SwapButton { get; private set; }

    //스킬 Steal 하기위한 입력
    //Left Shift 누르면 true 반환 
    public bool StealSkillButton { get; set; }

    //Esc키를 누르면 true 반환
    public bool EscButton { get; private set; }

    //left ctrl 누르면 true 반환
    public bool CopiedSkillUseButton { get; private set; }
    //left alt 누르면 true 반환
    public bool ExplainButton { get; private set; }
    //M키 누르면 true 반환
    public bool MapButton { get; private set; }
    private void Start()
    {
        GameManager.instance.IsStopAttack = false;
    }
    void Update()
    {
        if (!GameManager.instance.IsStopPlayerInput)
        {
            XAxisDir = Input.GetAxis(XAxis);
            ZAxisDir = Input.GetAxis(ZAxis);
            YAxisDir = Input.GetButtonDown(YAxis);
            XMouseOut = Input.GetAxis(XMouseName);
            YMouseOut = Input.GetAxis(YMouseName);
            MousePosition = Input.mousePosition;
            ExplainButton = Input.GetButton(ExplainName);
            MapButton = Input.GetKey(KeyCode.M);
            if (!GameManager.instance.IsStopAttack)
            {
                CopiedSkillUseButton = Input.GetButtonDown(CopiedSkillUseName);
                IsShootingButton = Input.GetButtonDown(ShootButton);
                SwapButton = Input.GetButtonDown(SwapName);
                if (!StealSkillButton)
                    StealSkillButton = Input.GetButtonDown(StealName);
            }
        }
        EscButton = Input.GetButtonDown(CancelName);
    }
}
