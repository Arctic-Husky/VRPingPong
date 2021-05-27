using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;
using System.Linq;
using UnityEngine.SceneManagement;


    public class CustomNetworkManager : NetworkManager
    {
        public Transform leftRacketSpawn;
        public Transform rightRacketSpawn;
    public Transform spawnPosition;
    public Transform XRRig;
    //GameObject XRRig;
    GameObject ball;

    public override void OnServerAddPlayer(NetworkConnection conn)
        {
            // add player at correct spawn position
            Transform start = numPlayers == 0 ? leftRacketSpawn : rightRacketSpawn;
            GameObject player = Instantiate(playerPrefab, start.position, start.rotation);
            //GameObject xrRig = Instantiate(XRRig, start.position, start.rotation);
            NetworkServer.AddPlayerForConnection(conn, player);
            //NetworkServer.AddPlayerForConnection(conn, xrRig);

         //spawn ball if two players
        if (numPlayers == 2)
        {
            XRRig.position = spawnPosition.position;
            XRRig.rotation = spawnPosition.rotation;
        }
        
    }

        public override void OnServerDisconnect(NetworkConnection conn)
        {
            // destroy ball
            if (ball != null)
                NetworkServer.Destroy(ball);

            // call base functionality (actually destroys the player)
            base.OnServerDisconnect(conn);
        }
    }


