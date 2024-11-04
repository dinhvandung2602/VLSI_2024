using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LessonData : MonoBehaviour
{
    public static LessonData instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public int T1_Index;
    public int T2_Index;
    public int T3_Index;

    public GameObject T2Prefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
