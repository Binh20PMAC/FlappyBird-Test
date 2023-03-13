using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BirdCheckPipe : MonoBehaviour
{

    [SerializeField]
    private GameObject GameButton;

    [SerializeField]
    private List<GameObject> Pipe_up;
    [SerializeField]
    private List<GameObject> Pipe_down;

    private float SpaceBird;

    private float dirPipeUpLeft;
    private float dirPipeUpRight;
    private float dirPipeUpCenter;

    private float dirPipeDownLeft;
    private float dirPipeDownRight;
    private float dirPipeDownCenter;

    private float dirUp;
    private float dirDown;
    private float dirLeft;
    private float dirRight;

    int count = 0;

    private void Update()
    {
        //dirUp = transform.position.y + 0.2f;
        //dirDown = transform.position.y - 0.2f;
        //dirLeft = transform.position.x - 0.2f;
        //dirRight = transform.position.x + 0.2f;
        ThisPosition(transform, 0.2f, 0.2f, 0.2f, 0.2f);

        //SpaceBird = transform.position.x + 3;
        SpaceBird = Space(transform, 3f);

        if (Pipe_up[count].transform.position.x < dirLeft - 1f)
        {
            count++;
            if (count == 3)
            {
                count = 0;
            }
        }

        Debug.Log(count);

        if (Pipe_up[count].transform.position.x < SpaceBird && Pipe_up[count].transform.position.x > dirLeft - 1f)
        {
            CheckPipeUp(0.6f, 0.6f);
            CheckPipeDown(0.6f, 0.6f);
        }

    }

    public virtual void ThisPosition(Transform Pos, float up, float down, float left, float right)
    {
        dirUp = Pos.position.y + up;
        dirDown = Pos.position.y - down;
        dirLeft = Pos.position.x - left;
        dirRight = Pos.position.x + right;
    }

    public virtual float Space(Transform Pos, float Space)
    {
        return Pos.position.x + Space;
    }

    private void CheckPipeUp(float left, float right)
    {
        dirPipeUpLeft = Pipe_up[count].transform.position.x - left;
        dirPipeUpRight = Pipe_up[count].transform.position.x + right;
        dirPipeUpCenter = Pipe_up[count].transform.position.y;

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

        if (dirRight > dirPipeDownLeft && dirDown < dirPipeDownCenter && dirLeft < dirPipeDownRight && transform.position.x == 0)
        {
            transform.position = new Vector3(Pipe_down[count].transform.position.x, Pipe_down[count].transform.position.y, 0);
            Sound("Hit");
            GameButton.SetActive(true);
        }
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

    private void FixedUpdate()
    {
        if (dirRight > dirPipeUpLeft && dirLeft < dirPipeDownRight && transform.position.x == 0)
        {
            Score.instance.ScoreUp();
        }

    }
}
