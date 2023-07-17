﻿using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Draw.src.Model
{
    [Serializable]
    public class GroupShape : Shape
    {
        //формите, от коиот е съставен groupShape
        public List<Shape> SubShapes = new List<Shape>();

        #region Constructor
        public GroupShape(RectangleF rect) : base(rect)
        {
        }

        public GroupShape(RectangleShape rectangle) : base(rectangle)
        {
        }

        #endregion

        /// <summary>
        /// Проверка за принадлежност на точка point към groupShape.
        /// В случая на groupShape този метод не съвпада с този на абстрактния клас Shape.
        /// Трябва да се провери за всяка фигура, която е включена в груповата форма
        /// </summary>
        public override bool Contains(PointF point)
        {
            foreach (Shape shape in SubShapes)
            {
                if (shape.Contains(point))
                {
                    return true;
                }
            }
            return false;
        }

        //пренаписваме всички properties от базовия клас, за да може методите да се извършват върху всички 
        //примитиви в групата
        public override PointF Location
        {
            get
            {
                return base.Location;
            }
            set
            {
                //override set 
                //за да може сменя Location(X,Y) на всеки един примитив в групата 
                foreach (Shape item in SubShapes)
                {
                    item.Location = new PointF(
                        item.Location.X - Location.X + value.X,
                        item.Location.Y - Location.Y + value.Y);
                }
                base.Location = new PointF(value.X, value.Y);
            }
        }

        public override Matrix TransformationMatrix
        {
            get => base.TransformationMatrix;

            set
            {
                base.TransformationMatrix.Multiply(value);

                //for each item in subshapes
                //multiply its matrix with the target matrix
                foreach (Shape item in SubShapes)
                {
                    item.TransformationMatrix.Multiply(value);
                }
            }
        }

        public override Color FillColor
        {
            get => base.FillColor;
            set
            {
                foreach (Shape shape in SubShapes)
                {
                    shape.FillColor = value;
                }
            }
        }

        public override Color StrokeColor
        {
            get => base.StrokeColor;
            set
            {
                foreach (Shape shape in SubShapes)
                {
                    shape.StrokeColor = value;
                }
            }
        }

        public override int Opacity
        {
            get => base.Opacity;
            set
            {
                foreach (Shape shape in SubShapes)
                {
                    shape.Opacity = value;
                }
            }
        }

        public override float ContourWidth
        {
            get => base.ContourWidth;
            set
            {
                foreach (Shape shape in SubShapes)
                {
                    shape.ContourWidth = value;
                }
            }
        }

        /// <summary>
        /// Частта, визуализираща конкретния примитив.
        /// </summary>
        public override void DrawSelf(Graphics grfx)
        {
            
            base.DrawSelf(grfx); // Call the base implementation of DrawSelf to perform any common drawing operations

            // Calculate the center point of the group shape
            this.Rotate(grfx);

            foreach (Shape item in SubShapes)
            {
                item.DrawSelf(grfx);
                this.Rotate(grfx);
                
            }
            grfx.ResetTransform();
        }

        public void Rotate(Graphics grfx)
        {
            // Calculate the center point of the group shape
            PointF groupCenter = new PointF(
                Rectangle.X + Rectangle.Width / 2,
                Rectangle.Y + Rectangle.Height / 2
            );

            grfx.TranslateTransform(groupCenter.X, groupCenter.Y);
            grfx.RotateTransform(ShapeAngle);
            grfx.TranslateTransform(-groupCenter.X, -groupCenter.Y);

        }

        public override void ScaleWidth(float width)
        { 
            //Дефинириаме 4 променливи - minX, maxY, minY, maxX
            float minX = float.MaxValue;
            float maxX = float.MinValue;
            float minY = float.MaxValue;
            float maxY = float.MinValue;
            foreach (var item in SubShapes)
            {
                item.Width = width;
                
                // find the left most primitive and store the x coord
                if (minX > item.Location.X) minX = item.Location.X;
                //find the right most primitive and store its right most locations
                if (minY > item.Location.Y) minY = item.Location.Y;
                //find the bottom most primitive and store its bottom most location
                if (maxX < item.Location.X + item.Width) maxX = item.Location.X + item.Width;
                // find the top most primitive and store the y coord
                if (maxY < item.Location.Y + item.Height) maxY = item.Location.Y + item.Height;

        }
            this.Rectangle = new RectangleF((int)minX, (int)minY, (int)maxX - (int)minX, (int)maxY - (int)minY);
        }
        public override void ScaleHeight(float height)
        {
            //Дефинириаме 4 променливи - minX, maxY, minY, maxX
            float minX = float.MaxValue;
            float maxX = float.MinValue;
            float minY = float.MaxValue;
            float maxY = float.MinValue;
            foreach (var item in SubShapes)
            {
                item.Height = height;

                // find the left most primitive and store the x coord
                if (minX > item.Location.X) minX = item.Location.X;
                //find the right most primitive and store its right most locations
                if (minY > item.Location.Y) minY = item.Location.Y;
                //find the bottom most primitive and store its bottom most location
                if (maxX < item.Location.X + item.Width) maxX = item.Location.X + item.Width;
                // find the top most primitive and store the y coord
                if (maxY < item.Location.Y + item.Height) maxY = item.Location.Y + item.Height;

            }
            this.Rectangle = new RectangleF((int)minX, (int)minY, (int)maxX - (int)minX, (int)maxY - (int)minY);

        }
    }
}
