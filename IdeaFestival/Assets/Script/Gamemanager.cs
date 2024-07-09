using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    public GameObject panel; // �޴� �г�
    public GameObject darkBackground; // ��ο� ���
    public GameObject BM;
    public GameObject Re;
    public GameObject QUit;

    void Start()
    {
        // �гΰ� ��ο� ����� ó���� ��Ȱ��ȭ
        panel.SetActive(false);
        darkBackground.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (Time.timeScale == 0)
            {
                // ������ �簳�ϰ� �гΰ� ��ο� ����� ��Ȱ��ȭ
                Time.timeScale = 1;
                panel.SetActive(false);
                darkBackground.SetActive(false);
            }
            else
            {
                // ������ �Ͻ������ϰ� �гΰ� ��ο� ����� Ȱ��ȭ
                Time.timeScale = 0;
                panel.SetActive(true);
                darkBackground.SetActive(true);
            }
        }
    }
    public void Backmenu()
    {
        //���θ޴��� ����
        SceneManager.LoadScene("Mainmenu");
    }
    public void quit()
    {
        //���Ӳ���
        Application.Quit();
    }
    public void REturn()
    {
        //�������� ���ư���
        Time.timeScale = 1;
        panel.SetActive(false);
        darkBackground.SetActive(false);
    }
}
