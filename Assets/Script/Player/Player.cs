using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class playerStats
{
    [Header("Player")]
    public float maxHP = 10f;
    public float Hp;
    public float Mp;
    public float maxMp =10f;
    public float attackspeed = 1f;
    public float damag = 2f;
    public float moveSpeed = 5f;
    public bool isShoting = true;
    public bool isSkil2 = true;
}
#region 타입
public enum PlayerType
{
    basic,
    fire,
    electricity,
    ice,
    ninja,
    legend
}
#endregion

public class Player : MonoBehaviour
{
    public playerStats stats = new playerStats();

    [Header("Type")]
    public PlayerType type;
    [SerializeField]
    private BasePlayer basePlayer;
    [SerializeField]
    private FirePlayer firePlayer;

    private Rigidbody2D rigidbody2D;
    public SpriteRenderer spriteRenderer;
    public Vector3 dir;

    private bool isJump;
    public int jumpPower = 5;

    [SerializeField]
    private SoundManager soundManager;


    #region 공격 
    [Header("Attack")]
    [SerializeField]
    private Vector2 boxSize;
    [SerializeField]
    private Transform rigntPos;
    [SerializeField]
    private Transform leftPos;
    #endregion


    private void Awake()
    {
        stats.Hp = stats.maxHP;
        stats.Mp = stats.maxMp;
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        type = PlayerType.basic;
        basePlayer = GetComponent<BasePlayer>();
        firePlayer = GetComponent<FirePlayer>();
    }
 
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if(Input.GetKeyDown(KeyCode.Q) && stats.isShoting == true)
        {
            soundManager.AudioPlay(0);
            if (type == PlayerType.basic)
            {
                //StartCoroutine(basePlayer.skil1());
                basePlayer.skil1();
            }
            if (type == PlayerType.fire)
            {
               firePlayer.skil1();
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && stats.isSkil2 == true)
        {
            soundManager.AudioPlay(1);
            Debug.Log("skil2");
            if (type == PlayerType.basic)
            {
                StartCoroutine(basePlayer.skil2());
            }
            if (type == PlayerType.fire)
            {
                StartCoroutine(firePlayer.skil2());
            }
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("해제");
            if (type != PlayerType.basic)
            {
                type = PlayerType.basic;
            }
        }
        Debug.Log($"isShoting:{stats.isShoting}");
    }
    void FixedUpdate()
    {
        Move();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) isJump = true;
    }
    #region 이동
    void Move()
    {
        if (Input.GetButton("Horizontal"))
        {
            float h = Input.GetAxisRaw("Horizontal");
            dir = new Vector3(h, 0f, 0f).normalized;
            transform.Translate(dir * stats.moveSpeed * Time.deltaTime);
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == 1;
        }
    }

    void Jump()
    {
        if (!isJump) return;

        rigidbody2D.velocity = Vector2.zero;

        Vector2 jumpVelocity = new Vector2(0, jumpPower);
        rigidbody2D.AddForce(jumpVelocity, ForceMode2D.Impulse);

        isJump = false;
    }
    #endregion

    #region 공격
    private void attack()
    {
        if (Input.GetMouseButtonDown(0) && stats.attackspeed <= 0)
        {
            Debug.Log("attack");

            if (spriteRenderer.flipX == true)
            {
                Collider2D[] collider2D = Physics2D.OverlapBoxAll(leftPos.position, boxSize, 0);
                foreach (Collider2D collider in collider2D)
                {
                    if (collider.tag == "Enemy") collider.GetComponent<Enemy>().TakeDamage(2);
                }
                stats.attackspeed = 0.5f;
                Debug.Log("leftAttack");
            }
            if (spriteRenderer.flipX == false)
            {
                Collider2D[] collider2D = Physics2D.OverlapBoxAll(rigntPos.position, boxSize, 0);
                foreach (Collider2D collider in collider2D)
                {
                    if (collider.tag == "Enemy") collider.GetComponent<Enemy>().TakeDamage(2);

                }
                stats.attackspeed = 0.5f;
                Debug.Log("RightAttack");
            }
        }

        else
        {
            stats.attackspeed -= Time.deltaTime;
        }
    }

    

    #endregion

    public void HpDown(int damgae)
    {
        if(stats.Hp > 0)
        {
            Debug.Log("HpDown");
            stats.Hp-=damgae;
        }
       /* else Destroy(this.gameObject);*/
    }
}
