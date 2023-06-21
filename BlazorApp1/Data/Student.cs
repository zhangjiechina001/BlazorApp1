namespace BlazorApp1.Data
{
    public class Student:IData
    {
        public string Id { get; set; }

        public int Age { get; set; }
        public string Name
        {
            get { return Id; }
            set { Id = value; }
        }
    }
}
