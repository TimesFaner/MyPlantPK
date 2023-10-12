using UnityEngine;
using QFramework;
using UnityEngine.Tilemaps;

namespace PlantPK
{
	public partial class GridControl : ViewController
	{
		public Tilemap Tilemap;
		private	EasyGrid<SoilData> mShowGrid=new EasyGrid<SoilData>(10,10);

		public EasyGrid<SoilData> ShowGrid => mShowGrid;

        public TileBase Pen;
		void Start()
		{
			mShowGrid[0,0] = new SoilData();
			mShowGrid[2,2] = new SoilData();
			// Code Here

			mShowGrid.ForEach((int x, int y, SoilData data) =>
			{
				if (data != null)
				{
                    Tilemap.SetTile( new Vector3Int(x,y), Pen);
                }
			}
			);
		}
	}
}
