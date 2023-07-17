using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Draw
{
	/// <summary>
	/// Базовия клас на примитивите, който съдържа общите характеристики на примитивите.
	/// </summary>
	[Serializable]
	public abstract class Shape
	{
		#region Constructors
		
		public Shape()
		{
		}
		
		public Shape(RectangleF rect)
		{
			rectangle = rect;
		}
		
		public Shape(Shape shape)
		{
			this.Height = shape.Height;
			this.Width = shape.Width;
			this.Location = shape.Location;
			this.rectangle = shape.rectangle;
			
			this.FillColor =  shape.FillColor;
		}
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Обхващащ правоъгълник на елемента.
		/// </summary>
		private RectangleF rectangle;		
		public virtual RectangleF Rectangle {
			get { return rectangle; }
			set { rectangle = value; }
		}
		
		/// <summary>
		/// Широчина на елемента.
		/// </summary>
		public virtual float Width {
			get { return Rectangle.Width; }
			set { rectangle.Width = value; }
		}
		
		/// <summary>
		/// Височина на елемента.
		/// </summary>
		public virtual float Height {
			get { return Rectangle.Height; }
			set { rectangle.Height = value; }
		}
		
		/// <summary>
		/// Горен ляв ъгъл на елемента.
		/// </summary>
		public virtual PointF Location {
			get { return Rectangle.Location; }
			set { rectangle.Location = value; }
		}
		
		/// <summary>
		/// Цвят на елемента.
		/// </summary>
		private Color fillColor;		
		public virtual Color FillColor {
			get { return fillColor; }
			set { fillColor = value; }
		}

        /// <summary>
        /// Цвят на контура елемента.
		/// по-подразбиране -> черен
        /// </summary>
        private Color strokeColor = Color.Black;
        public virtual Color StrokeColor
        {
            get { return strokeColor; }
            set { strokeColor = value; }
        }

        /// <summary>
        /// Широчина на контура на елемента.
        /// </summary>
        /// 
        private float contourWidth;
        public virtual float ContourWidth
        {
            get { return contourWidth; }
            set { contourWidth = value; }
        }

        /// <summary>
        /// Широчина на контура на елемента.
        /// </summary>
        
        private int opacity = 255;
        public virtual int Opacity
        {
            get { return opacity; }
            set { opacity = value; }
        }

        /// <summary>
        /// Име на елемента.
        /// </summary>
        
        private string name;
        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Трансформационна матрица, използваме я за преобразувания - мащаниране, ротация...
        /// </summary>
        [NonSerialized] 
        private Matrix transformationMatrix = new Matrix();
        public virtual Matrix TransformationMatrix
        {
            get
			{
				if (transformationMatrix == null)
				{
					transformationMatrix = new Matrix();
				} 
				return transformationMatrix; 
			}
            set { transformationMatrix = value; }
        }


        private float shapeAngle;
        public virtual float ShapeAngle
        {
            get { return shapeAngle; }
            set { shapeAngle = value; }
        }
        #endregion


        /// <summary>
        /// Проверка дали точка point принадлежи на елемента.
        /// </summary>
        /// <param name="point">Точка</param>
        /// <returns>Връща true, ако точката принадлежи на елемента и
        /// false, ако не пренадлежи</returns>
        public virtual bool Contains(PointF point)
		{
			return Rectangle.Contains(point.X, point.Y);
		}
		
		/// <summary>
		/// Визуализира елемента.
		/// </summary>
		/// <param name="grfx">Къде да бъде визуализиран елемента.</param>
		public virtual void DrawSelf(Graphics grfx)
		{
            ///
        }

        //Прилага ротационна трансформация към графичния обект (grfx) въз основа на свойствата на фигура
        public virtual void RotateShape(Graphics grfx)
        {
            //Премества началото на координатната система (точката (0,0) на графичната повърхност) до централната точка на формата.
            grfx.TranslateTransform(Rectangle.X + Rectangle.Width / 2, Rectangle.Y + Rectangle.Height / 2);
			grfx.RotateTransform(ShapeAngle);

			//Връща координатната система в начално състояние
            grfx.TranslateTransform(-(Rectangle.X + Rectangle.Width / 2), -(Rectangle.Y + Rectangle.Height / 2));
        }

        public virtual void ScaleWidth(float width)
		{
            this.Width = width;
        }
        public virtual void ScaleHeight(float height)
        {
            this.Height = height;
        }
        

    }
}
