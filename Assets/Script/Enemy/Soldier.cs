using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Soldier : Enemy
{
    [SerializeField]
    private GameObject enemyAttackE;

    void Start()
    {
        this.maxHp = 10;
        this.hp = maxHp;
        this.speed = 3f;
        this.attackDistance = 2f;
        this.attackTime = 2.5f;
        this.damage = 1;
        this.stopMove = true;
        this.stopTime = 1;
        this.isSkilldDamaged = true;
        this.isAttack = true;
    }

    void Update()
    {
        Move();
        float dist = Vector2.Distance(gameObject.transform.position,player.transform.position);
        if (dist <= attackDistance && this.isAttack == true)
        {
            StartCoroutine(Attackstop(stopTime));
            StartCoroutine(Attack(attackTime));
        }
    }

    protected override IEnumerator Attack(float attackTime)
    {
        Instantiate(enemyAttackE, gameObject.transform.position, quaternion.identity);
        player.HpDown(this.damage);
        this.isAttack = false;
        yield return new WaitForSeconds(this.attackTime);
        this.isAttack = true;
        Debug.Log("PlayerAttack");
    }
    public  IEnumerator Attackstop(int stopTime)
    {
        StartCoroutine(Attack(attackTime));
        stopMove = false;
        yield return new WaitForSeconds(this.stopTime);
        stopMove = true;
    }
}
