using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _cameraSpeed;

    private void Update()
    {
        var currentPlayerPosition = new Vector2(_playerTransform.position.x, _playerTransform.position.y);
        var currentCameraPosition = new Vector2(transform.position.x, transform.position.y);
        var deltaPosition = Vector2.Lerp(currentCameraPosition, currentPlayerPosition, _cameraSpeed * Time.deltaTime);

        transform.position = new Vector3(deltaPosition.x, deltaPosition.y, transform.position.z);
    }
}
