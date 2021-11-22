using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    int level = 5;
    int health = 30;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello Unity");

        // 1. ���� 
        int level = 5;
        float strength = 15.5f;
        string playerName = "���˻�";
        bool isFullLevel = false;

        // 2. �׷��� ����
        string[] monsters = { "������", "�縷��", "�Ǹ�" };
        int[] monsterLevel = new int[3];
        monsterLevel[0] = 1;
        monsterLevel[1] = 6;
        monsterLevel[2] = 20;

        Debug.Log("�ʿ� �����ϴ� ������ ����");
        Debug.Log(monsterLevel[0]);
        Debug.Log(monsterLevel[1]);
        Debug.Log(monsterLevel[2]);

        List<string> items = new List<string>();
        items.Add("������30");
        items.Add("��������10");


        //3.������
        int exp = 1500;
        exp = exp - 10;
        level = exp / 300;
        strength = level * 3.1f;

        int nextExp = 300 - (exp % 300);

        string title = "������";
        string fullName = title + " " + playerName;

        int fullLevel = 99;
        isFullLevel = level == fullLevel;

        bool isEndTutorial = level > 10;

        int health = 30;
        int mana = 25;
        bool isBadCondition = health <= 50 || mana <= 20;

        string condition = isBadCondition ? "����" : "����";

        //4. ���ǹ�
        if (condition == "����")
        {
            Debug.Log("�÷��̾� ���°� ���ڴ� �������� ����ϼ���.");
        }
        else
        {
            Debug.Log("�÷��̾� ���°� �����ϴ�.");
        }

        if (isBadCondition && items[0] == "������30")
        {
            items.RemoveAt(0);
            health += 30;
            Debug.Log("��������30�� ����Ͽ����ϴ�.");
        } else if (isBadCondition && items[0] == "��������30")
        {
            items.RemoveAt(0);
            mana += 30;
            Debug.Log("��������30�� ����Ͽ����ϴ�. ");
        }

        switch (monsters[1])
        {
            case "������":
                Debug.Log("���� ���Ͱ� ����!");
                break;
            case "�Ǹ�":
                Debug.Log("���� ���Ͱ� ����!");
                break;
            case "��":
                Debug.Log("���� ���Ͱ� ����!");
                break;
            default:
                Debug.Log("?? ���Ͱ� ����!");
                break;

        }

        //6.�ݺ���
        while (health > 0)
        {
            health--;
            if (health > 0)
                Debug.Log("�� �������� �Ծ����ϴ�. " + health); // ü���� 0 �̻��̸� ���̰� �Ѵ�.
            else
                Debug.Log("����Ͽ����ϴ�"); // ü���� 0�̸� �����Ŵ�.
        }

        if (health == 10)
        {
            Debug.Log("�ص����� ����մϴ�");
        }

    //6. �ݺ���
    while (health > 0)
        {
            health--;

            if(health == 10)
            {
                break;
            }
        }
    
    for(int count = 0; count<10; count++)
        {
            health++;
        }

    foreach (string monster in monsters)
        {
            //Debug.Log("�� ������ �ִ� ���� : " +monster);
            // ���� �׷��� ���� �ȿ��ִ� �������� ������� �߰�ȣ ������
            // ���� ���� ���� ����ϴ� ���
        }

        // 7.�Լ�(�޼ҵ�)

        Heal();
        for(int index=0; index < monsters.Length; index++)
        {
            Debug.Log("����" + monsters[index] + "����" +
                Battle(monsterLevel[index]));
        }
    }

    // 7.�Լ�(�޼ҵ�)
    void Heal()
    {
        health += 10;
        Debug.Log("���� �޾ҽ��ϴ�. " +health);
    }

    string Battle(int monsterLevel)
    {
        string result;
        if (level >= monsterLevel)
            result = "�̰���ϴ�.";
        else
            result = "�����ϴ�.";

        return result;
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
