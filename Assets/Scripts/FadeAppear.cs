using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAppear : MonoBehaviour
{
    public float m_fadeTime = 1.0f;

    private SpriteRenderer m_ren;

    void Start()
    {
        m_ren = GetComponent<SpriteRenderer>();
        m_ren.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    }

    public void FadeIn()
    {
        StartCoroutine(FadeInBegin());
    }

    IEnumerator FadeInBegin()
    {
        float alpha = 0.0f;

        while (alpha < 1.0f)
        {
            alpha = Mathf.Min(1.0f, alpha + Time.deltaTime / m_fadeTime);
            m_ren.color = new Color(1.0f, 1.0f, 1.0f, alpha);
            yield return null;
        }

        yield break;
    }
}
