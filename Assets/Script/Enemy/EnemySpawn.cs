using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    public GameObject _enemyPrefab;
    public GameObject _enemyfirePrefab;
    private BoxCollider2D area;
    public int enemycount;
    public float spawncooltime;
    public int randomenemy;


    private void Awake()
    {
        enemycount = 10;
        spawncooltime = 5f;
        area = GetComponent<BoxCollider2D>();
    }
    private void Start()
    {
        StartCoroutine(EnanySpawn());
    }
  

    private Enemy CreateEnemy()
    {
        Vector3 spawnPos = GetRandomPosition();
        Enemy enemy = Instantiate(_enemyPrefab, spawnPos, Quaternion.identity).GetComponent<Enemy>();
        return enemy;
    }
    private Enemy CreatefireEnemy()
    {
        Vector3 spawnPos = GetRandomPosition();
        FireEnemy fireenemy = Instantiate(_enemyfirePrefab, spawnPos, Quaternion.identity).GetComponent<FireEnemy>();
        return fireenemy;
    }

  
    private void OnDestroyEnemy(Enemy enemy)
    {
        Destroy(enemy.gameObject);
    }
    private IEnumerator EnanySpawn()
    {
        for (int i = 0; i < enemycount; i++)
        {
            randomenemy = Random.Range(1, 3);
            if(randomenemy == 1)
            {
                CreateEnemy();
            }
            else if(randomenemy == 2)
            {
                CreatefireEnemy();
            }
            yield return new WaitForSeconds(spawncooltime);
        }
    }
    private Vector2 GetRandomPosition()
    {
        Vector2 basePosition = transform.position; 
        Vector2 size = area.size;                   

        float posX = Random.Range(-size.x / 2f, size.x / 2f);
        float posY = Random.Range(-size.y / 2f, size.y / 2f);

        Vector2 spawnPos = new Vector2(posX, posY);

        return spawnPos;
    }
}