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

    public virtual void PickedUp()
    {
        this.gameObject.SetActive(false);
    }

    public virtual void PlaceOnTable(Transform parent)
    {
        this.gameObject.SetActive(true);
        this.gameObject.transform.parent = parent;
    }

    public virtual void DropOnFloor(Transform position)
    {
        this.gameObject.SetActive(true);
        this.gameObject.transform.position = position.position;
    }

}
