namespace dplus2.Model
{
    public class GraphicsDrawable : IDrawable
    {
        private float[] y_points = Array.Empty<float>();

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            if (y_points.Length == 0) return;

            canvas.StrokeColor = canvas.FillColor = Colors.Green;
            canvas.StrokeSize = 6;
            float last_xpoint = dirtyRect.X;
            
            for (int y_index = 0; y_index < y_points.Length - 1; )
            {
                var valor = y_points[y_index];
                canvas.FillCircle(last_xpoint, y_points[y_index], 6);
                canvas.DrawLine(last_xpoint, y_points[y_index],last_xpoint += 20, y_points[++y_index]);
            }
        }

        public void AddY_Points(double[] y_points)
        {
            this.y_points = y_points.ToList().Select(d => (float)d).ToArray();
        }
    }
}
