using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SquirrelHealth : MonoBehaviour
{
    // GameObjects
    public GameObject player;


    // Health Section

    private int health;
    public int maxHealth = 3;

    // GameOver section

    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;

    public CanvasGroup deadBackgroundImageCanvasGroup;

    public AudioSource gameOverAudio;

    bool m_HasAudioPlayed;

    // might need TXTMeshPro here
    [SerializeField]
    private TextMeshProUGUI healthTxt;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthTxt.text = health.ToString();

        player = GameObject.Find("squirrel");

    }

    void Update ()
    {
        
        // if (player.gameObject == null)
        // {
        //     EndLevel (deadBackgroundImageCanvasGroup, false, gameOverAudio);
        // }
        
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
            //Destroy(this.gameObject);
            player.SetActive(false);
            EndLevel (deadBackgroundImageCanvasGroup, false, gameOverAudio);
        }

        // might need TXTMeshPro here
        healthTxt.text = health.ToString();
    }

    // Game Ending screen when health is 0
    void EndLevel (CanvasGroup deadBackgroundImageCanvasGroup, bool doRestart, AudioSource audioSource)
    {

        deadBackgroundImageCanvasGroup.alpha = 1;

    }



} //class
