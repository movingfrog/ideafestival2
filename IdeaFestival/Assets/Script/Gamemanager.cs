using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    public GameObject panel; // �޴� �г�
    public GameObject darkBackground; // ��ο� ���
    public GameObject BM;
    public GameObject Re;
    public GameObject QUit;
    Mainmenu Mainmenu;
    public Slider Volume;
    public AudioSource audioSource;

    void Start()
    {
        // �гΰ� ��ο� ����� ó���� ��Ȱ��ȭ
        panel.SetActive(false);
        darkBackground.SetActive(false);

        // PlayerPrefs���� �����̴� ���� �ҷ��� ����
        if (PlayerPrefs.HasKey("Volume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("Volume");
            Volume.value = savedVolume; // �����̴� �ʱⰪ�� ����� ������ ����
            audioSource.volume = savedVolume; // ����� ������ ����
        }
        else
        {
            Volume.value = audioSource.volume; // �����̴� �ʱⰪ�� ���� ����� �������� ����
        }

        Volume.onValueChanged.AddListener(SetVolume); // �����̴� �� ���� �� SetVolume ȣ��
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
        // ���θ޴��� ����
        SceneManager.LoadScene("Mainmenu");
    }

    public void quit()
    {
        // ���Ӳ���
        Application.Quit();
    }

    public void REturn()
    {
        // �������� ���ư���
        Time.timeScale = 1;
        panel.SetActive(false);
        darkBackground.SetActive(false);
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume; // ����� ������ �����̴� ������ ����
        PlayerPrefs.SetFloat("Volume", volume); // �����̴� ���� PlayerPrefs�� ����
    }
}
