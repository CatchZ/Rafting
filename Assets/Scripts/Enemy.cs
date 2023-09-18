using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float force = 5.0f;
    public float maxSpeed = 40f;
    private Rigidbody enemyRb;
    private GameObject player;
    public int damage = -30;
    private GameManager gameManager;
    public ParticleSystem crashExplosion;
    private MaterialColourChange colorChangeManager;
    // Start is called before the first frame update
    void Start()
    {
        colorChangeManager = GameObject.Find("ColorChangeManager").GetComponent<MaterialColourChange>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive) { Chase(); }
       
        


    }
    private void Chase() {
        if (enemyRb.velocity.magnitude < maxSpeed)
        {
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;

            enemyRb.AddForce(lookDirection * force);
        }
        transform.LookAt(player.transform);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            colorChangeManager.ChangeColorForAmountOfTime();
            gameManager.UpdateLeben(damage);
            Destroy(gameObject);
            gameManager.GameOverCheck();
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Instantiate(crashExplosion, transform.position, crashExplosion.transform.rotation);
            Destroy(gameObject);
        }
    }


}
