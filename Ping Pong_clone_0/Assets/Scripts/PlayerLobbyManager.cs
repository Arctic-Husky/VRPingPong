using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLobbyManager : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] GameObject UIMenu;
    //[SerializeField] GameObject XRPlayer1;
    [SerializeField] GameObject XREventSystem;
    //[SerializeField] GameObject XRPlayer2;
    [SerializeField] GameObject EventSystem;
    [SerializeField] GameObject Spectator;
    [Header("Referencia as Cameras")]
    [SerializeField] GameObject menuCamera;
    [SerializeField] CustomNetworkManager networkManager;
    bool jaLogado = false;
    private void Start()
    {
        if (networkManager.StartWithVRMode)
        {
            EscolherJogador(1);
            menuCamera.SetActive(false);
        }
    }
    public void EscolherJogador(int number)
    {
        if (number==1)
        {
            print("escolhi o jogador");
            UIMenu.SetActive(false);
            //XRPlayer1.SetActive(true);
            XREventSystem.SetActive(true);
            EventSystem.SetActive(false);
            jaLogado = true;
        }else if (number == 1 && jaLogado){
            UIMenu.SetActive(false);
            //XRPlayer2.SetActive(true);
            XREventSystem.SetActive(true);
            EventSystem.SetActive(false);
        }
        if (number == 2)
        {
            UIMenu.SetActive(false);
            Spectator.SetActive(true);
        }
    }
}
