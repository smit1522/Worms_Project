using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private Rigidbody2D bulletPrefab;

    [SerializeField]
    private Transform currentGun;

    public float walkSpeed = 1f;
    public float maxRelativeVelocity = 6f;
    public float missileForce = 5f;

    public int playerID;

    private SpriteRenderer spriteRenderer;

    private Camera mainCam;

    // public bool IsTurn {}
    // WormHealth wormHealth;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
