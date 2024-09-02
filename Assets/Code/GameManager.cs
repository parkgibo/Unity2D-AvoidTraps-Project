using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }

    [SerializeField]
    private GameObject poop;
    private int score;

    [SerializeField]
    private Text scoreTxt;
    [SerializeField]
    private Transform objbox;
    [SerializeField]
    private Text bestScore;
    [SerializeField]
    private GameObject panel;

    [SerializeField]
    private GameObject Item1;
    [SerializeField]
    private GameObject Item2;
    [SerializeField]
    private GameObject Item3;


    


    // Use this for initialization
    void Start()
    {
        Screen.SetResolution(768, 1024, false);

    }

    public bool stopTrigger = true;
    public void GameOver()
    {
        stopTrigger = false;

        StopCoroutine(CreatepoopRoutine());
        StopCoroutine(CreateItemRoutine());

        if (score >= PlayerPrefs.GetInt("BestScore", 0))
            PlayerPrefs.SetInt("BestScore", score);

        bestScore.text = PlayerPrefs.GetInt("BestScore", 0).ToString();

        panel.SetActive(true);
    }

    public void GameStart() //게임 시작
    {
        score = 0;
        scoreTxt.text = "Score : " + score;
        stopTrigger = true;
        StartCoroutine(CreatepoopRoutine()); //아이템 생성 및 적 코드
        StartCoroutine(CreateItemRoutine());
        panel.SetActive(false);
    }

    public void Score() //현 게임 실행 시 스코어 추가
    {
        if (stopTrigger)
            score++;
        scoreTxt.text = "Score : " + score;
    }
    IEnumerator CreatepoopRoutine() //적 생성 코드
    {
        while (stopTrigger)
        {
            CreatePoop();
            float waitTime2 = Random.Range(0.3f,0.5f); //0.3초에서 0.5사이에서 작동
            yield return new WaitForSeconds(waitTime2);
        }
    }
    IEnumerator CreateItemRoutine() //아이템 생성
    {

        while (stopTrigger)
        {
            CreateItem();
            float waitTime = Random.Range(5f, 15f); //5초에서 15 사이에서 작동
            yield return new WaitForSeconds(waitTime);
            
}

    }

    private void CreateItem() //아이템 생성 코드
    {

        GameObject[] items = { Item1, Item2, Item3 };
        GameObject selectedItem = items[Random.Range(0, items.Length)];

        Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0.0f, 1.0f), 1.1f, 5.0f));
        pos.z = 0.0f;

        GameObject obj = Instantiate(selectedItem, pos, Quaternion.identity);
        obj.transform.parent = objbox.transform;
    }
    private void CreatePoop() //적 객체 생성 코드
    {
        Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0.0f, 1.0f), 1.1f, 5.0f));
        //pos.z = 0.0f;
        GameObject obj = Instantiate(poop, pos, Quaternion.identity);
        obj.transform.parent = objbox.transform;
    }

    private void OnCollisionEnter2D(Collision2D collision) //Enemy랑 똑같은 코드, 땅에 떨어지면 사라지고 플레이어에게 닿으면 작동되게 만듬
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            ApplyItemEffect(collision.gameObject);
            Destroy(gameObject);
        }
    }
    private void ApplyItemEffect(GameObject player) //플레이어 아이템 습득 시 효과 적용
    {
        if (gameObject.tag == "ITEM")
        {
            //Angel.SetActive(true);
            Debug.Log("1");

        }
        else if (gameObject.tag == "ITEM2")
        {
            //Heal.SetActive(true);
            Debug.Log("2");

        }
        else if (gameObject.tag == "ITEM3")
        {
            Debug.Log("3");

        }
    }

}