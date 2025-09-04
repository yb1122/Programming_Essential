using UnityEngine;

[ExecuteAlways] // Optional: enables the effect in Edit Mode
public class DayNightCycle : MonoBehaviour
{
    [Header("Day-Night Cycle Settings")]
    [Tooltip("Duration of a full day in seconds")]
    [Range(10f, 86400f)]
    public float dayDurationInSeconds = 60f; // Default: 1 minute per day

    [Tooltip("Start time offset in degrees (0 = sunrise, 90 = noon, 180 = sunset)")]
    public float initialRotationX = 0f;

    private void Update()
    {
        if (dayDurationInSeconds <= 0f)
            return;

        float degreesPerSecond = 360f / dayDurationInSeconds;
        float rotationThisFrame = degreesPerSecond * Time.deltaTime;

        // Apply rotation around X axis
        transform.Rotate(Vector3.right, rotationThisFrame, Space.Self);
    }

    private void OnEnable()
    {
        // Ensure consistent starting point on play
        Vector3 startRotation = transform.rotation.eulerAngles;
        startRotation.x = initialRotationX;
        transform.rotation = Quaternion.Euler(startRotation);
    }
}