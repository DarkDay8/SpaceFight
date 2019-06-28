using strange.extensions.context.impl;
using strange.extensions.context.api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.mediation.impl;

namespace SpaceFightProject
{
    public class RootContext : MVCSContext
    {
        public RootContext(MonoBehaviour contextView, bool autoMap) : base(contextView, autoMap) { }
        protected override void addCoreComponents()
        {
            base.addCoreComponents();

            injectionBinder.Bind<PreferencesModel>().ToSingleton();
            injectionBinder.Bind<GameModel>().ToSingleton();
        }
        protected override void mapBindings()
        {
            commandBinder.Bind(ContextEvent.START).To<StartAppCommand>();

            commandBinder.Bind(GlobalEvents.E_LoadView).To<LoadViewCommand>();
            commandBinder.Bind(GlobalEvents.E_RemoveView).To<RemoveViewCommand>();
            commandBinder.Bind(GlobalEvents.E_InstantiatePlayer).To<InstantiatePlayerCommand>();
            
            mediationBinder.BindView<MainMenuView>().ToMediator<MainMenuMediator>();
            mediationBinder.BindView<MainGameFieldView>().ToMediator<MainGameFieldMediator>();

        }
    }
    //We can't add template class in MonoBehaviour 
    //Mediator classes
    public class MainMenuMediator : BaseMediator<MainMenuView> { };
    public class MainGameFieldMediator : BaseMediator<MainGameFieldView> { };
}

