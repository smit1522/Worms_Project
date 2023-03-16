using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SquirrelHealth : MonoBehaviour
{

    private int health;
    public int maxHealth = 3;

    // might need TXTMeshPro here
    [SerializeField]
    private TextMeshProUGUI healthTxt;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthTxt.text = health.ToString();
    }

    public void ChangeHealth(int change) {

        health += change;

        if(health > maxHealth)
        {
            health = maxHealth;
        }
        else if(health <= 0)
        {
            health = 0;
            Destroy(this.gameObject);
        }

        // might need TXTMeshPro here
        healthTxt.text = health.ToString();
    }



} //class
