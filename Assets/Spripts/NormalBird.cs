using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NormalBird : MonoBehaviour
{

    private float gra = -9.8f;

    private Vector3 vel;

    private float strenth = 8f;

    private float angel;

    [SerializeField]
    private float cooldown = 5f;

    [SerializeField]
    private Image CircleCooldown;

    [SerializeField]
    private TMP_Text time;

    private float second = 5f;

    float last;

    private void Update()
    {
        BirdJump(gameObject);
        Fire();
        if (PlayerPrefs.GetInt("selectedOptions") == 0)
        {
            CircleCooldown.gameObject.SetActive(false);
            time.gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("selectedOptions") == 1)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                if (Input.GetKey(KeyCode.Q) && CircleCooldown.fillAmount <= 1f)
                {

                    if (BirdCheckPipe.itemIcrease)
                    {
                        CircleCooldown.fillAmount = 0f;
                    }
                    if (CircleCooldown.fillAmount < 1f)
                    {
                        StartCoroutine(Timer());
                        CircleCooldown.fillAmount += 5 / cooldown * Time.deltaTime;
                        second = CircleCooldown.fillAmount * 5f;
                    }
                }
            }
            else
            {
                CircleCooldown.fillAmount -= (BirdCheckPipe.itemIcrease) ? (1f) : (1 / cooldown * Time.deltaTime);
                second -= (BirdCheckPipe.itemIcrease) ? (5) : (5 / cooldown * Time.deltaTime);
            }

        }
        if (PlayerPrefs.GetInt("selectedOptions") == 2)
        {
            if (CircleCooldown.fillAmount == 0)
                if (Input.GetKey(KeyCode.Q))
                {
                    StartCoroutine(Dash());
                    CircleCooldown.fillAmount = 1f;
                    second = 5f;
                }
            CircleCooldown.fillAmount -= (BirdCheckPipe.itemIcrease) ? (1f) : (1 / cooldown * Time.deltaTime);
            second = CircleCooldown.fillAmount * 5f;
        }


        time.text = Mathf.Round(second).ToString();
        if (second <= 0)
        {

            time.gameObject.SetActive(false);
        }
        else
            time.gameObject.SetActive(true);

    }
    public virtual void BirdJump(GameObject bird)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            vel = Vector3.up * strenth;
            AudioManager.instance.PlaySFX("Jump");
        }

        //if(Input.touchCount > 0)
        //{
        //    Touch touch = Input.GetTouch(0);
        //    if(touch.phase == TouchPhase.Began)
        //    {
        //        vel = Vector3.up * strenth;
        //    }
        //}

        vel.y += 2f * (gra * Time.deltaTime);

        bird.transform.position += vel * Time.deltaTime;

        angel = 0;
        if (vel.y < 0)
        {
            angel = Mathf.Lerp(0, -80, -vel.y / strenth);
        }
        bird.transform.rotation = Quaternion.Euler(0, 0, angel);
    }

    public virtual void Fire()
    {
        if (Input.GetKey(KeyCode.F))
        {
            if (Time.time - last < 0.25f)
            { return; }
            last = Time.time;

            GameObject bullet = BulletPool.instance.GetPooledObject();

            if (bullet != null)
            {
                bullet.transform.position = new Vector3(0.7f, transform.position.y, 0);
                bullet.SetActive(true);
                AudioManager.instance.PlaySFX("Fire");
            }
        }

    }

    IEnumerator Dash()
    {
        ColliderPipe.speed = 8;
        Score.Dash = true;
        yield return new WaitForSeconds(0.3f);
        Score.Dash = false;
        ColliderPipe.speed = 1;
    }

    IEnumerator Timer()
    {
        Time.timeScale = 0.4f;
        yield return new WaitForSeconds(10f);
        Time.timeScale = 1f;
    }
}
