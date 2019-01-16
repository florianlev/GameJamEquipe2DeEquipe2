using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pieu : MasterObject
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interraction(Enemy enemyInterractedWith)
    {
        //Debug.Log("message from Cross");
        //Debug.Log(enemyInterractedWith.GetType());

        if (enemyInterractedWith.GetType() == typeof(Wolf))
        {
            Debug.Log("good job ! oops, the wood spike broke");
            base.Interraction(enemyInterractedWith);
        }

    }
}
