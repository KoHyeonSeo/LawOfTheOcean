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

    //��: -1,����:0,  ��: 1
    public float XAxisDir { get; private set; }
    //�Ʒ�: -1,����:0,  ��: 1
    public float ZAxisDir { get; private set; }
    //���콺 ��Ŭ���� 1(true), 0(false)
    public bool IsShootingButton { get; private set; }
    //�����̽��� ���� 1(true), 0(false)
    public bool YAxisDir { get; private set; }
    //���콺 Ŀ���� x�Է°� ��ȯ
    public float XMouseOut { get; private set; }
    //���콺 Ŀ���� y�Է°� ��ȯ
    public float YMouseOut { get; private set; }
    //���콺 ��ġ�� ��ȯ
    public Vector3 MousePosition { get; private set; }
    //��ų swap �ϱ����� �Է�
    //tab�� ������ true ��ȯ 
    public bool SwapButton { get; private set; }

    //��ų Steal �ϱ����� �Է�
    //Left Shift ������ true ��ȯ 
    public bool StealSkillButton { get; set; }

    //EscŰ�� ������ true ��ȯ
    public bool EscButton { get; private set; }

    //left ctrl ������ true ��ȯ
    public bool CopiedSkillUseButton { get; private set; }
    //left alt ������ true ��ȯ
    public bool ExplainButton { get; private set; }
    //MŰ ������ true ��ȯ
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
