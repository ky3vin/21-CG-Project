using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float speed = 10f, sensitivity = 500f, clampAngle = 70f;
    /*  speed : 카메라의 반응 속도
        sensitivity : 마우스로 카메라를 조종할 때 감도
        clampAngle : 상하 카메라 조작시 제한 각도(제한 없을 경우 뒤집혀 보일 수 있음)
    */
    private float rotX, rotY;
    /* mouse Input을 받을 변수들 */
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // 마우스 왼쪽 버튼을 누르고 있을 때에만 마우스로 카메라를 제어할 수 있도록
            rotX += -Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
            rotY += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);
            Quaternion rot = Quaternion.Euler(rotX, rotY, 0);
            transform.rotation = rot;
        }
        transform.position = target.position + offset;

    }
}
