using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform[] players;

    Camera cam;

    public float yBias;
    public float zBias;
    public float speed;


    private void Start()
    {
        cam = GetComponent<Camera>();    
    }

    private void Update()
    {
        SetCameraPos();
    }

    void SetCameraPos()
    {
        Vector3 middle = Vector3.zero;
        int numPlayers = 0;

        for (int i = 0; i < players.Length; ++i)
        {
            if (players[i] == null)
            {
                continue; //skip, since player is deleted
            }
            middle += players[i].position;
            numPlayers++;

        }//end for every player

        //take average:
        middle /= numPlayers;


        //regarde si les joueurs dépasse la camera
        for (int i = 0; i < players.Length; ++i)
        {
            if (players[i] == null)
            {
                continue; //skip, since player is deleted
            }
            if (middle.z >= players[i].transform.position.z)
                middle.z = players[i].transform.position.z - zBias;
        }//end for every player
         //cam.gameObject.transform.position = (new Vector3(middle.x, yBias, middle.z));

         // The step size is equal to speed times frame time.
        float step = speed * Time.deltaTime;

        // Move our position a step closer to the target.
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(middle.x, yBias, middle.z), step);
    }



}
