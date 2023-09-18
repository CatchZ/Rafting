using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int schadensWert = -20;
    public float pushForce = 5.0f;
    private GameManager gameManager;
    public float cooldownTime = 1.0f;
    private float lastCalledTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (Time.time - lastCalledTime > cooldownTime)
        {
            if (collision.gameObject.tag == "Player")
            {
                gameManager.UpdateLeben(schadensWert);
                Debug.Log("PlayerController Colided with Object");
                //Vektor des Kontaktes 
                lastCalledTime = Time.time;
            }

            if (collision.gameObject.tag == "Enemy")
            {
                Vector3 pushDirection = collision.contacts[0].normal;
                //push in die entgegengesetzte Richtung
                collision.gameObject.GetComponent<Rigidbody>().AddForce(-pushDirection * pushForce, ForceMode.Impulse);
            }
        }
        gameManager.GameOverCheck();
    }
    private void OnTriggerEnter(Collider other)
    {

    }

}
