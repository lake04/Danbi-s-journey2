using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breths : MonoBehaviour
{
    [SerializeField]
    private GameObject fireFlor;
    private bool isDamage = true;


    void Start()
    {
        Destroy(this.gameObject, 4);
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            Instantiate(fireFlor, new Vector2(collision.transform.position.x - 1, collision.transform.position.y + 1), Quaternion.identity);
        }

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
