using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    Transform player, finishLine;
    float startingDistance;

    [SerializeField]
    GameObject menu, gamePlay;

    [SerializeField]
    Slider progressBar;

    [SerializeField]
    Text wintext;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        finishLine = GameObject.FindGameObjectWithTag("FinishLine").transform;

        startingDistance = Vector3.Distance(player.position, finishLine.position);

        Time.timeScale = 0;
    }

    void Update()
    {
        UpdateProgressBar();
    }

    void UpdateProgressBar()
    {
        float value = 1 - (finishLine.position.z - player.position.z) / startingDistance;
        if (value > 1)
            wintext.gameObject.SetActive(true);
        else
            progressBar.value = value;
    }

    public void StartButton()
    {
        menu.SetActive(false);
        gamePlay.SetActive(true);

        Time.timeScale = 1;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(0);
    }

    public void PauseButton()
    {
        menu.SetActive(true);
        gamePlay.SetActive(false);

        Time.timeScale = 0;
    }
}
