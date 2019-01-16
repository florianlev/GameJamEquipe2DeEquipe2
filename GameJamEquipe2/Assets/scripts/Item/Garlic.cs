using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garlic : MasterObject
{

    public List<GameObject> disapearingOrder;
    private int indexDisappearing;

    // Start is called before the first frame update
    void Start()
    {
        indexDisappearing = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interraction(Enemy enemyInterractedWith)
    {
        //Debug.Log("message from Cross");
        //Debug.Log(enemyInterractedWith.GetType());

        if (enemyInterractedWith.GetType() == typeof(Vampire))
        {
            Debug.Log("good job ! oops, the wood spike broke");
            disapearingOrder[indexDisappearing].SetActive(false);
            indexDisappearing++;
            base.Interraction(enemyInterractedWith);
        }

    }

}
