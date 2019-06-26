using System;
using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;

namespace SpaceFightProject
{
    
    public class BaseMediator : Mediator
    {
        [Inject]
        public IMyWiew View { get; set; }

        [Inject(ContextKeys.CONTEXT_DISPATCHER)]
        public IEventDispatcher dispatcher { get; set; }

        public override void PreRegister()
        {

        }
        public override void OnRegister()
        {
            View.LoadView();
        }

        public override void OnRemove()
        {
            View.RemoveView();
        }

    }

}