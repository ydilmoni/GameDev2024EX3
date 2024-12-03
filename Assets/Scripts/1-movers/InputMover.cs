using UnityEngine;
using UnityEngine.InputSystem;

/**
 * This component moves its object when the player clicks the arrow keys.
 */
public class InputMover : MonoBehaviour
{
    [Tooltip("Speed of movement, in meters per second")]
    [SerializeField] float speed = 10f;

    [SerializeField]
    InputAction move = new InputAction(
        type: InputActionType.Value, expectedControlType: nameof(Vector2));

    [Tooltip("Boundary objects for restricting movement")]
    [SerializeField] Collider2D topBoundary;
    [SerializeField] Collider2D bottomBoundary;
    [SerializeField] Collider2D leftBoundary;
    [SerializeField] Collider2D rightBoundary;

    void OnEnable()
    {
        move.Enable();
    }

    void OnDisable()
    {
        move.Disable();
    }

    void Update()
    {
        Vector2 moveDirection = move.ReadValue<Vector2>();
        Vector3 movementVector = new Vector3(moveDirection.x, moveDirection.y, 0) * speed * Time.deltaTime;
        transform.position += movementVector;
        // Clamp Y position (top and bottom boundaries)
        Vector3 position = transform.position;
        if (topBoundary != null && bottomBoundary != null)
        {
            float topLimit = topBoundary.bounds.min.y; // גבול תחתון של הגבול העליון
            float bottomLimit = bottomBoundary.bounds.max.y; // גבול עליון של הגבול התחתון
            position.y = Mathf.Clamp(position.y, bottomLimit, topLimit);
        }

        // Handle wrapping on X axis (left and right boundaries)
        if (leftBoundary != null && rightBoundary != null)
        {
            float leftLimit = leftBoundary.bounds.max.x; // גבול ימין של הגבול השמאלי
            float rightLimit = rightBoundary.bounds.min.x; // גבול שמאל של הגבול הימני

            if (position.x < leftLimit)
            {
                position.x = rightLimit;
            }
            else if (position.x > rightLimit)
            {
                position.x = leftLimit;
            }
        }

        // Apply the adjusted position
        transform.position = position;
    }
}
