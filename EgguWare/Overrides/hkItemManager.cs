﻿using System;
using System.Collections.Generic;
using SDG.Unturned;
using UnityEngine;

namespace EgguWare.Overrides
{
	public class hkItemManager
	{
		public static void OV_getItemsInRadius(Vector3 center, float sqrRadius, List<RegionCoordinate> search, List<InteractableItem> result)
		{
			if (ItemManager.regions == null)
			{
				return;
			}
			for (int i = 0; i < search.Count; i++)
			{
				RegionCoordinate regionCoordinate = search[i];
				if (ItemManager.regions[(int)regionCoordinate.x, (int)regionCoordinate.y] != null)
				{
					for (int j = 0; j < ItemManager.regions[(int)regionCoordinate.x, (int)regionCoordinate.y].drops.Count; j++)
					{
						ItemDrop itemDrop = ItemManager.regions[(int)regionCoordinate.x, (int)regionCoordinate.y].drops[j];
						if ((itemDrop.model.position - center).sqrMagnitude < 361f)
						{
							result.Add(itemDrop.interactableItem);
						}
					}
				}
			}
		}
	}
}
