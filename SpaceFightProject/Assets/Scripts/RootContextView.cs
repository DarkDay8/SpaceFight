using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace SpaceFightProject
{
    public class RootContextView : ContextView
    {
        void Awake()
        {
            context = new RootContext(this, true);
            context.Start();
        }
    }
}

