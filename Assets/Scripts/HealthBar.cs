using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private float maxHealth;
    private float currentHealth;

    /*void start()
    {
        
    }*/

    void update()
    {
        setMinHealth(0.0f);
    }

    public Slider bar;

    public void setMaxHealth(float health) {
        bar.maxValue = health;
        maxHealth = health;
    }

    public void setMinHealth(float health) {
        bar.minValue = health;
    }

    public void setHealth(float health){
        bar.value = health;
        currentHealth = health;
    }

    public float getMaxHealth() {
        return maxHealth;
    }

    public float getCurrentHealth() {
        return currentHealth;
    }

    public void TakeDamage(float damage) {
         if ((currentHealth - damage) < 0){
            currentHealth = 0.0f;
            setHealth(currentHealth);
         }else {
         currentHealth -= damage;
         setHealth(currentHealth);
         }
     }

     public void Heal(float heal) {
         if ((currentHealth + heal) > maxHealth){
            currentHealth = maxHealth;
            setHealth(currentHealth);
         } else {
         currentHealth += heal;

         setHealth(currentHealth);
         }
     }

     public void IncreaseMaxHP(float increase) {
         maxHealth += increase;

         setMaxHealth(maxHealth);
         
     }

     public void DecreaseMaxHP(float decrease) {
         if (maxHealth < 0) {
             maxHealth = 0.0f;
         } else {
             maxHealth -= decrease;
         }

         if (currentHealth > maxHealth) {
             currentHealth = maxHealth;
        }

         setMaxHealth(maxHealth);
     }

    
}
