namespace RogueSharp.MapCreation
{
    /// <summary>
    /// Creates the Living World!
    /// </summary>
    /// <typeparam name="T">IMap to create to</typeparam>
    public class WorldCreationStrategy<T> : IMapCreationStrategy<T> where T : IMap, new()
    {
        private readonly int _width, _height;

        /// <summary>
        /// Inits the Strategy
        /// </summary>
        /// <param name="width">Number of tiles wide the map should be</param>
        /// <param name="height">Number of tiles tall the map should be</param>
        public WorldCreationStrategy(int width, int height)
        {
            this._width = width;
            this._height = height;
        }

        /// <summary>
        /// Runs the Map Creation Strategy
        /// </summary>
        /// <returns>A Created World Map</returns>
        public T CreateMap()
        {
            var map = new T();
            map.Initialize(_width, _height);
            map.Clear(true, true);
            DrawSquare(map, _width, _height);

            return map;
        }

        /// <summary>
        /// Sets Border Around Map
        /// </summary>
        /// <param name="map"></param>
        /// <param name="width">Width of the Square</param>
        /// <param name="height">Height of the Square</param>
        public void DrawSquare(T map, int width, int height)
        {
            foreach (ICell cell in map.GetCellsInRows(0, height - 1))
            {
                map.SetCellProperties(cell.X, cell.Y, false, false);
            }

            foreach (ICell cell in map.GetCellsInColumns(0, width - 1))
            {
                map.SetCellProperties(cell.X, cell.Y, false, false);
            }
        }
    }
}