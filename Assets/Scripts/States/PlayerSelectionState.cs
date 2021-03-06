﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectionState : PlayerState
{
    private CameraMovement cameraMovement;
    public PlayerSelectionState(GameManager gameManager, CameraMovement cameraMovement) : base(gameManager)
    {
        this.cameraMovement = cameraMovement;
    }
    public override void OnInputPanChange(Vector3 position)
    {
        cameraMovement.MoveCamera(position);
    }

    public override void OnInputPanUp()
    {
        cameraMovement.StopCameraMovement();
    }

    public override void OnInputPointerChange(Vector3 position)
    {
        return;
    }

    public override void OnInputPointerDown(Vector3 position)
    {
        return;
    }

    public override void OnInputPointerUp()
    {
        return;
    }

   public override void OnCancel()
    {
        return;
    }
}
