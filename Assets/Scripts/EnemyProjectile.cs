using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{

    public GameObject enemyProjectile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //to fly constantly downwards
        transform.Translate(new Vector3(0, -5 * Time.deltaTime, 0));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //behavior on collision with player
        if(collision.gameObject.tag == "Player")
        {
            //set Player position on respawn, destroy the projectile, pause the game and decrement a live
            collision.gameObject.transform.position = PlayerScript.respawnLocation;
            Destroy(enemyProjectile);
            GameManager.isGameRunning = false;
            GameManager.lives--;
            
        }

        //destroy projectile when out of screen 
        if(collision.gameObject.tag=="Border")
        {
            Destroy(enemyProjectile);
        } 
    }
}
