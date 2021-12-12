using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController_Forest : MonoBehaviour
{
    /* 카메라가 따라다닐 플레이어 객체 */
    public GameObject player; 
    /* x,y축 누적 이동량 */
    public float xmove = 0; 
    public float ymove = 0; 
    /* 3인칭 모드에서 플레이어와 카메라 사이의 간격(z축)*/
    public float distance = 3;

    /* 부드러운 카메라 시점 변환 */
    public float SmoothTime = 0.2f;
    private Vector3 velocity = Vector3.zero;

    /* 카메라모드 :  false=3인칭, true=1인칭 */
    bool cameraMode = false; 

    void LateUpdate()
    {
        /* 마우스 좌클릭 -> 카메라 이동 적용 */
        if (Input.GetMouseButton(0))
        {
            /* 누적된 x,y축 움직임만큼 반영 */
            xmove += Input.GetAxis("Mouse X"); 
            ymove -= Input.GetAxis("Mouse Y"); 
        }
        /* 입력받은 이동량에 따라 카메라 움직임 */
        transform.rotation = Quaternion.Euler(ymove, xmove, 0); 

        /* tab 키를 눌러 카메라 시점 모드 전환 */
        if (Input.GetKey(KeyCode.Tab))
        {
            cameraMode = !cameraMode;
        }

        /* 1인칭 */
        if (cameraMode==true)
        {
            /* 플레이어의 눈높이 등을 고려하여 적절하게 값 설정 */
            Vector3 standardDistance = new Vector3(0.0f, 1.8f, 1.0f);
            transform.position = player.transform.position + transform.rotation * standardDistance;
        }
        /* 3인칭 */
        else if (cameraMode==false)
        {
            /* 플레이어의 뒷모습을 적당한 거리에서 떨어져서 보도록 값 설정 */
            Vector3 standardDistance = new Vector3(0.0f, -1.2f, distance); 
            transform.position = Vector3.SmoothDamp(
                transform.position,
                player.transform.position - transform.rotation * standardDistance,
                ref velocity,
                SmoothTime);
        }
    }
}