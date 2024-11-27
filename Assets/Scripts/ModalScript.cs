using TMPro;
using UnityEngine;

public class ModalScript : MonoBehaviour
{
    private GameObject content;
    void Start()
    {
        content = transform.Find("Content").gameObject;
        Time.timeScale = content.activeInHierarchy ? 0.0f : 1.0f;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = content.activeInHierarchy ? 1.0f : 0.0f;

            content.transform.Find("TitleTmp").GetComponent<TextMeshProUGUI>().text = "�����";
            content.transform.Find("Message").GetComponent<TextMeshProUGUI>().text = "������� ESC ����� ����������";


            content.SetActive(! content.activeInHierarchy);
        }
    }
    public void ShowGameOverModal(int finalScore)
    {
        Time.timeScale = 0.0f; 
        content.SetActive(true);
        content.transform.Find("TitleTmp").GetComponent<TextMeshProUGUI>().text = "���� ��������";
        content.transform.Find("Message").GetComponent<TextMeshProUGUI>().text = $"��� ����: {finalScore}";
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }
    public void OnResumeButtonClick()
    {
        Time.timeScale = 1.0f;
        content.SetActive(false);
    }
}
