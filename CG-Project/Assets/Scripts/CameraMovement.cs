using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform targetObject; //카메라가 따라갈 오브젝트
    public float speed = 10f, sensitivity = 500f, clampAngle = 70f;
    /*  speed : 카메라의 반응 속도
        sensitivity : 마우스로 카메라를 조종할 때 감도
        clampAngle : 상하 카메라 조작시 제한 각도(제한 없을 경우 뒤집혀 보일 수 있음)
    */
    private float rotX, rotY;
    /* mouse Input을 받을 변수들 */
    public Transform realCamera; // 카메라의 정보
    public Vector3 dirNormalized; // 방향(크기 고려X)
    public Vector3 finalDir; // 입력값을 처리하여 최종적으로 저장된 방향
    public float minDistance, maxDistance, finalDistance;
    /* 카메라와 캐릭터 사이에 방해물이 있을 경우 최소/최대/최종 거리*/
    public float smoothness = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rotX = transform.localRotation.eulerAngles.x;
        rotY = transform.localRotation.eulerAngles.y;

        dirNormalized = realCamera.localPosition.normalized; // 크기 0으로 초기화
        finalDistance = realCamera.localPosition.magnitude;

    }

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
