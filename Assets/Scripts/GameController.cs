using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    UI m_ui;
    public GameObject wall;
    public float spawnTime;
    private float m_spawnTime;
    bool m_isGameOver;
    int m_score;


    // Start is called before the first frame update
    void Start()
    {
        m_spawnTime = 0;
        m_ui = FindObjectOfType<UI>();
        m_ui.SetScoreText("Score:" + m_score);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isGameOver)
        {
            m_spawnTime = 0;
            m_ui.ShowGameover(true);
            return;
        }
        m_spawnTime -= Time.deltaTime;
        if (m_spawnTime <= 0)
        {
            SpawnWall();
            m_spawnTime = spawnTime;
        }
    }
    public void Replay()
    {
        SceneManager.LoadScene("Main");
    }
    public void SpawnWall()
    {
        float ranX = Random.Range(0.0f, 5.0f);
        float ranY = Random.Range(-3.0f, -1.5f);
        Vector2 spawnPos = new Vector2(ranX, ranY);
        if (wall)
        {
            Instantiate(wall, spawnPos, Quaternion.identity);
        }
    }
    public void SetScore(int value)
    {
        m_score = value;
    }
    public int GetScore()
    {
        return m_score;
    }
    public void ScoreIncrememt()
    {
        m_score++;
        m_ui.SetScoreText("Score:" + m_score);
    }
    public bool IsGameOver()
    {
        return m_isGameOver;
    }
    public void SetGameover(bool state)
    {
        m_isGameOver = state;
    }
}
