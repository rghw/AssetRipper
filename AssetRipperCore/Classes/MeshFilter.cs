﻿using AssetRipper.Project;
using AssetRipper.Parser.Asset;
using AssetRipper.Classes.Misc;
using AssetRipper.IO.Asset;
using AssetRipper.YAML;
using System.Collections.Generic;

namespace AssetRipper.Classes
{
	public sealed class MeshFilter : Component
	{
		public MeshFilter(AssetInfo assetInfo) : base(assetInfo) { }

		public override void Read(AssetReader reader)
		{
			base.Read(reader);

			Mesh.Read(reader);
		}

		public override IEnumerable<PPtr<Object.UnityObject>> FetchDependencies(DependencyContext context)
		{
			foreach (PPtr<Object.UnityObject> asset in base.FetchDependencies(context))
			{
				yield return asset;
			}

			yield return context.FetchDependency(Mesh, MeshName);
		}

		protected override YAMLMappingNode ExportYAMLRoot(IExportContainer container)
		{
			YAMLMappingNode node = base.ExportYAMLRoot(container);
			node.Add(MeshName, Mesh.ExportYAML(container));
			return node;
		}

		public const string MeshName = "m_Mesh";

		public PPtr<Mesh.Mesh> Mesh;
	}
}