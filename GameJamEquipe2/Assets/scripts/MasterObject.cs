using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterObject : MonoBehaviour
{
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
    }

}
