using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" || collision.tag == "FireEnemy")
        {
            collision.GetComponent<Enemy>().TakeDamage(2);
            Destroy(this.gameObject,0.2f);
        }
        if (collision.CompareTag("Boss"))
        {
            Boss boss = collision.GetComponent<Boss>();

            if (boss.isSkilldDamaged == true)
            {
                boss.TakeDamage(3);
            }
        }
    }
}
