using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{

    public float Speed;
    Rigidbody2D rb;
    SpriteRenderer SR;
    bool canSwitch = true;

    public bool Left, Right, Up;

    public float GravitySwitchDelay;

    float timer;

    public float smooth = 1f;


    public Sprite SpriteOne;
    public Sprite SpriteTwo;
    public Sprite SpriteThree;

    public GameObject Fade;

    public GameObject Model;
    public Transform GroundCheck;
    public LayerMask GroundLayer;

    public TextMeshProUGUI FinalScoreText;
    public TextMeshProUGUI FinalTimeText;


    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody2D>();
        SR = Model.GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        float dirX = Input.GetAxis("Horizontal");

        if (dirX > 0)
        {
            if (Up)
            {
                transform.localScale = new Vector3(-0.22f, 0.22f, 1);
            }
            else
            {
                transform.localScale = new Vector3(0.22f, 0.22f, 1);
            }
            Left = false;
            Right = true;
        }
        else if(dirX < 0)
        {
            if (Up)
            {
                transform.localScale = new Vector3(0.22f, 0.22f, 1);
            }
            else
            {
                transform.localScale = new Vector3(-0.22f, 0.22f, 1);
            }
            Right = false;
            Left = true;
        }

        transform.position += new Vector3(dirX * Speed * Time.fixedDeltaTime, 0, 0);

        if(rb.gravityScale == 4 && Input.GetAxisRaw("Vertical") == 1 && canSwitch)
        {
            StartCoroutine(SwitchSide());

            Up = true;
            canSwitch = false;
            rb.gravityScale = -4;
            if (Right)
            {
                transform.localScale = new Vector3(-0.22f, 0.22f, 1);
            }
            else 
            {
                transform.localScale = new Vector3(0.22f, 0.22f, 1);
            }
        }
        if (rb.gravityScale == -4 && Input.GetAxisRaw("Vertical") == -1 && canSwitch)
        {
            StartCoroutine(SwitchSide());

            Up = false;
            canSwitch = false;
            rb.gravityScale = 4;
            if (Right)
            {
                transform.localScale = new Vector3(0.22f, 0.22f, 1);
            }
            else
            {
                transform.localScale = new Vector3(-0.22f, 0.22f, 1);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }


        IEnumerator SwitchSide()
        {
            for (int i = 0; i < 10; i++)
            {
                yield return new WaitForSeconds(0.01f);
                transform.eulerAngles += new Vector3(0, 0, 18);
            }
        }

        if (!canSwitch)
        {
            timer += Time.fixedDeltaTime;
            if(timer > GravitySwitchDelay)
            {
                canSwitch = true;
                timer = 0;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Die();
        }
        if(collision.gameObject.tag == "Finish")
        {
            Win();
        }
    }

    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Win()
    {
        ScoreManager SM = GetComponent<ScoreManager>();
        float time = SM.TotalTime;
        float score = SM.Score;
        SM.ScoreText.gameObject.SetActive(false);
        SM.TimeText.gameObject.SetActive(false);
        GetComponent<ShootingScript>().ammoText.gameObject.SetActive(false);

        StartCoroutine(Fade.GetComponent<StartFade>().StopFade());

        FinalScoreText.text = "Score: " + score.ToString();
        FinalTimeText.text = "Time: " + time.ToString() + @"
Kyan's best: 26.24 sec 21 Score";
    }
//
}
