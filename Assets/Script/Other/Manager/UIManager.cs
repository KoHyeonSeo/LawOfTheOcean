using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private GameObject player;
    public static UIManager instance;
    private UIManager()
    {
        instance = this;
    }
    public Stack<GameObject> UIObject;
    private GameObject enemy;
    private void Awake()
    {
        player = GameObject.Find("Player");
        PlayerObject = player;
    }
    private void Update()
    {
        //if (enemy)
        //    Debug.Log($"Enemy 이름:{enemy.GetComponent<NameTag>().Name} \nEnemy Health: {enemy.GetComponent<EnemyHealth>().Health}");
        //else
        //{
        //    Debug.Log("enemy 없음");
        //}
    }

    public GameObject CurrentEnemy { get { return enemy; } set { enemy = value; } }
    public GameObject PlayerObject { get; set; }
    public bool IsOrbMoving { get; set; }
}
