using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetObjectListContainName : MonoBehaviour
{
    ModelPrefabRef m_script;

    List<GameObject> matchingChild; 

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        m_script = GetComponent<ModelPrefabRef>();

        foreach (Transform child in transform)
        {
            if (child.name.Contains("trans"))
            {
                matchingChild.Add(child.gameObject);
            }
        }

        m_script.objLists = matchingChild.ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            m_script = GetComponent<ModelPrefabRef>();

            foreach (Transform child in transform)
            {
                if (child.name.Contains("trans"))
                {
                    matchingChild.Add(child.gameObject);
                }
            }

            m_script.objLists = matchingChild.ToArray();
        }
    }
}
