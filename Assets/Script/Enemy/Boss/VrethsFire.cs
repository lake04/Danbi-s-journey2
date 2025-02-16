using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VrethsFire : MonoBehaviour
{
    private bool isDamage = true;
    void Start()
    {
        Destroy(this.gameObject, 6);
    }

    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isDamage == true)
        {
            collision.gameObject.GetComponent<Player>().HpDown(5);
            StartCoroutine(fireDamage());
        }
    }

   private IEnumerator fireDamage()
    {
        isDamage = false;
        yield return new WaitForSeconds(0.5f);
        isDamage = true;
    }
}
