namespace Sales.Domain.Product
{
    public class Description
    {
        internal Description(string text)
        {
            Text = text;
        }

        public string Text { get; }
    }
}