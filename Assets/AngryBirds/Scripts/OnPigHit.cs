using UnityEngine;

public class OnPigHit : MonoBehaviour
{
    [SerializeField]
    private GameObject winMenu;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Bird")
        {
            winMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
