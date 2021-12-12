using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����Ƽ ���� Ʃ�丮�� ����
public class EnemyController_Forest : MonoBehaviour
{
    public Transform player;
    public GameEnding_Forest gameEnding;

    bool m_IsPlayerInRange;
    void Awake()
    {
       

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }

    void Update()
    {
        if (m_IsPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player)
                {
                    gameEnding.CaughtPlayer();
                }
            }
        }
    }
}