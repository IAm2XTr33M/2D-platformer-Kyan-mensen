using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFade : MonoBehaviour
{
    public SpriteRenderer SR;

    float timer;

    private void Start()
    {
        transform.position = new Vector3(0, 0, -9);

        StartCoroutine(startFade());

        IEnumerator startFade()
        {
            float opacity = 1;
            for (int i = 0; i < 20; i++)
            {
                opacity -= 0.05f;
                SR.color = new Color(0, 0, 0, opacity);
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    public IEnumerator StopFade()
    {
        float opacity = 0;
        for (int i = 0; i < 10; i++)
        {
            opacity += 0.1f;
            SR.color = new Color(0, 0, 0, opacity);
            yield return new WaitForSeconds(0.1f);
        }
    }

}
