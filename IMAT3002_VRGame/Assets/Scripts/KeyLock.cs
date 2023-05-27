using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyLock : MonoBehaviour
{
    public GameObject Key;
    public GameObject HiddenObject;
    public GameObject Blockade;
    public GameObject Reward;

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
            Reward.transform.position = Blockade.transform.position;
            Destroy(Blockade);
        }
    }
}
