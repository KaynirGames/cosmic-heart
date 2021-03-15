﻿using UnityEngine;

public interface IMoveHandler
{
    void Move(Vector3 direction);

    void SetMoveSpeed(float moveSpeed);
}