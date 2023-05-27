using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = Camera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Camera.transform.position;
    }
}
