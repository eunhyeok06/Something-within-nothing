using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    
    // Start is called before the first frame update
    public float sensitivity;
    public float maxAngle;

    private float deadZoneX; // 가로 dead zone (픽셀 기준)
  

    private float deadZoneRatioX = 0.3f;


    private float yRotation = 0f; // 좌우 회전을 위한 Y축 회전값

    void Start()
    {
        
        deadZoneX = Screen.width * deadZoneRatioX;
    }

    void Update()
    {
        
        Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Vector2 mousePosition = Input.mousePosition;
        Vector2 offset = mousePosition - screenCenter;

        if (Mathf.Abs(offset.x) <= deadZoneX)
            return;

        float mouseX = offset.x / Screen.width * sensitivity * Time.deltaTime;

        yRotation += mouseX;

        transform.localRotation = Quaternion.Euler(0f, yRotation, 0f);
    }
}
