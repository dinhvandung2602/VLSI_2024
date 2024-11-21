using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CameraRotate : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public float speedH = 4.0f;
    public float speedV = 4.0f;
    public float speedZoom = 4.0f;

    public float yaw = 0.0f;
    public float pitch = 0.0f;

    public float autoRotateSpeed = 0.05f;

    bool isPress = false;

    public GameObject cam;
    public Transform camPivot;


    private bool isPointerOver = false;

    Vector2 starterAngle;
    float starterZoom;

    bool canZoom = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        isPointerOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isPointerOver = false;
    }

    // Use this for initialization
    void Start()
    {
        camPivot.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        starterAngle = new Vector2(pitch, yaw);
        starterZoom = cam.transform.localPosition.z;

        StartCoroutine(delayCanZoom());
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector2 mousePosition = Input.mousePosition;

        if (isPointerOver && canZoom && !UIEvent.instance.IsPointerOverUIObject())
        {
            //if (Input.GetMouseButtonDown(0) && (!EventSystem.current.IsPointerOverGameObject()))
            if (Input.GetMouseButtonDown(0))
            {
                isPress = true;
            }

            if ((cam.transform.localPosition.z <= -2.0f) && (Input.GetAxis("Mouse ScrollWheel") > 0))
            {
                cam.transform.Translate(0, 0, Input.GetAxis("Mouse ScrollWheel") * speedZoom);
            }
            if ((cam.transform.localPosition.z >= -5.0f) && (Input.GetAxis("Mouse ScrollWheel") < 0))
            {
                cam.transform.Translate(0, 0, Input.GetAxis("Mouse ScrollWheel") * speedZoom);
            }
            
        }
        else
        {
            

        }

        if (Input.GetMouseButtonUp(0))
        {
            isPress = false;
        }


        if (isPress)
        {
            yaw = camPivot.transform.eulerAngles.y;
            yaw += speedH * Input.GetAxis("Mouse X");
            pitch -= speedV * Input.GetAxis("Mouse Y");


            //yaw = Mathf.Clamp(yaw, 110f, 260f);
            pitch = Mathf.Clamp(pitch, 0f, 55f);

            camPivot.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }
        else
        {
            camPivot.transform.eulerAngles += new Vector3(0.0f, autoRotateSpeed, 0.0f);
        }

        
    }

    public void mouseDown()
    {
        isPress = true;
    }

    public void MouseUp()
    {
        isPress = false;
    }

    public void ResetAngle()
    {
        camPivot.transform.eulerAngles = new Vector3(starterAngle.x, starterAngle.y, 0.0f);
        cam.transform.localPosition = new Vector3(0, 0, starterZoom);
    }

    IEnumerator delayCanZoom()
    {
        yield return new WaitForSeconds(0.1f);
        canZoom = true;
    }

}

public class UIEvent
{
    public static UIEvent instance = new UIEvent();
    public bool IsPointerOverUIObject()
    {
        //get GameObjects mouse hover
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        //if mouse hover on game object has tag named "NotBlockUI", return false

        //else return false
        if (results[0].gameObject.CompareTag("NotBlockUI"))
        {
            return false;
        }
        else
        {
            return true;
        }

    }
}