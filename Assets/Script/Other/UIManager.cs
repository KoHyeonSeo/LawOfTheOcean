using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    private UIManager()
    {
        instance = this;
    }
    public static UIManager getUIManager()
    {
        return instance;
    }

}
