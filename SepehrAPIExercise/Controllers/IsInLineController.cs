using Microsoft.AspNetCore.Mvc;

namespace SepehrAPIExercise.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class YourController : ControllerBase
    {
        [HttpGet("calculate")]
        public ActionResult<bool> Calculate([FromQuery] int x1, [FromQuery] int y1, [FromQuery] int x2, [FromQuery] int y2, [FromQuery] int x3, [FromQuery] int y3)
        {
            Point point1 = new Point(x1, y1);
            Point point2 = new Point(x2, y2);
            Point point3 = new Point(x3, y3);

            double slope1 = point1.CalculateSlope(point2);
            double slope2 = point2.CalculateSlope(point3);

            // Check if the slopes are equal, indicating the points are on a straight line
            bool areOnStraightLine = Math.Abs(slope1 - slope2) < double.Epsilon;

            return Ok(areOnStraightLine);
        }
    }

    public struct Point
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public double CalculateSlope(Point otherPoint)
        {
            if (otherPoint.X - X == 0)
            {
                // Handles the case when the line is vertical (undefined slope)
                return double.MaxValue;
            }
            return (double)(otherPoint.Y - Y) / (otherPoint.X - X);
        }
    }
}
