using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float speed = 10f, sensitivity = 500f, clampAngle = 70f;
    /*  speed : ī�޶��� ���� �ӵ�
        sensitivity : ���콺�� ī�޶� ������ �� ����
        clampAngle : ���� ī�޶� ���۽� ���� ����(���� ���� ��� ������ ���� �� ����)
    */
    private float rotX, rotY;
    /* mouse Input�� ���� ������ */
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // ���콺 ���� ��ư�� ������ ���� ������ ���콺�� ī�޶� ������ �� �ֵ���
            rotX += -Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
            rotY += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);
            Quaternion rot = Quaternion.Euler(rotX, rotY, 0);
            transform.rotation = rot;
        }
        transform.position = target.position + offset;

    }
}
