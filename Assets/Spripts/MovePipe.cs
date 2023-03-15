using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class MovePipe : MonoBehaviour
{
    [SerializeField]
    private GameObject bird;

    [SerializeField]
    private GameObject Pide_up;

    [SerializeField]
    private GameObject Pide_down;

    [SerializeField]
    private GameObject GameButton;

    [SerializeField]
    private float speed = 1f;
   

    private float dirXUp;
    private float dirYUp;

    float upXRight;
    float upYRight;

    float upXLeft;
    float upYLeft;

    private float dirXDown;
    private float dirYDown;

    float downXRight;
    float downYRight;

    float downXLeft;
    float downYLeft;

    

    // Update is called once per frame
    void Update()
    {
        if (-6 > transform.position.x)
        {
            //Destroy(this.gameObject);
            SimplePool.Despawn(this.gameObject);
        }

        transform.position += (Vector3.left * Time.deltaTime) * speed;

        // Check PipeUp
        dirXUp = Pide_up.transform.position.x;
        dirYUp = Pide_up.transform.position.y;


        upXLeft = dirXUp + 0.8f;
        upYLeft = dirYUp - 0.2f;

        upYRight = dirYUp - 0.2f;
        upXRight = dirXUp - 0.8f;


        if (bird.transform.position.x > upXRight && bird.transform.position.y > upYRight && bird.transform.position.x < upXLeft && bird.transform.position.y > upYLeft && bird.transform.position.x == 0)
        {
            GameButton.SetActive(true);
            bird.transform.position = new Vector3 (dirXUp, dirYUp);
            AudioManager.instance.PlaySFX("Hit");
        }

        // Check PipeDown
        dirXDown = Pide_down.transform.position.x;
        dirYDown = Pide_down.transform.position.y;


        downXLeft = dirXDown + 0.8f;
        downYLeft = dirYDown + 0.2f;

        downYRight = dirYDown + 0.2f;
        downXRight = dirXDown - 0.8f;

        if (bird.transform.position.x > downXRight && bird.transform.position.y < downYRight && bird.transform.position.x < downXLeft && bird.transform.position.y < downYLeft && bird.transform.position.x == 0)
        {
            GameButton.SetActive(true);
            bird.transform.position = new Vector3(dirXDown, dirYDown);
            AudioManager.instance.PlaySFX("Hit");
        }
    }

    //private void FixedUpdate()
    //{
    //    if (bird.transform.position.x < upXLeft && bird.transform.position.x > downXRight && bird.transform.position.x == 0)
    //    {
    //        Score.instance.ScoreUp();
    //    }
   
    //}
}
