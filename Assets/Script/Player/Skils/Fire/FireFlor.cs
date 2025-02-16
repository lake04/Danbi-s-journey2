using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class FireFlor : Skil
{
    private Player player;

    private void Awake()
    {
        player = FindAnyObjectByType<Player>();
        this.cooltime1 = 2;
    }
    void Start()
    {
       Destroy(this.gameObject,0.2f);
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        StartCoroutine(skil1(collider));
    }

    private IEnumerator skil1(Collider2D collider)
    {
        Debug.Log("skil1");
        if (collider.CompareTag("Enemy"))
        {
            Enemy enemy = collider.GetComponent<Enemy>();

            if (!enemy.isSkilldDamaged)
            {
                enemy.TakeDamage(player.stats.damag);
            }
        }
        if (collider.CompareTag("Boss"))
        {
            Boss boss = collider.GetComponent<Boss>();

            if (boss.isSkilldDamaged == true)
            {
                boss.TakeDamage(3);
            }
        }
        yield return new WaitForSeconds(cooltime1);
    }
}
