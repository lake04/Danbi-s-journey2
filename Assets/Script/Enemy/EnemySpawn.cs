using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    private BoxCollider2D area;
    private IObjectPool<Enemy> _pool;


    private void Awake()
    {

        area = GetComponent<BoxCollider2D>();
        //for (int i = 0; i < 5; i++)
        //{
        //    var enemy = _pool.Get();
        //}
        StartCoroutine(EnanySpawn());

    }


    void Update()
    {

    }

    private Enemy CreateEnemy()
    {
        Vector3 spawnPos = GetRandomPosition();
        Enemy enemy = Instantiate(_enemyPrefab, spawnPos, Quaternion.identity).GetComponent<Enemy>();
        enemy.SetManagePool(_pool);
        return enemy;
    }

    private void OnGetEnemy(Enemy enemy)
    {
        enemy.gameObject.SetActive(true);
    }

    private void OnRelwaseEnemy(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
    }
    private void OnDestroyEnemy(Enemy enemy)
    {
        Destroy(enemy.gameObject);
    }
    private IEnumerator EnanySpawn()
    {
        _pool = new ObjectPool<Enemy>(CreateEnemy, OnGetEnemy, OnRelwaseEnemy, OnDestroyEnemy, maxSize: 5);
        var enemy = _pool.Get();
        yield return new WaitForSeconds(1f);
    }
    private Vector2 GetRandomPosition()
    {
        Vector2 basePosition = transform.position;  //������Ʈ�� ��ġ
        Vector2 size = area.size;                   //box colider2d, �� ���� ũ�� ����

        //x, y�� ���� ��ǥ ���
        float posX = Random.Range(-size.x / 2f, size.x / 2f);
        float posY = Random.Range(-size.y / 2f, size.y / 2f);

        Vector2 spawnPos = new Vector2(posX, posY);

        return spawnPos;
    }
}