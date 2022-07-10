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
    public float HP
    {
        get 
        { return HP; }
        set
        {
            hp = value;
            sliderHP.value = value;
        }
    }

    public void AddDamage()
    {
        HP = HP - 1;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
