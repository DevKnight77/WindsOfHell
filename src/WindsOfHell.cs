using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Common.Entities;
using Vintagestory.API.Server;
using Vintagestory.GameContent;
using windsofhell.src.entities.abase;
using windsofhell.src.entities.ai;

[assembly: ModInfo("WindsOfHell",
    Description = "Their winds can push you away, their fire will melt your armor and latch unto your skin, their flight will shake trees, their sound is gloriously eerie",
    Authors = new []{"DevKnight", "BellCross"})]
namespace windsofhell.src
{
    internal class WindsOfHell : ModSystem
    {
        public override void Start(ICoreAPI api)
        {
            base.Start(api);

       //     api.RegisterMountable(EntityFlyingTameable.NAME, EntityFlyingTameable.GetMountable);
     //       api.RegisterEntity(EntityFlyingTameable.NAME, typeof(EntityFlyingTameable));
     //       api.RegisterEntityClass(EntityFlyingTameable.NAME, new EntityProperties()); 
 //           api.RegisterEntity(TestEntity.NAME, typeof(TestEntity));
  //          EntityProperties entityType = api.World.GetEntityType(new AssetLocation("wingedwolf_male", "wingedwolf_male"));
    //        api.RegisterEntityClass(TestEntity.NAME, entityType);
//
  //          AiTaskRegistry.Register<EntityAIFlyingRide>("fly");
        }

        public override void StartClientSide(ICoreClientAPI api)
        {
            
        }

        public override void StartServerSide(ICoreServerAPI api)
        {
            
        }
    }
}
