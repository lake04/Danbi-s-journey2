using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public bool isBossZone = false;
    [SerializeField]
    private int damage = 5;
    [SerializeField]
    private int hp;
    [SerializeField]
    private int maxhp = 200;
    [SerializeField]
    private float colltime = 20;
    private bool isAttack = true;

    [SerializeField]
    private float breatheColltime = 40;
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

    [SerializeField]
    private AudioSource breths;
    
    void Start()
    {
        hp = maxhp;
        
    }

    void Update()
    {
        if(isAttack)
        {
           
            StartCoroutine(Attack(colltime));
            Instantiate(attackEffect, attackSpawn);

        }
        if (isbreathe == true)
        {
            StartCoroutine(breathe(breatheColltime));
            Instantiate(fire, breathSpawn);

        }
    }

     private IEnumerator Attack(float attackTime)
    {
        isAttack = false;
        yield return new WaitForSeconds(attackTime);
        isAttack = true;
    }

    private IEnumerator breathe(float breatheColltime)
    {
        if (breths.isPlaying == false)
        {
            breths.Play();
        }
        
        isbreathe = false;
       
        yield return new WaitForSeconds(breatheColltime);
        isbreathe = true;
    }
}
