namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            IShape circle = new Circle();
            IShape square = new Square();
            IShape rexctanle = new Rectangle();

            var graphEditor = new GraphicEditor(square);
            graphEditor.DrawShape();
        }
    }
}
