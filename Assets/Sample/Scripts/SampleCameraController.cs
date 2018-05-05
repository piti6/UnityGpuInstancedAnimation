using UnityEngine;

public class SampleCameraController : MonoBehaviour
{
    private const string InputAxisX = "X Axis";
    private const string InputAxisY = "Y Axis";
    private const string InputAxisZ = "Z Axis";

    private Vector3 _previousMousePosition = Vector3.zero;
    private Vector3 _inputAxises = Vector3.zero;

    private float coefficient { get { return Time.deltaTime * 10; } }

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            var deltaMousePosition = Input.mousePosition - _previousMousePosition;

            transform.Rotate(Vector3.left, deltaMousePosition.y * coefficient, Space.Self);
            transform.Rotate(Vector3.up, deltaMousePosition.x * coefficient, Space.World);
        }

        _previousMousePosition = Input.mousePosition;
        _inputAxises.Set(Input.GetAxis(InputAxisX), Input.GetAxis(InputAxisY), Input.GetAxis(InputAxisZ));

        transform.Translate(_inputAxises * coefficient);
    }
}
