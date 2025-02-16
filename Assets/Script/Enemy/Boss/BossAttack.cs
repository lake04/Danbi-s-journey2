using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    
    void Start()
    {
        Destroy(this.gameObject,2);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().HpDown(5);
            Destroy(this.gameObject);
        }
    }
}

