using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject DamageCollider;

    private void Start()
    {
        DamageCollider.GetComponent<Collider>().enabled = false;
    }
    public void Active()
    {
        DamageCollider.GetComponent<Collider>().enabled = true;
    }

    public void InActive()
    {
        DamageCollider.GetComponent<Collider>().enabled = false;
    }
}
