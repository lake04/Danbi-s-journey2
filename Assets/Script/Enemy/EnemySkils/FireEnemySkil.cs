using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEnemySkil : MonoBehaviour
{
    [SerializeField]
    public GameObject player;
    public GameObject fireenemy;
    private Rigidbody2D rb;
    public float speed;
    public float maxDistance = 3f;
    public float fireBallCooltime = 7f;
    private int fireBallDamage = 3;
    public SpriteRenderer spriteRenderer;

    private Vector3 startPoint;
    private void Awake()
    {
        speed = 8f;
        rb = GetComponent<Rigidbody2D>();
        fireenemy = GameObject.FindGameObjectWithTag("FireEnemy");
        player = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer = fireenemy.GetComponent<FireEnemy>().renderer;
        Destroy(this.gameObject, 2f);
        startPoint = transform.position;
    }
    void Start()
    {
        if (spriteRenderer.flipX == true)
        {
            rb.AddForce(Vector3.right * speed, ForceMode2D.Impulse);
        }
        else rb.AddForce(Vector3.left * speed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
       //MoveFireBall();
        //transform.Translate(Vector3.right * speed * Time.deltaTime);
         if (Vector3.Distance(startPoint, transform.position) >= maxDistance)
        {
                Destroy(gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(Cooltime(collision));
    }
    public IEnumerator Cooltime(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<Player>().HpDown(fireBallDamage);
            Destroy(gameObject);
        }
        yield return new WaitForSeconds(fireBallCooltime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(gameObject.transform.position, gameObject.transform.position);
    }
    //public void MoveFireBall()
    //{
    //    if(GetComponent<FireEnemy>().shotFireBall == true)
    //    {
    //        rb.AddForce(Vector3.right * speed, ForceMode2D.Impulse);
    //    }
    //    else rb.AddForce(Vector3.left * speed, ForceMode2D.Impulse);
    //}
}

