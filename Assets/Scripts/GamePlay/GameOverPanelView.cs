using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverPanelView : MonoBehaviour
{
    [SerializeField] private Text textScore;
    [SerializeField] private Button buttonOK;

    public void Render(int score)
    {
        gameObject.SetActive(true);
        buttonOK.onClick.RemoveAllListeners();
        buttonOK.onClick.AddListener(OnClickOK);

        RenderScore(score);
    }

    private void OnClickOK()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene(GameConstants.MENU_SCENE);
    }

    private void RenderScore(int score)
    {
        textScore.text = "Score : " + score;
        PlayerPrefs.SetInt(GameConstants.TOP_SCORE_KEY , score);
    }

}
