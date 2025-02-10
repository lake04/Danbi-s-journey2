using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    protected virtual internal IEnumerator skil1()
    {
        yield return new WaitForSeconds(cooltime1);
    }

    protected virtual internal IEnumerator skil2()
    {
        yield return new WaitForSeconds(cooltime2);
    }
    protected internal virtual void collimage(float cooltimeMax, Image disble)
    {
        cooltime1= cooltimeMax;
        while (cooltime1 > 0.0f)
        {
            cooltime1 -= Time.deltaTime;
            disble.fillAmount = cooltime1 / cooltimeMax;

            if (cooltime1 <= 0)
            {
                break;
            }
        }
    }
}


