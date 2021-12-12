using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController_Forest : MonoBehaviour
{
    /* ī�޶� ����ٴ� �÷��̾� ��ü */
    public GameObject player; 
    /* x,y�� ���� �̵��� */
    public float xmove = 0; 
    public float ymove = 0; 
    /* 3��Ī ��忡�� �÷��̾�� ī�޶� ������ ����(z��)*/
    public float distance = 3;

    /* �ε巯�� ī�޶� ���� ��ȯ */
    public float SmoothTime = 0.2f;
    private Vector3 velocity = Vector3.zero;

    /* ī�޶��� :  false=3��Ī, true=1��Ī */
    bool cameraMode = false; 

    void LateUpdate()
    {
        /* ���콺 ��Ŭ�� -> ī�޶� �̵� ���� */
        if (Input.GetMouseButton(0))
        {
            /* ������ x,y�� �����Ӹ�ŭ �ݿ� */
            xmove += Input.GetAxis("Mouse X"); 
            ymove -= Input.GetAxis("Mouse Y"); 
        }
        /* �Է¹��� �̵����� ���� ī�޶� ������ */
        transform.rotation = Quaternion.Euler(ymove, xmove, 0); 

        /* tab Ű�� ���� ī�޶� ���� ��� ��ȯ */
        if (Input.GetKey(KeyCode.Tab))
        {
            cameraMode = !cameraMode;
        }

        /* 1��Ī */
        if (cameraMode==true)
        {
            /* �÷��̾��� ������ ���� ����Ͽ� �����ϰ� �� ���� */
            Vector3 standardDistance = new Vector3(0.0f, 1.8f, 1.0f);
            transform.position = player.transform.position + transform.rotation * standardDistance;
        }
        /* 3��Ī */
        else if (cameraMode==false)
        {
            /* �÷��̾��� �޸���� ������ �Ÿ����� �������� ������ �� ���� */
            Vector3 standardDistance = new Vector3(0.0f, -1.2f, distance); 
            transform.position = Vector3.SmoothDamp(
                transform.position,
                player.transform.position - transform.rotation * standardDistance,
                ref velocity,
                SmoothTime);
        }
    }
}