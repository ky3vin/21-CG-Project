using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform targetObject; //ī�޶� ���� ������Ʈ
    public float speed = 10f, sensitivity = 500f, clampAngle = 70f;
    /*  speed : ī�޶��� ���� �ӵ�
        sensitivity : ���콺�� ī�޶� ������ �� ����
        clampAngle : ���� ī�޶� ���۽� ���� ����(���� ���� ��� ������ ���� �� ����)
    */
    private float rotX, rotY;
    /* mouse Input�� ���� ������ */
    public Transform realCamera; // ī�޶��� ����
    public Vector3 dirNormalized; // ����(ũ�� ���X)
    public Vector3 finalDir; // �Է°��� ó���Ͽ� ���������� ����� ����
    public float minDistance, maxDistance, finalDistance;
    /* ī�޶�� ĳ���� ���̿� ���ع��� ���� ��� �ּ�/�ִ�/���� �Ÿ�*/
    public float smoothness = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rotX = transform.localRotation.eulerAngles.x;
        rotY = transform.localRotation.eulerAngles.y;

        dirNormalized = realCamera.localPosition.normalized; // ũ�� 0���� �ʱ�ȭ
        finalDistance = realCamera.localPosition.magnitude;

    }

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


    }
    void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetObject.position, speed * Time.deltaTime);
        finalDir = transform.TransformPoint(dirNormalized*maxDistance);
        RaycastHit hit;
        if(Physics.Linecast(transform.position, finalDir, out hit))
        {
            finalDistance = Mathf.Clamp(hit.distance, minDistance, maxDistance);
        }
        else
        {
            finalDistance = maxDistance;
        }
        realCamera.localPosition = Vector3.Lerp(realCamera.localPosition, dirNormalized * finalDistance, Time.deltaTime * smoothness);
    }
}
