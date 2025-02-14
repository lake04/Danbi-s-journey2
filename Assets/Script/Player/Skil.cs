using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class Skil : MonoBehaviour
{
    public float cooltime1;

    public float cooltime2;
    public bool isSkil2 = true;
    public bool isPassive = false;

    protected internal virtual IEnumerator PassiveSkill()
    {
        yield return new WaitForSeconds(cooltime1);
    }

    protected virtual internal void skil1()
    {

    }

    protected virtual internal IEnumerator skil2()
    {
        yield return new WaitForSeconds(cooltime2);
    }
    protected internal virtual IEnumerator collimage(float cooltimeMax, Image disble, Action<bool> isSkil)
    {
        Debug.Log("coolImage");
        float cooltime1 = cooltimeMax;
        isSkil(false); 

        while (cooltime1 > 0.0f)
        {
            cooltime1 -= Time.deltaTime;
            disble.fillAmount = cooltime1 / cooltimeMax;
            yield return null;
        }

        isSkil(true); 
    }
}


