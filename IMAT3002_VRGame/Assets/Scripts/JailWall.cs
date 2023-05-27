using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JailWall : MonoBehaviour
{
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
        if (other.gameObject.tag == "Rock")
        {
            health = health - 1;
        }
    }

    void HealthCheck()
    {
        if (health <= 0)
        {
            StartCoroutine(LoadLevelAfterDelay());
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;

        }
    }

    IEnumerator LoadLevelAfterDelay()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(1);
    }
}
