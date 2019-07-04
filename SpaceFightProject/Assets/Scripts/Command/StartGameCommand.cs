using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceFightProject
{
    public class StartGameCommand : Command
    {
        [Inject]
        public GameModel GameModel { set; get; }

        public override void Execute()
        {
            GameModel.player.SetMoveController().SetFireController().WeaponReloadTime = 0.3f;
            GameModel.StartGame();
        }
    }
}
