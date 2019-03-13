﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponSystem;

namespace PlayerSystem
{
    public class PlayerCharacterController
    {
        private int characterID;
        private PlayerController playerController;
        private PlayerCharacterView playerCharacterView;
        private ScriptableObjPlayer scriptableObjPlayer;
        private IWeaponService weaponService;

        public PlayerCharacterController(int characterID, PlayerController playerController,
        ScriptableObjPlayer scriptableObjPlayer, IWeaponService weaponService,
            Vector2 spawnPos)
        {
            this.scriptableObjPlayer = scriptableObjPlayer;
            this.characterID = characterID;
            this.weaponService = weaponService;
            this.playerController = playerController;
            GameObject playerObj = GameObject.Instantiate<GameObject>(
                        scriptableObjPlayer.characterViews[0].gameObject
                );
            playerObj.transform.position = spawnPos;
            playerCharacterView = playerObj.GetComponent<PlayerCharacterView>();
            playerCharacterView.SetCharacterController(this);
        }

        public int GetCharacterID()
        {
            return characterID;
        }

        public void SetShootInfo(float power, float angle, bool gettingInput)
        {
            playerCharacterView.SetShootInfo(power, angle,gettingInput);

            if (gettingInput == false)
                weaponService.SpawnWeapon(power, angle, playerCharacterView.ShootPos);
        }
    }
}