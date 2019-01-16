using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterObject : MonoBehaviour
{

    public int numberCharge;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetActive(bool activeStatus)
    {
        this.gameObject.SetActive(activeStatus);
    }

    public void SetParent(Transform transformParent)
    {
        this.gameObject.transform.parent = transformParent;
        if (transformParent != null)
        {
            this.GetComponent<Rigidbody>().isKinematic = true;
            this.GetComponent<Rigidbody>().useGravity = false;
        }
        else
        {
            this.GetComponent<Rigidbody>().isKinematic = false;
            this.GetComponent<Rigidbody>().useGravity = true;
        }
    }


    public virtual void Interraction(Enemy enemyInterractedWith)
    {
        //TO DO stuff
        //Debug.Log("interraction with " + enemyInterractedWith + " from masterObject");
        numberCharge--;
        if (numberCharge == 0)
        {
            Destroy(this.gameObject);
        }
    }

}
