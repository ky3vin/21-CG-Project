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

        // 1. 변수 
        int level = 5;
        float strength = 15.5f;
        string playerName = "나검사";
        bool isFullLevel = false;

        // 2. 그룹형 변수
        string[] monsters = { "슬라임", "사막뱀", "악마" };
        int[] monsterLevel = new int[3];
        monsterLevel[0] = 1;
        monsterLevel[1] = 6;
        monsterLevel[2] = 20;

        Debug.Log("맵에 존재하는 몬스터의 레벨");
        Debug.Log(monsterLevel[0]);
        Debug.Log(monsterLevel[1]);
        Debug.Log(monsterLevel[2]);

        List<string> items = new List<string>();
        items.Add("생명물약30");
        items.Add("마나물약10");


        //3.연산자
        int exp = 1500;
        exp = exp - 10;
        level = exp / 300;
        strength = level * 3.1f;

        int nextExp = 300 - (exp % 300);

        string title = "전설의";
        string fullName = title + " " + playerName;

        int fullLevel = 99;
        isFullLevel = level == fullLevel;

        bool isEndTutorial = level > 10;

        int health = 30;
        int mana = 25;
        bool isBadCondition = health <= 50 || mana <= 20;

        string condition = isBadCondition ? "나쁨" : "좋음";

        //4. 조건문
        if (condition == "나쁨")
        {
            Debug.Log("플레이어 상태가 나쁘니 아이템을 사용하세요.");
        }
        else
        {
            Debug.Log("플레이어 상태가 좋습니다.");
        }

        if (isBadCondition && items[0] == "생명물약30")
        {
            items.RemoveAt(0);
            health += 30;
            Debug.Log("생명포션30을 사용하였습니다.");
        } else if (isBadCondition && items[0] == "마나물약30")
        {
            items.RemoveAt(0);
            mana += 30;
            Debug.Log("마나포션30을 사용하였습니다. ");
        }

        switch (monsters[1])
        {
            case "슬라임":
                Debug.Log("소형 몬스터가 출현!");
                break;
            case "악마":
                Debug.Log("중형 몬스터가 출현!");
                break;
            case "골렘":
                Debug.Log("대형 몬스터가 출현!");
                break;
            default:
                Debug.Log("?? 몬스터가 출현!");
                break;

        }

        //6.반복문
        while (health > 0)
        {
            health--;
            if (health > 0)
                Debug.Log("독 데미지를 입었습니다. " + health); // 체력이 0 이상이면 깎이게 한다.
            else
                Debug.Log("사망하였습니다"); // 체력이 0이면 죽은거다.
        }

        if (health == 10)
        {
            Debug.Log("해독제를 사용합니다");
        }

    //6. 반복문
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
            //Debug.Log("이 지역에 있는 몬스터 : " +monster);
            // 직접 그룹형 변수 안에있는 아이템을 끄집어내서 중괄호 안으로
            // 넣은 다음 직접 사용하는 방식
        }

        // 7.함수(메소드)

        Heal();
        for(int index=0; index < monsters.Length; index++)
        {
            Debug.Log("용사는" + monsters[index] + "에게" +
                Battle(monsterLevel[index]));
        }
    }

    // 7.함수(메소드)
    void Heal()
    {
        health += 10;
        Debug.Log("힐을 받았습니다. " +health);
    }

    string Battle(int monsterLevel)
    {
        string result;
        if (level >= monsterLevel)
            result = "이겼습니다.";
        else
            result = "졌습니다.";

        return result;
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
