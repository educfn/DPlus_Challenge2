namespace dplus2.Model
{
    public class GraphicsDrawable : IDrawable
    {
        private double[] y_points = Array.Empty<double>();

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            if (y_points.Length == 0) return;

            PathF path = new PathF();
            float x_point = 0.0f;
            
            foreach(double y_point in y_points)
                path.LineTo(x_point++, (float)y_point);

            canvas.StrokeColor = Colors.Green;
            canvas.StrokeSize = 6;
            canvas.DrawPath(path);
        }

        public void AddY_Points(double[] y_points)
        {
            this.y_points = y_points;
        }
    }
}
