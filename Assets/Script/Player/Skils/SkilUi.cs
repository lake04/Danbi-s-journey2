using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkilUi : MonoBehaviour
{
    public Player player;
    [SerializeField]
    private Sprite[] skiliImages1;
    [SerializeField]
    private Sprite[] skiliImages2;
    [SerializeField]
    private Image skiliImage1;
    [SerializeField]
    private Image skiliImage2;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        chageUi();
    }

    private void chageUi()
    {
        if (player.type == PlayerType.basic)
        {
            skiliImage1.sprite = skiliImages1[0];
            skiliImage2.sprite = skiliImages2[0];
        }

        if (player.type == PlayerType.fire)
        {
            skiliImage1.sprite = skiliImages1[1];
            skiliImage2.sprite = skiliImages2[1];
        }
    }
   
}






