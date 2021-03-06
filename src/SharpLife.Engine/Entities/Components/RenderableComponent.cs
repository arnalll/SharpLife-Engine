﻿/***
*
*	Copyright (c) 1996-2001, Valve LLC. All rights reserved.
*	
*	This product contains software technology licensed from Id 
*	Software, Inc. ("Id Technology").  Id Technology (c) 1996 Id Software, Inc. 
*	All Rights Reserved.
*
*   This source code contains proprietary and confidential information of
*   Valve LLC and its suppliers.  Access to this code is restricted to
*   persons who have executed a written SDK license with Valve.  Any access,
*   use or distribution of this code by or to any unlicensed person is illegal.
*
****/

using SharpLife.Engine.Client.UI.Rendering;
using SharpLife.Engine.Client.UI.Rendering.Models;
using SharpLife.Engine.Entities.KeyValues;
using SharpLife.Engine.Models;
using SharpLife.Engine.ObjectEditor;
using SharpLife.Engine.Physics;
using System;
using System.Numerics;

namespace SharpLife.Engine.Entities.Components
{
    public abstract class RenderableComponent : Component
    {
        [ObjectEditorVisible(Visible = false)]
        public abstract IModel Model { get; set; }

        [KeyValue(Name = "model")]
        public string ModelName
        {
            get => Model?.Name;
            set => TrySetModel(value);
        }

        protected abstract Type ModelFormat { get; }

        public bool TrySetModel(string modelName) => TrySetModel(EntitySystem.Scene.Models.Load(modelName));

        public bool TrySetModel(IModel model)
        {
            if (!InternalTrySetModel(model))
            {
                EntitySystem.Scene.Logger.Warning("Entity {Entity} Model has wrong format: got {ActualFormat}, expected {ExpectedFormat}",
                    Entity.ToString(), model.GetType().Name, ModelFormat.Name);
                return false;
            }

            var collider = Entity.GetComponent<Collider>();

            if (collider != null)
            {
                if (model != null)
                {
                    collider.SetSize(model.Mins, model.Maxs);
                }
                else
                {
                    collider.SetSize(Vector3.Zero, Vector3.Zero);
                }
            }

            return true;
        }

        protected abstract bool InternalTrySetModel(IModel model);

        internal abstract void Render(IRendererModels renderer, in RenderContext renderContext);

        public void OnEnable()
        {
            EntitySystem.WorldState.RendererModels.AddRenderable(this);
        }

        public void OnDisable()
        {
            EntitySystem.WorldState.RendererModels.RemoveRenderable(this);
        }
    }
}
