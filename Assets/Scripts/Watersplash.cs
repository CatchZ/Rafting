using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Watersplash : MonoBehaviour
{
    public ParticleSystem waterSplashing;
    private GameObject player;
    private Rigidbody playerRigidbody;
    public int SplashStartValue=1; 
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerRigidbody = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerRigidbody.velocity.magnitude>SplashStartValue) {
            Instantiate(waterSplashing,player.transform.position,player.transform.rotation);
        }
        
    }
}
