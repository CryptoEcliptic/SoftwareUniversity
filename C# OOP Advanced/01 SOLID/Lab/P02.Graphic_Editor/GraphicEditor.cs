using System;

namespace P02.Graphic_Editor
{
    public class GraphicEditor
    {
        private IShape figure;

        public GraphicEditor(IShape figure)
        {
            this.Figure = figure;
        }

        public IShape Figure
        {
            get { return figure; }
            set { figure = value; }
        }

        public void DrawShape()
        {
            figure.Draw();
        }
    }
}
