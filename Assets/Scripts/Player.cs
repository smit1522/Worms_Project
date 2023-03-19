using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private Rigidbody2D acornPrefab;

    [SerializeField]
    private Transform currentGun;

    PlayerStates CurrentState {
        set {
            m_currentState = value;

            switch(m_currentState) {
                case PlayerStates.IDLE:
                    m_animator.Play("Idle");
                    break;
                case PlayerStates.WALK:
                    m_animator.Play("Walk");
                    break;
            }
        }
    }

    public float walkSpeed = 1f;
    public float maxRelativeVelocity = 6f;
    public float missileForce = 5f;

    public int playerID;

    private SpriteRenderer spriteRenderer;

    private Camera mainCam;

    public bool IsTurn { get { return SquirrelManager.instance.IsMyTurn(playerID); } }
    
    private  SquirrelHealth squirrelHealth;

    private Vector3 diff;

    public AudioSource squirrelFootsteps;

    // Animation
    public enum PlayerStates {
        IDLE,
        WALK
    }

    PlayerStates m_currentState;

    private Animator m_animator;

    // Audio
    public AudioSource shootSound;

    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // get health script
        squirrelHealth = GetComponent<SquirrelHealth>();

        m_animator = GetComponent<Animator>();

        mainCam = Camera.main;

        squirrelFootsteps = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if(!IsTurn)
            return;

        RotateGun();

        MovementAndShooting();

        if (m_currentState == PlayerStates.WALK)
        {
            if(!squirrelFootsteps.isPlaying)
            {
                squirrelFootsteps.Play();
            }

        }
        else
        {
            squirrelFootsteps.Stop();
        }
    }

    void RotateGun() 
    {
        diff = mainCam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rot_Z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        currentGun.rotation = Quaternion.Euler(0, 0, rot_Z + 180f);
    }

    void MovementAndShooting() {

        float hor = Input.GetAxis("Horizontal");

        if(hor == 0) {

            CurrentState = PlayerStates.IDLE;

            m_animator.SetFloat("xMove", hor);
            // m_animator.SetFloat("yMove", hor.y);

            currentGun.gameObject.SetActive(true);

            

            if (Input.GetKeyDown (KeyCode.E)) {
                Rigidbody2D acorn = Instantiate(acornPrefab, currentGun.position - currentGun.right, currentGun.rotation);

                acorn.AddForce(-currentGun.right * 10f, ForceMode2D.Impulse);

                if (IsTurn) {
                    SquirrelManager.instance.NextSquirrel();
                }
            }

            if(hor > 0) {
                spriteRenderer.flipX = false;
            } else if (hor < 0) {
                spriteRenderer.flipX = true;
            }

        }
        else {

            CurrentState = PlayerStates.WALK;

            currentGun.gameObject.SetActive(false);

            transform.position += Vector3.right * hor * Time.deltaTime * walkSpeed;

            spriteRenderer.flipX = Input.GetAxis("Horizontal") > 0;

            
        }
       

    }


    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Acorn")) {

            squirrelHealth.ChangeHealth(-1);


            // is broken for some reason

            // if(IsTurn)
            //     SquirrelManager.instance.NextSquirrel();
        }
    }

  

}


// Notes
// 
// Griffin's Tasks
//
// Friday Coding
// Player win screen
// 
// Friday/Weekend
// Add Animation
// 
// 
// Adam's Tasks
// 
// Thursday
// Add Audio
// Footstep Audio can't be added until Animation is ready
// The Player Win screen needs to be added before I can add a 
//
//
//
// Thursday?/ Weekend
// Finish Background
// I have added the new House background asset and added more ground so that way the background color is not visible
// 