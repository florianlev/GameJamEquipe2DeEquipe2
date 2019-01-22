using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cinematiqueTransition : MonoBehaviour

{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(deleteAube());
    }

    // Update is called once per frame


    IEnumerator deleteAube()
    {
        yield return new WaitForSeconds(5.73f);
        Destroy(this.gameObject);

    }
}
