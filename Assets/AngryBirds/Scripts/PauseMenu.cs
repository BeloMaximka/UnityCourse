using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject menu;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0 && !menu.activeInHierarchy)
            {
                return;
            }

            Time.timeScale = Time.timeScale == 0 ? 1.0f : 0;
            menu.SetActive(!menu.activeInHierarchy);
        }
    }
}
