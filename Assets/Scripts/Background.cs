using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public Transform m_camera;

    void Update()
    {
        var x = m_camera.position.x;
        var y = m_camera.position.y;
        var z = transform.position.z;
        transform.position = new Vector3(x, y, z);
    }
}
