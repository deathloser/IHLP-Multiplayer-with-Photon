using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    //for health/stamina UI
    public Text healthAmount;
    // public Text staminaAmount;
    CharacterStats playerStats;

    //for inventory UI
    // InventoryManager inventoryManager;

    void Start() {
        playerStats = GetComponent<CharacterStats>();
        // inventoryManager = GetComponent<InventoryManager>();
        SetStats();

        
    }

    private void Update() {
        SetStats();
    }
    //update stats UI
    void SetStats() {
        healthAmount.text = playerStats.currentHealth.ToString();
        // staminaAmount.text = playerStats.currentStamina.ToString();

    }

    

}
