using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    float moveTimer = 0;
    float movePeriod = 0.5f;
    int numOfMovements = 0;
    int movementPeriod = 10;
    int moveDirection = 1;

    public GameObject enemy;
    public GameObject enemyProjectile;
    public GameObject enemyProjectileClone;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isGameRunning)
        {
            
            //constantly move enemies to side then down
            moveTimer += Time.deltaTime;
            if (moveTimer >= movePeriod)
            {
                transform.Translate(new Vector3(.2f * moveDirection, 0, 0));
                moveTimer = 0;
                numOfMovements++;
            }
            if (numOfMovements >= movementPeriod)
            {
                transform.Translate(new Vector3(0, -0.4f, 0));
                numOfMovements = 0;
                moveDirection *= -1;


            }
            fireEnemyProjectile();
        }
    }

    void fireEnemyProjectile()
    {
        //randomly fire
        if (Random.Range(0f, 500f) < 1)
        {
            enemyProjectileClone = Instantiate(enemyProjectile, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.8f, enemy.transform.position.z), enemy.transform.rotation) as GameObject;
        }
    }
}
