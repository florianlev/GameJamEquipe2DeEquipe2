using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    public Transform destination;
    public List<GameObject> enemyDeath;
    float yDestination = 58;

    private float speed = 0.2f;


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
        }
    }

    void killAllEnemy() {

    }


}
