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
        Volume.onValueChanged.AddListener(SetVolume); // �����̴� �� ���� �� SetVolume ȣ��
        Volume.value = audioSource.volume; // �����̴� �ʱⰪ�� ���� ����� �������� ����
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
        audioSource.volume = volume; // ����� ������ �����̴� ������ ����
        PlayerPrefs.SetFloat("Volume", volume); // �����̴� ���� PlayerPrefs�� ����
    }
}
