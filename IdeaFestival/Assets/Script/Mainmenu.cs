using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Mainmenu : MonoBehaviour
{
    public GameObject start;
    public GameObject option;
    public GameObject quit;
    public GameObject Panel;
    public GameObject RT;
    public Slider Volume;
    public AudioSource audioSource;

    void Start()
    {
        Volume.onValueChanged.AddListener(SetVolume); // 슬라이더 값 변경 시 SetVolume 호출
        Volume.value = audioSource.volume; // 슬라이더 초기값을 현재 오디오 볼륨으로 설정
    }

    void Update()
    {

    }

    public void starts()
    {
        SceneManager.LoadScene("Start stage");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Option()
    {
        quit.SetActive(false);
        start.SetActive(false);
        option.SetActive(false);
        Time.timeScale = 0;
        Panel.SetActive(true);
    }

    public void Return()
    {
        quit.SetActive(true);
        start.SetActive(true);
        option.SetActive(true);
        Time.timeScale = 1;
        Panel.SetActive(false);
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume; // 오디오 볼륨을 슬라이더 값으로 설정
        PlayerPrefs.SetFloat("Volume", volume); // 슬라이더 값을 PlayerPrefs에 저장
    }
}
