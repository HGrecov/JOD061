using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonConnection : MonoBehaviourPunCallbacks {

	public string gameVersion = "0.0.1";
	public string nickname = "Player";
	public string roomName = "JOD061";


	private void Start () {

		Debug.Log ("Conectando ao servidor...");
		PhotonNetwork.GameVersion = gameVersion;
		PhotonNetwork.NickName = nickname + Random.Range (0, 9999);

		PhotonNetwork.ConnectUsingSettings ();
	}

	public override void OnConnectedToMaster () {

		if (PhotonNetwork.CountOfRooms == 0) {

			RoomOptions options = new RoomOptions ();
			options.MaxPlayers = 4;

			PhotonNetwork.JoinOrCreateRoom (roomName, options, TypedLobby.Default);

		} else {

			PhotonNetwork.JoinRoom (roomName);
		}
		Debug.Log ("Conectado!", this);
	}

	public override void OnDisconnected (Photon.Realtime.DisconnectCause cause) {

		Debug.Log (nickname + " foi desconectado por " + cause);
	}

	public override void OnCreatedRoom () {

		Debug.Log ("Criada a sala " + roomName);
		Debug.Log ("Jogador " + PhotonNetwork.LocalPlayer.NickName + " entrou na sala " + roomName + " (número de jogadores: " + PhotonNetwork.CurrentRoom.PlayerCount + ")");
	}

	public override void OnPlayerEnteredRoom (Player newPlayer) {
		
		Debug.Log ("Jogador " + PhotonNetwork.LocalPlayer.NickName + " entrou na sala " + roomName + " (número de jogadores: " + PhotonNetwork.CurrentRoom.PlayerCount + ")");
	}

	public override void OnPlayerLeftRoom (Player newPlayer) {

		Debug.Log ("Jogador " + PhotonNetwork.LocalPlayer.NickName + " saiu da sala " + roomName + " (número de jogadores: " + PhotonNetwork.CurrentRoom.PlayerCount + ")");
	}

}
