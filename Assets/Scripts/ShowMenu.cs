using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

public class ShowMenu : MonoBehaviour
{
    public VRInteractiveItem interactiveItem;
    public SelectionRadial selectionRadial;
    public AudioClip overAudio;
    public AudioClip outAudio;
    public AudioClip selectAudio;
    public GameObject selectionMenu;
    public string infos = "";
    private AudioSource audioSource;
    private bool gazeOver;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void ShowSelectionMenu()
    {
        if (selectionMenu.GetActive())
        {
            selectionMenu.SetActive(false);
        }
        HandleMenu handleMenu = selectionMenu.GetComponent<HandleMenu>();
        handleMenu.goButton = gameObject;
        selectionMenu.SetActive(true);
    }

    void OnEnable()
    {
        interactiveItem.OnOver += HandleOver;
        interactiveItem.OnOut += HandleOut;
        //selectionRadial.OnSelectionComplete += SelectionComplete;
    }

    void OnDisable()
    {
        interactiveItem.OnOver -= HandleOver;
        interactiveItem.OnOut -= HandleOut;
        selectionRadial.OnSelectionComplete -= SelectionComplete;
    }

    private void HandleOut()
    {
        //注意顺序
        gazeOver = false;
        selectionRadial.HandleUp();
        selectionRadial.Hide();
        audioSource.clip = outAudio;
        audioSource.Play();
    }

    private void HandleOver()
    {
        gazeOver = true;
        audioSource.clip = overAudio;
        audioSource.Play();
        selectionRadial.Show();
        selectionRadial.HandleDown();
    }

    public void SelectionComplete()
    {
        if (!gazeOver) return;
        audioSource.clip = selectAudio;
        audioSource.Play();
        ShowSelectionMenu();
    }
}
