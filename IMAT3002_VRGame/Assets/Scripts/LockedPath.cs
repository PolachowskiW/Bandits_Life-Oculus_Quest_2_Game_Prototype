using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedPath : MonoBehaviour
{
    public GameObject Key;
    public GameObject HiddenObject;
    public GameObject Blockade;
    

    // Start is called before the first frame update
    void Start()
    {
        HiddenObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Key)
        {
            HiddenObject.SetActive(true);
            Destroy(Key);
            Destroy(Blockade);
        }
    }
}
