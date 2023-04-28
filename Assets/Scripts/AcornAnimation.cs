using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcornAnimation : MonoBehaviour
   
{
    public Animator acornMiss;
    public Animator acornHit;
    public AudioSource acornMissAudio;


    void Start()
    {
        acornMiss = GetComponent<Animator>();
        acornMissAudio = GetComponent<AudioSource>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tree"))
        {
            acornMissAudio.Play();
            acornMiss.Play("acornExplode");
            Destroy(this.gameObject, 0.5f);
        }

        
    }

}
