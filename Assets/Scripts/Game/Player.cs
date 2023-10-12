using System;
using System.Linq;
using UnityEngine;
using QFramework;
using UnityEngine.Tilemaps;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace PlantPK
{
	public partial class Player : ViewController
	{

		public Grid Grid;
		public Tilemap Tilemap;
		void Start()
		{
			Global.Days.Register(day =>
			{//监听Days
				//发芽
				var seeds = SceneManager.GetActiveScene().GetRootGameObjects()
					.Where(gameObj => gameObj.name.StartsWith("wellseed"));
				foreach (var seed in seeds)
				{
					
					var tilepos = Grid.WorldToCell(seed.transform.position);
					var tiledata = FindObjectOfType<GridControl>().ShowGrid[tilepos.x, tilepos.y];
					if (tiledata != null&&tiledata.HasWatered==true)
					{
						seed.DestroySelf();
						ResControl.Instance.SmallPlantperfab.Instantiate().Position(seed.transform.position);


					}
				}
				
			});
		}
		
		public void OnGUI()
		{
			IMGUIHelper.SetDesignResolution(640,360);
			GUILayout.Space(10);
			GUILayout.BeginHorizontal();
			GUILayout.Label("days:"+Global.Days.Value);
			GUILayout.EndHorizontal();
			
		}

		public void Update()
		{
			// 按下f换天数
			if (Keyboard.current.fKey.wasPressedThisFrame)
			{
				Global.Days.Value += 1;
			}
			
			var cellPosition=Grid.WorldToCell(transform.position);
			var grid =	FindObjectOfType<GridControl>().ShowGrid;
			//算方块坐标的世界坐标
			var tileWorldPos = Grid.CellToWorld(cellPosition);
			tileWorldPos.x += Grid.cellSize.x*0.5f;
			tileWorldPos.y += Grid.cellSize.y*0;
			//选择表示
			if (cellPosition.x < 10 && cellPosition.x >= 0 && cellPosition.y < 10 && cellPosition.y >= 0)
			{
				TileSelectController.Instance.Show();
				TileSelectController.Instance.Position(tileWorldPos);
			}
			else
			{
				TileSelectController.Instance.Hide();
			}
			
			if(	Mouse.current.leftButton.wasPressedThisFrame)
			{
				
				if (cellPosition.x<10&&cellPosition.x>=0&&cellPosition.y<10&&cellPosition.y>=0)
				{
					
					//没耕地
					if (grid[cellPosition.x,cellPosition.y] ==null)
					{
						Tilemap.SetTile(cellPosition,FindObjectOfType<GridControl>().Pen);
						grid[cellPosition.x,cellPosition.y] = new SoilData();
						grid[cellPosition.x, cellPosition.y].HasPlanted = false;
					}
					//种种
					else if(grid[cellPosition.x,cellPosition.y].HasPlanted!=true)
					{
						Debug.Log("ok");
						
						
						ResControl.Instance.seedoerfab
							.Instantiate()
							.Position(tileWorldPos);
						grid[cellPosition.x, cellPosition.y].HasPlanted = true;
					}
					else
					{
						
					}
				}
				
			}

			if (Keyboard.current.eKey.wasPressedThisFrame)
			{
				if (grid[cellPosition.x,cellPosition.y] !=null)
				{
					//浇水
					if (grid[cellPosition.x, cellPosition.y].HasWatered != true)
					{
							ResControl.Instance.WaterPrefab
								.Instantiate()
								.Position(tileWorldPos);
							grid[cellPosition.x, cellPosition.y].HasWatered = true;
					}
				}
			}

		}
	}
}
