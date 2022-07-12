using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerHP : MonoBehaviour
{
    [SerializeField] Slider sliderHP;
    float hp;
    public float maxHP;
    GameObject player;
    PlayerHealth playerHP;
    //public float HP
    //{
    //    get 
    //    { return hp; }
    //    set
    //    {
    //        hp = value;
    //        sliderHP.value = value;
    //    }
    //}


    // Start is called before the first frame update
    void Start()
    {
        player = UIManager.instance.PlayerObject;
        playerHP = player.GetComponent<PlayerHealth>();
        maxHP = playerHP.MaxHealth;
        sliderHP.maxValue = maxHP;

    }

    // Update is called once per frame
    void Update()
    {
        player = UIManager.instance.PlayerObject;
        playerHP = player.GetComponent<PlayerHealth>();
        //maxHP = playerHP.PlayerHealthProp;

        hp = playerHP.Health;
        sliderHP.value = hp;
        
    }
}
