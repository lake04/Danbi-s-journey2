using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEnemy : Enemy
{
    public GameObject enemyFireBall;

    private float fireBallDis = 5;
    private float coolTime = 7;
    public bool readyFireball = true;

    [SerializeField]
    private GameObject enemyAttack;

    void Start()
    {
        this.maxHp = 14;
        this.hp = maxHp;
        this.speed = 4f;
        this.attackDistance = 3f;
        this.attackTime = 4f;
        this.damage = 2;
        this.stopTime = 5;
        this.stopMove = true;
        this.isSkilldDamaged = true;
        this.isAttack = true;
    }

    void Update()
    {

        float dist = Vector2.Distance(gameObject.transform.position, player.transform.position);
        if (dist <= attackDistance && this.isAttack == true)
        {
            StartCoroutine(Attackstop(stopTime));
            StartCoroutine(Attack(attackTime));
        }
        else if (dist <= fireBallDis)
        {
            this.stopMove = false;

            if (readyFireball == true)
            {
                StartCoroutine(Skil());

            }
        }
       else this.stopMove = true;
    }

    private void LateUpdate()
    {
         Move();

    }

    public IEnumerator Skil()
    {
        Instantiate(enemyFireBall, gameObject.transform.position, Quaternion.identity);
        readyFireball = false;
        yield return new WaitForSeconds(coolTime);
        readyFireball = true;
    }

    protected override IEnumerator Attack(float attackTime)
    {
        Instantiate(enemyAttack, gameObject.transform.position, Quaternion.identity);
        player.HpDown(this.damage);
        this.isAttack = false;
        yield return new WaitForSeconds(this.attackTime);
        this.isAttack = true;
        Debug.Log("PlayerAttack");
    }

}
