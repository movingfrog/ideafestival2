using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    public GameObject panel; // 메뉴 패널
    public GameObject darkBackground; // 어두운 배경
    public GameObject BM;
    public GameObject Re;
    public GameObject QUit;
    Mainmenu Mainmenu;
    public Slider Volume;
    public AudioSource audioSource;

    void Start()
    {
        // 패널과 어두운 배경을 처음에 비활성화
        panel.SetActive(false);
        darkBackground.SetActive(false);

        // PlayerPrefs에서 슬라이더 값을 불러와 설정
        if (PlayerPrefs.HasKey("Volume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("Volume");
            Volume.value = savedVolume; // 슬라이더 초기값을 저장된 값으로 설정
            audioSource.volume = savedVolume; // 오디오 볼륨도 설정
        }
        else
        {
            Volume.value = audioSource.volume; // 슬라이더 초기값을 현재 오디오 볼륨으로 설정
        }

        Volume.onValueChanged.AddListener(SetVolume); // 슬라이더 값 변경 시 SetVolume 호출
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
        // 메인메뉴로 가기
        SceneManager.LoadScene("Mainmenu");
    }

    public void quit()
    {
        // 게임끄기
        Application.Quit();
    }

    public void REturn()
    {
        // 게임으로 돌아가기
        Time.timeScale = 1;
        panel.SetActive(false);
        darkBackground.SetActive(false);
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume; // 오디오 볼륨을 슬라이더 값으로 설정
        PlayerPrefs.SetFloat("Volume", volume); // 슬라이더 값을 PlayerPrefs에 저장
    }
}
