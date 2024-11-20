using UnityEngine;
using UnityEngine.UI;

public class Continue : MonoBehaviour
{
    [SerializeField]
    private GameObject menu;

    private Button button;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Unpause);
    }

    void Unpause()
    {
        Time.timeScale = 1.0f;
        menu.SetActive(false);
    }
}
