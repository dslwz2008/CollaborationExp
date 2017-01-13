using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

public class UIController : MonoBehaviour
{
    public UIFader m_IntroUI;     // 开始界面
    public UIFader m_OutroUI;     // 结束界面
    public UIFader m_PlayerUI;    // 游戏过程中界面
    //private Text m_GameTime;     // 游戏剩余时间
    //private Text m_PlayerHealth;      // 玩家生命值


    public IEnumerator ShowIntroUI()
    {
        yield return StartCoroutine(m_IntroUI.InteruptAndFadeIn());
    }


    public IEnumerator HideIntroUI()
    {
        yield return StartCoroutine(m_IntroUI.InteruptAndFadeOut());
    }

    public void DisableIntroUI() {
        m_IntroUI.gameObject.SetActive(false);
    }
    public void DisableOuttroUI()
    {
        m_OutroUI.gameObject.SetActive(false);
    }

    public IEnumerator ShowOutroUI()
    {
        //m_TotalScore.text = SessionData.Score.ToString();
        //m_HighScore.text = SessionData.HighScore.ToString();

        yield return StartCoroutine(m_OutroUI.InteruptAndFadeIn());
        m_OutroUI.gameObject.SetActive(true);
    }


    public IEnumerator HideOutroUI()
    {
        yield return StartCoroutine(m_OutroUI.InteruptAndFadeOut());
    }


    public IEnumerator ShowPlayerUI()
    {
        yield return StartCoroutine(m_PlayerUI.InteruptAndFadeIn());
    }


    public IEnumerator HidePlayerUI()
    {
        yield return StartCoroutine(m_PlayerUI.InteruptAndFadeOut());
    }
}
