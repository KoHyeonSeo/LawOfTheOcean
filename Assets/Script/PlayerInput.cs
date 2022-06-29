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


    void Update()
    {
        XAxisDir = Input.GetAxis(XAxis);
        ZAxisDir = Input.GetAxis(ZAxis);
        IsShootingButton = Input.GetButtonDown(ShootButton);
        YAxisDir = Input.GetButtonDown(YAxis);
        XMouseOut = Input.GetAxis(XMouseName);
        YMouseOut = Input.GetAxis(YMouseName);
        //MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        MousePosition = Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2, 0);

    }
}
