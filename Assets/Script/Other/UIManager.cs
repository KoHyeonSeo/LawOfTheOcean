using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance = new UIManager();
    private UIManager(){ }
    public static UIManager getUIManager()
    {
        return instance;
    }

}
