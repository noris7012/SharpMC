﻿using SharpMC.Classes;

namespace SharpMC.Networking.Packages
{
	internal class EntityLook : Package<EntityLook>
	{
		public Player Player;

		public EntityLook(ClientWrapper client) : base(client)
		{
			SendId = 0x16;
		}

		public EntityLook(ClientWrapper client, MSGBuffer buffer) : base(client, buffer)
		{
			SendId = 0x16;
		}

		public override void Write()
		{
			if (Buffer != null)
			{
				Buffer.WriteVarInt(SendId);
				Buffer.WriteVarInt(Player.EntityId);
				Buffer.WriteByte((byte)Player.KnownPosition.Yaw);
				Buffer.WriteByte((byte)Player.KnownPosition.Pitch);
				Buffer.WriteBool(Player.KnownPosition.OnGround);
				Buffer.FlushData();
			}
		}
	}
}