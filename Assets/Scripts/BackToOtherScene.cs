using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using VRStandardAssets.Common;
using VRStandardAssets.Utils;

public class BackToOtherScene : MonoBehaviour {
    public SelectionSlider m_selectionSlider;
    public string m_sceneName = "Scenes/Enter"; 

    private void OnEnable()
    {
        m_selectionSlider.OnBarFilled += HandleBarFilled;
    }


    private void OnDisable()
    {
        m_selectionSlider.OnBarFilled -= HandleBarFilled;
    }

    void HandleBarFilled() {
        SceneManager.LoadScene(m_sceneName);
    }
}
