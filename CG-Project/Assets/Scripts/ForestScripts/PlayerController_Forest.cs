using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_Forest : MonoBehaviour
{
    public GameObject Cam; // ������ ĳ���� ��Ʈ�ѷ�
    public CharacterController SelectPlayer; // ������ ĳ���� ��Ʈ�ѷ�
    public float Speed;  // �̵��ӵ�
    public float JumpPow;

    private float Gravity; // �߷�   
    private Vector3 MoveDir; // ĳ������ �����̴� ����.
    private bool JumpButtonPressed;  //  ���� ���� ��ư ���� ����
    Rigidbody m_Rigidbody;
    Animator m_Animator;
    void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Animator = GetComponentInChildren<Animator>();

    }
    // Start is called before the first frame update
    void Start()
    {
        // �⺻��
        Speed = 5.0f;
        Gravity = 10.0f;
        MoveDir = Vector3.zero;
        JumpPow = 5.0f;
        JumpButtonPressed = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            var offset = Cam.transform.forward;
            offset.y = 0;
            transform.LookAt(SelectPlayer.transform.position + offset);
            m_Animator.SetBool("isWalking", true);
        }
        else
        {
            m_Animator.SetBool("isWalking", false);
        }
        // ĳ���Ͱ� �ٴڿ� �پ� �ִ� ��츸 �۵��մϴ�.
        // ĳ���Ͱ� �ٴڿ� �پ� ���� �ʴٸ� �ٴ����� �߶��ϰ� �ִ� ���̹Ƿ�
        // �ٴ� �߶� ���߿��� ���� ��ȯ�� �� �� ���� �����Դϴ�.
        if (SelectPlayer.isGrounded)
        {
            m_Animator.SetBool("isJumping", false);
            // Ű���忡 ���� X, Z �� �̵������� ���� �����մϴ�.
            MoveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            // ������Ʈ�� �ٶ󺸴� �չ������� �̵������� ������ �����մϴ�.
            MoveDir = SelectPlayer.transform.TransformDirection(MoveDir);
            // �ӵ��� ���ؼ� �����մϴ�.
            MoveDir *= Speed;

            // �����̽� ��ư�� ���� ���� : ���� ������ư�� �������� �ʾҴ� ��츸 �۵�
            if (JumpButtonPressed == false && Input.GetButton("Jump"))
            {
                SelectPlayer.transform.rotation = Quaternion.Euler(0, 45, 0);
                JumpButtonPressed = true;
                MoveDir.y = JumpPow;
                m_Animator.SetBool("isJumping", true);
            }
            
        }
        // ĳ���Ͱ� �ٴڿ� �پ� ���� �ʴٸ�
        else
        {       
                MoveDir.y -= Gravity * Time.deltaTime;
        }

        // ������ư�� �������� ���� ���
        if (!Input.GetButton("Jump"))
        {
            JumpButtonPressed = false;  // �������� ��ư ���� ���� ����
        }
        // �� �ܰ������ ĳ���Ͱ� �̵��� ���⸸ �����Ͽ�����,
        // ���� ĳ������ �̵��� ���⼭ ����մϴ�.
        SelectPlayer.Move(MoveDir * Time.deltaTime);
       
    }
}