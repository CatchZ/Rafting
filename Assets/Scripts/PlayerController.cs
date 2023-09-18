using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// controlls Speed of the players Movment
    /// </summary>
    public float speed = 15;
    /// <summary>
    /// ´controlls rotation speed of the player Objekt 
    /// </summary>
    public float turnSpeed = 40;
    /// <summary>
    /// decreasefactor that controlls slower Backward Movement
    /// </summary>
    public float backwardSpeedMod;
    /// <summary>
    ///  boundry Range of the Game
    /// </summary>
    public float boundryRange = 100;
    /// <summary>
    /// force of the Pushback
    /// </summary>
    public float pushbackForce = 50.0f;
    private Rigidbody rb;
    private float horizontallnput;
    private float forwardInput;
    private GameManager gameManager;
    public ParticleSystem waterSplashing;
    private GameObject player;
    public float waterSplashOfSet = 3.5f;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
      
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            OutOfBouncePushBack();
            Rotation(turnSpeed);
            ForwardBackwardMovement(speed, backwardSpeedMod);
        }
        FixYPosition();

    }
    /// <summary>
    /// rotates the Object by given speed
    /// </summary>
    /// <param name="turnSpeed"> speed of rotation</param>
    private void Rotation(float turnSpeed)
    {
        horizontallnput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontallnput);
        if (horizontallnput != 0) { Watersplash(); }
    }
    /// <summary>
    /// move Objeckt forward or Backwards
    /// </summary>
    /// <param name="speed">speed of Movment</param>
    /// <param name="backwardSpeedMod">Modifier that decreases speed of Negativ Movement</param>wa
    private void ForwardBackwardMovement(float speed, float backwardSpeedMod)
    {
       
            forwardInput = Input.GetAxis("Vertical");
        if (forwardInput < 0)
        {
           
            transform.Translate(Vector3.forward * Time.deltaTime * (speed / backwardSpeedMod) * forwardInput);
        }
        else
        {
            
            transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        }

        if (forwardInput != 0) {Watersplash() ;}
       
    }
    /// <summary>
    /// checks if player is in boundryRange if not pushes him back into it
    /// </summary>
    public void OutOfBouncePushBack()
    {
        // richtung x fahren und in die andere richtung geschubst werden
        if (transform.position.x > boundryRange)
        {
            rb.AddForce(Vector3.left*pushbackForce,ForceMode.Impulse);
        } else
        // links
        if (transform.position.x < -boundryRange)
        {
            rb.AddForce(Vector3.right * pushbackForce, ForceMode.Impulse);
        }
       // oben 
       else
        if (transform.position.z > boundryRange)
        {
            rb.AddForce(Vector3.back * pushbackForce, ForceMode.Impulse);
        } else
        //unten
        if (transform.position.z < -boundryRange)
        {
            rb.AddForce(Vector3.forward * pushbackForce, ForceMode.Impulse);
        }
    }

    private void FixYPosition()
    {
        transform.position = new Vector3(transform.position.x,0,transform.position.z);
        rb.angularVelocity = Vector3.zero;
    }

    private void Watersplash() {
        Instantiate(waterSplashing, player.transform.position - player.transform.forward * waterSplashOfSet, player.transform.rotation);
    }

}
