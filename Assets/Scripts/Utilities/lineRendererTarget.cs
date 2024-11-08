using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineRendererTarget : MonoBehaviour
{
    public Transform target;
    LineRenderer m_line;
    public bool isRealtimeUpdate = false;

    // Start is called before the first frame update
    void Start()
    {
        m_line = GetComponent<LineRenderer>();
        setLine();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRealtimeUpdate)
        {
            setLine();
        }
    }

    public void setLine()
    {
        m_line.SetPosition(0, transform.position);
        m_line.SetPosition(1, target.position);
    }
}
