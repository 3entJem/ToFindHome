using UnityEngine;
using UnityEngine.InputSystem;
public class SimplePlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float moveSpeed = 6.0f;
    Vector2 inputVector;
    public Transform playerMesh;
    public Transform cameraTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;

        camForward.y = 0f;
        camRight.y = 0f;

        camForward.Normalize();
        camRight.Normalize();
        Vector3 move = camForward * inputVector.y + camRight * inputVector.x;

        controller.Move(move * moveSpeed * Time.deltaTime);

        if (move.sqrMagnitude > 0.001f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(move);
            playerMesh.rotation = Quaternion.Slerp(playerMesh.rotation, targetRotation,
                10f * Time.deltaTime);
        }
    }

    public void OnMove(InputValue value)
    {
        inputVector = value.Get<Vector2>();
    }
}
