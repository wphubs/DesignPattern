using System;
using System.Collections;

namespace 迭代器模式
{
    class Program
    {
        static void Main(string[] args)
        {
            ColorList colors = new ColorList();
            //foreach遍历自定义的类型
            foreach (var item in colors)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }

    /// <summary>
    /// 自定义颜色集合，实现IEnumerable接口
    /// </summary>
    public class ColorList : IEnumerable
    {
        //实现GetEnumerator接口方法
        public IEnumerator GetEnumerator()
        {
            string[] colors = { "red", "green", "blue", "pink" };
            for (int i = 0; i < colors.Length; i++)
            {
                //yield return的作用是指定下一项的内容
                yield return colors[i];
            }

            //想反向遍历时可以这样写
            //for (int i = colors.Length-1; i >=0; i--)
            //{
            //    yield return colors[i];
            //}
        }
    }

}
