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
    public int maxHealth = 10;

    // GameOver section

    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;

    public CanvasGroup deadBackgroundImageCanvasGroup;

    public AudioSource gameOverAudio;
    public AudioSource gameStartAudio;
   

    bool m_HasStartAudioPlayed;
    bool m_HasEndAudioPlayed;

    // might need TXTMeshPro here
    [SerializeField]
    private TextMeshProUGUI healthTxt;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthTxt.text = health.ToString();
      
        player = GameObject.Find("squirrel");
        if (!m_HasStartAudioPlayed)
            {
                gameStartAudio.Play();
                m_HasStartAudioPlayed = true;
            }

    }

    void Update ()
    {
         
        // if (player.gameObject == null)
       //  {
            //EndLevel (deadBackgroundImageCanvasGroup, false, gameOverAudio);
            //gameOverAudio.play()
            //gameStartAudio.Stop(gameStartClip);
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
    void EndLevel (CanvasGroup deadBackgroundImageCanvasGroup, bool doRestart, AudioSource gameOverAudio)
    {

        deadBackgroundImageCanvasGroup.alpha = 1;

        if (m_HasStartAudioPlayed == true)
            {
                gameStartAudio.Stop();
                m_HasStartAudioPlayed = false;
            }

        if (!m_HasEndAudioPlayed)
        {
            gameOverAudio.Play();
            m_HasEndAudioPlayed = true;
        }

        

    }

//AudioSource gameOverAudio

} //class
