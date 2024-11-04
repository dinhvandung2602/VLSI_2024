using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerLessonT2 : MonoBehaviour
{
    public static ManagerLessonT2 instance;

    

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public int T1_Index;

    // Start is called before the first frame update
    void Start()
    {
        LessonData.instance.T1_Index = T1_Index;

        //reset
        LessonData.instance.T2_Index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
