List<int> list = new List<int>();
list.Add(4);
list.Add(2);
list.Add(4);
list.Add(5);
list.Add(5);

//List<int> list1 = new List<int>();
//list.Sort();
//foreach(var item in list)
//    Console.WriteLine(item);
//int count = 1;
//int pop = list[0];
//for (int i = 0; i < list.Count; i++)
//    if (list[i] == pop) { 
//        count++;
//    }
var list2 = list.GroupBy(x=>x);


//Console.WriteLine(list2);
//foreach (var item in list2)
//    Console.WriteLine(item.Key +"  "+item.Count()  );



int max = list2.Max(x => x.Count());

IEnumerable<int> l = list2.Where(x=>x.Count() == max).Select(x=>x.Key);

foreach(var item in l)
    Console.WriteLine(item);
