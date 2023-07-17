using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Draw.src.Model
{
    [Serializable]
    public class Line : Shape
    {
        private PointF lastPoint;
        public PointF LastPoint {
            get { return lastPoint;}
            set {lastPoint = value; } 
        }
        #region Constructor

        public Line(RectangleF rect) : base(rect)
        {
        }

        public Line(RectangleShape rectangle) : base(rectangle)
        {
        }

        #endregion

        /// <summary> 
        /// proba
        /// Проверка за принадлежност на точка point към правоъгълника.
        /// В случая на правоъгълник този метод може да не бъде пренаписван, защото
        /// Реализацията съвпада с тази на абстрактния клас Shape, който проверява
        /// дали точката е в обхващащия правоъгълник на елемента (а той съвпада с
        /// елемента в този случай).
        /// </summary>
        public override bool Contains(PointF point)
        {
            if (base.Contains(point))
                // Проверка дали е в обекта само, ако точката е в обхващащия правоъгълник.
                // В случая на правоъгълник - директно връщаме true
                return true;
            else
                // Ако не е в обхващащия правоъгълник, то неможе да е в обекта и => false
                return false;
        }

        /// <summary>
        /// Частта, визуализираща конкретния примитив.
        /// Тук линията е реализирана като правоъгълник с минимална височина
        /// </summary>
        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);
            base.RotateShape(grfx);

            FillColor = Color.FromArgb(
                Opacity,
                FillColor.R,
                FillColor.G,
                FillColor.B)
            ;

            grfx.DrawLine(new Pen(StrokeColor, ContourWidth), Rectangle.X, Rectangle.Y, Rectangle.X + 200, Rectangle.Y);
            // Restore the initial state of the graphics object
            grfx.ResetTransform();

        }
    }
}