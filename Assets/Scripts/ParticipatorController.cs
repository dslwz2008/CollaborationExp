using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using VRStandardAssets.Common;
using VRStandardAssets.Utils;

public class ParticipatorController : MonoBehaviour {
    public float m_GameLength = 90f;
    public float m_EndDelay = 1.5f;
    public float m_Health = 100f;
    public Text m_TimeLeftText;
    public Text m_HealthLeftText;
    public UIController m_UIController;
    public Reticle m_Reticle;
    public SelectionRadial m_SelectionRadial;
    public SelectionSlider m_SelectionSlider;

    public bool IsPlaying { get; private set; }

	// Use this for initialization
	private IEnumerator Start () {
        //由于时间限制，只能体验一次
        //while (true)
        {
            yield return StartCoroutine (StartPhase ());
            yield return StartCoroutine (PlayPhase ());
            //yield return StartCoroutine (EndPhase ());
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator StartPhase() {
        m_UIController.DisableOuttroUI();
        // Wait for the intro UI to fade in.
        yield return StartCoroutine(m_UIController.ShowIntroUI());

        // Show the reticle (since there is now a selection slider) and hide the radial.
        m_Reticle.Show();
        m_SelectionRadial.Hide();
        
        // Wait for the selection slider to finish filling.
        yield return StartCoroutine(m_SelectionSlider.WaitForBarToFill());

        // Wait for the intro UI to fade out.
        yield return StartCoroutine(m_UIController.HideIntroUI());
        
        //m_UIController.DisableOuttroUI();
        m_UIController.DisableIntroUI();
    }

    IEnumerator PlayPhase(){
        //显示时间倒计时条和生命值
        // Wait for the UI on the player's gun to fade in.
        yield return StartCoroutine(m_UIController.ShowPlayerUI());

        // The game is now playing.
        IsPlaying = true;

        // Make sure the reticle is being shown.
        m_Reticle.Show();

        // Reset the score.
        PartipatorSessionData.Restart();

        //更新倒计时
        // Wait for the play updates to finish.
        yield return StartCoroutine(PlayUpdate());

        // Wait for the gun's UI to fade.
        yield return StartCoroutine(m_UIController.HidePlayerUI());

        // The game is no longer playing.
        IsPlaying = false;
    }

    IEnumerator EndPhase(){
        // Hide the reticle since the radial is about to be used.
        m_Reticle.Hide();

        // In order, wait for the outro UI to fade in then wait for an additional delay.
        yield return StartCoroutine(m_UIController.ShowOutroUI());
        yield return new WaitForSeconds(m_EndDelay);

        // Wait for the radial to fill (this will show and hide the radial automatically).
        yield return StartCoroutine(m_SelectionRadial.WaitForSelectionRadialToFill());

        // Wait for the outro UI to fade out.
        yield return StartCoroutine(m_UIController.HideOutroUI());

        //跳到主场景
        //Application.LoadScene
    }

    IEnumerator PlayUpdate() {
        // The time remaining is the full length of the game length.
        float gameTimer = m_GameLength;

        // 游戏结束条件：失败：游戏时间结束、生命值用完；胜利：到达指定地点
        while (gameTimer > 0f)
        {
            // Wait for the next frame.
            yield return null;

            // Decrease the timers by the time that was waited.
            gameTimer -= Time.deltaTime;

            //更新界面元素
            //m_TimeLeftText.text = gameTimer.ToString();
        }
    }
}
