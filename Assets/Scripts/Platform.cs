using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float minMovementX;
    [SerializeField] private float maxMovementX;
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        var mousePosition = Input.mousePosition;
        if (Camera.main is null) return;
        var mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        var mouseX = mouseWorldPosition.x;
        var clampMouseX = Mathf.Clamp(mouseX, minMovementX, maxMovementX);
        var mouseY = transform.position.y;
        transform.position = new Vector3(clampMouseX, mouseY, 0);
    }
}
