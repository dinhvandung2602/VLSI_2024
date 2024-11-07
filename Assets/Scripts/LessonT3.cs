using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class LessonT3 : MonoBehaviour
{
    public string LessonTitle;

    public enum ContentType
    {
        Interactive,
        Image,
        Video
    }

    public ContentType contentType;

    public GameObject TextInfo;

    public GameObject UIController3D;

    public Sprite Picture;

    public VideoClip Video;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
