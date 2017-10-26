public enum MapCellType
{
	Ground = 0,
	Tree,
	Wall,
}

public struct Coordinate
{
	public int x;
	public int y;

	public Coordinate(int x,int y)
	{
		this.x = x;
		this.y = y;
	}
}

public class Map
{
	private int[,] _mapModel;

	public void InitMap(int width,int height)
	{
		_mapModel = new int[width,height];
	}

	public MapCellType GetMapCellType(Coordinate coordinate)
	{
		return (MapCellType)_mapModel[coordinate.x,coordinate.y];
	}

	public void SetMapCell(Coordinate coordinate,MapCellType cellType)
	{
		_mapModel[coordinate.x,coordinate.y] = (int)cellType;
	}
}
