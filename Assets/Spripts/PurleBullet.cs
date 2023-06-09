using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class PurleBullet : BirdCheckPipe
{
    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    int countBullet = 0;

    private float dirUpBullet;
    private float dirDownBullet;
    private float dirLeftBullet;
    private float dirRightBullet;

    private float SpaceBullet;

    private float DirPipeUpRightBullet;
    private float DirPipeUpLeftBullet;

    private float DirPipeDownRightBullet;
    private float DirPipeDownLeftBullet;

    // Update is called once per frame
    void Update()
    {
        dirRightBullet = transform.position.x + 0.2f;
        dirLeftBullet = transform.position.x - 0.4f;
        dirUpBullet = transform.position.y + 0.1f;
        dirDownBullet = transform.position.y - 0.1f;



        SpaceBullet = dirLeftBullet + 1f;



        if (DirPipeUpRight(countBullet, 0.6f) < dirLeftBullet - 1f)
        {
            countBullet++;
            if (countBullet == 3)
            {
                countBullet = 0;
            }
        }

        if (DirPipeUpLeft(countBullet, 0.4f) < SpaceBullet && DirPipeUpRight(countBullet, 0.4f) > dirLeftBullet)
        {

            DirPipeUpLeftBullet = DirPipeUpLeft(countBullet, 0.4f);

            if (dirRightBullet > DirPipeUpLeftBullet && dirUpBullet > DirPipeUpCenter(countBullet))
            {
                gameObject.SetActive(false);
            }
            DirPipeDownLeftBullet = DirPipeDownLeft(countBullet, 0.4f);

            if (dirRightBullet > DirPipeDownLeftBullet && dirDownBullet < DirPipeDownCenter(countBullet))
            {
                gameObject.SetActive(false);
            }

            CheckStoneBullet(countBullet, dirRightBullet, dirLeftBullet, dirUpBullet, dirDownBullet, 0.8f, 0.8f, 0.8f, 0.8f);
        }
        if (transform.position.x > ColliderPipe.screenWidthRight - 1f)
        {
            gameObject.SetActive(false);
        }

        transform.position += (Vector3.right * Time.deltaTime) * speed;
    }


}
