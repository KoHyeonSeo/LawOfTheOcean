using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameTag : MonoBehaviour
{

    [Header("Object Name")]
    [SerializeField] private string name;
    public string Name { get { return name; } set { name = value; } }
    private void Start()
    {
        Name = name;
    }
}
