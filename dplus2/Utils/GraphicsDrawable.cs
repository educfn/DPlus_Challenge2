namespace dplus2.Model
{
    public class GraphicsDrawable : IDrawable
    {
        private float[][] y_points = { Array.Empty<float>() };
        private int numSimulations = 1;

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            int simulationIndex = 0;
            canvas.StrokeColor = canvas.FillColor = Colors.Green;
            canvas.StrokeSize = 6;

            while (simulationIndex < numSimulations)
            {
                if (y_points[simulationIndex].Length == 0)
                    return;

                float last_xpoint = dirtyRect.X;
            
                for (int y_index = 0; y_index < y_points[simulationIndex].Length - 1; )
                {
                    canvas.FillCircle(last_xpoint, y_points[simulationIndex][y_index], 6);
                    canvas.DrawLine(last_xpoint, y_points[simulationIndex][y_index],last_xpoint += 20, y_points[simulationIndex][++y_index]);
                }
                simulationIndex++;
            }
        }

        /// <summary>
        /// This method adds the Y points and the number of simulations to be drawn.
        /// </summary>
        /// <param name="y_points">The values to be plotted.</param>
        /// <param name="numSimulations">The number of times to redo the simulation.</param>
        public void Add_YPoints_And_NSimulation(double[][] y_points, int numSimulations)
        {
            if (numSimulations <= 0) return;

            this.y_points = new float[numSimulations][];

            this.numSimulations = numSimulations;
            for (int i = 0; i < numSimulations; i++)
            {
                this.y_points[i] = new float[y_points[i].Length];
                for (int j = 0; j < y_points[i].Length; j++)
                {
                    this.y_points[i][j] = (float)y_points[i][j];
                }
            }
        }
    }
}
