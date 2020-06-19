using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerController : NetworkBehaviour {

    private float moveSpd = 0.1f, moveRot = 10.0f;

    public Transform projectilePos;

    public GameObject projectilePrefab;


    // Start is called before the first frame update
    void Start() {

        Material material = GetComponent<Renderer>().material;
        material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

    // Update is called once per frame
    void Update() {

        if (!isLocalPlayer) {

            return;
        }

        transform.Translate(0, 0, Input.GetAxis("Vertical") * moveSpd);
        transform.Rotate(0, Input.GetAxis("Horizontal") * moveRot, 0);

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.Z)) {

            CmdAtirar();
        }
    }

    [Command]
    void CmdAtirar() {
        GameObject projetil = Instantiate(projectilePrefab, projectilePos.position, transform.rotation);
        NetworkServer.Spawn(projetil);
    }
}
