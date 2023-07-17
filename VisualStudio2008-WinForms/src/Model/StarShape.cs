﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Draw.src.Model
{
    [Serializable]
    public class StarShape : Shape
    {
        #region Constructor

        public StarShape(RectangleF rect) : base(rect)
        {
        }

        public StarShape(RectangleShape rectangle) : base(rectangle)
        {
        }

        #endregion

        /// <summary>
        /// Проверка за принадлежност на точка point към звездата.
        /// В случая на звездата този метод трябва да бъде пренаписан, защото
        /// Реализацията НЕ съвпада с тази на абстрактния клас Shape, който проверява
        /// дали точката е в обхващащия правоъгълник на елемента
        /// </summary>
        
        //Дефинираме спомагателен клас Line и го инициализираме
        private class line
        {
            public PointF p1, p2;
            public line(PointF p1, PointF p2)
            {
                this.p1 = p1;
                this.p2 = p2;
            }
        }

        //Проверяваме дали дадена точка се намира върху линията
        static int onLine(line l1, PointF p)
        {
            if (p.X <= Math.Max(l1.p1.X, l1.p2.X)
                && p.X <= Math.Min(l1.p1.X, l1.p2.X)
                && (p.Y <= Math.Max(l1.p1.Y, l1.p2.Y)
                    && p.Y <= Math.Min(l1.p1.Y, l1.p2.Y)))
                return 1;

            return 0;
        }

        //Колинеарност е геометрично свойство на три или повече точки да лежат на една права
        //Този метод проверява колинеарността на 3 точки
        static int direction(PointF a, PointF b, PointF c)
        {
            //изчисляваме кръстосаното произведение на два вектора: (b - a) и (c - b).
            float val = (b.Y - a.Y) * (c.X - b.X)
              - (b.X - a.X) * (c.Y - b.Y);

            if (val == 0)

                // Колинеарни
                return 0;

            else if (val < 0)

                //  В посока обратна на часовниковата стрелка
                return 2;

            // В посока по часовниковата стрелка
            return 1;
        }

        //Метод, който проверява дали 2 линии се пресичат 
        static int IsIntersect(line l1, line l2)
        {
            // 4 directions за 2 линии и 1 точка от другата линия
            int dir1 = direction(l1.p1, l1.p2, l2.p1);
            int dir2 = direction(l1.p1, l1.p2, l2.p2);
            int dir3 = direction(l2.p1, l2.p2, l1.p1);
            int dir4 = direction(l2.p1, l2.p2, l1.p2);

            // Ако се пресичат
            if (dir1 != dir2 && dir3 != dir4)
                return 1;

            // Ако втората точка на линия2 е на линия1
            if (dir1 == 0 && onLine(l1, l2.p1) == 1)
                return 1;

            // Ако първата точка на линия2 е на линия1
            if (dir2 == 0 && onLine(l1, l2.p2) == 1)
                return 1;

            // Ако втората точка на линия1 е на линия2
            if (dir3 == 0 && onLine(l2, l1.p1) == 1)
                return 1;

            // Ако първата точка на линия1 е на линия2
            if (dir4 == 0 && onLine(l2, l1.p2) == 1)
                return 1;

            return 0;
        }


        static int checkInside(PointF[] poly, int n, Point p)
        {
            // Ако полигона има по-малко от 3 ръбове -> не е полигон
            if (n < 3)
                return 0;

            // Създаваме безкрайна линия  
            PointF pt = new PointF(9999, p.Y);
            line exline = new line(p, pt);

            //брой пресичания
            int count = 0;

            //Цикъл през всяка последователна двойка точки (линия) в многоъгълника:
            int i = 0;
            do
            {
                //Страна на полигона
                line side = new line(poly[i], poly[(i + 1) % n]);
                //Проверяваме дали страната на полигона се пресича с безкрайната линия
                if (IsIntersect(side, exline) == 1)
                {
                    // Проверяваме дали са колинеарни (дадената точка и двете точки от страната на полигона)
                    if (direction(side.p1, p, side.p2) == 0)
                        //Проверяваме дали е на линията
                        return onLine(side, p);
                    count++;
                }

                i = (i + 1) % n;
            } while (i != 0);

            // Ако броят е нечетен, това означава, че точката p се намира вътре в многоъгълника.
            // Ако броят е четен, това означава, че точката е извън многоъгълника.
            return count & 1;
        }

        //масив от точки, които използваме за полигона
        PointF[] points = new PointF[10];

        public override bool Contains(PointF point)
        {
            if (checkInside(points, 10, new Point((int)point.X, (int)point.Y)) == 1)
            {
                return true;
            };
            return false;
        }

        /// <summary>
        /// Частта, визуализираща конкретния примитив.
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
            
            ///<summary>
            /// Задаваме точки на звездата, които са съобразно обграждащия правоъгълник
            /// </summary>
            points[0] = new PointF(Rectangle.X + Width/2, Rectangle.Y);
            points[1] = new PointF(Rectangle.X + Width/2 + Width / 10, Rectangle.Y + Rectangle.Height/5 * 2);
            points[2] = new PointF(Rectangle.X + Rectangle.Width, Rectangle.Y + Rectangle.Height / 5 * 2);
            points[3] = new PointF(Rectangle.X + Width / 2 + Width / 6, Rectangle.Y + Rectangle.Height/5 * 3);
            points[4] = new PointF(Rectangle.X + Rectangle.Width/5*4, Rectangle.Y + Rectangle.Height);
            points[5] = new PointF(Rectangle.X + Rectangle.Width/2, Rectangle.Y + Rectangle.Height / 5 * 4);
            points[6] = new PointF(Rectangle.X + Rectangle.Width/5, Rectangle.Y + Rectangle.Height);
            points[7] = new PointF(Rectangle.X + Rectangle.Width / 3, Rectangle.Y + Rectangle.Height / 5 * 3);
            points[8] = new PointF(Rectangle.X, Rectangle.Y + Rectangle.Height / 5 * 2);
            points[9] = new PointF(Rectangle.X + Rectangle.Width / 2 - Rectangle.Width / 10, Rectangle.Y + Rectangle.Height / 5 * 2);

            grfx.FillPolygon(new SolidBrush(FillColor), points);
            grfx.DrawPolygon(new Pen(StrokeColor, ContourWidth), points);

            grfx.ResetTransform();

        }
    }
}
