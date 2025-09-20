using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dplus2.Model
{
    public class GraphicsDrawable : IDrawable
    {
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            //Test Graphics Code
            PathF path = new PathF();
            path.MoveTo(40, 10);
            path.LineTo(70, 80);
            path.LineTo(10, 50);
            path.Close();
            canvas.StrokeColor = Colors.Green;
            canvas.StrokeSize = 6;
            canvas.DrawPath(path);
        }
    }
}
