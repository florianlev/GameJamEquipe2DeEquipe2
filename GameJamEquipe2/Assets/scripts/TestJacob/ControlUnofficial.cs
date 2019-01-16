using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlUnofficial : MonoBehaviour
{
    public int movementSpeeed = 5;
    CharacterController CC;
    // Start is called before the first frame update
    void Start()
    {
       CC = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float MovX = Input.GetAxis("Horizontal_P1");
        float MovZ = Input.GetAxis("Vertical_P1");

        Vector3 speed = new Vector3(MovX * movementSpeeed, 0, MovZ * movementSpeeed);

        CC.Move(speed * Time.deltaTime);
    }
}
