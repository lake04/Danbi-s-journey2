using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    public Player player;
    [SerializeField]
    public CameraMove mainCamera;
    [SerializeField]
    private spawnManager spawnManager;
    public int a = 0;
    int b = 1;
    [SerializeField]
    private Boss bossZone;
    [SerializeField]
    private AudioSource bam;
    [SerializeField]
    private AudioSource bossBam;


    public void Update()
    {
        OnBossZone();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (a == 0)//2째 스테이지
            {
                player.transform.position = new Vector3(-20f, 15f, 0);
                mainCamera.limitMinY = 10.7f; mainCamera.limitMaxY = 22.5f;
                spawnManager.chageSpawn(a, b);
                a++;
                b++;
            }
            else if (a == 1)//보스전
            {
                player.transform.position = new Vector3(-20f, 28.5f, 0);
                mainCamera.limitMinY = 26.5f; mainCamera.limitMaxY = 40.9f;
                a++;
                b++;
            }
        }
    }
    private void OnBossZone()
    {
        if (a == 2)
        {
            bossZone.isBossZone = true;
            bossBam.Play();
            bam.Stop();
        }
    }

    private void OnBossZone()
    {
        if(a == 2)
        {
            bossZone.isBossZone = true;
            bossBam.Play();
            bam.Stop();
        }
    }
}
