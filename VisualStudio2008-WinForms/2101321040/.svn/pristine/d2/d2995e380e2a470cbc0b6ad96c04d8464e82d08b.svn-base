using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Draw.src.Model
{
    class Star : Shape
    {
		#region Constructor

		public Star(RectangleF rect) : base(rect)
		{
		}

		public Star(RectangleShape rectangle) : base(rectangle)
		{
		}

		#endregion

		/// <summary>
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
		/// </summary>
		public override void DrawSelf(Graphics grfx)
		{
			base.DrawSelf(grfx);

			PointF[] points = new PointF[10];
			points[0] = new Point(0, 25);
			points[1] = new Point(20, 20);
			points[2] = new Point(20, 0);
			points[3] = new Point(30, 20);
			points[4] = new Point(50, 20);
			points[5] = new Point(30, 30);
			points[6] = new Point(25, 60);
			points[7] = new Point(20, 30);
			points[8] = new Point(10, 55);
			points[9] = new Point(15, 33);

			grfx.FillPolygon(new SolidBrush(FillColor), points);
			grfx.DrawPolygon(Pens.Black, points);
		
		}
	}
}
