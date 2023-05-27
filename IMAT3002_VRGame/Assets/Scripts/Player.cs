using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private float health;
    public float StartHealth;

    // Start is called before the first frame update
    void Start()
    {
        health = StartHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Reload();
        }
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Attack")
        {
            health = health - 1;
            Debug.Log("PLAYER: Damage Taken");
        }
    }

    void Reload()
    {
        SceneManager.LoadScene(0);
    }

}
