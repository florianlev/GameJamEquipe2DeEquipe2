using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    public Transform destination;
    public Camera camera;
    float yDestination = 58;

    private float speed = 0.2f;
    GameObject client;
    private bool inDeath = false;

    private void Start()
    {
        client = GameObject.FindGameObjectWithTag("client");

    }
    void Update()
    {
        if (this.gameObject.transform.position.y != yDestination)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, destination.position, step);

        }

        if (inDeath)
        {
            camera.transform.position = client.transform.position;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "player") {
            Destroy(this.gameObject);
            inDeath = true;
            StartCoroutine(killAllEnemy());
        }
    }

    IEnumerator killAllEnemy() {
        GameObject[] listEnemy;

        listEnemy = GameObject.FindGameObjectsWithTag("enemy");
        yield return new WaitForSeconds(1);

        for (int i =0; i<listEnemy.Length; i++)
        {

            listEnemy[i].gameObject.GetComponent<Enemy>().deathBomb();
            StartCoroutine(killAllEnemy());

        }
        inDeath = false;
        camera.transform.position = Vector3.MoveTowards(client.transform.position, transform.position, 1 * Time.deltaTime);

        Debug.Log(listEnemy[0].name);
    }


}
