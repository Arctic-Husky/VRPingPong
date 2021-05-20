using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mirror;
using System;

public class ChatBoxVRNetwork : NetworkBehaviour
{
    [SerializeField]
    GameObject chatUI;
    [SerializeField]
    TMP_Text chatText;
    [SerializeField]
    TMP_InputField inputField;
    //evento que sera disparado quando
    static event Action<string> OnMessage;
    //so irei fazer isso no meu cliente o unico que tenho autoridade
    public void ApertarTecla(string letra) {
        inputField.text += letra;

    }
    public override void OnStartAuthority()
    {
        chatUI.SetActive(true);
        OnMessage += HandleNewMessage;
    }
    //previne do server rodar o codigo; se nao tiver autoridade nao faça nada, mas se tiver quando for destruido unsubscribe do evento
    [ClientCallback]
    private void OnDestroy()
    {
        if (!hasAuthority)
        {
            return;
        }
        OnMessage -= HandleNewMessage;
    }
    private void HandleNewMessage(string message)
    {
        chatText.text += message;
    }
    //metodo que so ira rodar no cliente
    [Client]
    public void Send(string message)
    {
        if (!Input.GetKeyDown(KeyCode.Return))
        {
            return;
        }
        if (string.IsNullOrWhiteSpace(message))
        {
            return;
        }
        //pedir servidor para mandar
        CmdSendMessage(inputField.text);
        inputField.text = string.Empty;
    }
    //comandos sao metodos que entram no servidor
    [Command]
    private void CmdSendMessage(string message)
    {
        //validar codigo, ex. ver se nao falou palavrao
        RpcHandleMessage($"[{connectionToClient.connectionId}]:{ message}");
    }
    //metodo para fazer que o servidor mande isso para todos os clientes
    [ClientRpc]
    private void RpcHandleMessage(string message)
    {
        OnMessage?.Invoke($"\n{message}");
    }
}
