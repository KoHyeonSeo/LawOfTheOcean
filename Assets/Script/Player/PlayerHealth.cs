using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : EntityHealth
{
    [SerializeField] private float playerHealth = 100;
    [SerializeField] private AudioClip hurtSound;
    private AudioSource source;
    public bool IsUnbeatable { get; set; }
    public bool IsHurt { get; set; }
    private void Awake()
    {
        this.DeadCheck = false;
        this.Health = playerHealth;
        this.MaxHealth = playerHealth;
        IsUnbeatable = false;
        IsHurt = false;
    }
    private void Start()
    {
        source = GetComponent<AudioSource>();   
    }
    public override void Damage(float power)
    {
        if (!IsUnbeatable)
        {
            source.PlayOneShot(hurtSound);
            IsHurt = true;
            base.Damage(power);
        }
    }
    public override void Heal(float healing)
    {
        base.Heal(healing);
    }

    protected override void Die()
    {
        base.Die();
       SceneManager.LoadScene("GameOverScene");
        

    }



}
