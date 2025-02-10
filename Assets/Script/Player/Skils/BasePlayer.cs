using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class BasePlayer : Skil
{
    [SerializeField]
    private Player player;
    [SerializeField]
    private Image skilImg1;
    [SerializeField]
    private Image skilImg2;
    [SerializeField]
    private GameObject ball;


    void Start()
    {
        this.cooltime1= 2f;
        this.cooltime2 = 4f;
        this.isPassive = true;

    }

    void Update()
    {
    }

    protected internal override IEnumerator PassiveSkill()
    {
        Debug.Log("ü�� ȸ��");

        yield return new WaitForSeconds(cooltime1);
        
        player.stats.Hp += 2;
    }
    protected internal override IEnumerator skil1()
    {
        player.stats.isShoting = false;
        Instantiate(ball, transform.position, Quaternion.identity);

        yield return new WaitForSeconds(cooltime1);
        collimage(this.cooltime1, skilImg1);

        player.stats.isShoting = true;
    }
    protected internal override IEnumerator skil2()
    {
        player.stats.moveSpeed = 8f;

        yield return new WaitForSeconds(cooltime2);
        collimage(this.cooltime2, skilImg2);

        player.stats.moveSpeed = 5f;
    }
   
}
