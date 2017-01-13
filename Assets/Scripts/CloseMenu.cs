using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using VRStandardAssets.Common;
using VRStandardAssets.Utils;

public class CloseMenu : MonoBehaviour
{
    public SelectionSlider m_selectionSlider;
    public GameObject m_menuGUI;

    private void OnEnable()
    {
        m_selectionSlider.OnBarFilled += HandleBarFilled;
    }


    private void OnDisable()
    {
        m_selectionSlider.OnBarFilled -= HandleBarFilled;
    }

    void HandleBarFilled()
    {
        m_menuGUI.SetActive(false);
    }
}
