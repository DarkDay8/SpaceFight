using strange.extensions.mediation.impl;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceFightProject
{
    public class GameGUIView : View, IMyView
    {
        private GameModel gameModel;
        #region Unity Fields
        [SerializeField]
        private Text ScoreLogo;
        [SerializeField]
        private Text ScoreText;
        [SerializeField]
        private Text HpLogo;
        [SerializeField]
        private Text HpValue;
        [SerializeField]
        private Text EnergyLogo;
        [SerializeField]
        private Text EnergyValue;
        [SerializeField]
        private RectTransform HpScroll;
        [SerializeField]
        private RectTransform HpBack;
        [SerializeField]
        private RectTransform EnergyScroll;
        [SerializeField]
        private RectTransform EnergyBack;
        #endregion
        public void LoadView()
        {

        }

        public void SetBacePreferences(GameModel gameModel)
        {
            this.gameModel = gameModel;
            gameModel.player.changeHP += ChangeHP;
            gameModel.player.changeEnergy += ChangeEnergy;
            ChangeHP(gameModel.player.CurrentHp, gameModel.player.MaxHp);
            ChangeEnergy(gameModel.player.CurrentEnergy, gameModel.player.MaxEnergy);
            //add localization
        }

        private void ChangeHP(float current, float max)
        {
            HpValue.text = current + "/" + max;
            HpScroll.sizeDelta = new Vector2(HpScroll.sizeDelta.x,current / max * HpBack.sizeDelta.y);

        }
        private void ChangeEnergy(float current, float max)
        {
            EnergyValue.text = current + "/" + max;
            EnergyScroll.sizeDelta = new Vector2(EnergyScroll.sizeDelta.x, current / max * EnergyBack.sizeDelta.y);
        }
        public void RemoveView()
        {

        }
    }
}
