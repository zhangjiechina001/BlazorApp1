using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Data
{
    public class Person:IData
    {
        [Display(Name = "学号")]
        public string Id { get; set; } = "";

        [Display(Name = "姓名")]
        public string Name { get; set; } = "";

        [Display(Name = "地址")]
        public string Address { get; set; } = "安徽省合肥市合肥工业大学";

        [Display(Name="年龄")]
        public int Age { get; set; }

        public static List<Person> GeneratorItems()
        {
            var items = new List<Person>();
            for (int i = 0; i < 1000; i++)
            {
                items.Add(new Person() { Id = i.ToString(), Name = "Name" + i });
            }
            return items;
        }
    }
}
