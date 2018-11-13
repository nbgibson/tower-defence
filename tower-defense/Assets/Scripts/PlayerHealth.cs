using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerHealth : MonoBehaviour {

    [SerializeField] int health = 10;
    [SerializeField] int healthDecrease = 1;
    [SerializeField] TextMeshProUGUI healthText;

    void Start()
    {
        healthText.text = health.ToString();  
        
    }

    private void OnTriggerEnter(Collider other)
    {
        health -= healthDecrease;
        healthText.text = health.ToString();
    }
}
