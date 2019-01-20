using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    public Transform destination;
    GameObject camera;
    float yDestination = 50;
    GameObject lightBomb;
    GameObject lightClientSpawn;

    private GameObject[] listParticles;

    public AudioClip songGregorien;
    public AudioClip halleluja;

    private AudioSource audioSource;


    private float speed = 0.4f;

    private void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        lightBomb = GameObject.FindGameObjectWithTag("LightBomb");
        lightClientSpawn = GameObject.FindGameObjectWithTag("light");
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = songGregorien;
        audioSource.Play();

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
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            audioSource.clip = halleluja;
            audioSource.Play();
            StartCoroutine(killAllEnemy());
        }
    }

    IEnumerator killAllEnemy() {
        GameObject[] listEnemy;
        GameObject lightClient = Instantiate(lightBomb, lightClientSpawn.transform.position, Quaternion.Euler(90, 0, 0));
        camera.GetComponent<CameraMovement>().moveCameraOnClient(true);
        yield return new WaitForSeconds(3);

        listEnemy = GameObject.FindGameObjectsWithTag("enemy");

        for (int i =0; i<listEnemy.Length; i++)
        {
            listEnemy[i].gameObject.GetComponent<Enemy>().deathBomb();
            yield return new WaitForSeconds(1);

        }
        
        camera.GetComponent<CameraMovement>().moveCameraOnClient(false);
        
        
        Destroy(lightBomb.gameObject);
        Destroy(lightClient.gameObject);
        yield return new WaitForSeconds(2.5f);

        destroyParticles();
        Destroy(this.gameObject);

    }

    private void destroyParticles()
    {
        listParticles = GameObject.FindGameObjectsWithTag("particle");

        if (listParticles != null)
        {
            for (int i = 0; i < listParticles.Length; i++)
            {
                Destroy(listParticles[i].gameObject);
            }
        }
    }


}
