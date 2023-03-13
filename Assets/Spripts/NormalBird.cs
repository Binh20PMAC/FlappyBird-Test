using System.Collections;
using System.Collections.Generic;
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
    private float cooldown;

    [SerializeField]
    private Image CircleCooldown;

    float last;

    private void Update()
    {
        BirdJump(gameObject);
        Fire();

        if (PlayerPrefs.GetInt("selectedOptions") == 1)
        {

            if (Input.GetKey(KeyCode.Q))
            {
                StartCoroutine(Timer());

            }
        }
        if (PlayerPrefs.GetInt("selectedOptions") == 2)
        {
            if (CircleCooldown.fillAmount == 0)
                if (Input.GetKey(KeyCode.Q))
                {
                    StartCoroutine(Dash());
                    CircleCooldown.fillAmount = 1f;
                }
        }
       

        CircleCooldown.fillAmount -= Time.deltaTime * 0.2f;
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
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Time.time - last < cooldown)
            { return; }
            last = Time.time;

            GameObject bullet = BulletPool.instance.GetPooledObject();

            if (bullet != null)
            {
                bullet.transform.position = transform.position;
                bullet.SetActive(true);
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
