using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    public BasePlayer _Player;

    #region enemy정보
    public float maxHp = 10;
    public float hp;
    public bool isSkilldDamaged;
    
    public float distance;
    public LayerMask isLayer;
    public float speed;
    public Player player;
    public Rigidbody2D rigidbody2D;
    public SpriteRenderer sp;

    public float attackDistance;
    public float attackTime;
    public int damage;
    public bool isAttack;

    [SerializeField]
    private GameObject fireEffect;
    [SerializeField]
    private AudioSource fireSound;
    #endregion

    #region 불 데미지 관련
    public int fireCount = 0;
    public int maxFireCount = 5;
    #endregion

    private void Awake()
    {
        player = FindAnyObjectByType<Player>();
        hp = maxHp;
        rigidbody2D = GetComponent<Rigidbody2D>();
        player = FindAnyObjectByType<Player>();
        _Player = FindAnyObjectByType<BasePlayer>();
        sp = GetComponent<SpriteRenderer>();
        fireSound = GetComponent<AudioSource>();
    }

    void Start()
    {
        player = FindAnyObjectByType<Player>();
        hp = maxHp;
        rigidbody2D = GetComponent<Rigidbody2D>();
        player = FindAnyObjectByType<Player>();
        _Player = FindAnyObjectByType<BasePlayer>();
        sp = GetComponent<SpriteRenderer>();
    }

    
    private void Update()
    {
     
        sp.flipX = true;
    }
  

    public void DestroyEnemy()
    {
            Destroy(this.gameObject);
    }

    public IEnumerator FireDamage()
    {
        Debug.Log("FireDamage");
        if (fireSound.isPlaying == false)
        {
            fireSound.Play();
        }
        while (true)
        {
            if (this.maxFireCount <= this.fireCount) break;
            this.TakeDamage(0.5f);
            Instantiate(fireEffect, new Vector2(transform.position.x, transform.position.y - 1), Quaternion.identity);
           
            
            yield return new WaitForSeconds(1.2f);
            this.fireCount++;
        }
        this.fireCount = 0;
    }

    public void TakeDamage(float damage)
    {
        if (hp >0)
        {
            if (hp <= 0)
            {
                //if(player.type == PlayerType.basic) { StartCoroutine(_Player.PassiveSkill()); }
                DestroyEnemy();
            }
            hp -= damage;
            Debug.Log("TakeDamage");
            StartCoroutine(SkillDamagedRoutine(1f));
           
        }
        if(hp <=0)
        {
            DestroyEnemy();
        }
    }

    public IEnumerator SkillDamagedRoutine(float skillTime)
    {
        this.isSkilldDamaged = true;
        yield return new WaitForSeconds(skillTime);
        this.isSkilldDamaged = false;
    }

    public void Move()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, distance, Vector2.one, distance,isLayer);
        Debug.Log($"{hit.collider.tag}");
        Vector3 targetPosition = hit.collider.transform.position;
       
        if (hit.collider.CompareTag("Player"))  
        {
        this.transform.position = Vector2.MoveTowards(this.transform.position,targetPosition, speed * Time.deltaTime);

        }
    }

    protected virtual IEnumerator Attack(float attackTime)
    {
        player.HpDown(damage);
        isAttack = false;
        yield return new WaitForSeconds(attackTime);
        isAttack = true;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, distance);
    }
}
