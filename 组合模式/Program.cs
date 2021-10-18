using System;
using System.Collections.Generic;

namespace 组合模式
{
    class Program
    {
        static void Main(string[] args)
        {
            //构造根节点
            Composite rootComponent = new Composite();
            rootComponent.Name = "根节点";

            //添加两个叶子几点，也就是子部件
            Leaf l = new Leaf();
            l.Name = "叶子节点一";
            Leaf l1 = new Leaf();
            l1.Name = "叶子节点二";

            rootComponent.Add(l);
            rootComponent.Add(l1);

            //遍历组合部件
            rootComponent.eachChild();
        }
    }
    //抽象的部件类描述将来所有部件共有的行为
    public abstract class Component
    {
        protected string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        //添加部件
        public abstract void Add(Component component);
        //删除部件
        public abstract void Remove(Component component);
        //遍历所有子部件
        public abstract void eachChild();
    }

    //组合部件类
    public class Leaf : Component
    {
        //叶子节点不具备添加的能力，所以不实现
        public override void Add(Component component)
        {
            throw new NotImplementedException();
        }

        //叶子节点不具备添加的能力必然也不能删除
        public override void Remove(Component component)
        {
            throw new NotImplementedException();
        }

        //叶子节点没有子节点所以显示自己的执行结果
        public override void eachChild()
        {
            Console.WriteLine("{0}执行了..", name);
        }
    }

    //组合类
    public class Composite : Component
    {
        //用来保存组合的部件
        List<Component> myList = new List<Component>();

        //添加节点 添加部件
        public override void Add(Component component)
        {
            myList.Add(component);
        }

        //删除节点 删除部件
        public override void Remove(Component component)
        {
            myList.Remove(component);
        }

        //遍历子节点
        public override void eachChild()
        {
            Console.WriteLine("{0}执行了..", name);
            foreach (Component c in myList)
            {
                c.eachChild();
            }
        }
    }
  
}
