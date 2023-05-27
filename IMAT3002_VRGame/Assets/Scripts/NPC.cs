using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public float offset;
    public GameObject Player;
    public Transform PlayerDirection;
    private Quaternion Rotation;

    public bool DropsItem;
    public GameObject drop;

    private bool IsAngry;
    private float irritation;
    public float irritationLimit;
    private bool IsIrritated;
    public GameObject AttackCollider;

    public float health;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        AttackCollider.GetComponent<Collider>().enabled = false;
        irritation = 0;
        IsAngry = false;
        IsIrritated = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        IrritationCheck();
        AngryCheck();
        HealthCheck();

        if (IsIrritated)
        {
            Observe();
        }
        if (IsAngry)
        {
            AttackCollider.GetComponent<Collider>().enabled = true;
            Attack();
            Observe();
        }

    }

    void DropItem()
    {
        Instantiate(drop, transform.position, Quaternion.identity);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Throwable" && !IsAngry && irritation < irritationLimit)
        {
            irritation++;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            irritation = irritationLimit;
            health = health - 1;
            Debug.Log("Damaged");
        }
    }

    void IrritationCheck()
    {
        if (irritation < irritationLimit && irritation > 0)
        {
            IsIrritated = true;
        }
    }

    void AngryCheck()
    {
        if (irritation == irritationLimit)
        {
            IsAngry = true;
        }
    }

    void HealthCheck()
    {
        if (health <= 0)
        {
            if (DropsItem)
            {
                DropItem();
            }
            Destroy(gameObject);
        }
    }

    void Observe()
    {
        gameObject.transform.LookAt(new Vector3(PlayerDirection.position.x,  offset, PlayerDirection.position.z));

    }

    void Attack()
    {
        gameObject.transform.position = Vector3.MoveTowards(transform.position, new Vector3(Player.transform.position.x, transform.position.y, Player.transform.position.z), speed * Time.deltaTime);
    }

}
