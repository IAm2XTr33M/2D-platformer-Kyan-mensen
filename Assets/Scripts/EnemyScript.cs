using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject HealthBar;
    float maxHealthbarlength;

    public GameObject Player;
    public float speed;

    public float Health = 100;

    public AudioClip death;
    AudioSource AS;

    private void Start()
    {
        maxHealthbarlength = HealthBar.transform.localScale.x;
        AS = Player.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(Mathf.Abs(transform.position.x - Player.transform.position.x) < 10)
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        }
        if(Health <= 0)
        {
            AS.PlayOneShot(death);
            Destroy(gameObject);
            Player.GetComponent<ScoreManager>().AddScore();
        }
        HealthBar.transform.localScale = new Vector3(maxHealthbarlength * Health / 100, 1, 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            StartCoroutine(loseHealth());

            IEnumerator loseHealth()
            {
                for (int i = 0; i < 5; i++)
                {
                    yield return new WaitForSeconds(0.05f);
                    Health -= 5f;
                }
            }
        }
    }
}
