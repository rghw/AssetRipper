using AssetRipper.Classes.Font;
using AssetRipper.Classes.Object;
using AssetRipper.Parser.Files.SerializedFiles;
using AssetRipper.Structure.Collections;

namespace AssetRipper.Project.Exporters
{
	public sealed class FontAssetExporter : BinaryAssetExporter
	{
		public override bool IsHandle(UnityObject asset, ExportOptions options)
		{
			Font font = (Font)asset;
			return font.IsValidData;
		}

		public override IExportCollection CreateCollection(VirtualSerializedFile virtualFile, UnityObject asset)
		{
			return new FontExportCollection(this, (Font)asset);
		}
	}
}