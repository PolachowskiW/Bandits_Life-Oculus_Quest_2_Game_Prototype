using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Statue : MonoBehaviour
{
    public GameObject Arm1;
    public GameObject Arm2;
    public GameObject Helm;
    public GameObject HiddenArm1;
    public GameObject HiddenArm2;
    public GameObject HiddenHelm;
    private bool Arm1In;
    private bool Arm2In;
    private bool HelmIn;


    // Start is called before the first frame update
    void Start()
    {
        HiddenArm1.SetActive(false);
        HiddenArm2.SetActive(false);
        HiddenHelm.SetActive(false);

        Arm1In = false;
        Arm2In = false;
        HelmIn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Arm1In && Arm2In && HelmIn)
        {
            Debug.Log("Statue fixed");
            StartCoroutine(LoadLevelAfterDelay());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Arm1)
        {
            HiddenArm1.SetActive(true);
            Destroy(Arm1);
            Arm1In = true;
            Debug.Log("Arm1 On");
        }

        if (other.gameObject == Arm2)
        {
            HiddenArm2.SetActive(true);
            Destroy(Arm2);
            Arm2In = true;
            Debug.Log("Arm2 On");
        }

        if (other.gameObject == Helm)
        {
            HiddenHelm.SetActive(true);
            Destroy(Helm);
            HelmIn = true;
            Debug.Log("Helm On");
        }
    }

    IEnumerator LoadLevelAfterDelay()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(1);
    }
}
