using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuPanelView : MonoBehaviour
{
    [SerializeField] private Text topScoreText;
    [SerializeField] private Button startGameButton;


    void Start()
    {
        startGameButton.onClick.RemoveAllListeners();
        startGameButton.onClick.AddListener(OnClickGameStart);

        RenderScoreView();
    }

    private void RenderScoreView()
    {
        if(PlayerPrefs.HasKey(GameConstants.TOP_SCORE_KEY))
        {
            int score = PlayerPrefs.GetInt(GameConstants.TOP_SCORE_KEY);

            topScoreText.text = "TOP SCORE : " + score;
        }else
        {
            topScoreText.text = "TOP SCORE : 0";
        }
    }

    private void OnClickGameStart()
    {
        SceneManager.LoadScene(GameConstants.GAME_SCENE);
    }
}
