using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject hudPanel;
    public GameObject gameOverPanel;
    public TextMeshProUGUI gameOverScoreText;
    public ARSession arSession;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        hudPanel.SetActive(true);
        gameOverPanel.SetActive(false);
    }

    public void MostrarGameOver()
    {
        hudPanel.SetActive(false);
        gameOverPanel.SetActive(true);

        int total = ScoreManager.instance.GetTotalScore();
        gameOverScoreText.text = $"Puntaje Final: {total}";
    }

    public void Jugar()
    {
        SceneManager.LoadScene("Juego");
    }

    public void VolverAlMenu()
    {
        SceneManager.LoadScene("Menu"); // <- Cambia esto por el nombre de tu escena de Menú
    }

    public void SalirDelJuego()
    {
        Application.Quit();
    }

    private IEnumerator RestartARAndLoadScene(string sceneName)
    {
        if (arSession != null)
        {
            arSession.Reset();
            yield return null; // Espera un frame para que ARSession se resetee
        }
        SceneManager.LoadScene(sceneName);
    }



}

