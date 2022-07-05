using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetScreen : MonoBehaviour
{
    private void Start() => ScreenSetting();
    public void ScreenSetting()
    {
        int width = 1920;
        int height = 1080;

        Screen.SetResolution(width, height, true);
    }
}
