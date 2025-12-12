using UnityEngine;
using UnityEngine.InputSystem;
public class SimplePlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float moveSpeed = 6.0f;
    Vector2 inputVector;
    public Transform playerMesh;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(inputVector.x, 0, inputVector.y);

        controller.Move(move * moveSpeed * Time.deltaTime);

        if (move != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(move);
            playerMesh.rotation = Quaternion.Slerp(playerMesh.rotation, targetRotation, 10f * Time.deltaTime);
        }
    }

    public void OnMove(InputValue value)
    {
        inputVector = value.Get<Vector2>();
    }
}
