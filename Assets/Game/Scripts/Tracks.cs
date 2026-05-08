using UnityEngine;

public class Tracks : MonoBehaviour
{
    private Transform[] points;

    private void Awake()
    {
        points = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
    public Vector2 GetPosition(float distance)
    {
        if (points.Length < 2)
            return transform.position;

        float remaining = distance;

        for (int i = 0; i < points.Length - 1; i++)
        {
            Vector2 a = points[i].position;
            Vector2 b = points[i + 1].position;

            float segmentLength = Vector2.Distance(a, b);

            if (remaining <= segmentLength)
            {
                float t = remaining / segmentLength;
                return Vector2.Lerp(a, b, t);
            }

            remaining -= segmentLength;
        }

        // End of track
        return points[points.Length - 1].position;
    }

    public Vector2 GetDirection(float distance)
    {
        if (points.Length < 2)
            return Vector2.right;

        float remaining = distance;

        for (int i = 0; i < points.Length - 1; i++)
        {
            Vector2 a = points[i].position;
            Vector2 b = points[i + 1].position;

            float segmentLength = Vector2.Distance(a, b);

            if (remaining <= segmentLength)
            {
                return (b - a).normalized;
            }

            remaining -= segmentLength;
        }

        // End direction
        return (
            points[points.Length - 1].position
            - points[points.Length - 2].position
        ).normalized;
    }
}
