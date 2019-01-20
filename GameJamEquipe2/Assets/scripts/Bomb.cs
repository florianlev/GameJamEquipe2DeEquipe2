using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    public Transform destination;
    GameObject camera;
    float yDestination = 58;

    private float speed = 0.2f;
    GameObject client;
    private bool inDeath = false;

    private void Start()
    {
        client = GameObject.FindGameObjectWithTag("client");
        camera = GameObject.FindGameObjectWithTag("MainCamera");

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
           // Destroy(this.gameObject);
            inDeath = true;
            StartCoroutine(killAllEnemy());
        }
    }

    IEnumerator killAllEnemy() {
        GameObject[] listEnemy;
        camera.GetComponent<CameraMovement>().moveCameraOnClient();
        yield return new WaitForSeconds(5);

        listEnemy = GameObject.FindGameObjectsWithTag("enemy");

        for (int i =0; i<listEnemy.Length; i++)
        {

            listEnemy[i].gameObject.GetComponent<Enemy>().deathBomb();
            yield return new WaitForSeconds(1);


        }
        inDeath = false;
    }


}
