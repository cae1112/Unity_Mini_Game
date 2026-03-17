using Unity.Netcode;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 5f; 
    private Animator anim; 
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!IsLocalPlayer) return;
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveStep = new Vector3(moveX, 0, moveZ) * speed * Time.deltaTime;

        transform.Translate(moveStep, Space.World);

        if (anim != null)
        {
            bool isWalking = (moveX != 0 || moveZ != 0);
            anim.SetBool("isMoving", isWalking);
        }

        if (moveX != 0 || moveZ != 0)
        {
            transform.forward = new Vector3(moveX, 0, moveZ);
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpServerRpc(); // Вызываем действие через сервер
        }
    }

    [ServerRpc]
    void JumpServerRpc()
    {
        Debug.Log("Игрок прыгнул!");
    }
}
