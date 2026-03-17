using Unity.Netcode;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, 10, 300, 300));
        
        if (!NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsServer)
        {
            if (GUILayout.Button("Host (Server + Client)")) 
                NetworkManager.Singleton.StartHost();

            if (GUILayout.Button("Client (Join Room)")) 
                NetworkManager.Singleton.StartClient();
        }

        GUILayout.EndArea();
    }
}
