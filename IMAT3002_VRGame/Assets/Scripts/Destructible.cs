using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public GameObject drop;

    public float health;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HealthCheck();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            health = health - 1;
        }
    }

    void DropItem()
    {
        Instantiate(drop, transform.position, Quaternion.identity);
    }

    void HealthCheck()
    {
        if (health <= 0)
        {
            DropItem();
            Destroy(gameObject);
        }
    }
}
