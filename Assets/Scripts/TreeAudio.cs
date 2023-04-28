using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeAudio : MonoBehaviour
{
    public AudioSource hitTree;

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Acorn"))
        {
            hitTree.Play();
           
        }
    }
}
