using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    public GameObject player;
    public GameObject projectile;
    public GameObject projectileClone;

    float shotTimer = 0;
    float shotPeriod = 0.6f;

    public static Vector3 respawnLocation = new Vector3(0, -3.5f, 0);


    public PhotonView photonView;
    public Rigidbody2D rb;
    public GameObject PlayerCamera;
    public SpriteRenderer sr;
    public Text PlayerNameText;


    private void Awake()
    {
        if (photonView.isMine)
        {
            //PlayerCamera.SetActive(true);
            PlayerNameText.text = PhotonNetwork.playerName;
        }
        else if (!photonView.isMine)
        {
            PlayerNameText.text = photonView.owner.name;
            PlayerNameText.color = Color.cyan;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.lives > 0 && photonView.isMine)
        {
            Movement();
            FireProjectile();
        }
        
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(5 * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-5 * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, 5 * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, -5 * Time.deltaTime, 0));
        }
    }

    void FireProjectile()
    {
        shotTimer += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && shotTimer >= shotPeriod)
        {
            projectileClone = Instantiate(projectile, new Vector3(player.transform.position.x, player.transform.position.y+0.8f, player.transform.position.z), player.transform.rotation) as GameObject;
            shotTimer = 0;
        }

    }



}
