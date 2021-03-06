﻿using System;
using System.Collections.Generic;
using Axios.Engine.Interfaces;
using FarseerPhysics.Common;
using FarseerPhysics.Common.Decomposition;
using FarseerPhysics.Common.PolygonManipulation;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using FarseerPhysics.SamplesFramework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Axios.Engine
{
    public abstract class SimpleDrawableAxiosGameObject : SimpleAxiosGameObject, IDrawableAxiosGameObject
    {
        protected Texture2D Texture;
        
        protected Boolean _adjustunits = true;
        protected Boolean _relativetocamera = true;
        protected int _draworder;
        protected bool _visible = true;

        public bool Visible
        {
            get { return _visible; }
            set { this._visible = value; }
        }

        

        public SimpleDrawableAxiosGameObject()
        {
            this.BodyPart = new Body();
            this.Position = new Vector2();
            this.Origin = new Vector2();
            
        }

        public override void LoadContent(AxiosGameScreen gameScreen)
        {
            base.LoadContent(gameScreen);

        }

        public virtual void Draw(AxiosGameScreen gameScreen, GameTime gameTime)
        {
            if (_visible)
            {
                if (_relativetocamera)
                    gameScreen.ScreenManager.SpriteBatch.Begin(0, null, null, null, null, null, gameScreen.Camera.View);
                else
                    gameScreen.ScreenManager.SpriteBatch.Begin();
                if (_adjustunits)
                    DrawObject(gameScreen.ScreenManager.SpriteBatch, Texture, BodyPart, Origin, true, _scale);
                else
                    DrawObject(gameScreen.ScreenManager.SpriteBatch, Texture, BodyPart, Origin, _scale);
                gameScreen.ScreenManager.SpriteBatch.End();
            }
        }

        protected void DrawObject(SpriteBatch sb, Texture2D texture, Body body, Vector2 origin)
        {
            DrawObject(sb, texture, body, origin, false, _scale);
        }

        protected void DrawObject(SpriteBatch sb, Texture2D texture, Body body, Vector2 origin, float scale)
        {
            DrawObject(sb, texture, body, origin, false, scale);
        }

        protected void DrawObject(SpriteBatch sb, Texture2D texture, Body body, Vector2 origin, bool Convertunits, float scale)
        {
            if (Convertunits)
                sb.Draw(texture, ConvertUnits.ToDisplayUnits(body.Position),
           null,
           Color.White, body.Rotation, origin, scale,
           SpriteEffects.None, 0);
            else
                sb.Draw(texture, body.Position,
           null,
           Color.White, body.Rotation, origin, scale,
           SpriteEffects.None, 0f);
        }

        public int DrawOrder
        {
            get
            {
                return this._draworder;
            }
            set
            {
                this._draworder = value;
            }
        }

        public void CreateBodyFromTexture(AxiosGameScreen gameScreen)
        {
            if (this.Texture != null)
            {
                uint[] data = new uint[this.Texture.Width * this.Texture.Height];
                this.Texture.GetData<uint>(data);
                Vertices vertices = PolygonTools.CreatePolygon(data, this.Texture.Width, false);
                Vector2 vector = -vertices.GetCentroid();
                vertices.Translate(ref vector);
                this.Origin = -vector;
                List<Vertices> list = BayazitDecomposer.ConvexPartition(SimplifyTools.ReduceByDistance(vertices, 4f));
                this._scale = 1f;
                Vector2 vector2 = (Vector2)(new Vector2(ConvertUnits.ToSimUnits(1)) * this._scale);
                foreach (Vertices vertices2 in list)
                {
                    vertices2.Scale(ref vector2);
                }
                this.BodyPart = BodyFactory.CreateCompoundPolygon(gameScreen.World, list, 1f, BodyType.Dynamic);
                this.BodyPart.BodyType = BodyType.Dynamic;
                this.BodyPart.Position = this.Position;
                this.BodyPart.UserData = this;
                this.BodyPart.CollidesWith = Category.All;
                this.BodyPart.CollisionCategories = Category.All;
            }
        }

 

 

    }
}
