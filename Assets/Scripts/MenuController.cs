using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update


    //// Update is called once per frame
    //void Update()
    //{

    //}


    [SerializeField] private string VersionName = "0.1";
    [SerializeField] private GameObject usernameMenu;
    [SerializeField] private GameObject ConnectPanel;

    [SerializeField] private InputField UsernameInput;
    [SerializeField] private InputField JoinGameInput;
    [SerializeField] private InputField CreateGameInput;

    [SerializeField] private GameObject StartButton;

    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings(VersionName);
    }

    void Start()
    {
        usernameMenu.SetActive(true);
    }

    private void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("Connected");
    }


    public void ChangeUserNameInput()
    {
        if(UsernameInput.text.Length >= 3)
        {
            StartButton.SetActive(true);

        }
        else
        {
            StartButton.SetActive(false);
        }
    }

    public void SetUserName()
    {
        usernameMenu.SetActive(false);
        PhotonNetwork.playerName = UsernameInput.text;
    }

    public void CreateGame()
    {
        PhotonNetwork.CreateRoom(CreateGameInput.text, new RoomOptions() { maxPlayers = 5 }, null);

    }

    public void JoinGame()
    {
        RoomOptions  roomOptions = new RoomOptions();
        roomOptions.maxPlayers = 5;
        PhotonNetwork.JoinOrCreateRoom(JoinGameInput.text, roomOptions, TypedLobby.Default);
    }

    private void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("GameScene");
    }

}
