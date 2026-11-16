using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Player : Character
{
    // OnTriggerEnter2D, OnTriggerStay2D, OnTriggerExit2D
    // digunakan kalau isTrigger = True(centang)
    // OnTiggerEnter2D dijalankan saat pertama kali collision
    // OnTrigerExit2D dijalankan setelah terjadi collision
    // OnTriggerStay2D ==> Selama Collision/Collider

    // OnCollisionEnter2D => isTigger == OFF
    // OnCollisionEnter2D, OnCollisionStay2D, OnCollisionExit2D

    //OnTriggerEnter2D(Collider2D collider)
    //OnCollisionEnter2D(Collision2D collision)

    public HealthBar healthBarPrefab;
    HealthBar healthBar;

    void Start()
    {
        healthPoint.value = startingHealthPoint;
        healthBar = Instantiate(healthBarPrefab);
        healthBar.character = this;
    }

    public int coin_quantity=0;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("CanBePickUp"))
        {
            Item hitObject = other.gameObject.GetComponent<Consumable>().item;
            if(hitObject != null)
            {
                bool shouldDisappear =false;
                Debug.Log("Object : " + hitObject.objectName);
                switch(hitObject.itemType)
                {
                    case Item.ItemType.COIN:
                        coin_quantity += hitObject.quantity;
                        Debug.Log("Coin : " + coin_quantity);
                        break;
                    case Item.ItemType.HEALTH:
                        shouldDisappear = AdjustHitPoints(hitObject.quantity);
                        break;
                    default:
                        break;
                }
            if (shouldDisappear)
            {
                other.gameObject.SetActive(false);
            }
            }
            
            
          }
        
    }

public bool AdjustHitPoints(int amount)
{
    // 6
    if (healthPoint.value < maxHealthPoint)
    {
        // 7
        healthPoint.value = healthPoint.value + amount;

        // 8
        print("Adjusted HP by: " + amount + ". New value: " + healthPoint.value);

        // 9
        return true;
    }

    // 10
    return false;
}

}
