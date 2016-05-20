using UnityEngine;
using System.Collections;

public class MoverCosCurve : MonoBehaviour
{
    Vector3 m_centerPosition;
    float m_degrees;
    public float m_speed;
    public float m_amplitude = 0.5f;
    public float m_period = 2.0f;


    void Start()
    {
        m_centerPosition = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        float deltaTime = Time.deltaTime;
        
        // Move center along z axis
        m_centerPosition.z += deltaTime * -m_speed;
        // Update degrees
        float degreesPerSecond = 360.0f / m_period;
        m_degrees = Mathf.Repeat(m_degrees + (deltaTime * degreesPerSecond), 360.0f);
        float radians = m_degrees * Mathf.Deg2Rad;
        
        // Offset by sin wave
        Vector3 offset = new Vector3(m_amplitude * Mathf.Sin(radians), 0.0f, 0.0f);
        transform.position = m_centerPosition + offset;

    }
}
