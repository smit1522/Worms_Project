using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private Rigidbody2D acornPrefab;

    [SerializeField]
    private Transform currentGun;

    public float walkSpeed = 1f;
    public float maxRelativeVelocity = 6f;
    public float missileForce = 5f;

    public int playerID;

    private SpriteRenderer spriteRenderer;

    private Camera mainCam;

    public bool IsTurn { get { return SquirrelManager.instance.IsMyTurn(playerID); } }
    
    private  SquirrelHealth squirrelHealth;

    private Vector3 diff;

    // Audio
    public AudioSource shootSound;

    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // get health script
        squirrelHealth = GetComponent<SquirrelHealth>();

        mainCam = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        if(!IsTurn)
            return;

        RotateGun();

        MovementAndShooting();
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

            currentGun.gameObject.SetActive(true);

            if (Input.GetKeyDown (KeyCode.E)) {
                Rigidbody2D acorn = Instantiate(acornPrefab, currentGun.position - currentGun.right, currentGun.rotation);

                acorn.AddForce(-currentGun.right * missileForce, ForceMode2D.Impulse);

                if (IsTurn) {
                    SquirrelManager.instance.NextSquirrel();
                }
            }

        }
        else {
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
// 
// Thursday?/ Weekend
// Finish Background
// 
// 