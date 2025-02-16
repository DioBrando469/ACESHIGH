using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] int playerHealth;
    [SerializeField] int maxPlayerHealth;
    [SerializeField] string hurtSound;
    void Start()
    {
        playerHealth = maxPlayerHealth;
    }
    public void TakeDamage(int damage)
    {
        FindObjectOfType<AudioManager>().Play(hurtSound);
        playerHealth -= damage;
    }
    public void TakeHealing(int healing)
    {
        playerHealth += healing;
    }
    public void SetHealth(int health){
        playerHealth = health;
    }
    public int ReturnHealth()
    {
        return playerHealth;
    }
    public int ReturnMaxHealth()
    {
        return maxPlayerHealth;
    }
}
