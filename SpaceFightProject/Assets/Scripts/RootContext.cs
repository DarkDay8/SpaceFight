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
        }
        protected override void mapBindings()
        {
            commandBinder.Bind(ContextEvent.START).To<StartAppCommand>();

            commandBinder.Bind(GlobalEvents.E_LoadView).To<LoadViewCommand>();
            
            mediationBinder.BindView<MainMenuView>().ToMediator<MainMenuMediator>();
        }
    }
    //Mediator classes
    public class MainMenuMediator : BaseMediator<MainMenuView> { };
}

