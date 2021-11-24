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

namespace windsofhell.src.entities.abase
{
    public class EntityFlyingTameable : EntityAgent, IMountable
    
    {
        public static string NAME { get; } = "EntityFlyingTameable";
        public EntityAgent pilot;
        public byte passengerIndex { get; set; }
        public bool isFlying { get; set; }
        public EntityFlyingTameable() : base()
        {
            
        }
        
        public override bool IsInteractable => true;
        public Vec3d MountPosition { 
            get{
                // edit position and animation
               return new Vec3d(Pos.X, Pos.Y, Pos.Z).AddCopy(0,0,0);
            }
        }

        public float? MountYaw => HeadYaw;

        public string SuggestedAnimation => "sit";

        // called when mounted
        public void DidMount(EntityAgent entityAgent)
        {
            if(pilot!=null) return;
            pilot=entityAgent;
        }
        
        // called when an entity dismounts
        public void DidUnmount(EntityAgent entityAgent)
        {
            pilot=null;
            Vec3d entityPos = Pos.AsBlockPos.ToVec3d().Add(0,0,0);
            if(!Api.World.CollisionTester.IsColliding(Api.World.BlockAccessor, entityAgent.CollisionBox, entityPos, false))
            {
                entityAgent.TeleportTo(entityPos);
            }
        }

        public void MountableToTreeAttributes(TreeAttribute tree)
        {
            tree.SetString("entityname", "flyingtameable");
            tree.SetDouble("posx", Pos.X);
            tree.SetDouble("posy", Pos.Y);
            tree.SetDouble("posz", Pos.Z);
        }

        public override void OnInteract(EntityAgent byEntity, ItemSlot slot, Vec3d hitPosition, EnumInteractMode mode)
        {
            if (mode == EnumInteractMode.Interact)
            {
                if(pilot!=null) return;
                byEntity.TryMount(this);
            }
            base.OnInteract(byEntity, slot, hitPosition, mode);
        }

        public bool isOnGround()
        {
            EntityPos blockOneBelow = new EntityPos(Pos.X, Pos.Y - 1, Pos.Z);
            BlockPos blockpos = blockOneBelow.AsBlockPos;
            Block loadedBlocks = World.GetBlockAccessor(true, false, true , true).GetBlock(blockpos.X, blockpos.Y, blockpos.Z);
            return loadedBlocks.GetBlockMaterial(World.GetBlockAccessor(true, false, true, true), blockpos, null) != EnumBlockMaterial.Air;
        } 

        public override void OnGameTick(float dt)
        {
            base.OnGameTick(dt);

            if (!isOnGround())
            {
                this.isFlying = true;
                //cancel controlledphysics gravity
                this.isFlying = controls.IsFlying; 
            } 
        }

        public override void Die(EnumDespawnReason reason = EnumDespawnReason.Death, DamageSource damageSourceForDeath = null)
        {
            base.Die(reason, damageSourceForDeath);
            pilot?.TryUnmount();
            
        }
         public static IMountable GetMountable(IWorldAccessor world, TreeAttribute tree)
        {
            Entity entity = world.GetEntityById(tree.GetLong("EntityId"));
            EntityFlyingTameable flyingTameable = (entity as EntityFlyingTameable);
           
            return flyingTameable;
        }

    }

}
