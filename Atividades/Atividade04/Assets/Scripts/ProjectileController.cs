using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ProjectileController : NetworkBehaviour {

    private float moveSpd = 20.0f;

    // Start is called before the first frame update
    void Start() {

        Destroy(gameObject, 1);
    }

    // Update is called once per frame
    void Update() {

        transform.Translate(0, 0, Time.deltaTime * moveSpd);
    }

    [ServerCallback]
    private void OnTriggerEnter(Collider other) {

        NetworkServer.Destroy(gameObject);
        NetworkServer.Destroy(other.gameObject);
    }
}
