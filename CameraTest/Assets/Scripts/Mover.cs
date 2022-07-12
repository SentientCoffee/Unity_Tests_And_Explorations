using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Mover : MonoBehaviour {
    [SerializeField] private float _moveSpeed = 3.0f;
    private CharacterController _controller;
    private Vector3 _moveDirection = Vector3.zero;

    [HideInInspector]
    public Vector3 inputVector = Vector2.zero;

    private void Awake() {
        _controller = GetComponent<CharacterController>();
    }

    private void Update() {
        _moveDirection = new Vector3(inputVector.x, 0.0f, inputVector.y);
        _moveDirection = transform.TransformDirection(_moveDirection);
        _moveDirection *= _moveSpeed;

        _controller.Move(_moveDirection * Time.deltaTime);
    }

}
