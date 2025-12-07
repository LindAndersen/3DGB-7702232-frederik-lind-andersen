using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Canvas : MonoBehaviour
{
    public Slider healthSlider;
    public GameObject defeatPanel;
    public GameObject victoryPanel;

    public void SetHealth(float healthPercent)
    {
        if(healthSlider != null)
        {
            healthSlider.value = Mathf.Clamp01(healthPercent);
        }
    }

    public void ShowDefeat()
    {
        SetCursorState(false);
        if (defeatPanel != null)
        {
            defeatPanel.SetActive(true);
        }
    }

    public void ShowVictory()
    {
        SetCursorState(false);
        if (victoryPanel != null)
        {
            victoryPanel.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SetCursorState(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void SetCursorState(bool newState)
    {
        Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
    }
}
