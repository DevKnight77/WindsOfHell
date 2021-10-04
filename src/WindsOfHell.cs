﻿using indsofhell.src.entities.abase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Common.Entities;
using Vintagestory.API.Datastructures;
using Vintagestory.API.Server;
using Vintagestory.GameContent;
using windsofhell.src.entities.ai;

[assembly: ModInfo("WindsOfHell",
    Description = "Their winds can push you away, their fire will melt your armor and latch unto your skin, their flight will shake trees, their sound is gloriously eerie",
    Authors = new[] {"DevKnight", "BellCross"})]
namespace windsofhell.src
{
    internal class WindsOfHell : ModSystem
    {
        public override void Start(ICoreAPI api)
        {
            base.Start(api);

       //     api.RegisterMountable(EntityFlyingTameable.NAME, EntityFlyingTameable.GetMountable);
            api.RegisterEntity("EntityFlyingTameable", typeof(EntityFlyingTameable)); 
      //      api.RegisterEntityClass(EntityFlyingTameable.NAME, new EntityProperties());

        //    AiTaskRegistry.Register<EntityAIFlyingRide>("fly");
        }

        public override void StartClientSide(ICoreClientAPI api)
        {
            
        }

        public override void StartServerSide(ICoreServerAPI api)
        {
            
        }
    }
}