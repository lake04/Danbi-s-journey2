using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public GameObject[] spawn;
    // Start is called before the first frame update
    void Start()
    {
        spawn[1].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void chageSpawn(int num,int num2)
    {
        spawn[num].gameObject.SetActive(false);
        spawn[num2].gameObject.SetActive(true);
    }
}
