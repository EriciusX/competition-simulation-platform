using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public float minimumY = -30f, maximumY = 90f;
    public float ScrollWheel_min = 20, ScrollWheel_max = 50;
    public float sensitivity = 3f;
    public float moveSpeed = 5f, ScrollWheelSpeed = 5f;
    public float x_max = 100, y_max = 100, z_max = 100;
    private float rotationY = 0f, rotationX = 0f;
    private float xInput, yInput, zInput;
    private string[] keys = {"w", "a", "s", "d", "up", "down", "right", "left", "space", "left ctrl"};
    private Vector3 cam_pos;

    void Start()
    {
        rotationX = transform.localEulerAngles.y;
        rotationY = transform.localEulerAngles.x;
    }

    void Update()
    {
        if (Input.mousePresent)
        {
            float Camer_Size = Camera.main.orthographicSize;
            if (Input.GetMouseButton(2))
            {
                rotationX += Input.GetAxis("Mouse X") * sensitivity;
                rotationY -= Input.GetAxis("Mouse Y") * sensitivity;
                rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
                transform.localEulerAngles = new Vector3(rotationY, rotationX, 0);
            }
            if (Input.GetMouseButton(1))
            {
                xInput += Input.GetAxis("Mouse X") * moveSpeed;
                yInput += Input.GetAxis("Mouse Y") * moveSpeed;
                transform.Translate(Vector3.forward * yInput * Time.deltaTime);
                transform.Translate(Vector3.right * xInput * Time.deltaTime);
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            // 滚轮改变缩放
            Camera.main.fieldOfView = Camera.main.fieldOfView - (Input.GetAxis("Mouse ScrollWheel") * ScrollWheelSpeed);
            // 限制size缩放大小
            Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, ScrollWheel_min, ScrollWheel_max);
        }
        if (string.Join("", keys).IndexOf(Input.inputString) != -1)
        {
            xInput = Input.GetAxis("Vertical") * moveSpeed;
            yInput = Input.GetAxis("Horizontal") * moveSpeed;
            zInput = Input.GetAxis("Jump") * moveSpeed;
            transform.Translate(Vector3.forward * xInput * Time.deltaTime);
            transform.Translate(Vector3.right * yInput * Time.deltaTime);
            transform.Translate(Vector3.up * zInput * Time.deltaTime);
            float tempx = transform.position.x;
            float tempy = transform.position.y;
            float tempz = transform.position.z;
            tempx = Mathf.Clamp(tempx, 0, x_max);
            tempy = Mathf.Clamp(tempy, 1, y_max);
            tempz = Mathf.Clamp(tempz, 0, z_max);
            transform.position = new Vector3(tempx, tempy, tempz);
        }
    }

}
