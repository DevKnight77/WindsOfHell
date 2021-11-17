using windsofhell.src.entities.abase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vintagestory.API.Common;
using Vintagestory.API.Common.Entities;
using Vintagestory.API.Datastructures;
using Vintagestory.GameContent;

namespace windsofhell.src.entities.ai
{
    class EntityAIFlyingRide : AiTaskBase
    {
        // true flyflap; flase flyglide
        public  bool isFlapping { get; set; }
        public EntityFlyingTameable flyingentity { get; set; }

        EntityAIFlyingRide(EntityFlyingTameable flyingentity) : base(flyingentity)
        {
            this.flyingentity = flyingentity;
        }

        public override bool ShouldExecute()
        {
            return flyingentity.pilot != null;
        }

        // make a one shot jump to commence liftoff
        // isOnGround Checks if it is high in the air
        public override void StartExecute()
        {
            if(!flyingentity.isFlying)
            {
                if(flyingentity.pilot.Controls.Jump)
                {
                    flyingentity.Pos.Y += 2;
                } else if(flyingentity.pilot.Controls.Backward)
                {
                    flyingentity.Pos.Y -= 2;
                }
            }
        }

        public override void LoadConfig(JsonObject taskConfig, JsonObject aiConfig)
        {
           
        }

        public override bool ContinueExecute(float dt)
        { // flyflapp
            // flyglide
            EntityAgent pilot = flyingentity.pilot;
            EntityControls pilotcontrols = pilot.Controls;
            if(flyingentity.isFlying) { 
                if(pilotcontrols.Jump)
                {
                    flyingentity.Pos.Y+=2;
                } else if (pilotcontrols.Forward) {
                    
                }

             }
            return true;
        }

        public override void FinishExecute(bool cancelled)
        {
            base.FinishExecute(cancelled);
        }
    }
}
