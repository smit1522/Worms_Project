using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcornAnimation : MonoBehaviour
   
{
    public Animator acornMiss;
    public Animator acornHit;
    


    void Start()
    {
        acornMiss = GetComponent<Animator>();
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tree"))
        {
            
            acornMiss.Play("acornExplode");
            Destroy(this.gameObject, 0.5f);
        }

        
    }

}
