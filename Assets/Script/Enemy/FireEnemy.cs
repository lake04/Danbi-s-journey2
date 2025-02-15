using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEnemy : Enemy
{
    public GameObject enemyFireBall;

    private float fireBallDis = 3;
    private float coolTime = 7;
    public bool readyFireball = true;
    public bool shotFireBall = true;
    public SpriteRenderer renderer;


    public void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        this.maxHp = 14;
        this.hp = maxHp;
        this.speed = 4f;
        this.attackDistance = 1.5f;
        this.attackTime = 4f;
        this.damage = 2;
        this.stopTime = 1;
        this.stopMove = true;
    }

    public void Update() 
    {
        //if(renderer.flipX == true)
        //{
        //    shotFireBall = true;
        //}
        //else if(renderer.flipX == false)
        //{
        //    shotFireBall = false;
        //}
        float dist = Vector2.Distance(gameObject.transform.position, player.transform.position);
        if (dist <= attackDistance)
        {
            StartCoroutine(Attackstop(stopTime));
        }
        if (dist <= fireBallDis)
        {
            if (readyFireball == true)
            {
                StartCoroutine(Skil());
            }
        }
    }

    private void LateUpdate()
    {
         Move();

    }

    protected override IEnumerator Attack(float attackTime)
    {
        yield return new WaitForSeconds(this.attackTime);
        Debug.Log("PlayerAttack");
        player.HpDown(this.damage);
    }
    public IEnumerator Attackstop(int stopTime)
    {
        StartCoroutine(Attack(attackTime));
        stopMove = false;
        yield return new WaitForSeconds(this.stopTime);
        stopMove = true;
    }

    public IEnumerator Skil()
    {
        Instantiate(enemyFireBall, gameObject.transform.position, Quaternion.identity);
        readyFireball = false;
        yield return new WaitForSeconds(coolTime);
        readyFireball = true;
        Debug.Log("น฿ป็");
    }
    
}
