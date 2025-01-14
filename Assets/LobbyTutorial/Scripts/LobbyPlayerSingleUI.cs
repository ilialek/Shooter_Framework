using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Services.Lobbies.Models;
using UnityEngine.UI;

public class LobbyPlayerSingleUI : MonoBehaviour {


    [SerializeField] private TextMeshProUGUI playerNameText;
    [SerializeField] private Image characterImage;
    [SerializeField] private Button kickPlayerButton;

    [SerializeField] private TextMeshProUGUI playerReadinessText;

    [SerializeField] private Color greenColor;
    [SerializeField] private Color redColor;

    private Player player;


    private void Awake() {
        kickPlayerButton.onClick.AddListener(KickPlayer);
    }

    public void SetKickPlayerButtonVisible(bool visible) {
        kickPlayerButton.gameObject.SetActive(visible);
    }

    public void SetReadinessTextVisible(bool visible)
    {
        playerReadinessText.gameObject.SetActive(!visible);
    }

    public void UpdatePlayer(Player player) {
        this.player = player;
        playerNameText.text = player.Data[LobbyManager.KEY_PLAYER_NAME].Value;
        LobbyManager.PlayerCharacter playerCharacter = 
            System.Enum.Parse<LobbyManager.PlayerCharacter>(player.Data[LobbyManager.KEY_PLAYER_CHARACTER].Value);
        characterImage.sprite = LobbyAssets.Instance.GetSprite(playerCharacter);

        playerReadinessText.text = player.Data[LobbyManager.KEY_PLAYER_READINESS].Value;

        //if (player.Data[LobbyManager.KEY_PLAYER_READINESS].Value == "Ready")
        //{
        //    playerReadinessText.color = greenColor;
        //    playerReadinessText.text = player.Data[LobbyManager.KEY_PLAYER_READINESS].Value;
        //}
        //else if (player.Data[LobbyManager.KEY_PLAYER_READINESS].Value == "Not ready")
        //{
        //    playerReadinessText.color = redColor;
        //    playerReadinessText.text = player.Data[LobbyManager.KEY_PLAYER_READINESS].Value;
        //}


    }

    private void KickPlayer() {
        if (player != null) {
            LobbyManager.Instance.KickPlayer(player.Id);
        }
    }


}