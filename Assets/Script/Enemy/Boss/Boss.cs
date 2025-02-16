using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Boss : MonoBehaviour
{
    public bool isBossZone = false;
    [SerializeField]
    private float damage = 5;
    [SerializeField]
    private float hp;
    [SerializeField]
    private float maxhp = 100;
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

    [SerializeField]
    public bool isSkilldDamaged = true;


    void Start()
    {
        hp = maxhp;

        if(hp <= 0)
        {
            SceneManager.LoadScene("chapter 2");
        }
        
    }

    void Update()
    {
        if(isBossZone == true)
        {
            if (isAttack)
            {

                StartCoroutine(Attack(colltime));
                Instantiate(attackEffect, new Vector2(player.transform.position.x + 4.5f, player.transform.position.y), Quaternion.identity);

            }
            if (isbreathe == true)
            {
                StartCoroutine(breathe(breatheColltime));
                Instantiate(fire, breathSpawn);

            }
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
    public void TakeDamage(float damage)
    {
        if (hp > 0 && isSkilldDamaged == true)
        {
            if (hp <= 0)
            {
                SceneManager.LoadScene("chapter 2");
            }
            hp -= damage;
            Debug.Log("TakeDamage");
            StartCoroutine(SkillDamagedRoutine(1f));

        }
        if (hp <= 0)
        {
            SceneManager.LoadScene("chapter 2");
        }
    }

     public IEnumerator SkillDamagedRoutine(float skillTime)
    {
        this.isSkilldDamaged = false;
        yield return new WaitForSeconds(skillTime);
        this.isSkilldDamaged = true;
    }
}
