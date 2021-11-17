using System.Linq;
using System.Threading.Tasks;
using windsofhell.src.entities.abase;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Common.Entities;
using Vintagestory.API.Server;
using Vintagestory.GameContent;
using windsofhell.src.entities.ai;

namespace WindsOfHell
{
    class WindsOfHell : ModSystem
    {
        public override void Start(ICoreAPI api)
        {
            base.Start(api);

            api.RegisterMountable(EntityFlyingTameable.NAME, EntityFlyingTameable.GetMountable);
            api.RegisterEntity(EntityFlyingTameable.NAME, typeof(EntityFlyingTameable));
            api.RegisterEntityClass(EntityFlyingTameable.NAME, new EntityProperties()); 

            AiTaskRegistry.Register<EntityAIFlyingRide>("fly");
        }

        public override void StartClientSide(ICoreClientAPI api)
        {
            
        }

        public override void StartServerSide(ICoreServerAPI api)
        {
            
        }
    }
}
