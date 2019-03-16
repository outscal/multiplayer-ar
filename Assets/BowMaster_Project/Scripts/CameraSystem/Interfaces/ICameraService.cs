﻿using UnityEngine;
using System.Collections;

namespace CameraSystem
{
    public interface ICameraService 
    {
        void ResetCameraOrthoSize();
        void OnGameStart();
        void SwitchCamera();
        void SetWeaponToFollow(GameObject weapon);
        void FollowProjectile();
    }
}