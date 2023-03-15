using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;

    public float currentStamina;
    public float maxStamina;

    public bool isDead = false;

    public GameObject youDiedImage;
    public Text healthBar;

    void Start() {
        healthBar = GameObject.Find("HealthBar").GetComponent<Text>();
        youDiedImage = GameObject.Find("YouDiedImage");
        youDiedImage.SetActive(false);
    }

    void Update() {
        healthBar.text = currentHealth.ToString();
    }

    public virtual void CheckHealth() {
        if (currentHealth>=maxHealth) {
            currentHealth = maxHealth;
        } 
        if (currentHealth<=0) {
            currentHealth=0;
            isDead=true;
        }

        if(isDead) {
            youDiedImage.SetActive(true);


        }



    }

    public virtual void CheckStamina() {
        if(currentStamina>=maxStamina) {
            currentStamina=maxStamina;
        }
        if (currentStamina<=maxStamina) {
            currentStamina=0;
        }


    }

    public virtual void Die() {

        //override
    }

    public void TakeDamage(float damage) {
        currentHealth -= damage;
        Debug.Log(currentHealth);

        if(currentHealth<1) {
            Debug.Log("YOU DIED!");

        }




    }
}
