using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vintagestory.API.Common;
using Vintagestory.API.Common.Entities;
using Vintagestory.API.Datastructures;
using Vintagestory.API.MathTools;
using Vintagestory.GameContent;
using windsofhell.src.entities.ai;

namespace indsofhell.src.entities.abase
{
    public class EntityFlyingTameable : EntityAgent, IMountable
    {
        public static string NAME { get; } = "EntityFlyingTameable";
        public EntityFlyingTameable() 
        {
            
        }
        public EntityAgent pilot { get; set; }
        public byte passengerIndex { get; set; }
        public bool isFlying { get; set; }

        public override bool IsInteractable => true;
        public Vec3d MountPosition => new Vec3d(0,0,0);

        public float? MountYaw => pilot.HeadYaw;

        public string SuggestedAnimation => "flyflap";

        public void DidMount(EntityAgent entityAgent)
        {
            entityAgent = this.pilot;
        }

        public void DidUnmount(EntityAgent entityAgent)
        {
            entityAgent = this.pilot;
        }

        public void MountableToTreeAttributes(TreeAttribute tree)
        {
            throw new NotImplementedException();
        }

        public override void OnInteract(EntityAgent byEntity, ItemSlot slot, Vec3d hitPosition, EnumInteractMode mode)
        {
            if (mode == EnumInteractMode.Interact)
            {
                byEntity = this.pilot;
            }

        }

        public bool isOnGround()
        {
            BlockPos blockOneBelow = new BlockPos((int)Pos.X, (int)Pos.Y - 1, (int)Pos.Z);
            Block loadedBlocks = (Block)World.Blocks;
            // SyncedEntityPos is double; BlockPos is int;
            return loadedBlocks.GetBlockMaterial(World.GetBlockAccessor(true, false, true, true), blockOneBelow, null) != EnumBlockMaterial.Air;
        } 

        public override void OnGameTick(float dt)
        {
            if (!isOnGround())
            {
                this.isFlying = true;
                //cancel controlledphysics gravity
                this.isFlying = controls.IsFlying; 
            }
            
        }

         public static IMountable GetMountable(IWorldAccessor world, TreeAttribute tree)
        {
            EntityFlyingTameable flyingtameable = (EntityFlyingTameable)world.GetEntityById(tree.GetLong("EntityId"));
            tree.SetString(EntityFlyingTameable.NAME, "EntityFlyingTameable");

            return flyingtameable;
        }

    }

}
