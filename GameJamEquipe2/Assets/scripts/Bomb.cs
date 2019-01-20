using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    public Transform destination;
    float yDestination = 58;

    private Enemy enemy;
    GameObject enemyObject;


    private float speed = 0.2f;

    void Start()
    {
        if (enemyObject == null)
        {
            enemyObject = GameObject.FindWithTag("enemy");
            enemy = enemyObject.GetComponent<Enemy>();
        }
    }

    void Update()
    {
        if (this.gameObject.transform.position.y != yDestination)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, destination.position, step);


        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "player") {
            Destroy(this.gameObject);
            killAllEnemy();
        }
    }

    private void killAllEnemy() {
        GameObject[] listEnemy;

        listEnemy = GameObject.FindGameObjectsWithTag("enemy");
        for(int i =0; i<listEnemy.Length; i++)
        {
            listEnemy[i].gameObject.GetComponent<Enemy>().deathBomb();
        }
        Debug.Log(listEnemy[0].name);
    }


}
