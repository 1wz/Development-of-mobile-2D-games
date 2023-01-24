using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JoostenProductions;

namespace Game.InputLogic
{
    internal class InputKeyboard : BaseInputView
    {
        //управление с клавиатуры. не работает, когда телефон подключен к компьютеру
        [SerializeField] private float _inputMultiplier = 0.05f;


        private void Start() =>
            UpdateManager.SubscribeToUpdate(Move);

        private void OnDestroy() =>
            UpdateManager.UnsubscribeFromUpdate(Move);


        private void Move()
        {

            Vector3 direction = CalcDirection();
            float moveValue = _speed * _inputMultiplier * Time.deltaTime * direction.x;

            float abs = Mathf.Abs(moveValue);
            float sign = Mathf.Sign(moveValue);

            if (sign > 0)
                OnRightMove(abs);
            else
                OnLeftMove(abs);
        }

        private Vector3 CalcDirection()
        {
            Vector3 direction = Vector3.zero;
            direction.x = Input.GetAxis("Horizontal");
            direction.y = Input.GetAxis("Vertical");
            return direction;
        }
    }
}
