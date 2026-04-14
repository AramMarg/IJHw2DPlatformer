using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    public event Action<Vector2> AxisesReceived;

    private void Update()
    {
        float axisX = Input.GetAxisRaw(Horizontal);
        float axisY = Input.GetAxisRaw(Vertical);

        AxisesReceived?.Invoke(new Vector2(axisX, axisY));
    }
}
