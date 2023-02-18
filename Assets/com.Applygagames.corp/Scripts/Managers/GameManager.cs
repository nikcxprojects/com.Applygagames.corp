using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject rules;
    [SerializeField] GameObject record;
    [SerializeField] GameObject game;
    [SerializeField] GameObject result;

    private void Awake()
    {
        Ball.OnBallPressed += (IsEnemy) =>
        {
            Debug.Log(IsEnemy);
        };
    }

    private void Start() => Init();

    private void Init()
    {
        rules.SetActive(false);
        record.SetActive(false);
        game.SetActive(false);
        result.SetActive(false);

        menu.SetActive(true);
    }

    public void OpenRules()
    {
        menu.SetActive(false);
        rules.SetActive(true);
    }

    public void OpenRecord()
    {
        menu.SetActive(false);
        record.SetActive(true);
    }

    public void StartGame()
    {
        StartCoroutine(nameof(Spawning));
    }

    public void OpenMenu()
    {
        foreach(Ball b in FindObjectsOfType<Ball>())
        {
            Destroy(b.gameObject);
        }

        StopCoroutine(nameof(Spawning));

        result.SetActive(false);
        rules.SetActive(false);
        record.SetActive(false);

        menu.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    private IEnumerator Spawning()
    {
        Transform parent = GameObject.Find("Environment").transform;
        GameObject[] balls = Resources.LoadAll<GameObject>("");

        while(true)
        {
            Instantiate(balls[Random.Range(0, balls.Length)], parent);
            yield return new WaitForSeconds(Random.Range(0.5f, 1.0f));
        }
    }
}
