using UnityEngine;
using System.Collections;

public class MoverCircle : MonoBehaviour 
{
    public float m_speed;

    private Vector3 v;

    void Update()
    {
        float deltaTime = Time.deltaTime;

        transform.Translate(0.0f, m_speed * deltaTime * 1.0f, 0.0f);    // move upward
        transform.Rotate(0.0f, 0.0f, m_speed * deltaTime * 100.0f);      // turn a little along z

        transform.position -= transform.forward * m_speed/60.0f;              // move forward
    }
}
