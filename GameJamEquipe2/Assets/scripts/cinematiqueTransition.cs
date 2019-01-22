using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cinematiqueTransition : MonoBehaviour


{


    public GameObject loading;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(deleteAube());

    }

    // Update is called once per frame


    IEnumerator deleteAube()
    {
        yield return new WaitForSeconds(5.73f);
        //Destroy(this.gameObject);
        this.gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
        loading.gameObject.SetActive(true);

        yield return new WaitForSeconds(0.50f);

        SceneManager.LoadScene("MainScene");
        Destroy(this.gameObject);
    }
}
