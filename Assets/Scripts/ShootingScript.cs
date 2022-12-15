using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShootingScript : MonoBehaviour
{
    public Transform BulletHole;
    public GameObject Bullet;
    public AudioClip pew;
    public AudioClip song;
    public AudioSource AS;

    public TextMeshProUGUI ammoText;
    public int maxAmmo;
    int currentAmmo;
    bool reloading = false;

    private void Start()
    {
        AS.Stop();
        AS.PlayOneShot(song);
        currentAmmo = maxAmmo;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(currentAmmo > 0)
            {
                currentAmmo--;
                ShootBullet();
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) || Input.GetKeyDown(KeyCode.R) && !reloading)
        {
            reloading = true;
            StartCoroutine(Reload());
        }

        ammoText.text = "Ammo: " + currentAmmo.ToString() + "/" + maxAmmo.ToString();
    }

    IEnumerator Reload()
    {
        int missing = maxAmmo - currentAmmo;

        for (int i = 0; i < missing; i++)
        {
            yield return new WaitForSeconds(0.1f);
            currentAmmo++;
        }
        reloading = false;
    }

    void ShootBullet()
    {
        AS.PlayOneShot(pew);
        GameObject bullet = Instantiate(Bullet);
        Destroy(bullet, 0.5f);
        bullet.transform.position = BulletHole.position;
    }
}
