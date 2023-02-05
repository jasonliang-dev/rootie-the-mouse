using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public float m_moveSpeed = 2.0f;

    [HideInInspector]
    public GameObject m_target;

    void Update()
    {
        var final = m_target.transform.position;
        var init = transform.position;
        transform.position = Vector3.Lerp(init, final, Time.deltaTime * m_moveSpeed);

        var dist = Vector3.Distance(init, final);
        if (dist < 0.8f)
        {
            var box = m_target.GetComponent<BoxCollider2D>();
            var anim = m_target.GetComponent<Animator>();

            box.enabled = true;
            anim.Play("Base Layer.VineGrow");
            Destroy(gameObject);
        }
    }
}
