using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vintagestory.API.Common;
using Vintagestory.API.Common.Entities;
using Vintagestory.GameContent;

namespace windsofhell.src.entities.abase
{
    class TestEntity : EntityAgent
    {
        public static string NAME { get; } = "TestEntity";

        public TestEntity() : base()
        {

        }

        public override void Initialize(EntityProperties properties, ICoreAPI api, long InChunkIndex3d)
        {
            base.Initialize(properties, api, InChunkIndex3d); 
        }


    }
}
