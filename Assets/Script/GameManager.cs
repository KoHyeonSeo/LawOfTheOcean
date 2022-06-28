using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = new GameManager();
    private GameManager(){ }
    public static GameManager getGameManager()
    {
        return instance;
    }

    [SerializeField] private int itemNum;

    public int GetAllItemNum
    {
        get
        {
            return itemNum;
        }
        set
        {
            itemNum = value;
        }
    }

}
