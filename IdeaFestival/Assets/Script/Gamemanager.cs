using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    public GameObject panel; // 메뉴 패널
    public GameObject darkBackground; // 어두운 배경
    public GameObject BM;
    public GameObject Re;
    public GameObject QUit;

    void Start()
    {
        // 패널과 어두운 배경을 처음에 비활성화
        panel.SetActive(false);
        darkBackground.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (Time.timeScale == 0)
            {
                // 게임을 재개하고 패널과 어두운 배경을 비활성화
                Time.timeScale = 1;
                panel.SetActive(false);
                darkBackground.SetActive(false);
            }
            else
            {
                // 게임을 일시정지하고 패널과 어두운 배경을 활성화
                Time.timeScale = 0;
                panel.SetActive(true);
                darkBackground.SetActive(true);
            }
        }
    }
    public void Backmenu()
    {
        SceneManager.LoadScene("Mainmenu");
    }
    public void quit()
    {
        Application.Quit();
    }
    public void REturn()
    {
        Time.timeScale = 1;
        panel.SetActive(false);
        darkBackground.SetActive(false);
    }
}
