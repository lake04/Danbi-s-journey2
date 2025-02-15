using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField]
    private int damage = 5;
    [SerializeField]
    private int hp;
    [SerializeField]
    private int maxhp = 200;
    [SerializeField]
    private float colltime = 7;
    private bool isAttack = true;

    [SerializeField]
    private float breatheColltime = 15;
    private bool isbreathe = true;
    [SerializeField]
    private GameObject fire;
    [SerializeField]
    private Transform breathSpawn;

    [SerializeField]
    private GameObject attackEffect;
    [SerializeField]
    private Transform attackSpawn;
    [SerializeField]
    private Player player;
    
    void Start()
    {
        hp = maxhp;
        
    }

    void Update()
    {
        if(isAttack)
        {
           
            StartCoroutine(Attack(colltime));
        }
        if (isbreathe)
        {
            StartCoroutine(breathe(breatheColltime));
        }
    }

     private IEnumerator Attack(float attackTime)
    {
        Instantiate(attackEffect, attackSpawn);
        isAttack = false;
        yield return new WaitForSeconds(attackTime);
        isAttack = true;
    }

    private IEnumerator breathe(float breatheColltime)
    {
        Instantiate(fire, breathSpawn);
        isbreathe = false;
        yield return new WaitForSeconds(breatheColltime);
        isbreathe = true;
    }
}
