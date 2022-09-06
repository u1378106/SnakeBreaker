using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractionManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    AudioManager audioManager;

    private void Start()
    {
        this.GetComponent<Animator>().enabled = false;
        audioManager = GameObject.FindObjectOfType<AudioManager>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.GetComponent<Animator>().enabled = true;
        this.GetComponent<Animator>().Play("ButtonZoom");
        this.GetComponent<Animator>().speed = 1;
        audioManager.buttonAudio.Play();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.GetComponent<Animator>().Play("ButtonZoomOut");
    }
}