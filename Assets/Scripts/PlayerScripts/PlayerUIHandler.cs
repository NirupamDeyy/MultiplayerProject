using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerUIHandler : MonoBehaviour
{
    [SerializeField] 
    private TMP_Text spheresCollectedText;

    [SerializeField] 
    private Button pause, quit, screen;

    int spheresCollected;

    private void Start()
    {
        pause.onClick.AddListener(() => GameManager.PauseResumeGame());
        quit.onClick.AddListener(() => GameManager.QuitGame());
        screen.onClick.AddListener(() => GameManager.ToggleFullScreen());
    }
    private void Update()
    {
       if(Input.GetKeyDown(KeyCode.Escape))
       {
            GameManager.PauseResumeGame();
       }
    }

    public void CollectCoin()
    {
        spheresCollected++;
        spheresCollectedText.text = "COINS COLLECTED: " + spheresCollected.ToString();
    }
}
