using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;


public class PlayMovie : MonoBehaviour
{
    public VRInteractiveItem interactiveItem;
    public SelectionRadial selectionRadial;
    public AudioClip overAudio;
    public AudioClip outAudio;
    public AudioClip selectAudio;
    public AudioClip mainAudio;
    private MovieTexture movieTexture;
    private AudioSource audioSource;
    private bool gazeOver;

    void Start()
    {
        movieTexture = (MovieTexture)(GetComponent<MeshRenderer>().material.mainTexture);
        audioSource = GetComponent<AudioSource>();
    }

    [PunRPC]
    void Play()
    {
        if (!movieTexture.isPlaying)
        {
            audioSource.clip = mainAudio;
            movieTexture.Play();
            audioSource.Play();
            OnDisable();//播放一次
        }
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
        //Play();
        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("Play",PhotonTargets.All);
    }
}
