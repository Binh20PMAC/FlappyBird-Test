using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.ShaderData;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class BirdCheckPipe : MonoBehaviour
{

    [SerializeField]
    private GameObject GameButton;
    [SerializeField]
    private GameObject[] Pipe_up;
    [SerializeField]
    private GameObject[] Pipe_down;
    [SerializeField]
    private GameObject[] Stone;
    [SerializeField]
    private GameObject[] Item;

    private float SpaceBird;

    private float dirPipeUpLeft;
    private float dirPipeUpRight;
    private float dirPipeUpCenter;

    private float dirStoneLeft;
    private float dirStoneRight;
    private float dirStoneTop;
    private float dirStoneBottom;

    private float dirPipeDownLeft;
    private float dirPipeDownRight;
    private float dirPipeDownCenter;

    private float dirUp;
    private float dirDown;
    private float dirLeft;
    private float dirRight;

    int count = 0;
    int countItem = 0;
    int countSpawnStone = 0;

    [SerializeField]
    private TMP_Text ScoreText;

    [SerializeField]
    private TMP_Text HighScoreText;

    [SerializeField]
    private float score;
    [SerializeField]
    private float highScore;

    bool pass = false;

    public static bool itemIcrease = false;

    private void Update()
    {
        //dirUp = transform.position.y + 0.2f;
        //dirDown = transform.position.y - 0.2f;
        //dirLeft = transform.position.x - 0.2f;
        //dirRight = transform.position.x + 0.2f;
        ThisPosition(transform, 0.2f, 0.2f, 0.2f, 0.2f);

        //SpaceBird = transform.position.x + 3;
        SpaceBird = Space(transform, 3f);

        if (Pipe_up[count].transform.position.x + 0.6f < dirLeft - 1f)
        {
            count++;
            if (count == Pipe_up.Length)
            {
                count = 0;
            }
        }

        if (Item[countItem].transform.position.x < dirLeft + 1f)
        {
            itemIcrease = false;
        }

        if (Pipe_up[countSpawnStone].transform.position.x < ColliderPipe.screenWidthLeft)
        {
            Spawn_Stone(countSpawnStone);
            if (Random.Range(0, 8) == 0)
                Item[countItem].SetActive(true);
            countSpawnStone++;
            if (countSpawnStone == 3)
            {
                countSpawnStone = 0;
            }
        }

        Debug.Log(countItem);

        if (Pipe_up[count].transform.position.x < SpaceBird && Pipe_up[count].transform.position.x > dirLeft - 1f)
        {
            CheckPipeUp(0.6f, 0.6f);
            CheckPipeDown(0.6f, 0.6f);
            if (Stone[count].activeInHierarchy)
            {
                CheckStone(0.6f, 0.6f, 0.6f, 0.6f);
            }
            if (Item[countItem].activeInHierarchy)
            {
                CheckItem(0.6f, 0.6f, 0.6f, 0.6f);
            }
        }
        ScoreUp(Pipe_up[count], Pipe_down[count]);

        if (PlayerPrefs.GetInt("selectedOptions") == 0)
        {
            Item[countItem].SetActive(false);
        }

    }

    public void ScoreUp(GameObject topPipe, GameObject bottomPipe)
    {
        highScore = PlayerPrefs.GetFloat("highscore", 0);
        HighScoreText.text = "HighScore: " + highScore.ToString();


        if (transform.position.x < topPipe.transform.position.x && !pass)
        {
            if (transform.position.x > dirPipeUpLeft && transform.position.y > bottomPipe.transform.position.y && transform.position.y < topPipe.transform.position.y && transform.position.x == 0)
            {
                score++;
                pass = true;
                Sound("Point");
            }
            if (NormalBird.isDash && transform.position.x < topPipe.transform.position.x && !pass && transform.position.x == 0)
            {
                score++;
                pass = true;
                Sound("Point");
            }

        }
        if (transform.position.x > bottomPipe.transform.position.x)
        {
            pass = false;
        }
        //temp++;
        //if(temp > 10 && Dash == true)
        //{
        //    temp = 80;
        //}
        //if (temp == 80)
        //{
        //    temp /= 80;
        //    score++;
        //    AudioManager.instance.PlaySFX("Point");
        //}
        ScoreText.text = score.ToString();

        if (score > highScore)
        {

            PlayerPrefs.SetFloat("highscore", score);
        }
        HighScoreText.text = "HighScore: " + highScore.ToString();

    }

    private void ThisPosition(Transform Pos, float up, float down, float left, float right)
    {
        dirUp = Pos.position.y + up;
        dirDown = Pos.position.y - down;
        dirLeft = Pos.position.x - left;
        dirRight = Pos.position.x + right;
    }

    public float Space(Transform Pos, float Space)
    {
        return Pos.position.x + Space;
    }

    private void CheckPipeUp(float left, float right)
    {
        dirPipeUpLeft = Pipe_up[count].transform.position.x - left;
        dirPipeUpRight = Pipe_up[count].transform.position.x + right;
        dirPipeUpCenter = Pipe_up[count].transform.position.y;
        if (!NormalBird.isDash)
            if (dirRight > dirPipeUpLeft && dirUp > dirPipeUpCenter && dirLeft < dirPipeUpRight && transform.position.x == 0)
            {
                transform.position = new Vector3(Pipe_up[count].transform.position.x, Pipe_up[count].transform.position.y, 0);
                Sound("Hit");
                GameButton.SetActive(true);
            }
    }


    private void CheckPipeDown(float left, float right)
    {
        dirPipeDownLeft = Pipe_down[count].transform.position.x - left;
        dirPipeDownRight = Pipe_down[count].transform.position.x + right;
        dirPipeDownCenter = Pipe_down[count].transform.position.y;
        if (!NormalBird.isDash)
            if (dirRight > dirPipeDownLeft && dirDown < dirPipeDownCenter && dirLeft < dirPipeDownRight && transform.position.x == 0)
            {
                transform.position = new Vector3(Pipe_down[count].transform.position.x, Pipe_down[count].transform.position.y, 0);
                Sound("Hit");
                GameButton.SetActive(true);
            }
    }

    private void CheckStone(float top, float bottom, float left, float right)
    {
        dirStoneLeft = Stone[count].transform.position.x - left;
        dirStoneRight = Stone[count].transform.position.x + right;
        dirStoneTop = Stone[count].transform.position.y + top;
        dirStoneBottom = Stone[count].transform.position.y - bottom;
        if (!NormalBird.isDash)
            ColiderStone();
    }

    private void CheckItem(float top, float bottom, float left, float right)
    {
        dirStoneLeft = Item[countItem].transform.position.x - left;
        dirStoneRight = Item[countItem].transform.position.x + right;
        dirStoneTop = Item[countItem].transform.position.y + top;
        dirStoneBottom = Item[countItem].transform.position.y - bottom;
        ColiderStoneItem();
    }

    public void CheckStoneBullet(int countBullet, float dirBulletRight, float dirBulletLeft, float dirBulletTop, float dirBulletBottom, float top, float bottom, float left, float right)
    {
        dirStoneLeft = Stone[countBullet].transform.position.x - left;
        dirStoneRight = Stone[countBullet].transform.position.x + right;
        dirStoneTop = Stone[countBullet].transform.position.y + top;
        dirStoneBottom = Stone[countBullet].transform.position.y - bottom;
        if (dirBulletRight > dirStoneLeft && dirBulletTop > dirStoneBottom && dirBulletBottom < dirStoneTop && dirBulletLeft < dirStoneRight && Stone[countBullet].activeInHierarchy)
        {
            Stone[countBullet].SetActive(false);
            AudioManager.instance.PlaySFX("Boom");
            Debug.Log("Stone: " + countBullet);
            gameObject.SetActive(false);
        }

    }

    private void ColiderStone()
    {
        if (dirRight > dirStoneLeft && dirUp > dirStoneBottom && dirDown < dirStoneTop && dirLeft < dirStoneRight && transform.position.x == 0)
        {
            transform.position = new Vector3(-0.1f, transform.position.y, 0);
            GameButton.SetActive(true);
            Sound("Hit");
        }
    }

    private void ColiderStoneItem()
    {
        if (dirRight > dirStoneLeft && dirUp > dirStoneBottom && dirDown < dirStoneTop && dirLeft < dirStoneRight && transform.position.x == 0)
        {
            itemIcrease = true;
            Item[countItem].SetActive(false);
            Sound("Item");
        }
    }

    private void Spawn_Stone(int countBullet)
    {
        Stone[countBullet].SetActive(true);
    }

    public virtual float DirPipeUpLeft(int count, float Left)
    {
        return Pipe_up[count].transform.position.x - Left;
    }

    public virtual float DirPipeUpRight(int count, float Right)
    {
        return Pipe_up[count].transform.position.x + Right;
    }

    public virtual float DirPipeUpCenter(int count)
    {
        return Pipe_up[count].transform.position.y;
    }

    public virtual float DirPipeDownLeft(int count, float Left)
    {
        return Pipe_down[count].transform.position.x - Left;
    }

    public virtual float DirPipeDownRight(int count, float Right)
    {
        return Pipe_down[count].transform.position.x + Right;
    }

    public virtual float DirPipeDownCenter(int count)
    {
        return Pipe_down[count].transform.position.y;
    }

    public virtual void Sound(string sound)
    {
        AudioManager.instance.PlaySFX(sound);
    }

    //private void FixedUpdate()
    //{
    //    if (dirRight > dirPipeUpLeft && dirLeft < dirPipeDownRight && transform.position.x == 0)
    //    {
    //        Score.instance.ScoreUp();
    //    }

    //}
}
